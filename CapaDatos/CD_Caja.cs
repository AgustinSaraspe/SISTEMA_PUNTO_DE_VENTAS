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
   public class CD_Caja
    {
        public bool Registrar(Caja obj, out string mensaje)
        {
            bool respuesta = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection objconexcion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_GUARDARREGISTROS", objconexcion);
                    cmd.Parameters.AddWithValue("IdCaja", obj.IdCaja);
                    cmd.Parameters.AddWithValue("FechaRegistro", obj.FechaRegistro );
                    cmd.Parameters.AddWithValue("Hora", obj.Hora);
                    cmd.Parameters.AddWithValue("Tipo", obj.Tipo);
                    cmd.Parameters.AddWithValue("Descripcion",obj.Descripcion );
                    cmd.Parameters.AddWithValue("Cliente",obj.Cliente );
                    cmd.Parameters.AddWithValue("Deuda",obj.Deuda );
                    cmd.Parameters.AddWithValue("FormaPago",obj.FormaPago );
                    cmd.Parameters.AddWithValue("TotalFinal",obj.TotalFinal );
                    cmd.Parameters.AddWithValue("SaldoFavor",obj.SaldoFavor);
                    cmd.Parameters.AddWithValue("EstadoCaja",obj.EstadoCaja);
                 

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;


                    cmd.CommandType = CommandType.StoredProcedure;


                    objconexcion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }

            return respuesta;
        }


        public List<Caja> ObtenerCaja(string Fecha)
        {
            List<Caja> objCaja = new List<Caja>();

            using (SqlConnection objconexcion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    objconexcion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.IdRegistro, c.FechaRegistro, c.Hora, ");
                    query.AppendLine("c.Descripcion, c.Cliente, c.Deuda, c.FormaPago, ");
                    query.AppendLine("c.TotalFinal, c.SaldoFavor, c.EstadoCaja, ");
                    query.AppendLine("c.Tipo from CAJA c where c.FechaRegistro = @FechaRegistro  ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objconexcion);
                    cmd.Parameters.AddWithValue("@FechaRegistro", Fecha);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objCaja.Add(new Caja()
                            {
                                IdRegistro = Convert.ToInt32(dr["IdRegistro"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Hora = dr["Hora"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Cliente = dr["Cliente"].ToString(),
                                Deuda = Convert.ToDecimal(dr["Deuda"].ToString()),
                                FormaPago = dr["FormaPago"].ToString(),
                                TotalFinal = Convert.ToDecimal(dr["TotalFinal"].ToString()),
                                SaldoFavor = Convert.ToDecimal(dr["SaldoFavor"].ToString()),
                                EstadoCaja = Convert.ToInt32(dr["EstadoCaja"].ToString()),
                                Tipo = dr["Tipo"].ToString(),
                            });
                        }
                    }



                }
                catch (Exception ex)
                {
                    objCaja = new List<Caja>();
                  string  mensaje = ex.Message;
                }

            }
            return objCaja;
        }

        public List<Caja> ObtenerCajaId(int id)
        {
            List<Caja> objCaja = new List<Caja>();

            using (SqlConnection objconexcion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    objconexcion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.IdRegistro, c.FechaRegistro, c.Hora, ");
                    query.AppendLine("c.Descripcion, c.Cliente, c.Deuda, c.FormaPago, ");
                    query.AppendLine("c.TotalFinal, c.SaldoFavor, c.EstadoCaja, ");
                    query.AppendLine("c.Tipo, c.IdCaja from CAJA c where c.IdCaja = @IdCaja");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objconexcion);
                    cmd.Parameters.AddWithValue("@IdCaja", id);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objCaja.Add(new Caja()
                            {
                                IdRegistro = Convert.ToInt32(dr["IdRegistro"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Hora = dr["Hora"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Cliente = dr["Cliente"].ToString(),
                                Deuda = Convert.ToDecimal(dr["Deuda"].ToString()),
                                FormaPago = dr["FormaPago"].ToString(),
                                TotalFinal = Convert.ToDecimal(dr["TotalFinal"].ToString()),
                                SaldoFavor = Convert.ToDecimal(dr["SaldoFavor"].ToString()),
                                EstadoCaja = Convert.ToInt32(dr["EstadoCaja"].ToString()),
                                Tipo = dr["Tipo"].ToString(),
                                IdCaja = Convert.ToInt32(dr["IdCaja"].ToString())
                            });
                        }
                    }



                }
                catch (Exception ex)
                {
                    objCaja = new List<Caja>();
                    string mensaje = ex.Message;
                }

            }
            return objCaja;
        }



        public List<Caja> obtnerUltimaFila()
        {
           List<Caja>  objCaja = new List<Caja>();

            using (SqlConnection objconexcion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    objconexcion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select top(1)*from CAJA");
                    query.AppendLine("order by IdRegistro desc");
                 
                    SqlCommand cmd = new SqlCommand(query.ToString(), objconexcion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objCaja.Add(new Caja()
                            {
                                IdCaja = Convert.ToInt32(dr["IdCaja"].ToString()),
                                IdRegistro = Convert.ToInt32(dr["IdRegistro"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Hora = dr["Hora"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Cliente = dr["Cliente"].ToString(),
                                Deuda = Convert.ToDecimal(dr["Deuda"].ToString()),
                                FormaPago = dr["FormaPago"].ToString(),
                                TotalFinal = Convert.ToDecimal(dr["TotalFinal"].ToString()),
                                SaldoFavor = Convert.ToDecimal(dr["SaldoFavor"].ToString()),
                                EstadoCaja = Convert.ToInt32(dr["EstadoCaja"].ToString()),
                                Tipo = dr["Tipo"].ToString(),
                            });
                        }
                    }



                }
                catch (Exception ex)
                {
                    objCaja = new List<Caja>();
                    string mensaje = ex.Message;
                }

            }
            return objCaja;
        }


    }
}
