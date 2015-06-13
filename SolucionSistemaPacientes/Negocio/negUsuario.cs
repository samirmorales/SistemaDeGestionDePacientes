using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class negUsuario
    {

        #region Singleton
        private static readonly negUsuario _instancia = new negUsuario();
        public static negUsuario Instancia
        {
            get { return negUsuario._instancia; }
        }
        #endregion Singleton

        public Boolean InsertarUsuarioVacio(int idTipoUsuario)
        {
            return datUsuario.Instancia.InsertarUsuarioVacio(idTipoUsuario);
        }

        public Boolean InsertarUsuario(entUsuario obj)
        {
            return datUsuario.Instancia.InsertarUsuario(obj);
        }

        public int UltimoUsuarioRegistrado()
        {
            return datUsuario.Instancia.UltimoUsuarioRegistrado();
        }

        public entUsuario VerificarAcceso(String usuario, String password)
        {
            try
            {
                if (usuario.Equals("") || usuario == String.Empty)
                {
                    throw new ApplicationException("Debe ingresar su nombre de usuario");
                }
                if (password.Equals("") || password == String.Empty)
                {
                    throw new ApplicationException("Debe ingresar su password");
                }
                entUsuario objUsuario = datUsuario.Instancia.VerificarAcceso(usuario, password);
                if (objUsuario != null)
                {
                    if (!objUsuario.activo)
                    {
                        throw new ApplicationException("El Administrador fue dado de baja");
                    }
                }
                else
                {
                    throw new ApplicationException("Usuario o Password no valido...");
                }
                return objUsuario;

            }
            catch (ApplicationException z)
            {
                throw z;
            }
            catch (Exception e) { throw e; }
        }

    }
}
