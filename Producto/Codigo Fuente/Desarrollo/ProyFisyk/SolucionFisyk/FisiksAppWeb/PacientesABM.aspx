<%@ Page Title="" Language="C#" MasterPageFile="~/MPF.Master" AutoEventWireup="true" CodeBehind="PacientesAbm.aspx.cs" Inherits="FisiksAppWeb.PacientesAbm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="lblControl" runat="server" Text="Label"></asp:Label>
        <h3>Pacientes</h3>
        <div class="form-inline">
            <div class="well">
                <div class="form-group">
                    <label>Documento</label>
                    <input type="text" class="form-control" id="txtDoc" runat="server" placeholder="Ingrese el Documento..." />
                </div>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />

                <a href="#myModalBusquedaAvanzada" role="button" class="btn" data-toggle="modal">
                    <asp:CheckBox ID="ckBusqueda" runat="server" Font-Bold="True" Text="Búsqueda Avanzada" Font-Size="Small" /></a>

            </div>
        </div>
        <br />

        <asp:Panel ID="panelColap" runat="server">
            <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingOne">
                        <h4 class="panel-title">
                            <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">Datos Pesonales</a>
                        </h4>
                    </div>
                    <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                        <div class="panel-body">

                            <!-- Datos Personales --------------------------------------------------------------------------------->
                            <div class="row">
                                <div class="col-md-4">
                                    <label>Nombre</label>
                                    <input id="txtNombre" runat="server" type="text" class="form-control" placeholder="Nombre Paciente..." />
                                </div>
                                <div class="col-md-4">
                                    <label>Apellido</label>
                                    <input id="txtApellido" runat="server" type="text" class="form-control" placeholder="Apellido Paciente..." />
                                </div>
                                <div class="col-md-2">
                                    <label>Fecha Nacimiento</label>
                                    <input runat="server" type="text" id="txtFecNac" class="form-control" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-4">
                                    <label>Télefono</label>
                                    <input runat="server" class="form-control" id="txtTel" placeholder="Teléfono Paciente..." />
                                </div>
                                <div class="col-md-4">
                                    <label>Dirección</label>
                                    <input runat="server" class="form-control" id="txtDire" placeholder="Dirección Paciente..." />
                                </div>
                                <div class="col-md-2">
                                    <label>Fecha Nacimiento</label>
                                </div>
                                <div class="col-md-2">
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
                            <br />
                            <hr />
                            <div class="row">
                                <!-- Obra Social --------------->
                                <div class="col-md-6">
                                    <label>Obras Sociales</label>
                                    <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#myModalObrasSociales"><b>+</b></button>
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
                                <div class="col-md-6">
                                    <label>Ocupaciones</label>
                                    <br />
                                    <asp:DropDownList ID="ddlOcu" runat="server" class="form-control"></asp:DropDownList>
                                </div>
                                <br />
                            </div>
                            <br />
                            <!-- Datos Personales --------------------------------------------------------------------------------->


                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading" role="tab" id="headingTwo">
                        <h4 class="panel-title">
                            <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">Antecedentes Médicos</a>
                        </h4>
                    </div>
                    <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                        <div class="panel-body">

                            <!-- Medidas --------------------------------------------------------------------------------->
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="col-md-12">
                                        <label>Medidas</label>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Altura</label>
                                        <asp:DropDownList ID="ddlAltura" runat="server" class="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Peso</label>
                                        <asp:DropDownList ID="ddlPeso" runat="server" class="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="col-md-12">
                                        <label>Tensión Arterial</label>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Mínima</label>
                                        <asp:DropDownList ID="ddlMin" runat="server" class="form-control"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-6">
                                        <label>Máxima</label>
                                        <asp:DropDownList ID="ddlMax" runat="server" class="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="col-md-12">
                                        <label>Realiza Actividad</label>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <input type="checkbox" runat="server" id="cbAct" aria-label="..." />
                                            </span>
                                            <input type="text" class="form-control" aria-label="..." id="txtAct" runat="server" placeholder="Frecuencia Semanal(Veces)..." />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <!-- Antecedentes --------------------------------------------------------------------------------->
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Antecedentes:</label>
                                </div>
                            </div>
                            <div class="row">
                                <asp:Panel ID="panelAntMed" runat="server">
                                   
                                </asp:Panel>
                                 <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>


        <!--  Modal Busqueda Avanzada  --------------------------------------------------------------------------------------------------------------------->
        <div id="myModalBusquedaAvanzada" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModalBusqueda" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnBusqAvanzada" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <!-- Modal Obras Sociales -->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Búsqueda Avanzada de Pacientes</h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-5">
                                        <label>Nombre</label>
                                        <input id="txtBNom" runat="server" type="text" class="form-control" placeholder="Nombre Paciente..." />
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="col-md-5">
                                        <label>Apellido</label>
                                        <input id="txtBApe" runat="server" type="text" class="form-control" placeholder="Apellido Paciente..." />
                                    </div>
                                    <div class="col-md-2">
                                        <br />
                                        <asp:Button ID="btnBusqAvanzada" runat="server" class="btn btn-info btn-block" Text="+" OnClick="btnBusqAvanzada_Click" />
                                        <br />
                                    </div>
                                </div>
                                <hr />
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-success" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <!--  Modal Busqueda Avanzada  --------------------------------------------------------------------------------------------------------------------->

        <!--  Modal Obras Sociales ------------------------------------------------------------------------------------------------------------------------->
        <div id="myModalObrasSociales" class="modal fade" role="dialog">
            <div class="modal-dialog  modal-lg">
                <asp:UpdatePanel ID="upModalSocial" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnOSAgregar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="gvOsocial" EventName="RowDeleting" />
                        <asp:AsyncPostBackTrigger ControlID="gvOsocial" EventName="SelectedIndexChanging" />
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
                                    <div class="col-md-7">
                                        <label>Lista de Obras Sociales</label>
                                        <asp:DropDownList ID="ddlOS" runat="server" class="form-control"></asp:DropDownList>
                                        <br />
                                    </div>
                                    <div class="col-md-3">
                                        <label>Número de Tarjeta</label>
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
                                        OnRowDeleting="ObraSocialEliminarFilaGrilla"
                                        OnSelectedIndexChanging="ObraSocial_SelectedIndexChanging">
                                        <Columns>

                                            <asp:BoundField DataField="OSOID" HeaderText="Código">
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
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




    </div>

    <div class="panel-footer">
        <div class="container">
            <asp:Button ID="btnConfirmar" runat="server" Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnConfirmar_Click" />
        </div>
    </div>

</asp:Content>
