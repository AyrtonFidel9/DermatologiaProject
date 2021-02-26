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
    public class ReservasController : Controller
    {
        private DermatologiaEntities db = new DermatologiaEntities();

        // GET: Reservas
        public ActionResult Index(string searchString)
        {
            var reserva = from s in db.Reserva.Include(r => r.Paciente) select s;
           
            if (!String.IsNullOrEmpty(searchString))
            {
                reserva = reserva.Where(s => s.IDPaciente.Contains(searchString)
                                       );
            }
            return View(reserva.ToList());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.IDPaciente = new SelectList(db.Paciente, "Cedula", "Cedula");
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Reserva,IDPaciente,Fecha,Servicio,Observaciones,Estado")] Reserva reserva)
        {
            var unicaReserva = from res in db.Reserva
                               select res;
            unicaReserva = unicaReserva.Where(res => res.IDPaciente == reserva.IDPaciente 
            && res.Fecha == reserva.Fecha && res.Servicio == reserva.Servicio);

            var unicoServicio = from ser in db.Reserva
                                select ser;
            

            if(unicaReserva.Count()<1)
            {
                
                var unicFecha = from fec in db.Reserva select fec;
                unicFecha = unicFecha.Where(fec => fec.Fecha == reserva.Fecha && fec.Servicio == reserva.Servicio);
                if (unicFecha.Count()<1)
                {

                        if (ModelState.IsValid)
                        {
                            db.Reserva.Add(reserva);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }

                }
                else
                {
                    Request.Flash("warning", "La fecha "+reserva.Fecha+" ya ha sido asignada a otro paciente");
                }
                
            }
            else
            {
                Request.Flash("warning","La reserva ya ha sido registrada en el servicio de "+reserva.Servicio);
            }
            

            ViewBag.IDPaciente = new SelectList(db.Paciente, "Cedula", "Cedula", reserva.IDPaciente);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPaciente = new SelectList(db.Paciente, "Cedula", "Cedula", reserva.IDPaciente);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Reserva,IDPaciente,Fecha,Servicio,Observaciones,Estado")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPaciente = new SelectList(db.Paciente, "Cedula", "Cedula", reserva.IDPaciente);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reserva.Find(id);
            db.Reserva.Remove(reserva);
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
