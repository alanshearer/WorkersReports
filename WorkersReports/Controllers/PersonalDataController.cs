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
    public class PersonalDataController : Controller
    {
        private WorkersReportsContext db = new WorkersReportsContext();

        // GET: PersonalDatas
        public ActionResult Index()
        {
            return View(db.PersonalDatas.ToList());
        }

        // GET: PersonalDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return HttpNotFound();
            }
            return View(personalData);
        }

        // GET: PersonalDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalDatas/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MACAddress,FirstName,LastName,FiscalCode,SerialNumber")] PersonalData personalData)
        {
            if (ModelState.IsValid)
            {
                db.PersonalDatas.Add(personalData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personalData);
        }

        // GET: PersonalDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return HttpNotFound();
            }
            return View(personalData);
        }

        // POST: PersonalDatas/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MACAddress,FirstName,LastName,FiscalCode,SerialNumber")] PersonalData personalData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personalData);
        }

        // GET: PersonalDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalData personalData = db.PersonalDatas.Find(id);
            if (personalData == null)
            {
                return HttpNotFound();
            }
            return View(personalData);
        }

        // POST: PersonalDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalData personalData = db.PersonalDatas.Find(id);
            db.PersonalDatas.Remove(personalData);
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
