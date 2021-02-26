using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppDermatologia.Models;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace WebAppDermatologia.Controllers
{
    public class PacientesController : Controller
    {
        private DermatologiaEntities db = new DermatologiaEntities();

        // GET: Pacientes
        public ActionResult Index(string searchString)
        {
            var pacientes = from s in db.Paciente
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                pacientes = pacientes.Where(s => s.Cedula.Contains(searchString));
                if (pacientes.Count()<1)
                {
                    Request.Flash("warning", "Paciente no Registrado");
                }
            }
            else
            {
           
              
                
            }

            return View(pacientes.ToList());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cedula,Nombre,Apellido,Telefono,Correo,Direccion,Sexo")] Paciente paciente)
        {
            try
            {
                ValidacionCedula validar = new ValidacionCedula();
                if(validar.validar(paciente.Cedula))
                {
                    if (ModelState.IsValid)
                    {
                        db.Paciente.Add(paciente);
                        db.SaveChanges();
                        return RedirectToAction("Index");


                    }
                }
                else
                {
                    Request.Flash("warning", "Cédula no válida");
                }
                
            }
            catch(DbUpdateException e)
            {
                Request.Flash("danger", "La cédula del paciente ya se encuentra registrada");

            }
            catch (SqlException ey) when (ey.Number == 2627)
            {
                Request.Flash("danger", ey.Message);
            }

            catch (Exception ex)
            {
                Request.Flash("danger", "Hubo problemas en el registro del paciente");


            }


            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cedula,Nombre,Apellido,Telefono,Correo,Direccion,Sexo")] Paciente paciente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(paciente).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException e)
            {
                Request.Flash("danger", e.Message);

            }
            catch (SqlException ey) when (ey.Number == 2627)
            {
                Request.Flash("danger", ey.Message);
            }

            catch (Exception ex)
            {
                Request.Flash("danger", "Hubo problemas en el registro del paciente");


            }
            
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Paciente paciente = db.Paciente.Find(id);
            db.Paciente.Remove(paciente);
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

        public ActionResult RptPaciente()
        {
            return View();
        }

        public ActionResult DescargarReportePaciente()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/Pacientes.rpt");
                rptH.Load();

                //rptH.SetParameterValue("DptoId", codigo);
                //rptH.SetParameterValue("ParamAlgo", algo);

                // Report connection
                var connInfo = Reporte.CrystalReportsCnn.GetConnectionInfo();
                TableLogOnInfo logonInfo = new TableLogOnInfo();
                Tables tables;
                tables = rptH.Database.Tables;
                foreach (Table table in tables)
                {
                    logonInfo = table.LogOnInfo;
                    logonInfo.ConnectionInfo = connInfo;
                    table.ApplyLogOnInfo(logonInfo);
                }

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                //En PDF
                Stream stream = rptH.ExportToStream(ExportFormatType.PortableDocFormat);
                rptH.Dispose();
                rptH.Close();
                return new FileStreamResult(stream, "application/pdf");

                //En Excel
                //Stream stream = rptH.ExportToStream(ExportFormatType.Excel);
                //stream.Seek(0, SeekOrigin.Begin);
                //return File(stream, "application/vnd.ms-excel", "empleadoRpt.xls");
            }
            catch (Exception )
            {
                throw;
            }
                
            }
        }
    }

