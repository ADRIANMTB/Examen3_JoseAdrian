using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen3_JoseAdrian
{
    public partial class Encuesta : System.Web.UI.MasterPage
    {
        internal string Nombre;
        internal DateTime FechaNacimiento;
        internal string CorreoElectronico;
        internal string PartidoPolitico;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}