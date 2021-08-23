using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualGymWebPage.Models;

namespace VirtualGymWebPage.Controllers
{
    public class ComentarioController : Controller
    {
        // GET: Comentario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comentario/Details/5
        public ActionResult InsertComentario(FormCollection collection)
        {
            Comentario_model om = new Comentario_model();
            Comentario comentario = new Comentario()
            {
                Descripcion = collection["txtComentario"],                
                IdRutina = int.Parse(collection["IdRutina"])
            };
            om.Insert(comentario);
            
            return RedirectToAction("Index", "Home");

        }

        public ActionResult Eliminar(FormCollection collection)
        {
            Comentario_model com = new Comentario_model();
            com.Delete(int.Parse(collection["comentario"]));
            return RedirectToAction("listRutinaFull", "Rutina");
        }

        
       
    }
}
