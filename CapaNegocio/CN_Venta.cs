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
  public class CN_Venta
  {
        private CD_Venta objcd_venta = new CD_Venta();

        
        public bool RestarStock(int idproducto, int cantidad)
        {
            return objcd_venta.RestarStock(idproducto, cantidad);
        }

        public bool SumarStock(int idproducto, int cantidad)
        {
            return objcd_venta.SumarStock(idproducto, cantidad);
        }

        public int obtenerCorrelativo()
        {
            return objcd_venta.obtenerCorrelativo();
        }

        public bool registrar(Venta obj, DataTable detalle_venta, out string mensaje)
        {
            return objcd_venta.Registrar(obj, detalle_venta, out mensaje);
        }

        public Venta obtenerVenta(string numero)
        {
            Venta objVenta = objcd_venta.obtenerVenta(numero);

            if(objVenta.IdVenta != 0)
            {
                List<Detalle_Venta> objDetalleVenta = objcd_venta.obtenerDetalleVenta(objVenta.IdVenta);
                objVenta.objDetalle_Venta = objDetalleVenta;
            }
            return objVenta;
        }
     
    }
}
