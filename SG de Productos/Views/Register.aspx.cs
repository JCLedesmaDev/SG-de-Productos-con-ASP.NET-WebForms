using SG_de_Productos.Controllers;
using System;
using System.Web.UI;
namespace SG_de_Productos
{
    public partial class Register : Page
    {
        private UserController userController = new UserController();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected  void register(object sender, EventArgs e)
        {
            Models.UserModel usuarioLogin = new Models.UserModel
            {
                _Email = txtRegisterEmail.Text,
                _Password = txtRegisterPassword.Text,
                _NombreCompleto = txtRegisterNombreCompleto.Text
            };

            var data = userController.Registrarse(usuarioLogin);

            if (data.StatusCode == 400)
            {       
               ScriptManager.RegisterStartupScript(
                   this, GetType(), 
                   "MostrarMensaje", 
                   $"MostrarMensaje('{data.Value}');", true
                   );
                return;
            }
            
            Response.Redirect("~/Views/Login.aspx");

            clearFormLogin();
        }

        protected void toLogin(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login.aspx");
        }
        public void clearFormLogin()
        {
            //txtRegisterEmail.Text = "";
            //txtRegisterPassword.Text = "";
        }
    }
}