using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class entAdministrador
    {
        public Int32 idAdministrador { get; set; }
        public entUsuario usuario { get; set; }
        public String nombre { get; set; }
        public String apellidoPaterno { get; set; }
        public String apellidoMaterno { get; set; }
        public String dni { get; set; }
        public String telefono { get; set; }
        public String direccion { get; set; }
        public String email { get; set; }
        public Boolean activo { get; set; }

        public entAdministrador() { }
        public entAdministrador(Int32 idAdministrador) 
        {
            this.idAdministrador = idAdministrador;
        }
    }
}
