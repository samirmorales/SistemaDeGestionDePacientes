using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidades;
using MvcApplication1.Models;
using Negocio;

namespace MvcApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult AgregarUsuario(String mensaje)
        {
            usuarioModel modeloUsuario = new usuarioModel();
            
            modeloUsuario.listaTipoUsuario = negTipoUsuario.Instancia.ListarTipoUsuario();

            modeloUsuario.listaUsuarios = new List<entUsuarioComun>();
            
            ViewBag.mensaje = mensaje;
            return View("AgregarUsuario", modeloUsuario);
        }

        [HttpPost]
        public ActionResult AgregarUsuario(usuarioModel modeloUsuario, FormCollection form)
        {

            entUsuario obj = new entUsuario();
            obj.usuario = modeloUsuario.usuario;
            obj.password = modeloUsuario.password;
            obj.idUsuario = Convert.ToInt32(form["nombre"]);
            try
            {
                Boolean inserto = negUsuario.Instancia.InsertarUsuario(obj);

                if (inserto)
                {
                    return RedirectToAction("AgregarUsuario", "Usuario", new { mensaje = "Se registró correctamente." });
                }
                else
                {
                    return RedirectToAction("AgregarUsuario", "Usuario", new { error = "No se pudo insertar." });
                }
            }
            catch (ApplicationException ae)
            {
                return RedirectToAction("AgregarUsuario", "Usuario", new { error = ae.Message });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { error = e.Message });
            }
        }

        public ActionResult GetUsuarioByTipoId(int tipoid)
        {
            usuarioModel modeloUsuario = new usuarioModel();
            if (tipoid == 1)
            {
                //modeloUsuario.listaUsuarios = negAdministrador.Instancia.ListarAdministradoresPorTipo();
            }
            else if (tipoid == 2)
            {
                List<entUsuarioComun> objUsuarios = new List<entUsuarioComun>();
                objUsuarios = negMedico.Instancia.ListarMedicosPorIdTipo(2);
                SelectList obgUsuarios = new SelectList(objUsuarios, "idUsuario", "nombre");

                return Json(obgUsuarios);
            }
            else if (tipoid == 3)
            {

            }
            else if (tipoid == 4)
            {
                List<entUsuarioComun> objUsuarios = new List<entUsuarioComun>();
                objUsuarios = negPaciente.Instancia.ListarPacientesPorIdTipo(4);
                SelectList obgUsuarios = new SelectList(objUsuarios, "idUsuario", "nombre");

                return Json(obgUsuarios);
            }

            return View();
        }

        public ActionResult GestionarUsuarios(String mensaje) {
            usuarioLoginModel modeloUsuarioLogin = new usuarioLoginModel();

            ViewData["ListaMedicosUsuario"] = negMedico.Instancia.ListarMedicosUsuario();
            ViewBag.mensaje = mensaje;
            return View("GestionarUsuarios", modeloUsuarioLogin);
        }
    }
}
