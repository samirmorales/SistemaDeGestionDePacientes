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
    public class MedicoController : Controller
    {
        //
        // GET: /Medico/


        public ActionResult GestionarMedico(String mensaje)
        {
            medicoModel modeloMedico = new medicoModel();
            modeloMedico.listaEspecialidades = negEspecialidad.Instancia.ListarEspecialidades();
            ViewData["ListaMedicos"] = negMedico.Instancia.ListarMedicos();
            ViewBag.mensaje = mensaje;
            return View("GestionarMedico", modeloMedico);
        }

        [HttpPost]
        public ActionResult GestionarMedico(medicoModel modeloMedico)
        {
            entMedico obj = new entMedico();
            obj.idEspecialidad = modeloMedico.idEspecialidad;
            obj.nombre = modeloMedico.nombre;
            obj.apellidoPaterno = modeloMedico.apellidoPaterno;
            obj.apellidoMaterno = modeloMedico.apellidoMaterno;
            obj.dni = modeloMedico.dni;
            obj.direccion = modeloMedico.direccion;
            obj.email = modeloMedico.email;
            obj.telefono = modeloMedico.telefono;

            try
            {
                Boolean inserto = negUsuario.Instancia.InsertarUsuarioVacio(2);
                
                if (inserto)
                {
                    int idUsuario = negUsuario.Instancia.UltimoUsuarioRegistrado();
                    obj.idUsuario = idUsuario;
                    inserto = negMedico.Instancia.InsertarMedico(obj);
                    int idMedico = negMedico.Instancia.UltimoMedicoRegistrado();
                    inserto = negHorario.Instancia.InsertarHorario(idMedico);
                    if (inserto)
                    {
                        return RedirectToAction("GestionarMedico", "Medico", new { mensaje = "Se registró correctamente." });
                    }
                    else
                    {
                        return RedirectToAction("GestionarMedico", "Medico", new { error = "No se pudo insertar." });
                    }
                    
                }
                else
                {
                    return RedirectToAction("GestionarMedico", "Medico", new { error = "No se pudo insertar." });
                }
            }
            catch (ApplicationException ae)
            {
                return RedirectToAction("GestionarMedico", "Medico", new { error = ae.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { error = e.Message });
            }
        }

        public ActionResult EliminarMedico(int idMedico)
        {
            try
            {
                Boolean eliminado = negMedico.Instancia.EliminarMedico(idMedico);
                if (eliminado)
                {
                    return RedirectToAction("GestionarMedico", "Medico", new { mensaje = "Se eliminó correctamente." });
                }
                else
                {
                    return RedirectToAction("GestionarMedico", "Medico", new { error = "No se pudo eliminar." });
                }
            }
            catch (ApplicationException ae)
            {
                return RedirectToAction("GestionarMedico", "Medico", new { error = ae.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { error = e.Message });
            }
        }

        public ActionResult EditarMedico(int idMedico)
        {
            medicoModel modeloMedico = new medicoModel();
            modeloMedico.listaEspecialidades = negEspecialidad.Instancia.ListarEspecialidades();
            ViewData["Medico"] = negMedico.Instancia.BuscarMedicoByID(idMedico);
            return View("EditarMedico", modeloMedico);
        }

        [HttpPost]
        public ActionResult EditarMedico(medicoModel modeloMedico)
        {
            entMedico obj = new entMedico();
            obj.idMedico = modeloMedico.idMedico;
            obj.idEspecialidad = modeloMedico.idEspecialidad;
            obj.nombre = modeloMedico.nombre;
            obj.apellidoPaterno = modeloMedico.apellidoPaterno;
            obj.apellidoMaterno = modeloMedico.apellidoMaterno;
            obj.dni = modeloMedico.dni;
            obj.direccion = modeloMedico.direccion;
            obj.email = modeloMedico.email;
            obj.telefono = modeloMedico.telefono;

            try
            {
                Boolean inserto = negMedico.Instancia.EditarMedico(obj);

                if (inserto)
                {
                    return RedirectToAction("GestionarMedico", "Medico", new { mensaje = "Los datos se modificaron correctamente." });
                }
                else
                {
                    return RedirectToAction("GestionarMedico", "Medico", new { error = "No se pudo modificar los datos." });
                }
            }
            catch (ApplicationException ae)
            {
                return RedirectToAction("GestionarMedico", "Medico", new { error = ae.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { error = e.Message });
            }
        }

        public ActionResult GestionarHorario(String mensaje)
        {
            medicoModel modeloMedico = new medicoModel();
            modeloMedico.listaEspecialidades = negEspecialidad.Instancia.ListarEspecialidades();
            ViewBag.mensaje = mensaje;
            return View("GestionarHorario", modeloMedico);
        }

        public ActionResult GetMedicoByEspecialidadId(Int32 especialidadid)
        {
            List<entMedico> objMedicos = new List<entMedico>();

            objMedicos = negMedico.Instancia.ListarMedicosPorIdEspecialidad(especialidadid);
            SelectList obgUsuarios = new SelectList(objMedicos, "idMedico", "nombre");

            return Json(obgUsuarios);
        }

        public ActionResult DetHorario(FormCollection form, String mensaje, String error, int idMedico=0)
        {
            if (idMedico == 0) {
                idMedico = Convert.ToInt32(form["medico"]);
            }
            
            ViewData["ListaDias"] = negHorario.Instancia.ListarDiasByRegistro(idMedico);
            ViewData["Horarios"] = negHora.Instancia.ListarHorariosByMedico(idMedico);
            ViewBag.mensaje = mensaje;
            ViewBag.error = error;
            ViewBag.idMedico = idMedico;
            return PartialView();
        }

        public ActionResult RegistrarHorario(FormCollection form, IEnumerable<int> dias)
        {
            Int32 idMedico = Convert.ToInt32(form["medico"]);
            if (dias != null)
            {
                foreach (var item in dias)
                {
                    int horaEstructura = 0;
                    int minutoEstructura = 0;
                    int idHorario = item;

                    TimeSpan hora = TimeSpan.Parse(form["horaEM"]);
                    horaEstructura = Convert.ToInt32(hora.ToString("%h"));
                    minutoEstructura = Convert.ToInt32(hora.ToString("%m"));
                    entHora objHoraEM = new entHora();
                    objHoraEM.hora = hora;
                    objHoraEM.estructurahora = horaEstructura;
                    objHoraEM.estructuraMinuto = minutoEstructura;

                    hora = TimeSpan.Parse(form["horaSM"]);
                    horaEstructura = Convert.ToInt32(hora.ToString("%h"));
                    minutoEstructura = Convert.ToInt32(hora.ToString("%m"));
                    entHora objHoraSM = new entHora();
                    objHoraSM.hora = hora;
                    objHoraSM.estructurahora = horaEstructura;
                    objHoraSM.estructuraMinuto = minutoEstructura;

                    hora = TimeSpan.Parse(form["horaET"]);
                    horaEstructura = Convert.ToInt32(hora.ToString("%h"));
                    minutoEstructura = Convert.ToInt32(hora.ToString("%m"));
                    entHora objHoraET = new entHora();
                    objHoraET.hora = hora;
                    objHoraET.estructurahora = horaEstructura;
                    objHoraET.estructuraMinuto = minutoEstructura;

                    hora = TimeSpan.Parse(form["horaST"]);
                    horaEstructura = Convert.ToInt32(hora.ToString("%h"));
                    minutoEstructura = Convert.ToInt32(hora.ToString("%m"));
                    entHora objHoraST = new entHora();
                    objHoraST.hora = hora;
                    objHoraST.estructurahora = horaEstructura;
                    objHoraST.estructuraMinuto = minutoEstructura;

                    Boolean inserto = negHora.Instancia.InsertarHoraPorDia(idHorario, objHoraEM, objHoraSM, objHoraET, objHoraST);

                    if (inserto)
                    {
                    }
                    else
                    {
                        return RedirectToAction("DetHorario", "Medico", new { error = "No se pudo insertar.", idMedico });
                    }
                }
            }
            else {
                return RedirectToAction("DetHorario", "Medico", new { error = "No selecciono días.", idMedico });
            }

            return RedirectToAction("DetHorario", "Medico", new { mensaje = "Se registró correctamente.", idMedico});
        }
    }
}
