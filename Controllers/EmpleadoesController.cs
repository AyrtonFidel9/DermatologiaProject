using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppDermatologia.Models;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

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
                empleados = empleados.Where(s => s.Cedula.Contains(searchString)
                                      );
                if (empleados.Count() < 1)
                {
                    Request.Flash("warning", "Empleado no Registrado");
                }
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
                var cedula = from c in db.Empleado select c;
                cedula = cedula.Where(c=>c.Cedula == empleado.Cedula);
                if (cedula.Count() < 1)
                {
                    ValidacionCedula objcedula = new ValidacionCedula();
                    if (objcedula.validar(empleado.Cedula))
                    {
                        if (ModelState.IsValid)
                        {
                            db.Empleado.Add(empleado);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        Request.Flash("danger", "Cédula ingresada no válida");
                    }
                }
                else
                {
                    Request.Flash("danger", "Cédula ya ingresada");
                }
                
            }
            catch (DbUpdateException e)
            {
                Request.Flash("danger", "La cédula del empleado ya se encuentra registrada");

            }
            catch (SqlException ey) when (ey.Number == 2627)
            {
                Request.Flash("danger", ey.Message);
            }

            catch (Exception ex)
            {
                Request.Flash("danger", "Hubo problemas en el registro del empleado");


            }

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
            try
            {
                Empleado empleado = db.Empleado.Find(id);
                db.Empleado.Remove(empleado);
                db.SaveChanges();

            }
            catch
            {
                Request.Flash("danger", "No puede eliminar al Administrador del Sistema");
              
            }
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
