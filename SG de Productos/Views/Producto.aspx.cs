using Microsoft.AspNetCore.Mvc;
using SG_de_Productos.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int productoId = Convert.ToInt32(e.CommandArgument); // Obtener el argumento del botón

            if (e.CommandName == "Delete")
            {
                // Llamar al método deseado pasando el productoId
            }            
            
            if (e.CommandName == "Update")
            {
                Models.ProductoModel fndProducto = ListadoProductos.Find(prod => {
                    return prod._Id == productoId;
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
        
        
        
        protected void selectCategoriaOption(object sender, EventArgs e)
        {
            //string opcionSeleccionada = selectCategoria.SelectedValue;
        }

        protected void selectMarcaOption(object sender, EventArgs e)
        {
            //string opcionSeleccionada = selectMarca.SelectedValue;
        }
        
        protected void BtnSave_Click(object sender, EventArgs e)
        {

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }
    
    }
}