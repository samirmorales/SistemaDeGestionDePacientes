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
    public class datCita
    {
        #region Singleton
        private static readonly datCita _instancia = new datCita();
        public static datCita Instancia
        {
            get { return datCita._instancia; }
        }
        #endregion Singleton

        public Boolean InsertarCita(entCita obj)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_InsertarCita", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMedico", obj.idMedico);
                cmd.Parameters.AddWithValue("@prmIdPaciente", obj.idPaciente);
                cmd.Parameters.AddWithValue("@prmDescripcion", obj.descripcion);
                cmd.Parameters.AddWithValue("@prmFecha", obj.fecha);
                cmd.Parameters.AddWithValue("@prmHoraInicio", obj.horaInicio);
                cmd.Parameters.AddWithValue("@prmHoraFin", obj.horaFin);
                cmd.Parameters.AddWithValue("@prmHoraInicioHora", obj.horaInicioHora);
                cmd.Parameters.AddWithValue("@prmHoraInicioMinuto", obj.horaInicioMinuto);
                cmd.Parameters.AddWithValue("@prmHoraFinHora", obj.horaFinHora);
                cmd.Parameters.AddWithValue("@prmHoraFinMinuto", obj.HoraFinMinuto);
                cmd.Parameters.AddWithValue("@prmMotivo", obj.motivo);
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

        public List<entCita> ListarCitasByIdMedico(int idMedico)
        {
            List<entCita> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarCitasByIdMedico", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMedico", idMedico);
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entCita>();
                while (dr.Read())
                {
                    entCita obj = new entCita();
                    obj.idCita = Convert.ToInt32(dr["idcita"]);
                    obj.especialidad = dr["especialidad"].ToString();
                    obj.idMedico = Convert.ToInt32(dr["idmedico"]);
                    obj.medico = dr["medico"].ToString();
                    obj.idPaciente = Convert.ToInt32(dr["idpaciente"]);
                    obj.paciente = dr["paciente"].ToString();
                    obj.descripcion = dr["descripcion"].ToString();
                    obj.motivo = dr["motivo"].ToString();
                    obj.fecha = Convert.ToDateTime(dr["fecha"]);
                    obj.horaInicio = TimeSpan.Parse(dr["horainicio"].ToString());
                    obj.horaFin = TimeSpan.Parse(dr["horafin"].ToString());
                    obj.horaInicioHora = Convert.ToInt32(dr["horainiciohora"]);
                    obj.horaInicioMinuto = Convert.ToInt32(dr["horainiciominuto"]);
                    obj.horaFinHora = Convert.ToInt32(dr["horafinhora"]);
                    obj.HoraFinMinuto = Convert.ToInt32(dr["horafinminuto"]);

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

        public Boolean ModificarCita(entCita obj)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_ModificarCita", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdCita", obj.idCita);
                cmd.Parameters.AddWithValue("@prmFecha", obj.fecha);
                cmd.Parameters.AddWithValue("@prmHoraInicio", obj.horaInicio);
                cmd.Parameters.AddWithValue("@prmHoraFin", obj.horaFin);
                cmd.Parameters.AddWithValue("@prmHoraInicioHora", obj.horaInicioHora);
                cmd.Parameters.AddWithValue("@prmHoraInicioMinuto", obj.horaInicioMinuto);
                cmd.Parameters.AddWithValue("@prmHoraFinHora", obj.horaFinHora);
                cmd.Parameters.AddWithValue("@prmHoraFinMinuto", obj.HoraFinMinuto);
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

        public Boolean EliminarCita(int idCita)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_EliminarCita", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdCita", idCita);
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

        public List<entCita> ListarCitaByMedicoAndFecha(int idMedico, DateTime fecha)
        {
            List<entCita> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarCitasByIdMedicoAndFecha", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMedico", idMedico);
                cmd.Parameters.AddWithValue("@prmFecha", fecha);
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entCita>();
                while (dr.Read())
                {
                    entCita obj = new entCita();
                    obj.idCita = Convert.ToInt32(dr["idcita"]);
                    obj.horaInicio = TimeSpan.Parse(dr["horainicio"].ToString());
                    obj.horaFin = TimeSpan.Parse(dr["horafin"].ToString());

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
