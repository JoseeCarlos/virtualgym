using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualGymWebPage.Models;

namespace VirtualGymWebPage.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UsersFree()
        {
            Usuario_model model = new Usuario_model();

            return View(model.listUserFree());
        }
        public ActionResult UsersPremium()
        {
            Usuario_model model = new Usuario_model();

            return View(model.listUserPremium());
        }

        public ActionResult UserDisabled()
        {
            Usuario_model model = new Usuario_model();

            return View(model.listUserDisabled());
        }



        public ActionResult FormPremium()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FormPremium(FormCollection collection)
        {
            Membresia_Model um = new Membresia_Model();
           
            DataTable dt = um.MembresiaExist(collection["txtcodigo"]);
            if (dt.Rows.Count > 0)
            {
                Membresia mem = new Membresia(int.Parse( dt.Rows[0][0].ToString()),dt.Rows[0][1].ToString(),int.Parse(dt.Rows[0][2].ToString()));
                DateTime fechafin = DateTime.Now.AddDays(mem.Dias);
                int id = int.Parse(Session["idUsuario"].ToString());
                um.insertMember2(mem,fechafin,id);
                Session["premium"] = 1;
                return RedirectToAction("index", "Home");

            }
            else
            {
                ViewBag.Message = "Error \n La Targeta de Membresia no es correcta ";
                return View("FormPremium");
            }

        }

        public ActionResult deleteFree(int id)
        {
            Usuario_model model = new Usuario_model();
            model.deleteUser(id);

            return RedirectToAction("usersFree", "User");

        }
        public ActionResult deletePremium(int id )
        {
            Usuario_model model = new Usuario_model();
            model.deleteUser(id);

            return RedirectToAction("UsersPremium", "User");
        }

        public ActionResult UserHabilit(int id)
        {
            Usuario_model model = new Usuario_model();
            model.habilitarUser(id);

            return RedirectToAction("userDisabled", "User");
        }

        public ActionResult DatosMember()
        {
            Membresia_Model model = new Membresia_Model();
            return View(model.getdatos(int.Parse( Session["idUsuario"].ToString())));
        }
    }
}