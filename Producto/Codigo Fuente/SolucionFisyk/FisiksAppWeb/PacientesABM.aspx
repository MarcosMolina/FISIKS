<%@ Page Title="" Language="C#" MasterPageFile="~/MPF.Master" AutoEventWireup="true" CodeBehind="PacientesABM.aspx.cs" Inherits="FisiksAppWeb.PacientesABM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h3>Pacientes</h3>
        <!--       /.Header-->
        <div class="panel-body">
            <div class="form-inline">
                <div class="well">
                    <div class="form-group">
                        <label for="lblDocumento">Documento</label>
                        <input type="text" class="form-control" id="txtDoc" runat="server" placeholder="Ingrese el Documento..." />
                    </div>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                    <asp:DropDownList ID="ddlAltura" runat="server" class="form-control"></asp:DropDownList>
                    <asp:DropDownList ID="ddlPeso" runat="server" class="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
            <asp:Panel ID="panelDatos" runat="server">

            <div class="row">
                <div class="form-tgroup">

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
                        <input runat="server" type="date" id="txtFecNac" class="form-control" />
                    </div>

                </div>
            </div>

            <div class="row">
                <div class="form-group">

                    <div class="col-md-4">
                        <label for="lblTelefono">Télefono</label>
                        <input type="tel" runat="server" class="form-control" id="txtTel" placeholder="Teléfono Paciente..." />
                    </div>

                    <div class="col-md-4">
                        <label for="lblTelefono">Altura</label>
                        <input type="text" runat="server" class="form-control" id="txtAltura" placeholder="Altura Paciente(Cm)..." />
                    </div>

                    <div class="col-md-4">
                        <label for="lblTelefono">Peso</label>
                        <input type="text" runat="server" class="form-control" id="txtPeso" placeholder="Peso Paciente(Kg)..." />
                    </div>

                </div>
            </div>

            <div class="row">
                <p></p>
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:DropDownList ID="ddlOS" runat="server" class="form-control"></asp:DropDownList>
                        <input type="text" runat="server" class="form-control" placeholder="Obras Sociales..." />
                        <span class="input-group-btn">
                            <button class="btn btn-default" type="button"><b>+</b></button>
                        </span>
                    </div>
                    <textarea class="form-control" rows="4"></textarea>
                </div>
                <!-- /.Obras Sociales-->
                <p></p>
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:DropDownList ID="ddlOcu" runat="server" class="form-control"></asp:DropDownList>
                        <input type="text" runat="server" class="form-control" placeholder="Ocupaciones..." />
                        <span class="input-group-btn">
                            <button class="btn btn-default" type="button"><b>+</b></button>
                        </span>
                    </div>
                    <textarea class="form-control" rows="4"></textarea>
                </div>
                <!-- /.Ocupaciones-->
                <p></p>
                <div class="col-md-3">
                    <label for="lblTelefono">Realiza Actividad</label>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <input type="checkbox" runat="server" id="cbAct" aria-label="..." />
                        </span>
                        <input type="text" class="form-control" aria-label="..." id="txtAct" runat="server" placeholder="Frecuencia Semanal(Veces)..." />
                    </div>
                    <!-- /input-group -->
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

            </asp:Panel>
        </div>

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
