using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class negEspecialidad
    {
        #region Singleton
        private static readonly negEspecialidad _instancia = new negEspecialidad();
        public static negEspecialidad Instancia
        {
            get { return negEspecialidad._instancia; }
        }
        #endregion Singleton

        public List<entEspecialidad> ListarEspecialidades()
        {
            return datEspecialidad.Instancia.ListarEspecialidades();
        } 
        public entEspecialidad BuscarEspecialidadPorID(int idEspecialidad)
        {
            return datEspecialidad.Instancia.BuscarEspecialidadPorID(idEspecialidad);
        } 
    }
}
