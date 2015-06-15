using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class entCita
    {
        public Int32 idCita { get; set; }
        public String especialidad { get; set; }
        public Int32 idMedico { get; set; }
        public String medico { get; set; }
        public Int32 idPaciente { get; set; }
        public String paciente { get; set; }
        public String descripcion { get; set; }
        public String diagnostico { get; set; }
        public String examenesAuxillares { get; set; }
        public DateTime fecha { get; set; }
        public String motivo { get; set; }
        public String tratamiento { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin { get; set; }

        public int horaInicioHora { get; set; }
        public int horaInicioMinuto { get; set; }
        public int horaFinHora { get; set; }
        public int HoraFinMinuto { get; set; }
    }
}
