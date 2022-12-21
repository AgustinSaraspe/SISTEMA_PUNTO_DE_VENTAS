using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Cliente
   {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string DocumentoCliente { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public decimal SaldoFavor { get; set; }
        public decimal Deuda { get; set; }
        public string FechaRegistro { get; set; }
        public int EstadoCliente { get; set; }
    }
}
