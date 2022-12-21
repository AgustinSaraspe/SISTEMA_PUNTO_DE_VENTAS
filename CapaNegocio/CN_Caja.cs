using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
   public class CN_Caja
   {
        private CD_Caja objcd_Caja = new CD_Caja();

        public bool resgistrar(Caja obj, out string mensaje)
        {
            return objcd_Caja.Registrar(obj, out mensaje);
        }

        public List<Caja> ObtenerCaja(string Fecha)
        {
            return objcd_Caja.ObtenerCaja(Fecha);
        }

        public List<Caja> obtnerUltimaFila()
        {
            return objcd_Caja.obtnerUltimaFila();
        }
        public List<Caja> ObtenerCajaId(int id)
        {
            return objcd_Caja.ObtenerCajaId(id);
        }
    }
}
