using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppDermatologia.Models;

namespace WebAppDermatologia.Controllers
{
    public class EmpleadoesController : Controller
    {
        private DermatologiaEntities db = new DermatologiaEntities();

        // GET: Empleadoes
        public ActionResult Index(string searchString)
        {
            var empleados = from s in db.Empleado
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                empleados = empleados.Where(s => s.Apellido.Contains(searchString)
                                       || s.Nombre.Contains(searchString));
            }
            return View(empleados.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Login,Password,Rol_Servicio,Nombre,Apellido,Correo,Telefono,Cedula")] Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Empleado.Add(empleado);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            };
            
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Empleado empleado = db.Empleado.Find(id);
                if (empleado == null)
                {
                    return HttpNotFound();
                }
                return View(empleado);

            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }

            //return null;
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Login,Password,Rol_Servicio,Nombre,Apellido,Correo,Telefono,Cedula")] Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(empleado).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
