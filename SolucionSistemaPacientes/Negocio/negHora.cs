using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class negHora
    {
        #region Singleton
        private static readonly negHora _instancia = new negHora();
        public static negHora Instancia
        {
            get { return negHora._instancia; }
        }
        #endregion Singleton

        public Boolean InsertarHoraPorDia(int idHorario, entHora objHoraEM, entHora objHoraSM, entHora objHoraET, entHora objHoraST)
        {
            return datHora.Instancia.InsertarHoraPorDia(idHorario, objHoraEM, objHoraSM, objHoraET, objHoraST);
        }

        public List<entHora> ListarHorariosByMedico(int idMedico)
        {
            return datHora.Instancia.ListarHorariosByMedico(idMedico);
        }
    }
}
