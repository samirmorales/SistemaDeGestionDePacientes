using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Entidades;

namespace MvcApplication1.Models
{
    public class medicoModel
    {
        public Int32 idMedico { get; set; }
        public entUsuario usuario { get; set; }
        public entEspecialidad especialidad { get; set; }
        public String nombre { get; set; }
        public String apellidoPaterno { get; set; }
        public String apellidoMaterno { get; set; }
        public String dni { get; set; }
        public String telefono { get; set; }
        public String direccion { get; set; }
        public String email { get; set; }
        public Boolean activo { get; set; }

        public Int32 idEspecialidad { get; set; }
        public List<entEspecialidad> listaEspecialidades { get; set; }
    }
}