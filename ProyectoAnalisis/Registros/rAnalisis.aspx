<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rAnalisis.aspx.cs" Inherits="ProyectoAnalisis.Registros.rAnalisis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-6">
            <div class="card text-white bg-dark mb-3">
                <div class="card-header text-uppercase text-center">Tipo de Analisis</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-4 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                                    <asp:Button class="btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                    <asp:TextBox class="form-control" ID="IdTextBox" type="number" Text="0" runat="server"></asp:TextBox>
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
                                    <asp:Label ID="Label1" runat="server" Text="Tipo de Analisis"></asp:Label>
                                    <asp:DropDownList class="form-control" ID="TipoAnalisisDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="TipoAnalisisDropDownList_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text="Precio"></asp:Label>
                                    <asp:TextBox class="form-control" ID="PrecioTextBox" Text="0" runat="server" ReadOnly="True" BackColor="#3399FF"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-8 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Resultado"></asp:Label>
                                    <asp:TextBox class="form-control" ID="ResultadoTextBox" runat="server"></asp:TextBox>
                                    <asp:Button class="btn btn-warning btn-sm" ID="agregarButton" runat="server" Text="Agregar" OnClick="agregarButton_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <hr>
                            <div class="col-md-8 col-md-offset-3">
                                <div class="container">
                                    <div class="form-group">
                                        <asp:Label ID="criterioLabel" runat="server" Text="Detalle" Font-Bold="True" ValidateRequestMode="Inherit" Font-Size="Large"></asp:Label>
                                        <asp:GridView ID="detalleGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#0066FF" GridLines="None">
                                            <AlternatingRowStyle BackColor="#999999" />
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="Id" />
                                                <asp:BoundField DataField="AnalisisId" HeaderText="AnalisisId" />
                                                <asp:BoundField DataField="TipoId" HeaderText="TipoId" />
                                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                                                <asp:BoundField DataField="Resultado" HeaderText="Resultado" />
                                            </Columns>
                                            <HeaderStyle BackColor="#003366" Font-Bold="True" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr>
                        <div class="col-md-4 col-md-offset-3">
                            <div class="container">
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Balance a Pagar"></asp:Label>
                                    <asp:TextBox class="form-control" ID="BalanceTextBox" Text="0" runat="server" ReadOnly="True" BackColor="#3399FF"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button Text="Nuevo" class="btn btn-primary btn-sm" runat="server" ID="nuevoButton" OnClick="nuevoButton_Click" />
                                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="guadarButton" OnClick="guadarButton_Click" />
                                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="eliminarButton" OnClick="eliminarButton_Click" />
                                </div>
                            </div>
                        </div>
                    </form>
                </article>
            </div>
    </div>
    </div>
</asp:Content>

