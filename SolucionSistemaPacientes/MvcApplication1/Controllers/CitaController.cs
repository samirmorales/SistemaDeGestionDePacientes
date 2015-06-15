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
                int inserto = negCita.Instancia.InsertarCita(obj);

                ViewData["ListaCitas"] = negCita.Instancia.ListarCitasByIdMedico(idMedico);
                ViewBag.anio = obj.fecha.ToString("yyyy");
                ViewBag.mes = obj.fecha.ToString("MM");
                ViewBag.dia = obj.fecha.ToString("dd");

                if (inserto==1)
                {
                    
                    ViewBag.mensaje ="Se registró con éxito";

                    return PartialView();

                }
                else if (inserto == 2)
                {
                    ViewBag.mensajeHora = "Cita fuera de horario de trabajo.";

                    return PartialView();
                }
                else if (inserto == 3)
                {
                    ViewBag.mensajeHora = "Cruze de citas.";

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

        public ActionResult ModificarEliminarCitas(FormCollection form)
        {
            if (form["btn"].ToString().Equals("modificar"))
            {
                int idMedico = Convert.ToInt32(form["idMedico"]);
                entCita obj = new entCita();
                obj.idCita = Convert.ToInt32(form["idCita"]);
                obj.fecha = Convert.ToDateTime(form["fecha"]);

                obj.horaInicio = TimeSpan.Parse(form["horaInicio"].ToString());
                obj.horaInicioHora = Convert.ToInt32(obj.horaInicio.ToString("%h"));
                obj.horaInicioMinuto = Convert.ToInt32(obj.horaInicio.ToString("%m"));

                obj.horaFin = TimeSpan.Parse(form["horaFin"].ToString());
                obj.horaFinHora = Convert.ToInt32(obj.horaFin.ToString("%h"));
                obj.HoraFinMinuto = Convert.ToInt32(obj.horaFin.ToString("%m"));

                try
                {
                    //Boolean inserto = negUsuario.Instancia.InsertarUsuarioVacio(4);
                    Boolean inserto = negCita.Instancia.ModificarCita(obj);

                    if (inserto)
                    {
                        return RedirectToAction("DetCitasMedico", "Cita", new { mensaje = "Se modificó con éxito", idMedico = idMedico });

                    }
                    else
                    {
                        return RedirectToAction("DetCitasMedico", "Cita", new { error = "No se pudo modificar.", idMedico = idMedico });
                    }
                }
                catch (ApplicationException ae)
                {
                    return RedirectToAction("DetCitasMedico", "Cita", new { error = ae.Message });
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", "Error", new { error = e.Message });
                }
            }
            else if (form["btn"].ToString().Equals("eliminar"))
            {
                int idCita = Convert.ToInt32(form["idCita"]);
                int idMedico = Convert.ToInt32(form["idMedico"]);

                try
                {
                    //Boolean inserto = negUsuario.Instancia.InsertarUsuarioVacio(4);
                    Boolean inserto = negCita.Instancia.EliminarCita(idCita);

                    if (inserto)
                    {
                        return RedirectToAction("DetCitasMedico", "Cita", new { mensaje = "Se eliminó con éxito", idMedico =  idMedico  });

                    }
                    else
                    {
                        return RedirectToAction("DetCitasMedico", "Cita", new { error = "No se pudo eliminar.", idMedico = idMedico });
                    }
                }
                catch (ApplicationException ae)
                {
                    return RedirectToAction("DetCitasMedico", "Cita", new { error = ae.Message });
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", "Error", new { error = e.Message });
                }
            }
            else {
                return RedirectToAction("DetCitasMedico", "Cita");
            }
        }

        public ActionResult _PartialHorario(FormCollection form, String mensaje, String error, int idMedico = 0)
        {
            if (idMedico == 0)
            {
                idMedico = idMedico;
            }

            ViewData["ListaDias"] = negHorario.Instancia.ListarDiasByRegistro(idMedico);
            ViewData["Horarios"] = negHora.Instancia.ListarHorariosByMedico(idMedico);
            ViewBag.mensaje = mensaje;
            ViewBag.error = error;
            ViewBag.idMedico = idMedico;
            return PartialView();
        }
    }
}
