<%@ Page Title="" Language="C#" MasterPageFile="~/MPF.Master" AutoEventWireup="true" CodeBehind="ProfesionalesABM.aspx.cs" Inherits="FisiksAppWeb.ProfesionalesABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3>Profesionales</h3>
        <div class="panel-body">
            <div class="form-inline">
                <div class="well">
                    <div class="form-group">
                        <label for="lblDocumento">Documento</label>
                        <input type="text" class="form-control" id="txtDoc" runat="server" maxlength="9" placeholder="Ingrese el Documento..." required/>
                    </div>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="lblNombre">Nombre</label>
                        <input type="text" class="form-control" id="txtNombre" runat="server" placeholder="Nombre Profesional..." required/>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="lblTelefono">Apellido</label>
                        <input type="text" class="form-control" id="txtApellido" runat="server" placeholder="Apellido Profesional..." required/>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="lblNombre">Matrícula</label>
                        <input type="text" class="form-control" id="txtMatricula" runat="server" placeholder="Matrícula Profesional..." />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-2">
                    <div class="form-group">
                        <label for="lblNombre">Fecha Nacimiento</label>
                        <input type="date" runat="server" class="form-control" id="txtFecNac" />
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="lblTelefono">Télefono Personal</label>
                        <input type="tel" class="form-control" id="txtTel" placeholder="Teléfono Profesional..." />
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="lblTelefono">Télefono Interno</label>
                        <input type="tel" class="form-control" runat="server" id="txtTelItn" placeholder="Interno Profesional..." />
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-inline">
                    <div class="radio">
                        <label>
                            <input type="radio" name="opciones" id="rbM" runat="server" value="masculino"/>
                            Masculino
                        </label>
                    </div>
                    <div class="radio">
                        <label>
                            <input type="radio" name="opciones" id="rbF" runat="server" value="femenino" />
                            Femenino
                        </label>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="vacaciones">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">Vacaciones</h4>
                        </div>

                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="lblNombre">Fecha Inicio</label>
                                        <input type="date" class="form-control" runat="server" id="txtFecIni" />
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="lblTelefono">Fecha Fin</label>
                                        <input type="date" class="form-control" runat="server" id="txtFecFin" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" runat="server" class="btn btn-success">Confirmar</button>
                            <button type="button" runat="server" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal vacaciones-->

        </div>
        <!--       /.Body-->

        <div class="panel-footer">
            <asp:Button ID="btnConfirmar" runat="server" Text="Guardar Cambios" CssClass="btn btn-success" />
            <asp:Button ID="btnAgenda" runat="server" Text="Agenda" CssClass="btn btn-warning" />
            <!--<asp:Button ID="btnVacaciones" runat="server" Text="Vaciones" Cssclass="btn btn-info"/>-->
            <a class="btn btn-info" data-toggle="modal" href="#vacaciones">Vacaciones</a>
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
        </div>
        <!--       /.Footer-->
    </div>
</asp:Content>
