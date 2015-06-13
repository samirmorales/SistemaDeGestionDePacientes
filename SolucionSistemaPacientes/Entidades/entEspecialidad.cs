using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class entEspecialidad
    {
        public Int32 idEspecialidad { get; set; }
        public String especialidad { get; set; }

        public entEspecialidad(){}

        public entEspecialidad(Int32 idEspecialidad)
        {
            this.idEspecialidad = idEspecialidad;
        }
    }
}
