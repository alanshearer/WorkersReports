using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WorkersReports.Models;

namespace WorkersReports.ApiControllers
{
    public class WorkerDatasController : ApiController
    {
        private WorkersReportsContext db = new WorkersReportsContext();

        // GET api/WorkerData
        public IQueryable<WorkerData> GetWorkerDatas(WorkerDataSearchParameter parameter)
        {
            List<WorkerData> wd = db.WorkerDatas.ToList();
            List<PersonalData> pd = db.PersonalDatas.ToList();
            wd.ForEach(w => w.PersonalData = pd.Find(p => p.ID == w.PersonalDataId));
            return wd.AsQueryable();
        }

        // GET api/WorkerData/5
        [ResponseType(typeof(WorkerData))]
        public IHttpActionResult GetWorkerData(int id)
        {
            WorkerData workerdata = db.WorkerDatas.Find(id);
            
            if (workerdata == null)
            {
                return NotFound();
            }

            return Ok(workerdata);
        }

        // PUT api/WorkerData/5
        public IHttpActionResult PutWorkerData(int id, WorkerData workerdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workerdata.ID)
            {
                return BadRequest();
            }

            db.Entry(workerdata).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/WorkerData
        [ResponseType(typeof(WorkerData))]
        public IHttpActionResult PostWorkerData(WorkerData workerdata)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkerDatas.Add(workerdata);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workerdata.ID }, workerdata);
        }

        // DELETE api/WorkerData/5
        [ResponseType(typeof(WorkerData))]
        public IHttpActionResult DeleteWorkerData(int id)
        {
            WorkerData workerdata = db.WorkerDatas.Find(id);
            if (workerdata == null)
            {
                return NotFound();
            }

            db.WorkerDatas.Remove(workerdata);
            db.SaveChanges();

            return Ok(workerdata);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkerDataExists(int id)
        {
            return db.WorkerDatas.Count(e => e.ID == id) > 0;
        }
    }
}