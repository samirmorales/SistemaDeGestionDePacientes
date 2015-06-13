using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class negMedico
    {
        #region Singleton
        private static readonly negMedico _instancia = new negMedico();
        public static negMedico Instancia
        {
            get { return negMedico._instancia; }
        }
        #endregion Singleton

        #region Metodos
        public Boolean InsertarMedico(entMedico obj)
        {
            return datMedico.Instancia.InsertarMedico(obj);
        }

        public Boolean EliminarMedico(int idMedico)
        {
            return datMedico.Instancia.EliminarMedico(idMedico);
        }

        public List<entMedico> ListarMedicosPorIdEspecialidad(Int32 idEspecialidad)
        {
            return datMedico.Instancia.ListarMedicosPorIdEspecialidad(idEspecialidad);
        }

        public List<entUsuarioComun> ListarMedicosPorIdTipo(Int32 idTipo)
        {
            return datMedico.Instancia.ListarMedicosPorIdTipo(idTipo);
        }

        public List<entMedico> ListarMedicosUsuario()
        {
            return datMedico.Instancia.ListarMedicosUsuario();
        }

        public int UltimoMedicoRegistrado()
        {
            return datMedico.Instancia.UltimoMedicoRegistrado();
        }

        public List<entMedico> ListarMedicos() 
        {
            return datMedico.Instancia.ListarMedicos();
        }

        public Boolean EditarMedico(entMedico obj)
        {
            return datMedico.Instancia.EditarMedico(obj);
        }

        public entMedico BuscarMedicoByID(int idMedico)
        {
            return datMedico.Instancia.BuscarMedicoByID(idMedico);
        }
        #endregion Metodos
    }
}
