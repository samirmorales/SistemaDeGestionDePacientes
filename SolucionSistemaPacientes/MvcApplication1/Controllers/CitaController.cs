using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcApplication1.Models;
using Entidades;
using Negocio;

namespace MvcApplication1.Controllers
{
    public class CitaController : Controller
    {
        //
        // GET: /Cita/

        public ActionResult AgregarCita(String mensaje)
        {
            citaModel modelocita = new citaModel();
            modelocita.listaEspecialidades = negEspecialidad.Instancia.ListarEspecialidades();
            ViewBag.mensaje = mensaje;
            return View("AgregarCita", modelocita);
        }
        
        public ActionResult AutoCompletePaciente(string id)
        {
            List<entPaciente> result = negPaciente.Instancia.BuscarPacienteByName(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _PartialCalendario(Int32 idMedico)
        {
            ViewData["ListaCitas"] = negCita.Instancia.ListarCitasByIdMedico(idMedico);
            ViewBag.idmedico = idMedico;
            //String prueba = "";
            //ToString("%dd")ToString("%M")ToString("%yyyy")
            return PartialView();
        }

        public ActionResult _PartialCalendarioRegistro(Int32 idMedico, Int32 idPaciente, String descripcion, String motivo, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin)
        {
            entCita obj = new entCita();
            obj.idMedico = idMedico;
            obj.idPaciente = idPaciente;
            obj.descripcion = descripcion;
            obj.motivo = motivo;
            obj.fecha = fecha;

            obj.horaInicio = horaInicio;
            obj.horaInicioHora = Convert.ToInt32(obj.horaInicio.ToString("%h"));
            obj.horaInicioMinuto = Convert.ToInt32(obj.horaInicio.ToString("%m"));

            obj.horaFin = horaFin;
            obj.horaFinHora = Convert.ToInt32(obj.horaFin.ToString("%h"));
            obj.HoraFinMinuto = Convert.ToInt32(obj.horaFin.ToString("%m"));



            try
            {
                //Boolean inserto = negUsuario.Instancia.InsertarUsuarioVacio(4);
                Boolean inserto = negCita.Instancia.InsertarCita(obj);

                if (inserto)
                {
                    ViewData["ListaCitas"] = negCita.Instancia.ListarCitasByIdMedico(idMedico);
                    ViewBag.anio = obj.fecha.ToString("yyyy");
                    ViewBag.mes = obj.fecha.ToString("MM");
                    ViewBag.dia = obj.fecha.ToString("dd");
                    ViewBag.mensaje ="Se registró con éxito";

                    return PartialView();

                }
                else
                {
                    return RedirectToAction("AgregarCita", "Cita", new { error = "No se pudo insertar." });
                }
            }
            catch (ApplicationException ae)
            {
                return RedirectToAction("AgregarCita", "Cita", new { error = ae.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { error = e.Message });
            }
        }

        public ActionResult CitasMedico(String mensaje)
        {
            medicoModel modeloMedico = new medicoModel();
            modeloMedico.listaEspecialidades = negEspecialidad.Instancia.ListarEspecialidades();
            ViewBag.mensaje = mensaje;
            return View("CitasMedico", modeloMedico);
        }

        public ActionResult DetCitasMedico(FormCollection form, String mensaje, String error, int idMedico = 0)
        {
            if (idMedico == 0)
            {
                idMedico = Convert.ToInt32(form["medico"]);
            }

            ViewData["ListaCitas"] = negCita.Instancia.ListarCitasByIdMedico(idMedico);
            ViewBag.idmedico = idMedico;
            return View();
        }
    }
}
