using SG_de_Productos.Controllers;
using System;
using System.Web.UI;
using System.Windows.Forms;

namespace SG_de_Productos
{
    public partial class Login : Page
    {
        private UserController userController = new UserController();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            Models.UserModel usuarioLogin = new Models.UserModel
            {
                _Email = txtEmail.Text,
                _Password = txtPassword.Text,
            };

            var UserData = userController.Login(usuarioLogin);

            if (UserData != null)
            {
                //Agregamos una sesion de usuario
                Session["UserData"] = UserData;
                Response.Redirect("/Default.aspx");
            }
            else
            {
                MessageBox.Show("Datos ingresados incorrectos, intentelo nuevamente");
            }

            clearFormLogin();
        }


        public void clearFormLogin()
        {
            //txtcontraseña.Text = "";
            //MASKEDTXTUSUARIO.Text = "";
        }
    }
}