using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidades;
using Negocio;

namespace MvcApplication1.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginIntranet(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult LoginIntranet(FormCollection form)
        {
            try
            {
                String Usuario = form["txtUsuario"];
                String Password = form["txtPassword"];
                entUsuario u = negUsuario.Instancia.VerificarAcceso(Usuario, Password);
                Session["usuario"] = u;
                if (u.tipoUsuario.idTipoUsuario == 1) 
                {
                    entAdministrador objAdm = negAdministrador.Instancia.BuscarAdministradorPorIdUsuario(u.idUsuario);
                    Session["usuarioAdministrador"] = objAdm;

                }else if(u.tipoUsuario.idTipoUsuario == 2)
                {

                }
                else if (u.tipoUsuario.idTipoUsuario == 3)
                {
                
                }
                
                return RedirectToAction("PrincipalIntranet", "Inicio");

            }
            catch (ApplicationException z)
            {
                // ViewBag.mensaje =z.Message;
                //return View();
                return RedirectToAction("LoginIntranet", "Inicio", new { mensaje = z.Message });

            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { error = e.Message });
            }
        }

        public ActionResult PrincipalIntranet()
        {
            return View();
        }
    }
}
