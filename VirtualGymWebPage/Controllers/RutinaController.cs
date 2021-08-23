using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualGymWebPage.Models;

namespace VirtualGymWebPage.Controllers
{
    public class RutinaController : Controller
    {
        // GET: Rutina
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listaRutinas(int id)
        {
            Rutina_Model rumodel = new Rutina_Model();
            Session["idEjercicio"] = id;
            return View(rumodel.list_rutina(id));
        }

        public ActionResult insert(int id)
        {
            Ejercicio_Model model = new Ejercicio_Model();
            Ejercicio eje = model.getRutinaId(id);
            return View(eje);
        }

        public ActionResult insertRutina(FormCollection collection)
        {
            Response.Write(collection["txtname"]);
            Rutina_Model rutimodel = new Rutina_Model();
            Rutina r = new Rutina(collection["txtname"],collection["txtdescri"],collection["txtvideo"],int.Parse(collection["txtid"].ToString()));
            rutimodel.insert(r);
            return RedirectToAction("index","Ejercicio");
        }

        public ActionResult editRutina(int id)
        {
            Rutina_Model modelRut = new Rutina_Model();
            Rutina rut = modelRut.get(id);
            return View(rut);
        }

        public ActionResult editRut(FormCollection collection)
        {
            Rutina_Model modelRt = new Rutina_Model();
            Rutina ru = new Rutina(int.Parse(collection["txtid"]),collection["txtname"],collection["txtdescri"],collection["txtvideo"]);
            modelRt.update(ru);

            return RedirectToAction("index", "Ejercicio");
        }

        public ActionResult delete(int id)
        {
            Rutina_Model model = new Rutina_Model();
            model.delete(id);

            return RedirectToAction("index", "Ejercicio");
        }

        public ActionResult listRutinaFull()
        {

            Rutina_Model rumodel = new Rutina_Model();
            Ejercicio_Model ejemodel = new Ejercicio_Model();            
            EjercicioRutina rut = new EjercicioRutina(ejemodel.list_get(),rumodel.list_rutina_full());
           
            return View(rut);
        }

        public ActionResult RutinaGet(int id)
        {
            Rutina_Model modelRut = new Rutina_Model();
            Comentario_model modelCom = new Comentario_model();
            //Comentario com = comenModel.SelectComentario();
            RutinaComentario rut = new RutinaComentario(modelRut.list_rutina_full(), modelCom.SelectComentario(), modelRut.get(id));
            //rut. = modelRut.get(id);
            //RutinaComentario rut = modelRut.get(id);
            ViewBag.Confirm = "premiun";
            return View(rut);
        }

        public ActionResult RutinasCalificadas()
        {
            Rutina_Model model = new Rutina_Model();


            return View(model.lista_rutinas_Cali());

        }

    }
}