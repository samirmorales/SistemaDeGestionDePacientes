using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class entUsuarioComun
    {
        public Int32 idUsuarioComun { get; set; }
        public Int32 idUsuario { get; set; }
        public String nombre { get; set; }
        public String apellidoPaterno { get; set; }
        public String apellidoMaterno { get; set; }
    }
}
