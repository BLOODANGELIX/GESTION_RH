using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo.Models
{
    public class ModeloAsistencia
    {
        public int IdAsistencia {  get; set; }
        public DateTime Fecha { get; set; }
        public ModeloEmpleado RFC { get; set; }
    }
}
