﻿using System;
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
            if (Session["UserData"] != null)
            {
                //string usuariologueado = Session["usuariologueado"].ToString();
                //lblBienvenida.Text = "Bienvenido/a " + usuariologueado;
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("/Views/Login.aspx");
            }
        }
    }
}