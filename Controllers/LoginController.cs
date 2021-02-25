using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppDermatologia.Models;

namespace WebAppDermatologia.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Empleado objUser)
        {
            //if (ModelState.IsValid)
            //{
                using (DermatologiaEntities db = new DermatologiaEntities())
                {
                    var obj = db.Empleado.Where(a => a.Login.Equals(objUser.Login) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Login"] = obj.Login.ToString();
                        Session["Name"] = obj.Nombre.ToString();
                        return RedirectToAction("Index", "Home", null);
                    }
                    else
                    {
                        
                    }
                }
            //}
            return View(objUser);
        }
    }
}