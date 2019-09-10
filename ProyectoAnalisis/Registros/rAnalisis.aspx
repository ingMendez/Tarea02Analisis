<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rAnalisis.aspx.cs" Inherits="ProyectoAnalisis.Registros.rAnalisis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="col-md-2 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" />
                <asp:TextBox class="form-control" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Persona"></asp:Label>
                <asp:DropDownList class="form-control" ID="PersonaDropDownList" runat="server">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Resultado"></asp:Label>
                <asp:TextBox class="form-control" ID="ResultadoTextBox" runat="server"></asp:TextBox>
                <asp:Button class="btn btn-warning btn-sm" ID="agregarButton" runat="server" Text="Agregar" />
            </div>
        </div>
    </div>    
    <asp:GridView ID="egresoGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#0066FF" GridLines="None">
        <AlternatingRowStyle BackColor="#999999" />
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="EgresoId" HeaderText="EgresoId" />
            <asp:BoundField DataField="CategoriaId" HeaderText="CategoriaId" />
            <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
            <asp:BoundField DataField="MontoEgresado" HeaderText="Monto Egresado" />
        </Columns>
        <HeaderStyle BackColor="#003366" Font-Bold="True" />
    </asp:GridView>
    <div class="col-md-3 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Cantidad de Analisis"></asp:Label>
                <asp:TextBox class="form-control" ID="CantidadAnalisisTextBox" Text="0" runat="server"></asp:TextBox>                
            </div>
        </div>
    </div>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button Text="Nuevo" class="btn btn-primary btn-sm" runat="server" ID="nuevoButton" />
                <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="guadarButton" />
                <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="eliminarButton" />
            </div>
        </div>
    </div>
</asp:Content>
