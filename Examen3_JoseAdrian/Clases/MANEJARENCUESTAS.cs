using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen3_JoseAdrian.Clases
{
    public class MANEJARENCUESTAS
    {
        private readonly string connectionString;

        public MANEJARENCUESTAS(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AgregarEncuesta(Encuesta encuesta)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Encuestas (Nombre, FechaNacimiento, CorreoElectronico, PartidoPolitico) VALUES (@Nombre, @FechaNacimiento, @CorreoElectronico, @PartidoPolitico)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", encuesta.Nombre);
                    command.Parameters.AddWithValue("@FechaNacimiento", encuesta.FechaNacimiento);
                    command.Parameters.AddWithValue("@CorreoElectronico", encuesta.CorreoElectronico);
                    command.Parameters.AddWithValue("@PartidoPolitico", encuesta.PartidoPolitico);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Encuesta> ObtenerTodasEncuestas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Encuestas";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<Encuesta> encuestas = new List<Encuesta>();
                    while (reader.Read())
                    {
                        Encuesta encuesta = new Encuesta
                        {
                            NumeroEncuesta = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            FechaNacimiento = reader.GetDateTime(2),
                            CorreoElectronico = reader.GetString(3),
                            PartidoPolitico = reader.GetString(4)
                        };
                        encuestas.Add(encuesta);
                    }
                    return encuestas;
                }
            }
        }

        internal void AgregarEncuesta(Examen3_JoseAdrian.Encuesta nuevaEncuesta)
        {
            throw new NotImplementedException();
        }
    }
}