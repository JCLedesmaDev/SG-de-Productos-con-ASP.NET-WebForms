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

            var data = userController.Login(usuarioLogin);

            if (data.StatusCode == 400)
            {
                MessageBox.Show(data.Value.ToString());
                return;
            }
            
            //Agregamos una sesion de usuario
            Session["UserData"] = data.Value;
            Response.Redirect("~/Views/Default.aspx");

            clearFormLogin();
        }


        public void clearFormLogin()
        {
            //txtcontraseña.Text = "";
            //MASKEDTXTUSUARIO.Text = "";
        }
    }
}