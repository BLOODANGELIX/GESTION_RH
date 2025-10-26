using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ejemplo.Repositories
{
    public class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()

        {
            // Para poder hacer pruebas es necesario cambiar el nombre del servidor para cada integrante que vaya a realizar las pruebas
            _connectionString = "Server=DESKTOP-S4PFS0S\\VSGESTION; Database=RHDB; Integrated Security=true";
            
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
