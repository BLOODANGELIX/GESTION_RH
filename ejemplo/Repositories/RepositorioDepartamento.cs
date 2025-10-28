using ejemplo.Models; // asegurarse de importar esta libreria para que te aparezca 
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel; // asegurarse de importar este tambien para datos nulos

namespace ejemplo.Repositories
{
    public class RepositorioDepartamento : RepositoryBase, IBaseRepository<ModeloDepartamento, int>
    {
        public void Add(ModeloDepartamento modelo)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {

                // El @ evita tener que concatenar el texto 
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO [dbo].[Departamento] (nombreDepartamento,idJefe)
                                       VALUES (@nombreDepartamento, @idJefe)";
                command.Parameters.AddWithValue("@nombreDepartamento", modelo.Nombre);
                command.Parameters.AddWithValue("@idJefe", modelo.JefeDepartamento.RFC);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Edit(ModeloDepartamento modelo)
        {
            string consultaSql = @"UPDATE [dbo].[Departamento] 
                                SET nombreDepartamento = @nombreDepartamento,
                                idJefe = @idJefe
                                WHERE idDepartamento = @idDepartamento
                                 ";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaSql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@nombreDepartamento", modelo.Nombre);
                command.Parameters.AddWithValue("@idJefe", modelo.JefeDepartamento.RFC); // Cambiar el id jefe
                command.Parameters.AddWithValue("@idDepartamento",modelo.IdDepartamento);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ModeloDepartamento> GetAll()
        {
            ObservableCollection<ModeloDepartamento> lsResult = new ObservableCollection<ModeloDepartamento>();

            // 1. Modifica la consulta para incluir la tabla Empleado (usamos LEFT JOIN
            //    por si un departamento NO tiene jefe asignado)
            string consultaSql = @"SELECT 
                                    d.idDepartamento, 
                                    d.nombreDepartamento,
                                    e.RFC AS Jefe_RFC,
                                    e.Nombre AS Jefe_Nombre,
                                    e.Paterno AS Jefe_Paterno,
                                    e.Materno AS Jefe_Materno
                                   FROM [dbo].[Departamento] d
                                   LEFT JOIN [dbo].[Empleado] e ON d.idJefe = e.RFC"; // eliminar esto de la cosulta 

            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaSql, connection))
            {
                connection.Open();
                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ModeloEmpleado jefe = null;

                    if (reader["Jefe_RFC"] != DBNull.Value)
                    {
                        jefe = new ModeloEmpleado()
                        {
                            RFC = (int)reader["Jefe_RFC"],
                            Nombre = (string)reader["Jefe_Nombre"],
                            Paterno = (string)reader["Jefe_Paterno"],
                            Materno = (string)reader["Jefe_Materno"]
                        };
                    }

                    lsResult.Add(new ModeloDepartamento()
                    {
                        IdDepartamento = (int)reader["idDepartamento"],
                        Nombre = (string)reader["nombreDepartamento"],
                        JefeDepartamento = jefe 
                    });
                }
            }

            return lsResult;
        }

        public ModeloDepartamento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
