using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class entTipoUsuario
    {
        public Int32 idTipoUsuario { get; set; }
        public String tipo { get; set; }
        public String descripcion { get; set; }

        public entTipoUsuario() 
        { 
            
        }
        public entTipoUsuario(Int32 idTipoUsuario)
        {
            this.idTipoUsuario = idTipoUsuario;
        }
    }
}
