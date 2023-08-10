<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SG_de_Productos.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="row vh-100">

       <div >
           <asp:Label class="h2" ID="lblBienvenida" runat="server" Text="Iniciar Sesion"></asp:Label>
       </div>

       <div>
           <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
           <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email de usuario"></asp:TextBox>
       </div>

       <div>
           <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
           <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
       </div>

       <br />

       <asp:Label ID="lblMessageError" runat="server" Text=""></asp:Label>

       <hr />

       <div >
           <asp:Button ID="btnLogin" CssClass="btn btn-primary btn-dark" runat="server" Text="Ingresar" OnClick="login" />
            
           <asp:Button ID="btnToRegister" CssClass="btn btn-primary btn-dark" runat="server" Text="Ir a registrar" OnClick="toRegister" />            
       </div>
   </div>

<script type="text/javascript">
    function MostrarMensajeLogin(mensaje) {
        const lblMensaje = document.getElementById('<%= lblMessageError.ClientID %>');
        lblMensaje.innerText = mensaje;

        setTimeout(function () {
            lblMensaje.innerText = "";
        }, 5000); // 5000 ms = 5 segundos
    }
</script>

</asp:Content>

