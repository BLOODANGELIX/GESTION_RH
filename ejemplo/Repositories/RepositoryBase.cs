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
            //Lista de los servidores
            string[] servidores = new string[]
            {
                "LAPTOP-A6E4VDMG\\VSGESTION",
                "DESKTOP-S4PFS0S\\VSGESTION",
                "DESKTOP-85CNOQA\\VSGESTION",
                "NITRO-BRAYAN\\VSGESTION"
            };
            // Para poder hacer pruebas es necesario cambiar el nombre del servidor para cada integrante que vaya a realizar las pruebas
            //LAPTOP-A6E4VDMG\VSGESTION
            
            //Seleccion de servidor
            string servidorPedido = servidores[1];

            _connectionString = $"Server={servidorPedido}; Database=RHDB; Integrated Security=true";
            
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);

        }
    }
}
