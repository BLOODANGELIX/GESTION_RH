using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo.Models
{
    public class ModeloPuesto
    {
        public int IdPuesto { get; set; }
        public string Nombre { get; set; }
    
        public decimal Salario { get; set; }

        public int VacantesDisponibles;

        /*
          * El tipo de dato decimal es un tipo de dato 
          * especial para manejar calculos 
          * ya que suele tener mayor precisión que otros
          * tipos de punto flotante como double 
          * también se caracteriza por utilizar base 10 
          * para la parte decimal a diferencia de un double que
          * usa base dos lo que suele dar problemas de
          * redondeo
          * comentario escrito por Juan D.
        */

    }
}
