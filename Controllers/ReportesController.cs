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

namespace WebAppDermatologia.Controllers
{
    public class ReportesController : Controller
    {
        private DermatologiaEntities db = new DermatologiaEntities();

        public ActionResult RptReserva()
        {
            return View();
        }
        public ActionResult RptEmpleados()
        {
            return View();
        }
        public ActionResult RptHistoriaClinica()
        {
            return View();
        }
        public ActionResult DescargarReporteReserva()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/reservas.rpt");
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
            catch (Exception)
            {
                throw;
            }

        }
        public ActionResult DescargarReporteEmpleado()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/Empleados.rpt");
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
            catch (Exception)
            {
                throw;
            }

        }
        public ActionResult DescargarReporteHistoriaClinica()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/HistoriaClinica.rpt");
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
            catch (Exception)
            {
                throw;
            }

        }


    }

}
