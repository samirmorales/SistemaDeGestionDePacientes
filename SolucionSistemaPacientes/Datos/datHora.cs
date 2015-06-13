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
    public class datHora
    {
        #region Singleton
            private static readonly datHora _instancia = new datHora();
            public static datHora Instancia
            {
                get { return datHora._instancia; }
            }
        #endregion Singleton

        public Boolean InsertarHoraPorDia(int idHorario, entHora objHoraEM, entHora objHoraSM, entHora objHoraET, entHora objHoraST)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_InsertarHoraPorDia", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdHorario", idHorario);

                cmd.Parameters.AddWithValue("@prmHoraEM", objHoraEM.hora);
                cmd.Parameters.AddWithValue("@prmEstructuraHoraEM", objHoraEM.estructurahora);
                cmd.Parameters.AddWithValue("@prmEstructuraMinutoEM", objHoraEM.estructuraMinuto);

                cmd.Parameters.AddWithValue("@prmHoraSM", objHoraSM.hora);
                cmd.Parameters.AddWithValue("@prmEstructuraHoraSM", objHoraSM.estructurahora);
                cmd.Parameters.AddWithValue("@prmEstructuraMinutoSM", objHoraSM.estructuraMinuto);

                cmd.Parameters.AddWithValue("@prmHoraET", objHoraET.hora);
                cmd.Parameters.AddWithValue("@prmEstructuraHoraET", objHoraET.estructurahora);
                cmd.Parameters.AddWithValue("@prmEstructuraMinutoET", objHoraET.estructuraMinuto);

                cmd.Parameters.AddWithValue("@prmHoraST", objHoraST.hora);
                cmd.Parameters.AddWithValue("@prmEstructuraHoraST", objHoraST.estructurahora);
                cmd.Parameters.AddWithValue("@prmEstructuraMinutoST", objHoraST.estructuraMinuto);
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

        public List<entHora> ListarHorariosByMedico(int idMedico)
        {
            List<entHora> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarHorariosByMedico", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMedico", idMedico);
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entHora>();
                while (dr.Read())
                {
                    entHora obj = new entHora();
                    obj.idHora = Convert.ToInt32(dr["idhora"]);
                    obj.idTipoHorario = Convert.ToInt32(dr["idtipohorario"]);
                    obj.idHorario = Convert.ToInt32(dr["idhorario"]);
                    obj.idDia = Convert.ToInt32(dr["iddia"]);
                    obj.estructurahora = Convert.ToInt32(dr["estructurahora"]);
                    obj.estructuraMinuto = Convert.ToInt32(dr["estructuraminuto"]);
                    obj.hora = TimeSpan.Parse(dr["hora"].ToString());

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
