using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class datTipoUsuario
    {
        #region Singleton
        private static readonly datTipoUsuario _instancia = new datTipoUsuario();
        public static datTipoUsuario Instancia
        {
            get { return datTipoUsuario._instancia; }
        }
        #endregion Singleton
        
        #region Metodos
        public List<entTipoUsuario> ListarTipoUsuario()
        {
            List<entTipoUsuario> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarTipoUsuario", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entTipoUsuario>();
                while (dr.Read())
                {
                    entTipoUsuario obj = new entTipoUsuario();
                    obj.idTipoUsuario = Convert.ToInt32(dr["idtipousuario"]);
                    obj.tipo = dr["tipo"].ToString();
                    lista.Add(obj);
                }
            }
            catch
            {
                lista = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }
        #endregion Metodos
    }
}
