using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {

        private CD_Cliente objcd_Cliente = new CD_Cliente();


        public List<Cliente> Listar() 
        {
            return objcd_Cliente.Listar(); 
        }

        public int Registrar(Cliente obj, out string Mensaje) 
        {
            Mensaje = string.Empty;

            if (obj.NombreCliente == "")
            {
                Mensaje += "Es necesario un nombre de Cliente\n";
            }

            if (obj.DocumentoCliente == "")
            {
                Mensaje += "Es necesario el documento del Cliente\n";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario el telefono del Cliente\n";
            }

            if (obj.Direccion == "")
            {
                Mensaje += "Es necesario la direccion del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Cliente.Registrar(obj, out Mensaje); 
            }

        }

        public bool Editar(Cliente obj, out string Mensaje) 
        {

            Mensaje = string.Empty;

            if (obj.NombreCliente == "")
            {
                Mensaje += "Es necesario un nombre de Cliente\n";
            }

            if (obj.DocumentoCliente == "")
            {
                Mensaje += "Es necesario el documento del Cliente\n";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario el telefono del Cliente\n";
            }

            if (obj.Direccion == "")
            {
                Mensaje += "Es necesario la direccion del Cliente\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Cliente.Editar(obj, out Mensaje); 
            }
        }

        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            return objcd_Cliente.Eliminar(obj, out Mensaje);
        }


        public bool editarDueda(int id, decimal Deuda,out string Mensaje)
        {

            return objcd_Cliente.editarDeuda(id, Deuda, out Mensaje);

        }

        public bool editarSaldoFavor(int id, decimal SaldoFavor, out string Mensaje)
        {
            return objcd_Cliente.editarSaldoFavor(id, SaldoFavor, out Mensaje);

        }

        public List<Cliente> ObtenerClienteId(int id)
        {
            return objcd_Cliente.ObtenerClienteId(id);

        }

    }
}
