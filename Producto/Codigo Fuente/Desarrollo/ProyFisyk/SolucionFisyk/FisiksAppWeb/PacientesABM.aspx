<%@ Page Title="" Language="C#" MasterPageFile="~/MPF.Master" AutoEventWireup="true" CodeBehind="PacientesAbm.aspx.cs" Inherits="FisiksAppWeb.PacientesAbm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h3>Pacientes</h3>
        <div class="form-inline">
            <div class="well">
                <div class="form-group">
                    <label for="lblDocumento">Documento</label>
                    <input type="text" class="form-control" id="txtDoc" runat="server" placeholder="Ingrese el Documento..." />
                </div>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />


            </div>
        </div>
        <br />
        <asp:Panel ID="panelDatos" runat="server">
            <div class="panel-body">

                <div class="row">
                    <div class="col-md-4">
                        <label for="lblNombre">Nombre</label>
                        <input id="txtNombre" runat="server" type="text" class="form-control" placeholder="Nombre Paciente..." />
                    </div>
                    <div class="col-md-4">
                        <label for="lblTelefono">Apellido</label>
                        <input id="txtApellido" runat="server" type="text" class="form-control" placeholder="Apellido Paciente..." />
                    </div>
                    <div class="col-md-2">
                        <label for="lblNombre">Fecha Nacimiento</label>
                        <input runat="server" type="text" id="txtFecNac" class="form-control" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-4">
                        <label for="lblTelefono">Télefono</label>
                        <input runat="server" class="form-control" id="txtTel" placeholder="Teléfono Paciente..." />
                    </div>
                    <div class="col-md-4">
                        <label for="lblTelefono">Dirección</label>
                        <input runat="server" class="form-control" id="txtDire" placeholder="Dirección Paciente..." />
                    </div>
                    <div class="col-md-2">
                        <label for="lblTelefono">Altura</label>
                        <asp:DropDownList ID="ddlAltura" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <label for="lblTelefono">Peso</label>
                        <asp:DropDownList ID="ddlPeso" runat="server" class="form-control"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="row">
                    <!-- Obra Social --------------------------------------------------------------------------------->
                    <div class="col-md-3">
                        <label for="lblTelefono">Obras Sociales</label>
                        <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#myModal"><b>+</b></button>
                        <br />
                        <br />
                        <asp:UpdatePanel ID="UpdatePanelObraSocial" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnOSAgregar" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="gvOsocial" EventName="RowDeleting" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:ListBox ID="ListObraSoial" runat="server" Enable="false" Style="width: 100%;" />
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <br />
                    </div>
                    <!-- Ocupaciones---------------------------------------------------------------------------------->
                    <div class="col-md-3">
                        <label for="lblTelefono">Ocupaciones</label>
                        <br />
                        <div class="row">
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlOcu" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <asp:Button ID="btnOcu" class="btn btn-info btn-md btn-block" runat="server" Text="+" Font-Bold="True" OnClick="btnOcu_Click" />
                            </div>
                        </div>
                        <br />
                        <asp:ListBox ID="ListOcu" runat="server" Enable="false" Style="width: 100%;" />
                        <br />
                    </div>
                    <br />

                    <p></p>
                    <div class="col-md-3">
                        <label for="lblTelefono">Realiza Actividad</label>
                        <div class="input-group">
                            <span class="input-group-addon">
                                <input type="checkbox" runat="server" id="cbAct" aria-label="..." />
                            </span>
                            <input type="text" class="form-control" aria-label="..." id="txtAct" runat="server" placeholder="Frecuencia Semanal(Veces)..." />
                        </div>
                    </div>
                    <p></p>
                    <div class="col-md-3">
                        <div class="radio">
                            <label>
                                <input type="radio" runat="server" name="opciones" id="rbM" value="masculino" />
                                Masculino
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" runat="server" name="opciones" id="rbF" value="femenino" />
                                Femenino
                            </label>
                        </div>
                    </div>
                </div>

            </div>
        </asp:Panel>

        <!--  Modal Obras Sociales ------------------------------------------------------------------------------------------------------------------------->
        <div id="myModal" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnOSAgregar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="gvOsocial" EventName="RowDeleting" />
                    </Triggers>
                    <ContentTemplate>
                        <!-- Modal Obras Sociales -->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Obras Sociales</h4>
                            </div>
                            <div class="modal-body">

                                <div class="row">
                                    <div class="col-md-5">
                                        <label for="lblTelefono">Lista de Obras Sociales</label>
                                        <asp:DropDownList ID="ddlOS" runat="server" class="form-control"></asp:DropDownList>
                                        <br />
                                    </div>
                                    <div class="col-md-5">
                                        <label for="lblTelefono">Número de Tarjeta</label>
                                        <input type="text" id="txtNrotarj" runat="server" class="form-control" placeholder="Número de Tarjeta..." />
                                        <br />
                                    </div>
                                    <div class="col-md-2">
                                        <br />
                                        <asp:Button ID="btnOSAgregar" runat="server" class="btn btn-info btn-block" Text="+" OnClick="btnObraSocial_Click" />
                                        <br />
                                    </div>
                                </div>
                                <hr />
                                <div class="row">
                                    <asp:GridView ID="gvOsocial" runat="server" CssClass="table table-hover table-striped" GridLines="None"
                                        AutoGenerateColumns="False"
                                        OnRowDeleting="ObraSocialEliminarFilaGrilla">
                                        <Columns>

                                            <asp:BoundField DataField="OSOID" HeaderText="Código">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="OSODESCRIPCION" HeaderText="Descripción">
                                                <ItemStyle Width="50%" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="OSPNROSOCIO" HeaderText="Número de Tarjeta">
                                                <ItemStyle Width="40%" />
                                            </asp:BoundField>

                                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Img/edit_16x16.png" ShowSelectButton="True" />
                                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Img/delete16x16.png" ShowDeleteButton="True" />
                                        </Columns>
                                        <RowStyle CssClass="cursor-pointer" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-success" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <!--  Modal Obras Sociales ------------------------------------------------------------------------------------------------------------------------->



        <!--       /.Body-->
        <div class="panel-footer">
            <asp:Button ID="btnConfirmar" runat="server" Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnConfirmar_Click" />
            <asp:Button ID="btnDomicilio" runat="server" Text="Domicilio" CssClass="btn btn-warning" />
            <asp:Button ID="btnAntecedentes" runat="server" Text="Antecedentes" CssClass="btn btn-info" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
        </div>
        <!--       /.Footer-->

    </div>

</asp:Content>
