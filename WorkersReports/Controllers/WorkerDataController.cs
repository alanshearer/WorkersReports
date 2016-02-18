using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorkersReports.Models;

namespace WorkersReports.Controllers
{
    public class WorkerDataController : Controller
    {
        private WorkersReportsContext db = new WorkersReportsContext();

        // GET: /Default1/
        public ActionResult Index()
        {
            return View(db.WorkerDatas.ToList());
        }

        // GET: /Default1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkerData workerdata = db.WorkerDatas.Find(id);
            if (workerdata == null)
            {
                return HttpNotFound();
            }
            return View(workerdata);
        }
    }
}
