using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class negAdministrador
    {
        #region Singleton
        private static readonly negAdministrador _instancia = new negAdministrador();
        public static negAdministrador Instancia
        {
            get { return negAdministrador._instancia; }
        }
        #endregion Singleton

        public entAdministrador BuscarAdministradorPorIdUsuario(int idUsuario)
        {
            return datAdministrador.Instancia.BuscarAdministradorPorIdUsuario(idUsuario);
        }
    }
}
