using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UniversityPortal.Models;

namespace UniversityPortal.Controllers
{
    [Authorize]
    public class TestimonialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Testimonials
        public async Task<ActionResult> Index()
        {
            if (User.IsInRole("Student") || User.IsInRole("Teacher"))
            {
                string id = User.Identity.GetUserId();
                var testimonials = from t in db.Testimonial
                                   where t.UserName == id
                                   select t;
                return View(testimonials.ToList());
            }
            return View(await db.Testimonial.ToListAsync());
        }
        
        // GET: Testimonials/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonial testimonial = await db.Testimonial.FindAsync(id);
            if (testimonial == null)
            {
                return HttpNotFound();
            }
            return View(testimonial);
        }
        
        // GET: Testimonials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Testimonials/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                db.Testimonial.Add(testimonial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(testimonial);
        }

        // GET: Testimonials/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonial testimonial = await db.Testimonial.FindAsync(id);
            if (testimonial == null)
            {
                return HttpNotFound();
            }
            return View(testimonial);
        }

        // POST: Testimonials/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testimonial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testimonial);
        }

        // GET: Testimonials/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Testimonial testimonial = await db.Testimonial.FindAsync(id);
            if (testimonial == null)
            {
                return HttpNotFound();
            }
            return View(testimonial);
        }

        // POST: Testimonials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Testimonial testimonial = await db.Testimonial.FindAsync(id);
            db.Testimonial.Remove(testimonial);
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

        #region Frontend Json Methods

        [AllowAnonymous]
        [HttpPost]
        public JsonResult GetTestinomial(int n)
        {
            var testimonials = (from t in db.Testimonial
                                orderby t.CreatedDate descending
                                select t).Take(n);
            return Json(testimonials.ToList());
        }

        [AllowAnonymous]
        [HttpPost]
        // GET: Testimonials/Details/5
        public JsonResult GetTestinomialDetailjsonResult(int? id)
        {
            if (id == null)
            {
                return Json(HttpStatusCode.BadRequest);
            }
            Testimonial testimonial = db.Testimonial.Find(id);
            if (testimonial == null)
            {
                return Json(HttpNotFound().ToString());
            }
            return Json(testimonial);
        }

        #endregion

    }
}
