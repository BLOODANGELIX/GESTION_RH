using ejemplo.Models; // asegurarse de importar esta libreria para que te aparezca 
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // asegurarse de importar este tambien para datos nulos

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
                command.CommandText = @"INSERT INTO [dbo].[Departamento] (nombreDepartamento,idJefe)
                                       VALUES (@nombreDepartamento, @idJefe)";
                command.Parameters.AddWithValue("@nombreDepartamento", modelo.Nombre);
                command.Parameters.AddWithValue("@idJefe", modelo.JefeDepartamento.RFC);

            }
        }

        public void Edit(ModeloDepartamento modelo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ModeloDepartamento> GetAll()
        {
            throw new NotImplementedException();
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
