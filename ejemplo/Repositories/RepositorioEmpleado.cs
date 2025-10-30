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
            using (var connection  = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [dbo].[Empleado] (RFC, " +
                    "nombre, paterno, materno, telefono, correo, idDepartamento, " +
                    "idPuesto) VALUES (@RFC, @nombre, @paterno, @materno, " +
                    "@telefono, @correo, @idDepartamento, @idPuesto)";
                command.Parameters.AddWithValue("@RFC",modelo);
                command.Parameters.AddWithValue("@nombre",modelo.Nombre);
                command.Parameters.AddWithValue("@paterno", modelo.Paterno);
                command.Parameters.AddWithValue("@nombre", modelo.Nombre);


            }
        }
        public void Edit(ModeloEmpleado modelo)
        {
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
