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
    public class PacienteController : Controller
    {
        //
        // GET: /Paciente/

        public ActionResult GestionarPaciente(String mensaje)
        {
            pacienteModel modeloPaciente = new pacienteModel();
            ViewData["ListaPacientes"] = negPaciente.Instancia.ListarPacientes();
            ViewBag.mensaje = mensaje;
            return View("GestionarPaciente", modeloPaciente);
        }

        [HttpPost]
        public ActionResult GestionarPaciente(pacienteModel modeloPaciente, FormCollection form)
        {
            entPaciente obj = new entPaciente();
            obj.nombre = modeloPaciente.nombre;
            obj.apellidoPaterno = modeloPaciente.apellidoPaterno;
            obj.apellidoMaterno = modeloPaciente.apellidoMaterno;
            obj.dni = modeloPaciente.dni;
            obj.direccion = modeloPaciente.direccion;
            obj.email = modeloPaciente.email;
            obj.telefono = modeloPaciente.telefono;
            obj.fechaNacimiento = Convert.ToDateTime(form["fechaNacimiento"]);
            obj.edad = Convert.ToInt32(form["edad"]);
            obj.lugarNacimiento = modeloPaciente.lugarNacimiento;
            obj.ruc = modeloPaciente.ruc;
            
            try
            {
                Boolean inserto = negUsuario.Instancia.InsertarUsuarioVacio(4);

                if (inserto)
                {
                    int idUsuario = negUsuario.Instancia.UltimoUsuarioRegistrado();
                    obj.idUsuario = idUsuario;
                    inserto = negPaciente.Instancia.InsertarPaciente(obj);
                    if (inserto)
                    {
                        return RedirectToAction("GestionarPaciente", "Paciente", new { mensaje = "Se registró correctamente." });
                    }
                    else
                    {
                        return RedirectToAction("GestionarPaciente", "Paciente", new { error = "No se pudo insertar." });
                    }

                }
                else
                {
                    return RedirectToAction("GestionarPaciente", "Paciente", new { error = "No se pudo insertar." });
                }
            }
            catch (ApplicationException ae)
            {
                return RedirectToAction("GestionarPaciente", "Paciente", new { error = ae.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { error = e.Message });
            }
        }
    }
}
