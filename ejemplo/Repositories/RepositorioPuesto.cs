using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;  
using System.Text;  
using System.Threading.Tasks;
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
            }
        }   

        public void Edit(ModeloPuesto modelo)
        {
            string cosultaEditar = "UPDATE [dbo].[Puesto] " +
                "SET nombre = @nombre, " +
                "salario = @salario " +
                "WHERE idPuesto = @idPuesto";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(cosultaEditar,connection))
            {
                connection.Open ();
                command.Parameters.AddWithValue("@nombre", modelo.Nombre);
                command.Parameters.AddWithValue("@salario", modelo.Salario);
                command.Parameters.AddWithValue("@idPuesto", modelo.IdPuesto);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ModeloPuesto> GetAll()
        {
            ObservableCollection<ModeloPuesto> todosLosPuesto = new ObservableCollection<ModeloPuesto>();

            string consultaGetAll = "SELECT * FROM [dbo].[Puesto]";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaGetAll, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    todosLosPuesto.Add(new ModeloPuesto()
                    {
                        IdPuesto = (int)reader["idPuesto"],
                        Nombre = (string)reader["nombre"],
                        Salario = (decimal)reader["salario"]
                    });
                }
                reader.Close();
            }
            return todosLosPuesto;
        }

        public ModeloPuesto GetById(int id)
        {
            ModeloPuesto modeloPuesto = null;

            string consultaGetbyId = "SELECT idPuesto, nombre, salario " +
                "From [dbo].[Puesto] " +
                "WHERE idPuesto = @id";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaGetbyId, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    modeloPuesto = new ModeloPuesto()
                    {
                        IdPuesto = (int)reader["idPuesto"],
                        Nombre = (string)reader["nombre"],
                        Salario = (decimal)reader["salario"]
                    };

                }
                reader.Close();
            }

            return modeloPuesto;
        }

        public void Remove(int id)
        {
            string consultaEliminar = "DELETE FROM  [dbo].[Puesto] WHERE idPuesto = @id";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaEliminar,connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id",id);
                command.ExecuteNonQuery();
            }

        }
    }
}
