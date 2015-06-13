using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class entMedico
    {
        public Int32 idMedico { get; set; }

        public static entUsuario usuarioEnt { get; set; }
        public String usuario { get; set; }
        public String password { get; set; }
        public Boolean activoUsuario { get; set; }

        public Int32 idUsuario { get; set; }

        public entEspecialidad especialidades { get; set; }
        public Int32 idEspecialidad { get; set; }
        public String especialidad { get; set; }

        public String nombre { get; set; }
        public String apellidoPaterno { get; set; }
        public String apellidoMaterno { get; set; }
        public String dni { get; set; }
        public String telefono { get; set; }
        public String direccion { get; set; }
        public String email { get; set; }
        public Boolean activo { get; set; }

        public entMedico() { }
        public entMedico(Int32 idMedico) 
        {
            this.idMedico = idMedico;
        }
    }
}
