using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo.Models
{
    public class ModeloEmpleado
    {
        public int RFC {  get; set; }
        public string Nombre { get; set; } 
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public ModeloDepartamento Departamento { get; set;}
        public ModeloPuesto Puesto {get; set;}

    }
}
