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

        protected List<Models.ProductoModel> ListadoProductos = new List<Models.ProductoModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
   
                if (Session["UserData"] == null)
                {
                    Response.Redirect("~/Views/Login.aspx");
                    return;
                }


            if (!IsPostBack)
            {

                ListadoProductos.Add(new Models.ProductoModel
                {
                    _Id = 1,
                    _Categoria = new Models.CategoriaModel { _Descripcion = "LELE" },
                    _Marca = new Models.MarcaModel { _Descripcion = "LALA" },
                    _Descripcion = "PEPSI",
                    _Precio = 3000
                });

     
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

                ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal();", true);

            }
        }


        protected void BtnCreate_Click(object sender, EventArgs e)
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