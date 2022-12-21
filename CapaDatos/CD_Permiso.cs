using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;


namespace CapaDatos
{
   public class CD_Permiso
    {
        public List<Permiso> Listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>(); 

            using (SqlConnection objconexion = new SqlConnection(Conexion.cadena)) 
            {
                try
                {
                    StringBuilder query = new StringBuilder(); 
                    query.AppendLine("select p.IdRol, p.NombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.IdRol = p.IdRol");
                    query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");
                    query.AppendLine("where u.IdUsuario = @idUsuario");


                    SqlCommand cmd = new SqlCommand(query.ToString(), objconexion);

                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    cmd.CommandType = CommandType.Text; 

                    objconexion.Open(); 

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    { 

                        while (dr.Read())
                        {
                            lista.Add(new Permiso() 
                            {
                                objRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"])},
                                NombreMenu = dr["NombreMenu"].ToString()
                                
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }
    }
}
