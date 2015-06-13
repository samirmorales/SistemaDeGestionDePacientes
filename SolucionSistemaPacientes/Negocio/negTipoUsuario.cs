using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class negTipoUsuario
    {
        #region Singleton
        private static readonly negTipoUsuario _instancia = new negTipoUsuario();
        public static negTipoUsuario Instancia
        {
            get { return negTipoUsuario._instancia; }
        }
        #endregion Singleton

        public List<entTipoUsuario> ListarTipoUsuario()
        {
            return datTipoUsuario.Instancia.ListarTipoUsuario();
        }
    }
}
