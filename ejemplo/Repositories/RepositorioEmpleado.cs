using ejemplo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
            }
        }
        public void Edit(ModeloEmpleado modelo)
        {
            command.CommandText = "INSERT INTO [dbo].[Empleado] (RFC, " +
                  "nombre, paterno, materno, telefono, correo, idDepartamento, " +
                  "idPuesto) VALUES (@RFC, @nombre, @paterno, @materno, " +
                      "@telefono, @correo, @idDepartamento, @idPuesto)"
                string consultaEditar = "UPDATE [dbo].[Empleado] " +
                "SET RFC = @RFC, " +
                "nombre = @nombre, " +
                "";
            throw new NotImplementedException();
        }

        public IEnumerable<ModeloEmpleado> GetAll()
        {
            throw new NotImplementedException();
        }

        public ModeloEmpleado GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
