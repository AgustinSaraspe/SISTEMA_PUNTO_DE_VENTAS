using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Caja
   {
        public int IdCaja { get; set; }
        public int IdRegistro { get; set; }
        public string FechaRegistro { get; set; }
        public string Hora { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string Cliente { get; set; }
        public decimal Deuda { get; set; }
        public string FormaPago { get; set; }
        public decimal TotalFinal { get; set; }
        public decimal SaldoFavor { get; set; }
        public int EstadoCaja { get; set; }
    }
}
