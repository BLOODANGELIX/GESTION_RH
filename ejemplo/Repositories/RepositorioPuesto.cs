using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Collections.ObjectModel;

namespace ejemplo.Repositories
{
    public class RepositorioPuesto : RepositoryBase, IBaseRepository<ModeloPuesto, int>
    {
        public void Add(ModeloPuesto modelo)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO [dbo].[Puesto] (nombre,salario)
                                        VALUES (@nombre, @salario)";
                command.Parameters.AddWithValue("@nombre", modelo.Nombre);
                command.Parameters.AddWithValue("@salario", modelo.Salario);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Edit(ModeloPuesto modelo)
        {

        }
        
    }
}
