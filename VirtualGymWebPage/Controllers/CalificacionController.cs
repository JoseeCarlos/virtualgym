using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualGymWebPage.Models;

namespace VirtualGymWebPage.Controllers
{
    public class CalificacionController : Controller
    {
        // GET: Calificacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult insert(FormCollection collection)
        {
            //knkdsfnd
            Calificacion_Model model = new Calificacion_Model();
            Calificacion calificacion = new Calificacion(int.Parse(collection["txtidrutina"].ToString()),int.Parse(Session["idUsuario"].ToString()),int.Parse(collection["txtcalificacion"].ToString()));
            model.insert(calificacion);

            return RedirectToAction("listRutinaFull","Rutina");
        }
    }
}