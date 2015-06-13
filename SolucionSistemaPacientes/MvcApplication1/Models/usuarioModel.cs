using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Entidades;

namespace MvcApplication1.Models
{
    public class usuarioModel
    {
        public Int32 idUsuario { get; set; }
        public entTipoUsuario tipoUsuario { get; set; }
        public String usuario { get; set; }
        public String password { get; set; }
        public Boolean activo { get; set; }
        public List<entTipoUsuario> listaTipoUsuario { get; set; }
        public List<entUsuarioComun> listaUsuarios { get; set; }
        public Int32 idTipoUsuario { get; set; }
        public Int32 idUsuarioComun { get; set; }
    }
    public class tiposUsuario
    {
        public Int32 idTipoUsuario { get; set; }
        public String nombreTipoUsuario { get; set; }
    }
    public class usuarios
    {
        public Int32 idUsuario { get; set; }
        public Int32 idUsuarioComun { get; set; }
        public String nombre { get; set; }
        public String apellidoPaterno { get; set; }
        public String apellidoMaterno { get; set; }
    }
}