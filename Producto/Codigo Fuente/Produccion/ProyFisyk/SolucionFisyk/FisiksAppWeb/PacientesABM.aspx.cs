using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using FisiksAppWeb.Entities;
using FisykBLL;

namespace FisiksAppWeb
{
    public partial class PacientesAbm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                panelDatos.Visible = true;

                Cargar_DDL();

                //gvOsocial.DataSource = ManagerOcupaciones.ListOcupaciones();
                //gvOsocial.DataBind();
                //gvOsocial.UseAccessibleHeader = true;
                //gvOsocial.HeaderRow.TableSection = TableRowSection.TableHeader;

                ObraSocialIniFila();
                panelDatos.Visible = true;
            }
        }


        private void ObtenerDatosPantalla(PacienteDto paciente)
        {
            #region  Persona ----------------------------------------

            paciente.PsnNroDcto = txtDoc.Value;
            paciente.PsnNombre = txtNombre.Value;
            paciente.PsnApellido = txtApellido.Value;
            paciente.PsnFechaNac = txtFecNac.Value;
            paciente.PsnTelefono = txtTel.Value;
            if (rbM.Checked) { paciente.PsnSexo = "M"; } else if (rbF.Checked) { paciente.PsnSexo = "F"; }

            paciente.PsnDomicilio = txtDire.Value;
            #endregion
            #region  Paciente ---------------------------------------

            var varPeso = ddlPeso.SelectedValue;
            varPeso = varPeso.Replace("Kg", "");
            if (ddlPeso.SelectedIndex != 0) { paciente.PaePeso = Convert.ToDecimal(varPeso); }
            var varAltura = ddlAltura.SelectedValue;
            varAltura = varAltura.Replace("cm", "");
            if (ddlAltura.SelectedIndex != 0) { paciente.PaeAltura = Convert.ToInt16(varAltura); }
            if (cbAct.Checked)
            {
                paciente.PaeActFisica = "S";
                if (!string.IsNullOrEmpty(txtAct.Value)) { paciente.PaePeriodicidad = Convert.ToInt16(txtAct.Value); }
            }
            else { paciente.PaeActFisica = "N"; }

            #endregion
            #region Obra Social ------------------------------------

            var dtOs = (DataTable)ViewState["DadaTableOS"];
            List<PacienteOsDto> listaObraSoc = new List<PacienteOsDto>();
            foreach (DataRow dtRow in dtOs.Rows)
            {
                var obrasSoc = new PacienteOsDto(Convert.ToInt32(dtRow[0].ToString()), Convert.ToInt64(dtRow[2].ToString()));
                // Agrego la lista de obras sociales al paciente
                listaObraSoc.Add(obrasSoc);
            }
            paciente.PaeListObraSocial = listaObraSoc;

            #endregion
            #region Ocupaciones ------------------------------------

            List<PacienteOcupacionesDto> listaOcupa = new List<PacienteOcupacionesDto>();
            for (var i = 0; i < ListOcu.Items.Count; i++)
            {
                var ocupaciones = new PacienteOcupacionesDto(Convert.ToInt32(ListOcu.Items[i].Value));
                //ocupaciones.OpaOcuId = Convert.ToInt32(ListOcu.Items[i].Value);//string info = ListOcu.Items[i].ToString();
                // Agrego la lista de obras sociales al paciente
                listaOcupa.Add(ocupaciones);
            }
            paciente.PaeListOcupaciones = listaOcupa;

            #endregion
        }

        private void CargarDatosPantalla(PacienteDto paciente)
        {
            //  Persona
            txtDoc.Value = paciente.PsnNroDcto;
            txtNombre.Value = paciente.PsnNombre;
            txtApellido.Value = paciente.PsnApellido;
            txtFecNac.Value = paciente.PsnFechaNac;
            paciente.PsnTelefono = txtTel.Value;
            if (paciente.PsnSexo == "M") { rbM.Checked = true; rbF.Checked = false; }
            else if (paciente.PsnSexo == "F") { rbM.Checked = false; rbF.Checked = true; }
            //  Paciente
            //if (!string.IsNullOrEmpty(txtPeso.Value)) { Paciente.paePeso = Convert.ToDecimal(txtPeso.Value); }
            //if (!string.IsNullOrEmpty(txtAltura.Value)) { Paciente.paeAltura = Convert.ToInt16(txtAltura.Value); }
            if (cbAct.Checked)
            {
                paciente.PaeActFisica = "S";
                if (!string.IsNullOrEmpty(txtAct.Value)) { paciente.PaePeriodicidad = Convert.ToInt16(txtAct.Value); }
            }
            else { paciente.PaeActFisica = "N"; }


        }


        //Botones --------------------------------------------------------------------------------------------------
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDoc.Value))
            {
                //PacienteDTO pac = ManagerPacientes.ExistePaciente(txtDoc.Value.ToString());

                //panelDatos.Visible = true;
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var personaPaciente = new PacienteDto();
                ObtenerDatosPantalla(personaPaciente);
                ManagerPacientes.GrabarPaciente(ref personaPaciente);
            }
        }

        //Cargar DropDownList --------------------------------------------------------------------------------------
        private void Cargar_DDL()
        {
            //________________________________________________________________________________________________________
            //  Cargar Altura
            var altura = PublicData.ArrayAltura();
            ddlAltura.DataSource = altura;
            ddlAltura.DataBind();

            //________________________________________________________________________________________________________
            //  Cargar Peso
            var peso = PublicData.ArrayPeso();
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


        #region Manejo de Obra Sociales ------------------------------------------------------------------------------------

        private void ObraSocialIniFila()
        {
            //Obra Social
            var dtObraSoc = new DataTable();
            dtObraSoc.Columns.Add(new DataColumn("OSOID", typeof(int)));
            dtObraSoc.Columns.Add(new DataColumn("OSODESCRIPCION", typeof(string)));
            dtObraSoc.Columns.Add(new DataColumn("OSPNROSOCIO", typeof(string)));

            ViewState["DadaTableOS"] = dtObraSoc;

            gvOsocial.DataSource = dtObraSoc;
            gvOsocial.DataBind();

            ListObraSoial.DataSource = dtObraSoc;
            ListObraSoial.DataBind();
        }

        protected void btnObraSocial_Click(object sender, EventArgs e)
        {
            ObraSocialAgregarFilaGrilla();
        }

        private void ObraSocialAgregarFilaGrilla()
        {
            if (ViewState["DadaTableOS"] != null)
            {
                var dtCurrentTable = (DataTable)ViewState["DadaTableOS"];
                //recorro la tabla para saber si se agrego otro
                var controlExiste = false;
                foreach (DataRow fila in dtCurrentTable.Rows)
                {
                    if (fila["OSOID"].ToString() == ddlOS.SelectedValue)
                    {
                        controlExiste = true;
                        break;
                    }
                }
                if (controlExiste == false)
                {
                    DataRow drCurrentRow = null;
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["OSOID"] = ddlOS.SelectedItem.Value;
                    drCurrentRow["OSODESCRIPCION"] = ddlOS.SelectedItem.Text;
                    drCurrentRow["OSPNROSOCIO"] = txtNrotarj.Value;

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["DadaTableOS"] = dtCurrentTable;

                    //lblErrorSin.Visible = false;
                    //lblErrorSin.Text = null;
                }
                else
                {
                    //lblErrorSin.Visible = true;
                    //lblErrorSin.Text = "(*) Seleccione otro Sintoma.";
                }
                gvOsocial.DataSource = dtCurrentTable;
                gvOsocial.DataBind();

                ListObraSoial.DataSource = dtCurrentTable;
                ListObraSoial.DataValueField = "OSOID";
                ListObraSoial.DataTextField = "OSODESCRIPCION";
                ListObraSoial.DataBind();
            }
        }

        protected void ObraSocialEliminarFilaGrilla(object sender, GridViewDeleteEventArgs e)
        {
            var index = Convert.ToInt32(e.RowIndex);
            var dt = ViewState["DadaTableOS"] as DataTable;
            if (dt.Rows.Count > 1)
            {
                dt.Rows[index].Delete();
                ViewState["DadaTableOS"] = dt;
                ObraSocialBindGrid();
            }
            else
            {
                ObraSocialIniFila();
            }
        }

        protected void ObraSocialBindGrid()
        {
            gvOsocial.DataSource = ViewState["DadaTableOS"] as DataTable;
            gvOsocial.DataBind();
            gvOsocial.UseAccessibleHeader = true;
            gvOsocial.HeaderRow.TableSection = TableRowSection.TableHeader;

            ListObraSoial.DataSource = ViewState["DadaTableOS"] as DataTable;
            ListObraSoial.DataValueField = "OSOID";
            ListObraSoial.DataTextField = "OSODESCRIPCION";
            ListObraSoial.DataBind();
        }

        #endregion

        protected void btnOcu_Click(object sender, EventArgs e)
        {
            if (ListOcu.Items.Count > 0)
            {
                for (var i = 0; i < ListOcu.Items.Count; i++)
                {
                    if (ddlOcu.SelectedItem.Value != ListOcu.Items[i].Value)
                    {
                        ListOcu.Items.Add(new ListItem(ddlOcu.SelectedItem.Text, ddlOcu.SelectedItem.Value));
                    }
                }
            }
            else { ListOcu.Items.Add(new ListItem(ddlOcu.SelectedItem.Text, ddlOcu.SelectedItem.Value)); }
        }

    }
}