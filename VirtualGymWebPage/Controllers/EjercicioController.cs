using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualGymWebPage.Models;

namespace VirtualGymWebPage.Controllers
{
    public class EjercicioController : Controller
    {
        // GET: Ejercicio
        public ActionResult Index()
        {
            Ejercicio_Model ejercicio_model = new Ejercicio_Model();

            return View(ejercicio_model.list());
        }

        public ActionResult insertEjercicio()
        {
            return View();
        }

        
        public ActionResult insertEje(FormCollection collection)
        {
            Response.Write(collection["txtname"]);
            Ejercicio_Model ejemodel = new Ejercicio_Model();
            Ejercicio e = new Ejercicio(collection["txtname"]);
            ejemodel.insert(e);
            return RedirectToAction("index");
        }

        public ActionResult edit(int id)
        {
            Ejercicio_Model model = new Ejercicio_Model();
           
            Ejercicio eje = model.get(id);
            return View(eje);
        }
    }
}