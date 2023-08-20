using Microsoft.AspNetCore.Mvc;
using SG_de_Productos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SG_de_Productos
{
    public partial class Producto : Page
    {

        private ProductoController productoController = new ProductoController();
        private CategoriaController categoriaController = new CategoriaController();
        private MarcaController marcaController = new MarcaController();

        protected List<Models.ProductoModel> ListadoProductos = new List<Models.ProductoModel>();
        protected List<Models.MarcaModel> ListadoMarca = new List<Models.MarcaModel>();
        protected List<Models.CategoriaModel> ListadoCategoria= new List<Models.CategoriaModel>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserData"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
                return;
            }

            ObjectResult ObtenerListadoProductos = productoController.ObtenerListadoProductos();
            ObjectResult ObtenerListadoMarca = marcaController.ObtenerListadoMarca();
            ObjectResult ObtenerListadoCategoria = categoriaController.ObtenerListadoCategoria();

            ListadoProductos = (List<Models.ProductoModel>)ObtenerListadoProductos.Value;

            if (ObtenerListadoProductos.StatusCode == 400)
            {
                ScriptManager.RegisterStartupScript(
                  this, GetType(),
                  "MostrarMensajeProducto",
                  $"MostrarMensajeProducto('{ObtenerListadoProductos.Value}');",
                  true
                );
                return;
            }

            if (!IsPostBack)
            {
                // Enlazar la fuente de datos al Repeater
                repeaterProductos.DataSource = ObtenerListadoProductos.Value;
                repeaterProductos.DataBind();

                // Agregar opciones al DropDownList
                foreach (
                    Models.CategoriaModel cat in (List<Models.CategoriaModel>)ObtenerListadoCategoria.Value
                )
                {
                    selectCategoria.Items.Add(new ListItem(cat._Descripcion, cat._Id.ToString()));
                }

                foreach (
                    Models.MarcaModel marca in (List<Models.MarcaModel>)ObtenerListadoMarca.Value
                )
                {
                    selectMarca.Items.Add(new ListItem(marca._Descripcion, marca._Id.ToString()));
                }
            }
        }

        protected void logOut(object sender, EventArgs e)
        {
            Session.Remove("UserData");
            Response.Redirect("/Views/Login.aspx");
        }


        protected void onExecuteAction(object source, RepeaterCommandEventArgs e)
        {
            idProdcutoSelected.Text = e.CommandArgument.ToString();

            if (e.CommandName == "Delete")
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    this.GetType(),
                    "myModalConfirm",
                    "$('#myModalConfirm').modal();",
                    true
                );
            }            
            
            if (e.CommandName == "Update")
            {
                Models.ProductoModel fndProducto = ListadoProductos.Find(prod => {
                    return prod._Id == Convert.ToInt32(e.CommandArgument);
                });
                                                                    
                txtNombreProducto.Text = fndProducto._Descripcion;
                selectCategoria.SelectedValue = fndProducto._IdCategoria.ToString();
                selectMarca.SelectedValue = fndProducto._IdMarca.ToString();
                txtPrecioProducto.Text = fndProducto._Precio.ToString();
                                                                                    
                ScriptManager.RegisterStartupScript(
                    this, 
                    this.GetType(), 
                    "myModal", 
                    "$('#myModal').modal();", 
                    true
                );
            }
        }


        protected void ShowModal(object sender, EventArgs e)
        {
            txtNombreProducto.Text = "";
            selectCategoria.SelectedValue = "1";
            selectMarca.SelectedValue = "1";
            txtPrecioProducto.Text = "";

            ScriptManager.RegisterStartupScript(
                this, 
                this.GetType(), 
                "myModal", 
                "$('#myModal').modal();", 
                true
            );
        }
        
                
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ObjectResult response = new ObjectResult(null);

            Models.ProductoModel prod = new Models.ProductoModel
            {
                _Descripcion = txtNombreProducto.Text.ToString(),
                _IdCategoria = int.Parse(selectCategoria.SelectedValue),
                _IdMarca = int.Parse(selectMarca.SelectedValue),
                _Precio = double.Parse(txtPrecioProducto.Text),
            };

            if (idProdcutoSelected.Text != "")
            {
                prod._Id = int.Parse(idProdcutoSelected.Text);
                response = productoController.EditarProducto(prod);
            } else
            {
                prod._Id = 0;
                response = productoController.InsertarProducto(prod);
            }

            if (response.StatusCode == 400)
            {
                ScriptManager.RegisterStartupScript(
                  this, GetType(),
                  "MostrarMensajeProducto",
                  $"MostrarMensajeProducto('{response.Value}');",
                  true
                );
                return;
            }

            idProdcutoSelected.Text = "";
            Response.Redirect(Request.RawUrl);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            ObjectResult EliminarProducto = productoController.EliminarProducto(
                int.Parse(idProdcutoSelected.Text)
            );

            ScriptManager.RegisterStartupScript(
              this, GetType(),
              "MostrarMensajeProducto",
              $"MostrarMensajeProducto('{EliminarProducto.Value}');",
              true
            );

            idProdcutoSelected.Text = "";
            if (EliminarProducto.StatusCode != 400)
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void selectCategoriaOption(object sender, EventArgs e)
        {
            //string opcionSeleccionada = selectCategoria.SelectedValue;
        }

        protected void selectMarcaOption(object sender, EventArgs e)
        {
            //string opcionSeleccionada = selectMarca.SelectedValue;
        }
    }
}