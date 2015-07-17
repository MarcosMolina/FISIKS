using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using FisiksAppWeb.Clases;
using FisiksAppWeb.Entities;
using FisykBLL;

namespace FisiksAppWeb
{
    public partial class PacientesAbm : Page
    {
        static CheckBox[] arregloCheckBoxs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                //-----------------------------------------------------------
                txtNroHistoriaClinica.Disabled = true;
                txtDocumento.Disabled = false;
                //-----------------------------------------------------------
                //B(busqueda) - N(nuevo)
                string varEstado = Request.QueryString["e"];
                PanelBusqueda.Visible = false;
                PanelPantalla.Visible = true;
                if (varEstado == "B")
                {
                    PanelBusqueda.Visible = true;
                    PanelPantalla.Visible = false;

                    btnConfirmar.Visible = false;

                    txtDocumento.Disabled = true;
                }
                //-----------------------------------------------------------
                CargarDatosIniciales();
                ObraSocialIniFila();
            }
        }


        private void ObtenerDatosPantalla(PacienteDto paciente)
        {
            #region  Persona ----------------------------------------

            paciente.PsnNroDcto = txtDocumento.Value;
            paciente.PsnNombre = txtNombre.Value;
            paciente.PsnApellido = txtApellido.Value;
            paciente.PsnFechaNac = txtFecNac.Value;
            paciente.PsnTelefono = txtTel.Value;
            paciente.PsnDomicilio = txtDire.Value;
            if (rbM.Checked) { paciente.PsnSexo = "M"; } else if (rbF.Checked) { paciente.PsnSexo = "F"; }

            #endregion
            #region  Paciente ---------------------------------------

            var varPeso = ddlPeso.SelectedValue;
            varPeso = varPeso.Replace("Kg", "");
            paciente.PaePeso = ddlPeso.SelectedIndex != 0 ? Convert.ToInt16(varPeso) : 0;
            var varAltura = ddlAltura.SelectedValue;
            varAltura = varAltura.Replace("cm", "");
            paciente.PaeAltura = ddlAltura.SelectedIndex != 0 ? Convert.ToInt16(varAltura) : 0;

            paciente.PaeTensionMax = ddlMax.SelectedIndex != 0 ? Convert.ToInt16(ddlMax.SelectedValue) : 0;
            paciente.PaeTensionMin = ddlMin.SelectedIndex != 0 ? Convert.ToInt16(ddlMin.SelectedValue) : 0;
           
            if (cbAct.Checked)
            {
                paciente.PaeActFisica = "S";
                if (!string.IsNullOrEmpty(txtAct.Value)) { paciente.PaePeriodicidad = Convert.ToInt16(txtAct.Value); }
            }
            else { paciente.PaeActFisica = "N"; }

            paciente.PaeOcuId = ddlOcu.SelectedIndex != 0 ? Convert.ToInt16(ddlOcu.SelectedValue) : 0;

            #endregion
            #region Obra Social ------------------------------------

            var dtOs = (DataTable)ViewState["DadaTableOS"];
            List<PacienteOsDto> listaObraSoc = new List<PacienteOsDto>();
            foreach (DataRow dtRow in dtOs.Rows)
            {
                var obrasSoc = new PacienteOsDto();
                obrasSoc.OspOsoId = Convert.ToInt32(dtRow[0].ToString());
                if (!string.IsNullOrEmpty(dtRow["OSPNROSOCIO"].ToString())) { obrasSoc.OspNroSocio = Convert.ToInt64(dtRow["OSPNROSOCIO"].ToString()); }
                listaObraSoc.Add(obrasSoc);
            }
            paciente.PaeListObraSocial = listaObraSoc;

            #endregion
            #region Antecedentes Medicos ---------------------------



            #endregion
            
            var varEstado = Request.QueryString["e"];
            if (varEstado == "B")
            {
                if (lblPaeId != null) paciente.PaeId = Convert.ToInt32(lblPaeId.Text);
                if (lblPsnId != null) paciente.PsnId = Convert.ToInt32(lblPsnId.Text);
            }
        }

        private void CargarDatosPantalla(PacienteDto paciente)
        {
            #region  Persona ----------------------------------------

            lblPsnId.Text = paciente.PsnId.ToString();

            txtDocumento.Value = paciente.PsnNroDcto;
            txtNombre.Value = paciente.PsnNombre;
            txtApellido.Value = paciente.PsnApellido;
            txtFecNac.Value = paciente.PsnFechaNac;
            txtTel.Value = paciente.PsnTelefono;
            txtDire.Value = paciente.PsnDomicilio;
            switch (paciente.PsnSexo) { case "M":rbM.Checked = true; rbF.Checked = false; break; case "F":rbM.Checked = false; rbF.Checked = true; break; }

            #endregion
            #region  Paciente ---------------------------------------

            lblPaeId.Text = paciente.PaeId.ToString();

            if (paciente.PaePeso == 0) { ddlPeso.SelectedIndex = 0; } else { ddlPeso.SelectedValue = paciente.PaePeso + " Kg"; }
            if (paciente.PaeAltura == 0) { ddlAltura.SelectedIndex = 0; } else { ddlAltura.SelectedValue = paciente.PaeAltura + " cm"; }
            if (paciente.PaeTensionMax == 0) { ddlMax.SelectedIndex = 0; } else { ddlMax.SelectedValue = paciente.PaeTensionMax.ToString(); }
            if (paciente.PaeTensionMin == 0) { ddlMin.SelectedIndex = 0; } else { ddlMin.SelectedValue = paciente.PaeTensionMin.ToString(); }

            if (cbAct.Checked)
            {
                paciente.PaeActFisica = "S";
                if (!string.IsNullOrEmpty(txtAct.Value))
                {
                    paciente.PaePeriodicidad = Convert.ToInt16(txtAct.Value);

                }
            }
            else
            {
                paciente.PaeActFisica = "N";
                paciente.PaePeriodicidad = 0;
            }

            if (paciente.PaeOcuId == 0) { ddlPeso.SelectedIndex = 0; } else { ddlOcu.SelectedValue = Convert.ToString(paciente.PaeOcuId); }


            #endregion
            #region Obra Social ------------------------------------

            ObraSocialIniFila();

            var dtOs = (DataTable)ViewState["DadaTableOS"];

            List<PacienteOsDto> listaObraSoc = ManagerObraSociales.ListObraSocialesPaciente(paciente.PaeId);
            var dtCurrentTable = (DataTable)ViewState["DadaTableOS"];
            foreach (var los in listaObraSoc)
            {
                DataRow drCurrentRow = null;
                drCurrentRow = dtCurrentTable.NewRow();

                drCurrentRow["OSOID"] = los.OspId;
                drCurrentRow["OSODESCRIPCION"] = los.OsoDescripcion;
                drCurrentRow["OSPNROSOCIO"] = los.OspNroSocio;

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["DadaTableOS"] = dtCurrentTable;
            }

            gvOsocial.DataSource = dtCurrentTable;
            gvOsocial.DataBind();

            ListObraSoial.DataSource = dtCurrentTable;
            ListObraSoial.DataValueField = "OSOID";
            ListObraSoial.DataTextField = "OSODESCRIPCION";
            ListObraSoial.DataBind();

            #endregion
            #region Antecedentes Medicos ---------------------------



            #endregion
        }


        //Botones --------------------------------------------------------------------------------------------------
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lbl.Text = null;
            if (!string.IsNullOrEmpty(txtDoc.Value))
            {
                PacienteDto pac = new PacienteDto();
                pac = ManagerPacientes.ExistePaciente(txtDoc.Value);

                if (pac != null)
                {
                    lbl.Text = "Existe";
                    CargarDatosPantalla(pac);
                    PanelPantalla.Visible = true;
                    btnConfirmar.Visible = true;
                }
                else
                {
                    lbl.Text = "El paciente buscado No existe!, desea buscar otro? o registar este paciente?";
                    PanelPantalla.Visible = false;
                    btnConfirmar.Visible = false;
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var personaPaciente = new PacienteDto();
                ObtenerDatosPantalla(personaPaciente);
                string varEstado = Request.QueryString["e"];
                if (varEstado == "N")
                {
                    ManagerPacientes.GrabarPacienteInsert(ref personaPaciente);
                }
                else if (varEstado == "B")
                {
                    ManagerPacientes.GrabarPacienteUpdate(ref personaPaciente);
                }
            }
        }

        #region Cargar Datos Iniciales

        private void CargarDatosIniciales()
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
            //  Cargar Maxima
            var max = PublicData.ArrayMaxMin();
            ddlMax.DataSource = max;
            ddlMax.DataBind();

            //________________________________________________________________________________________________________
            //  Cargar Minima
            var min = PublicData.ArrayMaxMin();
            ddlMin.DataSource = min;
            ddlMin.DataBind();

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

            //________________________________________________________________________________________________________
            //  Cargar Check Antecedentes Medicos
            CargaAntecedentesMedicos();
        }

        private void CargaAntecedentesMedicos()
        {
            List<AntecedenteMedicoDto> listAntMed = ManagerAntecedentesMedicos.ListAntecedenteMedico();
            arregloCheckBoxs = new CheckBox[listAntMed.Count];
            int nroPos = 0;
            foreach (var antemed in listAntMed)
            {
                CheckBox nuevoCk = new CheckBox();
                nuevoCk.ID = "ckAntMed" + antemed.AmeId.ToString();
                //nuevoCk.Click += new EventHandler(cb_Click);
                nuevoCk.Text = " " + antemed.AmeDescripcion.ToString();
                arregloCheckBoxs[nroPos] = nuevoCk;
                PlaceHolder1.Controls.Add(new LiteralControl("<div class='col-md-3'>"));
                PlaceHolder1.Controls.Add(nuevoCk);
                PlaceHolder1.Controls.Add(new LiteralControl("</div>"));
                nroPos++;
            }
        }

        #endregion

        #region Manejo de Obra Sociales

        private void ObraSocialIniFila()
        {
            ViewState["DadaTableOS"] = null;
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

            ListObraSoial.DataSource = dtObraSoc;
            ListObraSoial.DataValueField = "OSOID";
            ListObraSoial.DataTextField = "OSODESCRIPCION";
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
                lblMsjObrasocial.Text = null;
                lblMsjObrasocial.Visible = false;
                var dtCurrentTable = (DataTable)ViewState["DadaTableOS"];
                //recorro la tabla para saber si se agrego otro
                var controlExiste = false;
                foreach (DataRow fila in dtCurrentTable.Rows)
                {
                    if (fila["OSOID"].ToString() == ddlOS.SelectedValue)
                    {
                        lblMsjObrasocial.Visible = true;
                        lblMsjObrasocial.Text = "Verifique los datos,  ya existe una Obra Social con distintos Número de Socio.";

                        if (fila["OSOID"].ToString() == ddlOS.SelectedValue &&
                            fila["OSPNROSOCIO"].ToString() == txtNrotarj.Value)
                        {
                            controlExiste = true;
                            lblMsjObrasocial.Text = "Verifique los datos, ya existe una Obra Social con el mismo Número de Socio.";
                            break;
                        }
                    }
                }
                if (controlExiste == false)
                {
                    DataRow drCurrentRow = null;
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["OSOID"] = ddlOS.SelectedItem.Value;
                    drCurrentRow["OSODESCRIPCION"] = ddlOS.SelectedItem.Text;
                    if (!string.IsNullOrEmpty(txtNrotarj.Value)) { drCurrentRow["OSPNROSOCIO"] = txtNrotarj.Value; } else { drCurrentRow["OSPNROSOCIO"] = "0"; }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["DadaTableOS"] = dtCurrentTable;

                    txtNrotarj.Value = null;
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
            lblMsjObrasocial.Text = null;
            lblMsjObrasocial.Visible = false;

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

        protected void ObraSocial_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            if (gvOsocial.Rows.Count > 0)
            {
                ddlOS.SelectedValue = gvOsocial.Rows[e.NewSelectedIndex].Cells[0].Text;
                txtNrotarj.Value = gvOsocial.Rows[e.NewSelectedIndex].Cells[2].Text;
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

        protected void ckBusqueda_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnBusqAvanzada_Click(object sender, EventArgs e)
        {

        }

        protected void cbBusquedaAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            PanelBusquedaAvanzada.Visible = cbBusquedaAvanzada.Checked;
        }

    }
}