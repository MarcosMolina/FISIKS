using FisykBLL;
using FisiksAppWeb;
using System;
using System.Web.UI;
using System.Collections;

namespace FisiksAppWeb
{
    public partial class PacientesABM : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                panelDatos.Visible = true;

                Cargar_DDL();

            }
        }


        private void ObtenerDatosPantalla(PacienteDTO Paciente)
        {
            //  Persona
            Paciente.psnNroDcto = txtDoc.Value;
            Paciente.psnNombre = txtNombre.Value;
            Paciente.psnApellido = txtApellido.Value;
            Paciente.psnFechaNac = txtFecNac.Value;
            Paciente.psnTelefono = txtTel.Value;
            if (rbM.Checked) { Paciente.psnSexo = "M"; } else if (rbF.Checked) { Paciente.psnSexo = "F"; }

            string xx = ddlPeso.SelectedValue;
            xx = xx.Replace("Kg", "");
            string zz = ddlAltura.SelectedValue;
            zz = zz.Replace("cm", "");
            //  Paciente
            if (ddlPeso.SelectedIndex != 0) { Paciente.paePeso = Convert.ToDecimal(xx); }
            if (ddlAltura.SelectedIndex != 0) { Paciente.paeAltura = Convert.ToInt16(zz); }
            if (cbAct.Checked)
            {
                Paciente.paeActFisica = "S";
                if (!string.IsNullOrEmpty(txtAct.Value)) { Paciente.paePeriodicidad = Convert.ToInt16(txtAct.Value); }
            }
            else { Paciente.paeActFisica = "N"; }
        }

        private void CargarDatosPantalla(PacienteDTO Paciente)
        {
            //  Persona
            txtDoc.Value = Paciente.psnNroDcto;
            txtNombre.Value = Paciente.psnNombre;
            txtApellido.Value = Paciente.psnApellido;
            txtFecNac.Value = Paciente.psnFechaNac;
            Paciente.psnTelefono = txtTel.Value;
            if (Paciente.psnSexo == "M") { rbM.Checked = true; rbF.Checked = false; }
            else if (Paciente.psnSexo == "F") { rbM.Checked = false; rbF.Checked = true; }
            //  Paciente
            if (!string.IsNullOrEmpty(txtPeso.Value)) { Paciente.paePeso = Convert.ToDecimal(txtPeso.Value); }
            if (!string.IsNullOrEmpty(txtAltura.Value)) { Paciente.paeAltura = Convert.ToInt16(txtAltura.Value); }
            if (cbAct.Checked)
            {
                Paciente.paeActFisica = "S";
                if (!string.IsNullOrEmpty(txtAct.Value)) { Paciente.paePeriodicidad = Convert.ToInt16(txtAct.Value); }
            }
            else { Paciente.paeActFisica = "N"; }


        }


        //Botones
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDoc.Value))
            {
                PacienteDTO pac = ManagerPacientes.ExistePaciente(txtDoc.Value.ToString());

                panelDatos.Visible = true;
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                PacienteDTO PersonaPaciente = new PacienteDTO();
                ObtenerDatosPantalla(PersonaPaciente);
                ManagerPacientes.GrabarPaciente(ref PersonaPaciente);
            }
        }


        //Cargar DropDownList
        private void Cargar_DDL()
        {
            //________________________________________________________________________________________________________
            //  Cargar Altura
            ArrayList altura = PublicData.ArrayAltura();
            ddlAltura.DataSource = altura;
            ddlAltura.DataBind();

            //________________________________________________________________________________________________________
            //  Cargar Peso
            ArrayList peso = PublicData.ArrayPeso();
            ddlPeso.DataSource = peso;
            ddlPeso.DataBind();

            //________________________________________________________________________________________________________
            //  Cargar Ocupaciones
            ddlOcu.DataSource = ManagerOcupaciones.ListOcupaciones();
            ddlOcu.DataValueField = "ocuId";
            ddlOcu.DataTextField = "ocuDescripcion";
            ddlOcu.DataBind();

            //________________________________________________________________________________________________________
            //  Cargar Obra Sociales
            ddlOS.DataSource = ManagerObraSociales.ListObraSociales();
            ddlOS.DataValueField = "osoId";
            ddlOS.DataTextField = "osoDescripcion";
            ddlOS.DataBind();

        }
    }
}