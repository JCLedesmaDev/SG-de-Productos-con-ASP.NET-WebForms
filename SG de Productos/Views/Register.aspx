<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SG_de_Productos.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="row vh-100">

       <div >
           <asp:Label class="h2" ID="lblRegisterWelbome" runat="server" Text="Registrarse"></asp:Label>
       </div>

       <div>
           <asp:Label ID="lblRegisterEmail" runat="server" Text="Email:"></asp:Label>
           <asp:TextBox ID="txtRegisterEmail" CssClass="form-control" runat="server" placeholder="Email de usuario"></asp:TextBox>
       </div>

       <div>
           <asp:Label ID="lblRegisterPassword" runat="server" Text="Password:"></asp:Label>
           <asp:TextBox ID="txtRegisterPassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
       </div>

       <div>
           <asp:Label ID="lblRegisterNombreCompleto" runat="server" Text="Nombre Completo:"></asp:Label>
           <asp:TextBox ID="txtRegisterNombreCompleto" CssClass="form-control" runat="server" placeholder="Nombre Completo"></asp:TextBox>
       </div>
       
       <br />

       <asp:Label ID="lblMessageError" runat="server" Text=""></asp:Label>

       <hr />

        <div >
           <asp:Button ID="btnRegister" CssClass="btn btn-primary btn-dark" runat="server" Text="Registrar" OnClick="register" />
       
           <asp:Button ID="btnToLogin" CssClass="btn btn-primary btn-dark" runat="server" Text="Ir a login" OnClick="toLogin" />
       
        </div>
   </div>

<script type="text/javascript">
    function MostrarMensajeRegister(mensaje) {
        const lblMensaje = document.getElementById('<%= lblMessageError.ClientID %>');
        lblMensaje.innerText = mensaje;

        setTimeout(function () {
            lblMensaje.innerText = "";
        }, 5000); // 5000 ms = 5 segundos
    }
</script>

</asp:Content>

