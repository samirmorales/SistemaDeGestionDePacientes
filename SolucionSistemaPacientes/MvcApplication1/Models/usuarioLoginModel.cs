using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Entidades;

namespace MvcApplication1.Models
{
    public class usuarioLoginModel
    {
        public Int32 idUsuario { get; set; }
        public String usuario { get; set; }
        public String password { get; set; }
        public Boolean activo { get; set; }
        public List<entTipoUsuario> listaTipoUsuario { get; set; }
        public List<entAdministrador> listaAdministradores { get; set; }
        //public List<entSecretaria> listaSecretarias { get; set; }
        public List<entMedico> listaMedicos { get; set; }
        //public List<entPacientes> listaPacientes { get; set; }
        public Int32 idTipoUsuario { get; set; }
        public Int32 idUsuarioComun { get; set; }
    }
}