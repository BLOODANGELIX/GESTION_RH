using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo.Models
{
    public class ModeloDepartamento
    {
        public int IdDepartamento { get; set; }
        public string Nombre {  get; set; }
        public ModeloEmpleado JefeDepartamento { get; set; }
    }
}
