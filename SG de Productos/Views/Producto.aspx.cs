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
        protected List<Models.ProductoModel> ListadoProductos = new List<Models.ProductoModel>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserData"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
                return;
            }


            ObjectResult res = productoController.ObtenerListadoProductos();

            if (res.StatusCode == 400)
            {
                ScriptManager.RegisterStartupScript(
                  this, GetType(),
                  "MostrarMensajeLogin",
                  $"MostrarMensajeLogin('{res.Value}');", true
                  );
                return;
            }

            ListadoProductos = (List<Models.ProductoModel>)res.Value;

            if (!IsPostBack)
            {
                // Enlazar la fuente de datos al Repeater
                repeaterProductos.DataSource = ListadoProductos;
                repeaterProductos.DataBind();
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
                /// COMPLETAR LOS 2 SELECTS
                txtPrecioProducto.Text = fndProducto._Precio.ToString();



                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal();", true);

            }
        }


        protected void ShowModal(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal();", true);
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {

        }


        protected void selectCategoriaOption(object sender, EventArgs e)
        {
            //string opcionSeleccionada = selectCategoria.SelectedValue;

            // Agregar opciones al DropDownList
            //foreach (string opcion in opciones)
            //{
            //    ddlOpciones.Items.Add(new ListItem(opcion));
            //}
        }        
        
        protected void selectMarcaOption(object sender, EventArgs e)
        {
            //string opcionSeleccionada = selectMarca.SelectedValue;
        }
    }
}