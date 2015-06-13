using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using Entidades;

namespace Datos
{
    public class datAdministrador
    {
        #region Singleton
        private static readonly datAdministrador _instancia = new datAdministrador();
        public static datAdministrador Instancia
        {
            get { return datAdministrador._instancia; }
        }
        #endregion Singleton


        #region Metodos
        public entAdministrador BuscarAdministradorPorIdUsuario(int idUsuario)
        {
            SqlCommand cmd = null;
            entAdministrador obj = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_BuscarAdministradorPorIdUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdUsuario", idUsuario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = new entAdministrador();
                    obj.idAdministrador = Convert.ToInt32(dr["idadministrador"]);
                    obj.nombre = dr["nombre"].ToString();
                    obj.apellidoPaterno = dr["apellidopaterno"].ToString();
                    obj.apellidoMaterno = dr["apellidomaterno"].ToString();
                    obj.dni = dr["dni"].ToString();
                    obj.telefono = dr["telefono"].ToString();
                    obj.direccion = dr["direccion"].ToString();
                    obj.email = dr["email"].ToString();
                    obj.activo = Convert.ToBoolean(dr["Activo"]);

                }
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }


        #endregion Metodos
    }
}
