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

        public ActionResult RptPacienteDeudor()
        {
            return View();
        }

        public ActionResult RptTop10Pacientes()
        {
            return View();
        }
        public ActionResult RptPacientesAlergicos()
        {
            return View();
        }
        public ActionResult RptPacientesHoy()
        {
            return View();
        }
        public ActionResult RptPacientesEstetica()
        {
            return View();
        }
        public ActionResult RptPacientesDerma()
        {
            return View();
        }
        public ActionResult RptAcne()
        {
            return View();
        }
        public ActionResult RptME()
        {
            return View();
        }
        public ActionResult RptMD()
        {
            return View();
        }

        public ActionResult RptFE()
        {
            return View();
        }
        public ActionResult RptFD()
        {
            return View();
        }

        /*---------------------------*/
        public ActionResult DescargarRptFD()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/FemeninosDerma.rpt");
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
        public ActionResult DescargarRptFE()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/FemeninosEstetica.rpt");
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


        public ActionResult DescargarRptMD()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/MaculinosDerma.rpt");
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

        public ActionResult DescargarRptME()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/MaculinosEstetica.rpt");
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

        public ActionResult DescargarRptAcne()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/Acne.rpt");
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

        public ActionResult DescargarRptPacienteDerma()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/PacienteDerma.rpt");
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

        public ActionResult DescargarRptPacienteEstetica()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/PacienteEstetica.rpt");
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

        public ActionResult DescargarRptPacienteHoy()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/PacienteHoy.rpt");
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

        public ActionResult DescargarRptPacienteAlergia()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/PacienteAlergico.rpt");
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

        public ActionResult DescargarRptTop10Pacientes()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/Top10Pacientes.rpt");
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

        public ActionResult DescargarReporteDeudor()
        {
            try
            {
                var rptH = new ReportClass();
                rptH.FileName = Server.MapPath("/Reporte/EstadoPendiente.rpt");
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
