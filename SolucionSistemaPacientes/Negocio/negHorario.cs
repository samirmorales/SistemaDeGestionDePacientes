using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class negHorario
    {
        #region Singleton
            private static readonly negHorario _instancia = new negHorario();
            public static negHorario Instancia
            {
                get { return negHorario._instancia; }
            }
        #endregion Singleton

        public Boolean InsertarHorario(int idMedico)
        {
            return datHorario.Instancia.InsertarHorario(idMedico);
        }
        public List<entHorario> ListarDiasByRegistro(int idMedico)
        {
            return datHorario.Instancia.ListarDiasByRegistro(idMedico);
        }
    }
}
