<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rTipoAnalisis.aspx.cs" Inherits="ProyectoAnalisis.Regsitros.rTipoAnalisis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    </br>
    <div class="col-md-2 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="TipoId"></asp:Label>
                <asp:Button class="btn btn-secondary" ID="BuscarButton" runat="server" Text="Buscar" />
                <asp:TextBox class="form-control" ID="TipoIdTextBox" type="number" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox class="form-control" ID="DescripcionTextBox" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button class="btn btn-primary" ID="nuevoButton" runat="server" Text="Nuevo" />
                <asp:Button class="btn btn-success" ID="guardarButton" runat="server" Text="Guardar" />
                <asp:Button class="btn btn-danger" ID="eliminarutton" runat="server" Text="Eliminar" />
            </div>
        </div>
    </div>
</asp:Content>
