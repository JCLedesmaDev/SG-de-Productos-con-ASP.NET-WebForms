using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SG_de_Productos
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserData"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }else
            {
                Models.UserModel nameComplete = (Models.UserModel)Session["UserData"];
                lblTitle.Text = $"{nameComplete._NombreCompleto}, bienvenido al Sistema de Gestion de Productos";
            }
        }

        protected void logOut(object sender, EventArgs e)
        {
            Session.Remove("UserData");
            Response.Redirect("/Views/Login.aspx");
        }
    }
}