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
    public class datPaciente
    {
        #region Singleton
        private static readonly datPaciente _instancia = new datPaciente();
        public static datPaciente Instancia
        {
            get { return datPaciente._instancia; }
        }
        #endregion Singleton

        public Boolean InsertarPaciente(entPaciente obj)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_InsertarPaciente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdUsuario", obj.idUsuario);
                cmd.Parameters.AddWithValue("@prmNombre", obj.nombre);
                cmd.Parameters.AddWithValue("@prmApellidoPaterno", obj.apellidoPaterno);
                cmd.Parameters.AddWithValue("@prmApellidoMaterno", obj.apellidoMaterno);
                cmd.Parameters.AddWithValue("@prmDNI", obj.dni);
                cmd.Parameters.AddWithValue("@prmDireccion", obj.direccion);
                cmd.Parameters.AddWithValue("@prmEmail", obj.email);
                cmd.Parameters.AddWithValue("@prmTelefono", obj.telefono);
                cmd.Parameters.AddWithValue("@prmFechaNacimiento", obj.fechaNacimiento);
                cmd.Parameters.AddWithValue("@prmEdad", obj.edad);
                cmd.Parameters.AddWithValue("@prmLugarNacimiento", obj.lugarNacimiento);
                cmd.Parameters.AddWithValue("@prmRuc", obj.ruc);

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

        public List<entPaciente> ListarPacientes()
        {
            List<entPaciente> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarPacientes", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entPaciente>();
                while (dr.Read())
                {
                    entPaciente obj = new entPaciente();
                    obj.idPaciente = Convert.ToInt32(dr["idpaciente"]);
                    String val = dr["idusuario"].ToString();
                    if (dr["idusuario"].ToString() != "" || dr["idusuario"].ToString() != String.Empty)
                    {
                        obj.idUsuario = Convert.ToInt32(dr["idusuario"]);
                    }
                    obj.nombre = dr["nombre"].ToString();
                    obj.apellidoPaterno = dr["apellidopaterno"].ToString();
                    obj.apellidoMaterno = dr["apellidomaterno"].ToString();
                    obj.dni = dr["dni"].ToString();
                    obj.direccion = dr["direccion"].ToString();
                    obj.email = dr["email"].ToString();
                    obj.telefono = dr["telefono"].ToString();
                    obj.fechaNacimiento = Convert.ToDateTime(dr["fechanacimiento"]);
                    obj.edad = Convert.ToInt32(dr["edad"]);
                    obj.lugarNacimiento = dr["lugarnacimiento"].ToString();
                    obj.ruc = dr["ruc"].ToString();
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

        public List<entPaciente> BuscarPacienteByName(String term)
        {
            List<entPaciente> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_BuscarPacienteByName", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmName", term);
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entPaciente>();
                while (dr.Read())
                {
                    entPaciente obj = new entPaciente();
                    obj.idPaciente = Convert.ToInt32(dr["idpaciente"]);
                    obj.nombre = dr["nombre"].ToString() + " " + dr["apellidopaterno"].ToString() + " " + dr["apellidomaterno"].ToString();
                    obj.apellidoPaterno = dr["apellidopaterno"].ToString();
                    obj.apellidoMaterno = dr["apellidomaterno"].ToString();
                    
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

        public List<entUsuarioComun> ListarPacientesPorIdTipo(Int32 idTipo)
        {
            List<entUsuarioComun> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarPacientesPorIdTipo", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdTipo", idTipo);
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entUsuarioComun>();
                while (dr.Read())
                {
                    entUsuarioComun obj = new entUsuarioComun();
                    obj.idUsuarioComun = Convert.ToInt32(dr["idpaciente"]);
                    if (dr["idusuario"].ToString() != "" || dr["idusuario"].ToString() != String.Empty)
                    {
                        obj.idUsuario = Convert.ToInt32(dr["idusuario"]);
                    }
                    obj.nombre = dr["nombre"].ToString() + " " + dr["apellidopaterno"].ToString() + " " + dr["apellidomaterno"].ToString();
                    obj.apellidoPaterno = dr["apellidopaterno"].ToString();
                    obj.apellidoMaterno = dr["apellidomaterno"].ToString();
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
    }
}
