using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class negCita
    {
        #region Singleton
        private static readonly negCita _instancia = new negCita();
        public static negCita Instancia
        {
            get { return negCita._instancia; }
        }
        #endregion Singleton

        public Boolean InsertarCita(entCita obj)
        {
            return datCita.Instancia.InsertarCita(obj);
        }

        public List<entCita> ListarCitasByIdMedico(int idMedico)
        {
            return datCita.Instancia.ListarCitasByIdMedico(idMedico);
        }
    }
}
