using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;

namespace Negocio
{
    public class negCita
    {
        #region Singleton
        private static readonly negCita _instancia = new negCita();
        public static negCita Instancia
        {
            get { return negCita._instancia; }
        }
        #endregion Singleton

        public int InsertarCita(entCita obj)
        {
            int idDia = 0;
            String dia = obj.fecha.ToString("ddd");
            if (dia.Equals("lu."))
            {
                idDia = 1;
            } 
            else if(dia.Equals("ma.")){
                idDia = 2;
            }
            else if (dia.Equals("mie"))
            {
                idDia = 3;
            }
            else if (dia.Equals("ju."))
            {
                idDia = 4;
            }
            else if (dia.Equals("vi."))
            {
                idDia = 5;
            } 

            List<entHora> listHora = datHora.Instancia.ListarHorarioByMedicoAndDia(obj.idMedico, idDia);

            List<entCita> listCita = datCita.Instancia.ListarCitaByMedicoAndFecha(obj.idMedico, obj.fecha);

            foreach (var e in listCita)
            {
                if ((obj.horaInicio >= e.horaInicio && obj.horaInicio <= e.horaFin) || (obj.horaFin >= e.horaInicio && obj.horaFin <= e.horaFin))
                {
                    return 3;
                }
            }

            if (listHora[0].hora <= obj.horaInicio && listHora[1].hora >= obj.horaFin) {
                Boolean ret = datCita.Instancia.InsertarCita(obj);
                if(ret){
                    return 1;
                }else{
                    return 0;
                }
            }
            else if (listHora[2].hora <= obj.horaInicio && listHora[3].hora >= obj.horaFin)
            {
                Boolean ret = datCita.Instancia.InsertarCita(obj);
                if(ret){
                    return 1;
                }else{
                    return 0;
                }
            }
            else {
                return 2;
            }

            
        }

        public List<entCita> ListarCitasByIdMedico(int idMedico)
        {
            return datCita.Instancia.ListarCitasByIdMedico(idMedico);
        }

        public Boolean ModificarCita(entCita obj)
        {
            return datCita.Instancia.ModificarCita(obj);
        }

        public Boolean EliminarCita(int idCita)
        {
            return datCita.Instancia.EliminarCita(idCita);
        }
    }
}
