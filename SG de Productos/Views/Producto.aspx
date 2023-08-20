<%@ Page Title="Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableViewStateMac="true" CodeBehind="Producto.aspx.cs" Inherits="SG_de_Productos.Producto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Mostrar el componente si la URL contiene "url-a-validar" -->
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container row">
            <div class="navbar-header col" >
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse" title="more options">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" runat="server" href="~/Views/Default">SG de Productos</a>
            </div>
              <div class="asd">
                    <a runat="server" href="~/Views/Producto">Productos</a>
                   <asp:Button ID="btnLogOut" runat="server" Text="Cerrar Sesion" CssClas="btn btn-dark" OnClick="logOut" />
            </div>
        </div>
    </div>
 
    <br />

    <div class="container">

        <div class="row">
            <div class="col align-self-end">
                <asp:Label runat="server" ID="lblTitleProd"> Listado de Productos</asp:Label>
                <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-control-sm" Text="Crear producto" OnClick="ShowModal" />
            </div>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="table-responsive">

            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">Nombre de producto</th>
                        <th scope="col">Categoria</th>
                        <th scope="col">Marca</th>
                        <th scope="col">Precio</th>
                        <th scope="col">Opciones del administrador</th>
                    </tr>
                </thead>

                <tbody>
                    <asp:Repeater ID="repeaterProductos" runat="server" DataSource='<%# ListadoProductos %>' OnItemCommand="onExecuteAction" >
                        <ItemTemplate>
                            <tr>
                                <th scope="row"><%# Eval("_Descripcion") %></th>
                                <td><%# Eval("_Categoria._Descripcion") %></td>
                                <td><%# Eval("_Marca._Descripcion") %></td>
                                <td><%# Eval("_Precio") %></td>
                                <td>
                                    <asp:Button runat="server" Text="Eliminar" CssClass="btn form-control-sm btn-warning" CommandName="Delete" CommandArgument='<%# Eval("_Id") %>'/>
                                    <asp:Button runat="server" Text="Actualizar" CssClass="btn form-control-sm btn-danger" CommandName="Update" CommandArgument='<%# Eval("_Id") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

        </div>
    </div>


    <!-- Modal ABM -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        Detalle del Producto
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </h4>
                </div>
                <div class="modal-body">

                    <div class="row g-3 align-items-center marginLeft1rem">
                        <div class="col-auto">
                            Nombre Producto:
                            <asp:TextBox ID="txtNombreProducto" CssClass="form-control" runat="server" placeholder="Nombre del producto"></asp:TextBox>
                        </div>
                    </div>
                    <br />

                    <div class="row g-3 align-items-center marginLeft1rem" >
                        <div class="col-auto">
                            Categoria del Producto:
                            <asp:DropDownList ID="selectCategoria"  CssClass="form-select" runat="server" AutoPostBack="false" OnSelectedIndexChanged="selectCategoriaOption">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <br />

                    <div class="row g-3 align-items-center marginLeft1rem">
                        <div class="col-auto">
                            Marca del Producto:
                            <asp:DropDownList ID="selectMarca" CssClass="form-select" runat="server" AutoPostBack="false" OnSelectedIndexChanged="selectMarcaOption">
                            </asp:DropDownList>
                        </div>
                    </div>
               
                    <br />

                     <div class="row g-3 align-items-center marginLeft1rem">
                        <div class="col-auto">
                            Precio del Producto:
                            <asp:TextBox ID="txtPrecioProducto" CssClass="form-control" TextMode="Number" runat="server" placeholder="Precio del producto"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <asp:Button runat="server" ID="BtnSave" CssClass="btn btn-success form-control-sm" Text="Guardar" OnClick="BtnSave_Click" />    
                </div>
            </div>
        </div>
    </div>

    <%-- MODAL CONFIRMACION --%>
      <div id="myModalConfirm" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <h4 class="modal-title">
                        ¿Deseas eliminar este producto?
                    </h4>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <asp:Button runat="server" ID="Button1" CssClass="btn btn-success form-control-sm" Text="Aceptar" OnClick="BtnDelete_Click" />
               
                </div>
            </div>
        </div>
    </div>

   <asp:Label ID="lblMessageProducto" runat="server" Text=""></asp:Label>


    <script type="text/javascript">
        function MostrarMensajeProducto(mensaje) {
            const lblMensaje = document.getElementById('<%= lblMessageProducto.ClientID %>');
            lblMensaje.innerText = mensaje;

            setTimeout(function () {
                lblMensaje.innerText = "";
            }, 5000); // 5000 ms = 5 segundos
        }
    </script>

    <asp:Label runat="server" ID="idProdcutoSelected" Visible="false"/>
</asp:Content>
