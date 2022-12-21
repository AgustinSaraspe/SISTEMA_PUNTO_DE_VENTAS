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
    public class CD_Reporte
    {
        public List<ReporteVenta> Venta(string fechaInicio, string fechaFin)
        {
            List<ReporteVenta> lista = new List<ReporteVenta>();

            using (SqlConnection objConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("SP_REPORTEVENTAS", objConexion);
                    cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                    cmd.CommandType = CommandType.StoredProcedure;

                    objConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVenta()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                MontoTotal = dr["MontoTotal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Categoria = dr["Categoria"].ToString(),
                                PrecioVenta = dr["PrecioVenta"].ToString(),
                                Cantidad = dr["Cantidad"].ToString(),
                                SubTotal = dr["SubTotal"].ToString(),
                                FormaPago = dr["FormaPago"].ToString(),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReporteVenta>();
                }
            }
            return lista;
        }



        public List<Caja> Caja(string fechaInicio, string fechaFin)
        {
            List<Caja> lista = new List<Caja>();

            using (SqlConnection objConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.FechaRegistro, c.Hora, c.Tipo, c.Descripcion, c.Cliente, c.Deuda, c.FormaPago,");
                    query.AppendLine(" c.TotalFinal, c.SaldoFavor, c.EstadoCaja from caja c ");
                    query.AppendLine("where CONVERT(date,c.FechaRegistro) between @fechaInicio and @fechaFin");

                    SqlCommand cmd = new SqlCommand(query.ToString(), objConexion);
                    cmd.Parameters.AddWithValue("fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("fechaFin", fechaFin);
                    cmd.CommandType = CommandType.Text;

                    objConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Caja()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                Hora = dr["Hora"].ToString(),
                                Tipo = dr["Tipo"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Cliente = dr["Cliente"].ToString(),
                                Deuda = Convert.ToDecimal(dr["Deuda"].ToString()),
                                FormaPago = dr["FormaPago"].ToString(),
                                TotalFinal = Convert.ToDecimal(dr["TotalFinal"].ToString()),
                                SaldoFavor = Convert.ToDecimal(dr["SaldoFavor"].ToString()),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    lista = new List<Caja>();
                   string mensaje = ex.Message;
                }
            }
            return lista;

        }







       
    }
}
