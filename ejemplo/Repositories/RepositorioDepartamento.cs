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

                if (modelo.JefeDepartamento != null)
                {
                    command.Parameters.AddWithValue("@idJefe", modelo.JefeDepartamento.RFC);
                }
                else
                {
                    command.Parameters.AddWithValue("@idJefe", DBNull.Value);
                }

                command.ExecuteNonQuery();
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

                if (modelo.JefeDepartamento != null)
                {
                    command.Parameters.AddWithValue("@idJefe", modelo.JefeDepartamento.RFC);
                }
                else
                {
                    command.Parameters.AddWithValue("@idJefe", DBNull.Value);
                }

                command.Parameters.AddWithValue("@idDepartamento",modelo.IdDepartamento);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ModeloDepartamento> GetAll()
        {
            ObservableCollection<ModeloDepartamento> lsResult = new ObservableCollection<ModeloDepartamento>();

            string consultaSql = @"SELECT 
                                    d.idDepartamento, 
                                    d.nombreDepartamento,
                                    e.RFC AS Jefe_RFC,
                                    e.Nombre AS Jefe_Nombre,
                                    e.Paterno AS Jefe_Paterno,
                                    e.Materno AS Jefe_Materno
                                   FROM [dbo].[Departamento] d
                                   LEFT JOIN [dbo].[Empleado] e ON d.idJefe = e.RFC";

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
                            RFC = (string)reader["Jefe_RFC"],
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
            ModeloDepartamento departamento = null;

            string consultaSql = @"SELECT 
                                    d.idDepartamento, 
                                    d.nombreDepartamento,
                                    e.RFC AS Jefe_RFC,
                                    e.Nombre AS Jefe_Nombre,
                                    e.Paterno AS Jefe_Paterno,
                                    e.Materno AS Jefe_Materno
                                   FROM [dbo].[Departamento] d
                                   LEFT JOIN [dbo].[Empleado] e ON d.idJefe = e.RFC
                                   WHERE d.idDepartamento = @idDepartamento"; 

            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaSql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@idDepartamento", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ModeloEmpleado jefe = null;

                    if (reader["Jefe_RFC"] != DBNull.Value)
                    {
                        jefe = new ModeloEmpleado()
                        {
                            RFC = (string)reader["Jefe_RFC"],
                            Nombre = (string)reader["Jefe_Nombre"],
                            Paterno = (string)reader["Jefe_Paterno"],
                            Materno = (string)reader["Jefe_Materno"]
                        };
                    }

                    departamento = new ModeloDepartamento()
                    {
                        IdDepartamento = (int)reader["idDepartamento"],
                        Nombre = (string)reader["nombreDepartamento"],
                        JefeDepartamento = jefe
                    };
                }
            }
            return departamento;
        }


        public void Remove(int id)
        {
            string consultaEliminar = "DELETE FROM  [dbo].[DEPARTAMENTO] WHERE idDepartamento = @id";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaEliminar, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}
