using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class negPaciente
    {
        #region Singleton
        private static readonly negPaciente _instancia = new negPaciente();
        public static negPaciente Instancia
        {
            get { return negPaciente._instancia; }
        }
        #endregion Singleton

        public Boolean InsertarPaciente(entPaciente obj)
        {
            return datPaciente.Instancia.InsertarPaciente(obj);
        }

        public List<entPaciente> ListarPacientes()
        {
            return datPaciente.Instancia.ListarPacientes();
        }
        public List<entPaciente> BuscarPacienteByName(String term)
        {
            return datPaciente.Instancia.BuscarPacienteByName(term);
        }

        public List<entUsuarioComun> ListarPacientesPorIdTipo(Int32 idTipo)
        {
            return datPaciente.Instancia.ListarPacientesPorIdTipo(idTipo);
        }
    }
}
