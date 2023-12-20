using System;
using System.Collections.Generic;

namespace Examen3_JoseAdrian
{
    public class MANEJARENCUESTA
    {
        private string connectionString;

        public MANEJARENCUESTA(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal static List<Encuesta> ObtenerTodasEncuestas()
        {
            throw new NotImplementedException();
        }

        internal object AgregarEncuesta(Encuesta nuevaEncuesta)
        {
            throw new NotImplementedException();
        }
    }
}