using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZJB.SQLDataAccess
{
    public class RepositorioPacientes
    {
        private readonly string connectionString = "TuCadenaDeConexion";

        public DataTable ObtenerPacientes()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("SELECT * FROM Pacientes", connection))
                {
                    var dataTable = new DataTable();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        public void AgregarPaciente(string nombre)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("INSERT INTO Pacientes (Nombre) VALUES (@Nombre)", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
