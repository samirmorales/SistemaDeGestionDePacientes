using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class entUsuario
    {
        public Int32 idUsuario { get; set; }
        public entTipoUsuario tipoUsuario { get; set; }
        public String usuario { get; set; }
        public String password { get; set; }
        public Boolean activo { get; set; }

        public entUsuario() { }
        public entUsuario(Int32 idUsuario) 
        {
            this.idUsuario = idUsuario;
        }
    }
}
