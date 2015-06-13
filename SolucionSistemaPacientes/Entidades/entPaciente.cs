using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class entPaciente
    {
        public Int32 idPaciente { get; set; }

        public Int32 idUsuario { get; set; }
        public String usuario { get; set; }
        public String password { get; set; }
        public Boolean activoUsuario { get; set; }

        public String nombre { get; set; }
        public String apellidoPaterno { get; set; }
        public String apellidoMaterno { get; set; }
        public String dni { get; set; }
        public String telefono { get; set; }
        public String direccion { get; set; }
        public String email { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int edad { get; set; }
        public String lugarNacimiento { get; set; }
        public String ruc { get; set; }
        public Boolean activo { get; set; } 
    }
}
