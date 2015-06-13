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
    public class datEspecialidad
    {
        #region Singleton
        private static readonly datEspecialidad _instancia = new datEspecialidad();
        public static datEspecialidad Instancia
        {
            get { return datEspecialidad._instancia; }
        }
        #endregion Singleton

        #region Metodos
        public List<entEspecialidad> ListarEspecialidades()
        {
            List<entEspecialidad> lista = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_ListarEspecialidades", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                conex.Open();
                dr = cmd.ExecuteReader();
                lista = new List<entEspecialidad>();
                while (dr.Read())
                {
                    entEspecialidad obj = new entEspecialidad();
                    obj.idEspecialidad = Convert.ToInt32(dr["idespecialidad"]);
                    obj.especialidad = dr["especialidad"].ToString();
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

        public entEspecialidad BuscarEspecialidadPorID(int idEspecialidad)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            entEspecialidad obj = null;
            try
            {
                Conexion cn = new Conexion();
                SqlConnection conex = cn.Conectar();
                cmd = new SqlCommand("sp_BuscarEspecialidadPorId", conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdEspecialidad", idEspecialidad);
                conex.Open();
                dr = cmd.ExecuteReader();
                obj = new entEspecialidad();
                while (dr.Read())
                {
                    obj.idEspecialidad = Convert.ToInt32(dr["idespecialidad"]);
                    obj.especialidad = dr["especialidad"].ToString();
                }

                return obj;
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
        #endregion Metodos
    }
}
