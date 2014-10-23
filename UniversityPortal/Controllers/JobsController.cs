using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityPortal.Models;

namespace UniversityPortal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        public async Task<ActionResult> Index()
        {
            return View(await db.Job.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Job.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Job.Add(job);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Job.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Job.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Job job = await db.Job.FindAsync(id);
            db.Job.Remove(job);
            await db.SaveChangesAsync();
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

        #region Frontend Methods

        [AllowAnonymous]
        [HttpPost]
        public JsonResult GetJobJsonResult(int n)
        {
            List<JobFrontEndViewModel> jobs = (
                (db.Job.OrderByDescending(j => j.created_date).Select(j => new JobFrontEndViewModel
                {
                    Title = j.title,
                    Description = j.desc_,
                    Department = j.department,
                    Hours = j.hours,
                    JobReference = j.job_ref,
                    Location = j.location,
                    MaxSalary = j.max_salary,
                    MinSalary = j.min_salary
                })).Take(n)).ToList();
                //from t in db.Job
                //                orderby t.title descending
                //                select new JobFrontEndViewModel
                //                {
                //                    Title = t.title,
                //                    Description = t.desc_,
                //                    Department = t.department,
                //                    Hours = t.hours,
                //                    JobReference = t.job_ref,
                //                    Location = t.location,
                //                    MaxSalary = t.max_salary,
                //                    MinSalary = t.min_salary
                //                }).Take(n)).ToList();
            return Json(jobs);
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult GetJobDetailJsonResult(int? id)
        {
            if (id == null)
            {
                return Json(HttpStatusCode.BadRequest);
            }
            Job job = db.Job.Find(id);
            if (job == null)
            {
                return Json(HttpNotFound().ToString());
            }
            return Json(job);
        }

        #endregion
    }
}
