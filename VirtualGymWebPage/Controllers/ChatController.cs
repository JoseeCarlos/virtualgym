using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualGymWebPage.Models;

namespace VirtualGymWebPage.Controllers
{
    public class ChatController : Controller
    {

        EnvioCorreos correo = new EnvioCorreos();
        public ActionResult OpenChat()
        {

            return View();
        }

        public ActionResult EnviarCorreo(string email)
        {
            
            return View();
        }

        public ActionResult EnviarCorreoPrivado(FormCollection collection)
        {
            correo.EnviarCorreoPrivado(collection["txtEmail"], collection["txtPassword"], collection["txtAsunto"],collection["txtMensaje"]);
            return RedirectToAction("Index", "Home");

        }
    }
}
