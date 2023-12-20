using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen3_JoseAdrian.Clases
{
    public class VALIDARENCUESTA
    {
        internal bool ValidarCorreo(string correo)
        {
            throw new NotImplementedException();
        }

        internal bool ValidarEdad(DateTime fechaNacimiento)
        {
            throw new NotImplementedException();
        }

        public class EncuestaValidator
        {
            public bool ValidarEdad(DateTime fechaNacimiento)
            {
                DateTime fecha18 = DateTime.Now.AddYears(-18);
                DateTime fecha50 = DateTime.Now.AddYears(-50);

                return fechaNacimiento <= fecha18 && fechaNacimiento >= fecha50;
            }

            public bool ValidarCorreo(string correo)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(correo);
                    return addr.Address == correo;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}