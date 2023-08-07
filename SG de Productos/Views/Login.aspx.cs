using SG_de_Productos.Controllers;
using System;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

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
                //Task.Run(() => {
                //    lblMessageError.Text = data.Value.ToString();
                //    Task.Delay(40000);
                //    lblMessageError.Text = "";
                //});
                return;
            }
            
            //Agregamos una sesion de usuario
            Session["UserData"] = data.Value;
            Response.Redirect("~/Views/Default.aspx");

            clearFormLogin();
        }


        public void clearFormLogin()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
        }
    }
}