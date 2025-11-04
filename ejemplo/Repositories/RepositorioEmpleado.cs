using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;

namespace ejemplo.Repositories
{
    public class RepositorioEmpleado : RepositoryBase, IBaseRepository<ModeloEmpleado, string>
    {
        public void Add(ModeloEmpleado modelo)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [dbo].[Empleado] (RFC, " +
                    "nombre, paterno, materno, telefono, correo, idDepartamento, " +
                    "idPuesto) VALUES (@RFC, @nombre, @paterno, @materno, " +
                    "@telefono, @correo, @idDepartamento, @idPuesto)";
                command.Parameters.AddWithValue("@RFC", modelo);
                command.Parameters.AddWithValue("@nombre", modelo.Nombre);
                command.Parameters.AddWithValue("@paterno", modelo.Paterno);
                command.Parameters.AddWithValue("@materno", modelo.Materno);
                command.Parameters.AddWithValue("@telefono", modelo.Telefono);
                command.Parameters.AddWithValue("@correo", modelo.Correo);

                if (modelo.Puesto == null && modelo.Departamento == null)
                {
                    command.Parameters.AddWithValue("@idDepartamento", DBNull.Value);
                    command.Parameters.AddWithValue("@idPuesto", DBNull.Value);
                }


                else if (modelo.Puesto == null && modelo.Departamento != null)
                {
                    command.Parameters.AddWithValue("@idDepartamento", modelo.Departamento.IdDepartamento);
                    command.Parameters.AddWithValue("@idPuesto", DBNull.Value);
                }

                else
                {
                    command.Parameters.AddWithValue("@idDepartamento", modelo.Departamento.IdDepartamento);
                    command.Parameters.AddWithValue("@idPuesto", modelo.Puesto.IdPuesto);
                }

                command.ExecuteNonQuery();
            }
        }
        public void Edit(ModeloEmpleado modelo)
        {
            string consultaSql = @"UPDATE [dbo].[Empleado] 
                       SET nombre = @nombre,
                           paterno = @paterno,
                           materno = @materno,
                           telefono = @telefono,
                           correo = @correo,
                           idDepartamento = @idDepartamento,
                           idPuesto = @idPuesto
                       WHERE RFC = @RFC";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaSql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@nombre", modelo.Nombre);
                command.Parameters.AddWithValue("@paterno", modelo.Paterno);
                command.Parameters.AddWithValue("@materno", modelo.Materno);
                command.Parameters.AddWithValue("@telefono", modelo.Telefono);
                command.Parameters.AddWithValue("@correo", modelo.Correo);

                if (modelo.Puesto == null && modelo.Departamento == null)
                {
                    command.Parameters.AddWithValue("@idDepartamento", DBNull.Value);
                    command.Parameters.AddWithValue("@idPuesto", DBNull.Value);
                }


                else if (modelo.Puesto == null && modelo.Departamento != null)
                {
                    command.Parameters.AddWithValue("@idDepartamento", modelo.Departamento.IdDepartamento);
                    command.Parameters.AddWithValue("@idPuesto", DBNull.Value);
                }

                else
                {
                    command.Parameters.AddWithValue("@idDepartamento", modelo.Departamento.IdDepartamento);
                    command.Parameters.AddWithValue("@idPuesto", modelo.Puesto.IdPuesto);
                }

                command.Parameters.AddWithValue("@RFC", modelo);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ModeloEmpleado> GetAll()
        {
            ObservableCollection<ModeloEmpleado> lsResult = new ObservableCollection<ModeloEmpleado>();

            string consultaSql = @"SELECT 
                                    e.RFC, e.nombre, e.paterno, e.materno,e.telefono, e.correo,
                                    d.idDepartamento,
                                    d.nombreDepartamento,
                                    p.idPuesto,
                                    p.nombre AS nombrePuesto
                                   FROM [dbo].[Empleado] e
                                   LEFT JOIN [dbo].[Departamento] d ON e.idDepartamento = d.idDepartamento
                                   LEFT JOIN [dbo].[Puesto] p ON e.idPuesto = p.idPuesto";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaSql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ModeloDepartamento departamento = null;
                    if (reader["idDepartamento"] != DBNull.Value)
                    {
                        departamento = new ModeloDepartamento()
                        {
                            IdDepartamento = (int)reader["idDepartamento"],
                            Nombre = (string)reader["nombreDepartamento"]
                        };
                    }

                    ModeloPuesto puesto = null;
                    if (reader["idPuesto"] != DBNull.Value)
                    {
                        puesto = new ModeloPuesto()
                        {
                            IdPuesto = (int)reader["idPuesto"],
                            Nombre = (string)reader["nombre"]
                        };
                    }

                    var empleado = new ModeloEmpleado()
                    {
                        RFC = (string)reader["RFC"],
                        Nombre = (string)reader["nombre"],
                        Paterno = (string)reader["paterno"],
                        Materno = (string)reader["materno"],
                        Telefono = (string)reader["telefono"],
                        Correo = (string)reader["correo"],
                        Departamento = departamento,
                        Puesto = puesto
                    };

                    lsResult.Add(empleado);

                }
            }

            return lsResult;
        }

        public ModeloEmpleado GetById(string id)
        {
            ModeloEmpleado modeloEmpleado = null;

            string consultaSql = @"SELECT 
                                    e.RFC, e.nombre, e.paterno, e.materno,e.telefono, e.correo,
                                    d.idDepartamento,
                                    d.nombreDepartamento,
                                    p.idPuesto,
                                    p.nombre AS nombrePuesto
                                   FROM [dbo].[Empleado] e
                                   LEFT JOIN [dbo].[Departamento] d ON e.idDepartamento = d.idDepartamento
                                   LEFT JOIN [dbo].[Puesto] p ON e.idPuesto = p.idPuesto
                                   WHERE e.RFC = @RFC";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaSql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@RFC",id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ModeloDepartamento departamento = null;
                    if (reader["idDepartamento"] != DBNull.Value)
                    {
                        departamento = new ModeloDepartamento()
                        {
                            IdDepartamento = (int)reader["idDepartamento"],
                            Nombre = (string)reader["nombreDepartamento"]
                        };
                    }

                    ModeloPuesto puesto = null;
                    if (reader["idPuesto"] != DBNull.Value)
                    {
                        puesto = new ModeloPuesto()
                        {
                            IdPuesto = (int)reader["idPuesto"],
                            Nombre = (string)reader["nombre"]
                        };
                    }

                    modeloEmpleado = new ModeloEmpleado()
                    {
                        RFC = (string)reader["RFC"],
                        Nombre = (string)reader["nombre"],
                        Paterno = (string)reader["paterno"],
                        Materno = (string)reader["materno"],
                        Telefono = (string)reader["telefono"],
                        Correo = (string)reader["correo"],
                        Departamento = departamento,
                        Puesto = puesto
                    };

                }
            }
            return modeloEmpleado;
        }

        public void Remove(string id)
        {
            string consultaEliminar = "DELETE FROM [dbo].[Empleado] WHERE RFC = @RFC";
            using (var connection = GetConnection())
            using (var command = new SqlCommand(consultaEliminar, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@RFC", id);
                command.ExecuteNonQuery();
            }

        }
    }
}
