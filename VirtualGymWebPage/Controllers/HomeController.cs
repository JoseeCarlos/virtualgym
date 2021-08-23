using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualGymWebPage.Models;
using System.Net.Mail;

namespace VirtualGymWebPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            Opinion_model opinion_Model = new Opinion_model();
            return View(opinion_Model.SelectOpinion()); ;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult InsertOpinion(FormCollection collection)
        {
            Opinion_model om = new Opinion_model();
            Opinion opinion = new Opinion()
            {
                Fecha = (collection["txtFecha"]),
                Comentario = collection["txtComentario"],
                IdUsuario = int.Parse(collection["usuario"])
            };
            om.Insert(opinion);

            return RedirectToAction("Index");
        }
       
    }
}