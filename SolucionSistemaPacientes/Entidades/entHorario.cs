using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class entHorario
    {
        public Int32 idHorario { get; set; }
        public Int32 idMedico { get; set; }
        public Int32 idDia { get; set; }
        public String dia { get; set; }
        public Boolean registro { get; set; }

        public entHorario() { }
        public entHorario(Int32 idHorario)
        {
            this.idHorario = idHorario;
        }
    }
}
