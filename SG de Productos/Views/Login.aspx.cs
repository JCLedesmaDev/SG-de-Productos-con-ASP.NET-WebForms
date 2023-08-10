using SG_de_Productos.Controllers;
using System;
using System.Web.UI;

namespace SG_de_Productos
{
    public partial class Login : Page
    {
        private UserController userController = new UserController();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected  void login(object sender, EventArgs e)
        {
            Models.UserModel usuarioLogin = new Models.UserModel
            {
                _Email = txtEmail.Text,
                _Password = txtPassword.Text,
            };

            var data = userController.Login(usuarioLogin);

            if (data.StatusCode == 400)
            {       
               ScriptManager.RegisterStartupScript(
                   this, GetType(),
                   "MostrarMensajeLogin",
                   $"MostrarMensajeLogin('{data.Value}');", true
                   );
                return;
            }
            
            //Agregamos una sesion de usuario
            Session["UserData"] = data.Value;
            Response.Redirect("~/Views/Default.aspx");

            clearFormLogin();
        }


        protected void toRegister(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Register.aspx");
        }

        public void clearFormLogin()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
        }
    }
}