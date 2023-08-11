<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SG_de_Productos._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <!-- Mostrar el componente si la URL contiene "url-a-validar" -->
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse" title="more options">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" runat="server" href="~/">SG de Productos</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a runat="server" href="~/Views/About">Productos</a></li>
                    <li><a runat="server" href="~/Views/Contact">Categoria</a></li>
                    <li><a runat="server" href="~/Views/Contact">Marcas</a></li>
                    <li> 
                        <asp:Button ID="btnLogOut" runat="server" Text="Cerrar Sesion" CssClas="btn btn-dark" OnClick="logOut" />
                    </li>
                </ul>
            </div>
        </div>
    </div>

    <div class="jumbotron">
        <asp:Label 
            ID="lblTitle" 
            runat="server"  
            CssClass="h3"
        />
            
        <p class="lead"> ¿Que desea hacer? </p>
    </div>

 </asp:Content>










