using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class entHora
    {
        public Int32 idHora { get; set; }
        public Int32 idHorario { get; set; }
        public Int32 idTipoHorario { get; set; }
        public Int32 idDia { get; set; }
        public TimeSpan hora { get; set; }
        public int estructurahora { get; set; }
        public int estructuraMinuto { get; set; }
    }
}
