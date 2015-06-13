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
    public class datUsuario
    {
        #region Singleton
        private static readonly datUsuario _instancia = new datUsuario();
        public static datUsuario Instancia
        {
            get { return datUsuario._instancia; }
        }
        #endregion Singleton


        #region Metodos
        public entUsuario VerificarAcceso(String usuario, String password)
        {
            SqlCommand cmd = null;
            entUsuario obj = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spSEG_VerificarAcceso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsuario", usuario);
                cmd.Parameters.AddWithValue("@prmPassword", password);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = new entUsuario();
                    obj.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    obj.tipoUsuario = new entTipoUsuario(Convert.ToInt32(dr["idtipousuario"]));
                    obj.activo = Convert.ToBoolean(dr["Activo"]);

                }
                return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { 
                cmd.Connection.Close(); 
            }
        }

        public Boolean InsertarUsuarioVacio(int idTipoUsuario)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_InsertaUsuarioVacio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdTipoUsuario", idTipoUsuario);
                cn.Open();
                //  SqlDataReader dr = cmd.ExecuteReader();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    resultado = true;
                };
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return resultado;
        }

        public Boolean InsertarUsuario(entUsuario obj)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_InsertaUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdUsuario", obj.idUsuario);
                cmd.Parameters.AddWithValue("@prmUsuario", obj.usuario);
                cmd.Parameters.AddWithValue("@prmPassword", obj.password);
                cn.Open();
                //  SqlDataReader dr = cmd.ExecuteReader();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    resultado = true;
                };
            }
            catch (Exception e) { throw e; }
            finally { cmd.Connection.Close(); }
            return resultado;
        }

        public int UltimoUsuarioRegistrado()
        {
            int idMedico = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_UltimoUsuarioRegistrado", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                conex.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    idMedico = Convert.ToInt32(dr["idusuario"]);
                }
            }
            catch
            {
                idMedico = 0;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return idMedico;
        } 
        #endregion Metodos
    }
}
