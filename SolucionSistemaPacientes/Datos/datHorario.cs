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
    public class datHorario
    {
        #region Singleton
            private static readonly datHorario _instancia = new datHorario();
            public static datHorario Instancia
            {
                get { return datHorario._instancia; }
            }
        #endregion Singleton

        public Boolean InsertarHorario(int idMedico)
        {
            SqlCommand cmd = null;
            Boolean resultado = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("sp_InsertarHorario", cn);
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

        public List<entHorario> ListarDiasByRegistro(int idMedico)
        {
            List<entHorario> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarDiasByRegistro", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdMedico", idMedico);
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entHorario>();
                while (dr.Read())
                {
                    entHorario obj = new entHorario();
                    obj.idHorario = Convert.ToInt32(dr["idhorario"]);
                    obj.idMedico = Convert.ToInt32(dr["idmedico"].ToString());
                    obj.idDia = Convert.ToInt32(dr["iddia"].ToString());
                    obj.dia = dr["dia"].ToString();
                    obj.registro = Convert.ToBoolean(dr["registro"]);
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
