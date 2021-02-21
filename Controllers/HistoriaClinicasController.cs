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
    public class HistoriaClinicasController : Controller
    {
        private DermatologiaEntities db = new DermatologiaEntities();
        
        // GET: HistoriaClinicas
        public ActionResult HistoriaCompleta()
        {
            //var nombre = "1";
            using (var DB = new DermatologiaEntities())
            {
                var nombre = DB.Database.SqlQuery<string>("Select * From Paciente JOIN HistoriaClinica ON Paciente.Cedula = HistoriaClinica.IDPaciente").ToList();
                return View(nombre);
            }
          // return View(nombre.ToList()); 
        }
        public ActionResult Index(string searchString)
        {
            var historiaClinica = from s in db.HistoriaClinica.Include(h => h.Paciente) 
                                  select s;
       
            if (!String.IsNullOrEmpty(searchString))
            {
                historiaClinica = historiaClinica.Where(s => s.IDPaciente.Contains(searchString)
                                       || s.Paciente.Nombre.Contains(searchString));
            }

            return View(historiaClinica.ToList());
        }

        // GET: HistoriaClinicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaClinica historiaClinica = db.HistoriaClinica.Find(id);
            if (historiaClinica == null)
            {
                return HttpNotFound();
            }
            return View(historiaClinica);
        }

        // GET: HistoriaClinicas/Create
        public ActionResult Create()
        {
            ViewBag.IDPaciente = new SelectList(db.Paciente, "Cedula", "Nombre");
            return View();
        }

        // POST: HistoriaClinicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HistClinica,IDPaciente,Fecha_Nacimiento,Antecedentes_Medicos,Alergias,Enfermedades_Hereditarias,Observaciones,Fotografias")] HistoriaClinica historiaClinica)
        {
            if (ModelState.IsValid)
            {
                db.HistoriaClinica.Add(historiaClinica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPaciente = new SelectList(db.Paciente, "Cedula", "Nombre", historiaClinica.IDPaciente);
            return View(historiaClinica);
        }

        // GET: HistoriaClinicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaClinica historiaClinica = db.HistoriaClinica.Find(id);
            if (historiaClinica == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPaciente = new SelectList(db.Paciente, "Cedula", "Nombre", historiaClinica.IDPaciente);
            return View(historiaClinica);
        }

        // POST: HistoriaClinicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HistClinica,IDPaciente,Fecha_Nacimiento,Antecedentes_Medicos,Alergias,Enfermedades_Hereditarias,Observaciones,Fotografias")] HistoriaClinica historiaClinica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historiaClinica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPaciente = new SelectList(db.Paciente, "Cedula", "Nombre", historiaClinica.IDPaciente);
            return View(historiaClinica);
        }

        // GET: HistoriaClinicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaClinica historiaClinica = db.HistoriaClinica.Find(id);
            if (historiaClinica == null)
            {
                return HttpNotFound();
            }
            return View(historiaClinica);
        }

        // POST: HistoriaClinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistoriaClinica historiaClinica = db.HistoriaClinica.Find(id);
            db.HistoriaClinica.Remove(historiaClinica);
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
