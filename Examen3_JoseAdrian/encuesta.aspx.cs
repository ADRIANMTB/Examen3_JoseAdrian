using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Examen3_JoseAdrian.Clases;

namespace Examen3_JoseAdrian
{
    public partial class encuesta : System.Web.UI.Page
    {

        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private readonly MANEJARENCUESTAS encuestaManager;
        
        private readonly VALIDARENCUESTA.EncuestaValidator encuestaValidator;

        public MANEJARENCUESTA MANEJARENCUESTAS { get; private set; }
        public VALIDARENCUESTA VALIDARENCUESTAS { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            MANEJARENCUESTAS = new MANEJARENCUESTA(connectionString);
            VALIDARENCUESTAS = new VALIDARENCUESTA();
            if (!IsPostBack)
            {
                CargarEncuestas();
            }
        }

        protected void btnGuardarEncuesta_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            DateTime fechaNacimiento;
            string correo = txtCorreo.Text;
            string partido = ddlPartido.SelectedValue;

            if (DateTime.TryParse(txtFechaNacimiento.Text, out fechaNacimiento) && encuestaValidator.ValidarCorreo(correo) && encuestaValidator.ValidarEdad(fechaNacimiento))
            {
                Encuesta nuevaEncuesta = new Encuesta
                {
                    Nombre = nombre,
                    FechaNacimiento = fechaNacimiento,
                    CorreoElectronico = correo,
                    PartidoPolitico = partido
                };

                object value = MANEJARENCUESTAS.AgregarEncuesta(nuevaEncuesta);

                LimpiarCampos();
                CargarEncuestas();
            }
            else
            {
                lblMensaje.Text = "Por favor, ingrese una fecha de nacimiento válida (mayor de 18 y menor de 50) y un correo electrónico válido.";
            }
        }

        private void CargarEncuestas()
        {
            List<Encuesta> encuestas = MANEJARENCUESTA.ObtenerTodasEncuestas();
            gvEncuestas.DataSource = encuestas;
            gvEncuestas.DataBind();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
        }

        protected void ddlPartido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
       