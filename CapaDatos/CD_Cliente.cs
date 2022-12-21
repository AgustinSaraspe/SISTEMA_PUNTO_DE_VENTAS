using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Cliente
    {


        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdCliente, DocumentoCliente, NombreCliente, Telefono, Correo, Direccion, EstadoCliente, Deuda, SaldoFavor, FechaRegistro  from CLIENTE");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objconexion);

                    cmd.CommandType = CommandType.Text;

                    objconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            lista.Add(new Cliente() 
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                EstadoCliente = Convert.ToInt32(dr["EstadoCliente"].ToString()),
                                Deuda = Convert.ToDecimal(dr["Deuda"].ToString()),
                                SaldoFavor = Convert.ToDecimal(dr["SaldoFavor"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();
                    string mensaje = ex.Message;
                }
            }
            return lista;
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            int idClienteGenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("SP_REGISTRARCLIENTE", objconexion);
                    cmd.Parameters.AddWithValue("DocumentoCliente", obj.DocumentoCliente);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("EstadoCliente", obj.EstadoCliente);
                    cmd.Parameters.AddWithValue("Deuda", obj.Deuda);
                    cmd.Parameters.AddWithValue("SaldoFavor", obj.SaldoFavor);
                    cmd.Parameters.AddWithValue("FechaRegistro", obj.FechaRegistro);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    cmd.ExecuteNonQuery();

                    idClienteGenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idClienteGenerado = 0;
                Mensaje = ex.Message;
            }

            return idClienteGenerado;

        }


        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {


                    SqlCommand cmd = new SqlCommand("SP_MODIFICARCLIENTE", objconexion);
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("DocumentoCliente", obj.DocumentoCliente);
                    cmd.Parameters.AddWithValue("NombreCliente", obj.NombreCliente);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Direccion", obj.Direccion);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("EstadoCliente", obj.EstadoCliente);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    objconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;

        }




        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("delete from cliente where IdCliente = @IdCliente", objconexion);
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    cmd.CommandType = CommandType.Text;

                    objconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;

        }

        public bool editarDeuda(int id, decimal Deuda ,out string Mensaje)
        {

            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("update CLIENTE set Deuda = @Deuda where IdCliente = @IdCliente ", objconexion);
                    cmd.Parameters.AddWithValue("IdCliente", id);
                    cmd.Parameters.AddWithValue("Deuda", Deuda);
                    cmd.CommandType = CommandType.Text;

                    objconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }








        public bool editarSaldoFavor(int id, decimal SaldoFavor, out string Mensaje)
        {

            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("update CLIENTE set SaldoFavor = @SaldoFavor where IdCliente = @IdCliente", objconexion);
                    cmd.Parameters.AddWithValue("IdCliente", id);
                    cmd.Parameters.AddWithValue("SaldoFavor", SaldoFavor);
                    cmd.CommandType = CommandType.Text;

                    objconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }

        public List<Cliente> ObtenerClienteId(int id)
        {
            List<Cliente> objCliente = new List<Cliente>();

            using (SqlConnection objconexcion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                   
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdCliente, DocumentoCliente, NombreCliente, Telefono, Deuda, SaldoFavor, EstadoCliente from CLIENTE");
                    query.AppendLine("where IdCliente = @IdCliente");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objconexcion);
                    cmd.Parameters.AddWithValue("@IdCliente", id);
                    cmd.CommandType = CommandType.Text;
                    objconexcion.Open();


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objCliente.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"].ToString()),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),     
                                Telefono = dr["Telefono"].ToString(),
                                Deuda = Convert.ToDecimal(dr["Deuda"].ToString()),                             
                                SaldoFavor = Convert.ToDecimal(dr["SaldoFavor"].ToString()),
                                EstadoCliente = Convert.ToInt32(dr["EstadoCliente"].ToString()),
                              
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    objCliente = new List<Cliente>();
                    string mensaje = ex.Message;
                }

            }
            return objCliente;
        }

    }
}
