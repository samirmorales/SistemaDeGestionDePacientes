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
    public class datMedico
    {
        #region Singleton
        private static readonly datMedico _instancia = new datMedico();
        public static datMedico Instancia
        {
            get { return datMedico._instancia; }
        }
        #endregion Singleton

        #region Metodos
        public Boolean InsertarMedico(entMedico obj)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_InsertarMedico", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdEspecialidad", obj.idEspecialidad);
                cmd.Parameters.AddWithValue("@prmIdUsuario", obj.idUsuario);
                cmd.Parameters.AddWithValue("@prmNombre", obj.nombre);
                cmd.Parameters.AddWithValue("@prmApellidoPaterno", obj.apellidoPaterno);
                cmd.Parameters.AddWithValue("@prmApellidoMaterno", obj.apellidoMaterno);
                cmd.Parameters.AddWithValue("@prmDNI", obj.dni);
                cmd.Parameters.AddWithValue("@prmDireccion", obj.direccion);
                cmd.Parameters.AddWithValue("@prmEmail", obj.email);
                cmd.Parameters.AddWithValue("@prmTelefono", obj.telefono);
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

        public Boolean EditarMedico(entMedico obj)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_EditarMedico", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMedico", obj.idMedico);
                cmd.Parameters.AddWithValue("@prmIdEspecialidad", obj.idEspecialidad);
                cmd.Parameters.AddWithValue("@prmIdUsuario", obj.idUsuario);
                cmd.Parameters.AddWithValue("@prmNombre", obj.nombre);
                cmd.Parameters.AddWithValue("@prmApellidoPaterno", obj.apellidoPaterno);
                cmd.Parameters.AddWithValue("@prmApellidoMaterno", obj.apellidoMaterno);
                cmd.Parameters.AddWithValue("@prmDNI", obj.dni);
                cmd.Parameters.AddWithValue("@prmDireccion", obj.direccion);
                cmd.Parameters.AddWithValue("@prmEmail", obj.email);
                cmd.Parameters.AddWithValue("@prmTelefono", obj.telefono);
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

        public Boolean EliminarMedico(int idMedico)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_EliminarMedico", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMedico", idMedico);
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

        public List<entMedico> ListarMedicos()
        {
            List<entMedico> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarMedicos", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entMedico>();
                while (dr.Read())
                {
                    entMedico obj = new entMedico();
                    obj.idMedico = Convert.ToInt32(dr["idmedico"]);
                    String val = dr["idusuario"].ToString();
                    if (dr["idusuario"].ToString() != "" || dr["idusuario"].ToString() != String.Empty)
                    {
                        obj.idUsuario = Convert.ToInt32(dr["idusuario"]);
                    }
                    obj.idEspecialidad = Convert.ToInt32(dr["idespecialidad"]);
                    obj.especialidad = datEspecialidad.Instancia.BuscarEspecialidadPorID(Convert.ToInt32(dr["idespecialidad"])).especialidad;
                    obj.nombre = dr["nombre"].ToString();
                    obj.apellidoPaterno = dr["apellidopaterno"].ToString();
                    obj.apellidoMaterno = dr["apellidomaterno"].ToString();
                    obj.dni = dr["dni"].ToString();
                    obj.direccion = dr["direccion"].ToString();
                    obj.email = dr["email"].ToString();
                    obj.telefono = dr["telefono"].ToString();
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

        public entMedico BuscarMedicoByID(int idMedico)
        {
            entMedico obj = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_BuscarMedicoByID", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMedico", idMedico);
                conex.Open();
                dr = cmd.ExecuteReader();
                obj = new entMedico();
                while (dr.Read())
                {
                    obj.idMedico = Convert.ToInt32(dr["idmedico"]);
                    String val = dr["idusuario"].ToString();
                    if (dr["idusuario"].ToString() != "" || dr["idusuario"].ToString() != String.Empty)
                    {
                        obj.idUsuario = Convert.ToInt32(dr["idusuario"]);
                    }
                    obj.idEspecialidad = Convert.ToInt32(dr["idespecialidad"]);
                    obj.especialidad = datEspecialidad.Instancia.BuscarEspecialidadPorID(Convert.ToInt32(dr["idespecialidad"])).especialidad;
                    obj.nombre = dr["nombre"].ToString();
                    obj.apellidoPaterno = dr["apellidopaterno"].ToString();
                    obj.apellidoMaterno = dr["apellidomaterno"].ToString();
                    obj.dni = dr["dni"].ToString();
                    obj.direccion = dr["direccion"].ToString();
                    obj.email = dr["email"].ToString();
                    obj.telefono = dr["telefono"].ToString();
                }
            }
            catch
            {
                obj = null;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return obj;
        }

        public List<entMedico> ListarMedicosUsuario()
        {
            List<entMedico> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarMedicosUsuario", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entMedico>();
                while (dr.Read())
                {
                    entMedico obj = new entMedico();
                    obj.idMedico = Convert.ToInt32(dr["idmedico"]);
                    String val = dr["idusuario"].ToString();
                    if (dr["idusuario"].ToString() != "" || dr["idusuario"].ToString() != String.Empty)
                    {
                        obj.idUsuario = Convert.ToInt32(dr["idusuario"]);
                    }
                    obj.idEspecialidad = Convert.ToInt32(dr["idespecialidad"]);
                    obj.especialidad = datEspecialidad.Instancia.BuscarEspecialidadPorID(Convert.ToInt32(dr["idespecialidad"])).especialidad;
                    obj.nombre = dr["nombre"].ToString();
                    obj.apellidoPaterno = dr["apellidopaterno"].ToString();
                    obj.apellidoMaterno = dr["apellidomaterno"].ToString();
                    obj.dni = dr["dni"].ToString();
                    obj.direccion = dr["direccion"].ToString();
                    obj.usuario = dr["usuario"].ToString();
                    obj.password = dr["password"].ToString();
                    obj.activoUsuario = Convert.ToBoolean(dr["activo"]);
                    obj.direccion = dr["direccion"].ToString();
                    obj.email = dr["email"].ToString();
                    obj.telefono = dr["telefono"].ToString();
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

        public List<entUsuarioComun> ListarMedicosPorIdTipo(Int32 idTipo)
        {
            List<entUsuarioComun> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarMedicosPorIdTipo", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdTipo", idTipo);
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entUsuarioComun>();
                while (dr.Read())
                {
                    entUsuarioComun obj = new entUsuarioComun();
                    obj.idUsuarioComun = Convert.ToInt32(dr["idmedico"]);
                    if (dr["idusuario"].ToString() != "" || dr["idusuario"].ToString() != String.Empty)
                    {
                        obj.idUsuario = Convert.ToInt32(dr["idusuario"]);
                    }
                    obj.nombre = dr["nombre"].ToString() + " " +dr["apellidopaterno"].ToString() +" "+ dr["apellidomaterno"].ToString();
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

        public List<entMedico> ListarMedicosPorIdEspecialidad(Int32 idEspecialidad)
        {
            List<entMedico> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarMedicosPorIdEspecialidad", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdEspecialidad", idEspecialidad);
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entMedico>();
                while (dr.Read())
                {
                    entMedico obj = new entMedico();
                    obj.idMedico = Convert.ToInt32(dr["idmedico"]);
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

        public int UltimoMedicoRegistrado()
        {
            int idMedico=0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_UltimoMedicoRegistrado", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                conex.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    idMedico = Convert.ToInt32(dr["idmedico"]);
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
