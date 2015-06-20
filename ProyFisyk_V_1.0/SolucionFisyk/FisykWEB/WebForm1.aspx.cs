using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FisykBLL;
using FisykDTO.Entities;

namespace FisykWEB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                lbl1.Text = "Primera";

                //GridView1.DataSource = PersonaManager.GetPersona();
                //GridView1.DataBind();
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

      
 
    }
}