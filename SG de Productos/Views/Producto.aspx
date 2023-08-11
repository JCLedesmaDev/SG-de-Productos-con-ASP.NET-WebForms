<%@ Page Title="Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="SG_de_Productos.Producto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <br />
  <div class="container">

        <div class="row">
                <div class="col align-self-end">
                    <asp:Label runat="server" ID="lblTitleProd"> Listado de Productos</asp:Label>
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success form-control-sm" Text="Crear producto" OnClick="BtnCreate_Click"/>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="table-responsive">
                <asp:GridView runat="server" ID="GridProductos" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">

                     <Columns>
                        <asp:TemplateField HeaderText="Nombre de producto">
                            <ItemTemplate> A
                <%--                <asp:Button runat="server" Text="Update" CssClass="btn form-control-sm btn-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                <asp:Button runat="server" Text="Delete" CssClass="btn form-control-sm btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click"/>--%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>
                    
                    <Columns>
                        <asp:TemplateField HeaderText="Categoria">
                            <ItemTemplate> A
                <%--                <asp:Button runat="server" Text="Update" CssClass="btn form-control-sm btn-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                <asp:Button runat="server" Text="Delete" CssClass="btn form-control-sm btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click"/>--%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>

                    <Columns>
                        <asp:TemplateField HeaderText="Marca">
                            <ItemTemplate> A
                <%--                <asp:Button runat="server" Text="Update" CssClass="btn form-control-sm btn-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                <asp:Button runat="server" Text="Delete" CssClass="btn form-control-sm btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click"/>--%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>

                    <Columns>
                        <asp:TemplateField HeaderText="Precio">
                            <ItemTemplate> A
                <%--                <asp:Button runat="server" Text="Update" CssClass="btn form-control-sm btn-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                <asp:Button runat="server" Text="Delete" CssClass="btn form-control-sm btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click"/>--%>
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>
                    
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones del administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Eliminar" CssClass="btn form-control-sm btn-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                <asp:Button runat="server" Text="Actualizar" CssClass="btn form-control-sm btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
