using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppDermatologia.Controllers
{
    public class InicioReportesController : Controller
    {
        // GET: InicioReportes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportePacientes()
        {
            return View();
        }


    }
}