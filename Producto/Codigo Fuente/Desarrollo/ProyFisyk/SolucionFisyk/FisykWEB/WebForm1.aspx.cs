using System.Configuration;
using System.Data;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FisykBLL;
using FisykDTO;


namespace FisykWEB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lbl1.Text = "Primera";

                ddlPruebas.DataSource = ListarLocalidadSP();
                ddlPruebas.DataValueField = "LOCID";
                ddlPruebas.DataTextField = "LOCDESCRIPCION";
                ddlPruebas.DataBind();
            }
            else
            {
                lbl1.Text = "Segunda";
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                PersonaDTO Persona = new PersonaDTO();


                Persona.psn_tpdId = Convert.ToInt32(txtTpDoc.Text);
                Persona.psnNroDcto = Convert.ToInt32(txtNroDoc.Text);
                Persona.psnNombre = txtNom.Text.ToString();
                Persona.psnApellido = txtApe.Text.ToString();
                Persona.psnFechaNac = txtFecNac.Text.ToString();
                Persona.psnTelefono = txtTel.Text.ToString();
                Persona.psnSexo = txtSexo.Text.ToString();
                Persona.psn_domId = Convert.ToInt32(txtDom.Text);

                PersonaManager.SavePersona(Persona);
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdLoc.Text) == false)
            {
                //Creo un objeto "Caulquiera para este caso"
                LocalidadDTO objLoc = new LocalidadDTO();

                //Obtengo los valores de la pantalla
                objLoc.locId = Convert.ToInt32(txtIdLoc.Text);
                objLoc.locDescripcion = txtLocdesc.Text;

                //Llamo ala funcion y paso por parametro "x" objeto
                InsertarPrueba(objLoc);

                //Limpio la pantalla
                txtIdLoc.Text = null;
                txtLocdesc.Text = null;
            }
        }

        //____________________________________________________________
        //Insert con SP
        public static void InsertarPrueba(LocalidadDTO prueba)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = new OracleConnection(ConfigurationManager.ConnectionStrings["CHAPA"].ConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PRUEBA_INSERT";
            cmd.BindByName = true;

            cmd.Parameters.Add(new OracleParameter("valID", prueba.locId));
            cmd.Parameters.Add(new OracleParameter("valDESCRI", prueba.locDescripcion));

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            cmd.Dispose();
        }

        //____________________________________________________________
        //Lista "objeto" con StoredProcedure
        public static List<LocalidadDTO> ListarLocalidadSP()
        {
            OracleCommand cmd = new OracleCommand();
            List<LocalidadDTO> ListaLocalidades = new List<LocalidadDTO>();

            cmd.Connection = new OracleConnection(ConfigurationManager.ConnectionStrings["CHAPA"].ConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LOCALIDAD_SELECT";
            cmd.BindByName = true;

            cmd.Parameters.Add("o_c_loc", OracleDbType.RefCursor, ParameterDirection.Output);

            cmd.Connection.Open();
            OracleDataReader odr = cmd.ExecuteReader();
            while (odr.Read())
            {
                LocalidadDTO objLoc = new LocalidadDTO();

                objLoc.locId = Convert.ToInt32(odr[0]);
                objLoc.locDescripcion = odr[1].ToString();

                ListaLocalidades.Add(objLoc);
            }
            cmd.Connection.Close();
            cmd.Dispose();

            return ListaLocalidades;
        }


        //____________________________________________________________
        //Lista "objeto" con Text
        public static List<LocalidadDTO> ListarLocalidadText()
        {
            OracleCommand cmd = new OracleCommand();
            List<LocalidadDTO> ListaLocalidades = new List<LocalidadDTO>();

            cmd.Connection = new OracleConnection(ConfigurationManager.ConnectionStrings["CHAPA"].ConnectionString);
            string strParcial = "Select  * from localidad";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strParcial;
            cmd.Connection.Open();
            OracleDataReader odr = cmd.ExecuteReader();
            while (odr.Read())
            {
                LocalidadDTO objLoc = new LocalidadDTO();

                objLoc.locId = Convert.ToInt32(odr[0]);
                objLoc.locDescripcion = odr[1].ToString();

                ListaLocalidades.Add(objLoc);
            }
            cmd.Connection.Close();
            cmd.Dispose();

            return ListaLocalidades;
        }


        //____________________________________________________________
        // Seleccionar una localidad del dll
        protected void ddlPruebas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Limpio las cajas de texto
            txtLocIdSel.Text = null;
            txtLocDescriSel.Text = null;

           // Verifico si selecciono algo del dll
            if (ddlPruebas.SelectedIndex != 0)
            {
                // Busqueda del elemento seleccionado en las dll
                LocalidadDTO objLoc = unaLocalidad(Convert.ToInt32(ddlPruebas.SelectedValue));
                // Agrego los valores obtenidos de la base
                txtLocIdSel.Text = Convert.ToString(objLoc.locId);
                txtLocDescriSel.Text = objLoc.locDescripcion;
            }
        }

        //____________________________________________________________
        public static LocalidadDTO unaLocalidad(int prueba)
        {
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = new OracleConnection(ConfigurationManager.ConnectionStrings["CHAPA"].ConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LOCALIDAD_SELECT_FILTRO";
            cmd.BindByName = true;

            cmd.Parameters.Add(new OracleParameter("p_locId", prueba));
            cmd.Parameters.Add("o_c_loc", OracleDbType.RefCursor, ParameterDirection.Output);

            cmd.Connection.Open();

            OracleDataReader odr = cmd.ExecuteReader();

            LocalidadDTO objLoc = new LocalidadDTO();
            while (odr.Read())
            {
                objLoc.locId = Convert.ToInt32(odr[0]);
                objLoc.locDescripcion = odr[1].ToString();
            }
            cmd.Connection.Close();
            cmd.Dispose();

            return objLoc;
        }





    }
}