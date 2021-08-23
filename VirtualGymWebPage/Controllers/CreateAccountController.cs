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
    public class CreateAccountController : Controller
    {
        EnvioCorreos correo = new EnvioCorreos();
        // GET: CreateAccount
        public ActionResult Index()
        {
            return View();

        }

        // GET: CreateAccount/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: CreateAccount/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Recover()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            Usuario_model um = new Usuario_model();
            DataTable dt = um.Login(collection["txtUsuario"], collection["txtPassword"]);
            if (dt.Rows.Count > 0)
            {
                Session["idUsuario"] = dt.Rows[0][0].ToString();
                Session["nombre"] = dt.Rows[0][1].ToString();
                Session["email"] = dt.Rows[0][2].ToString();
                Session["nombreUsuario"] = dt.Rows[0][3].ToString();
                Session["premium"] = dt.Rows[0][4].ToString();
                Session["rol"] = dt.Rows[0][5].ToString();


                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.Message = "Error en el usuario/contraseña";
                return View("Login");
            }

        }

        // POST: CreateAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Random rdn = new Random();            
            string nums = "0123456789";
            string letras = "abcdefghijklmnopqrstuvwxyz";           
            string pass = "";
            string nom = new string(
                new string[]
                {
                    collection["txtPrimerAp"],
                    collection["txtSegundoAp"],
                    collection["txtNombre"]
                }.ToList().Select(x => x[0]).ToArray()
            );
            for (int i = 0; i < 7; i++)
            {
                nom += nums[rdn.Next(nums.Length)].ToString();
            }
            for (int i = 0; i < 6; i++)
            {
                pass += (rdn.Next(2) == 0) ? nums[rdn.Next(nums.Length)] : (rdn.Next(2) == 0) ? letras[rdn.Next(nums.Length)].ToString().ToUpper()[0] : letras[rdn.Next(nums.Length)];
            }
            Usuario_model um = new Usuario_model();
            Usuario user = new Usuario()
            {
                Nombre = collection["txtNombre"],
                PrimerApellido = collection["txtPrimerAp"],
                SegundoApellido = collection["txtSegundoAp"],
                Email = collection["txtEmail"],
                NombreUsuario = nom,
                Password = pass

            };
            correo.EnviarCorreo(collection["txtEmail"], nom, pass);            
            um.Insert(user);
            ViewBag.Message = "Le enviamos su nombre de usuario y contraseña, por favor revise su correo electronico";
            return View();

        }

        // GET: CreateAccount/Edit/5

        public ActionResult Edit(int id)
        {
            Usuario_model user = new Usuario_model();
            Usuario us = user.get(id);
            return View(us);
        }

        // POST: CreateAccount/Edit/5
        [HttpPost]
        public ActionResult EditForm(FormCollection collection)
        {
            Usuario_model modelUser = new Usuario_model();
            Usuario us = new Usuario(int.Parse(collection["txtId"]), collection["txtNombre"], collection["txtPrimerApellido"], collection["txtSegundoApellido"], collection["txtEmail"]);
            modelUser.update(us);
            return RedirectToAction("index", "Home");
        }

        // GET: CreateAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreateAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Contents.RemoveAll();
            return RedirectToAction("index", "Home");
        }

        

        
        string codigo = "";

        public ActionResult RecoverAccount(FormCollection collection)
        {

            string pw = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            Random rnd = new Random();
            Usuario_model um = new Usuario_model();
            DataTable dt = um.SearchAccount(collection["txtUsuario"]);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    codigo += pw[rnd.Next(pw.Length)].ToString();                     
                }                    
                
                int id = int.Parse(dt.Rows[0][0].ToString());
                string destino = dt.Rows[0][4].ToString();
                ViewBag.id = id;
                ViewBag.codigo = codigo;
                correo.EnviarCorreoCodigo(destino, codigo);
                ViewBag.Confirmacion = "codigo";
                return View("Recover");
            }
            else
            {    
                ViewBag.Message = "El usuario no existe";
                return View("Recover");
            }
        }
        public ActionResult CodeConfirm(FormCollection collection)
        {
            if (collection["txtCodigo"] == collection["codigo"])
            {               
                ViewBag.id = int.Parse(collection["id"]);
                ViewBag.Confirmacion = "password";
                return View("Recover");
            }
            else
            {
                ViewBag.Message = "Ingrese el codigo correcto";
                
                return View("Recover");
            }            
        }

        public ActionResult PasswordUpdate(FormCollection collection)
        {            
            if (collection["txtPassword"] == collection["txtPasswordR"])
            {
                Usuario_model us = new Usuario_model();
                Usuario user = new Usuario(int.Parse(collection["id"]),collection["txtPassword"]);
                us.updatePassword(user);
                ViewBag.Message = "Contraseña modificada con exito";
                return View("Login");
            }
            else
            {
                ViewBag.Message = "Ingrese las mismas contraseñas";
                ViewBag.id = int.Parse(collection["id"]);
                ViewBag.Confirmacion = "password";
                return View("Recover");

            }            
        }

        
    }
}
