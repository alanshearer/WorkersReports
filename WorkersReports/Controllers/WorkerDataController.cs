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

        // GET: /Default1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Default1/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,MACAddress,Time,Latitude,Longitude")] WorkerData workerdata)
        {
            if (ModelState.IsValid)
            {
                db.WorkerDatas.Add(workerdata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workerdata);
        }

        // GET: /Default1/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: /Default1/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,MACAddress,Time,Latitude,Longitude")] WorkerData workerdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workerdata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workerdata);
        }

        // GET: /Default1/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkerData workerdata = db.WorkerDatas.Find(id);
            db.WorkerDatas.Remove(workerdata);
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
