using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UniversityPortal.Models;

namespace UniversityPortal.Controllers
{
    public class TestimonialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Testimonials/
        public async Task<ActionResult> Index()
        {
            return View(await db.Testimonial.ToListAsync());
        }

        // GET: /Testimonials/Details/5
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

        // GET: /Testimonials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Testimonials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,UserName,Review,Name,CreatedDate")] Testimonial testimonial)
        {
            var currentUserId = User.Identity.GetUserId();
            ApplicationUser user = await db.Users.FirstOrDefaultAsync(x => x.Id == currentUserId);
            testimonial.CreatedDate = DateTime.Now;
            testimonial.Name = user.FirstName + " " + user.MiddleName;
            testimonial.UserName = user.UserName;
            testimonial.IsApproved = 0;

            if (ModelState.IsValid)
            {
                db.Testimonial.Add(testimonial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(testimonial);
        }

        // GET: /Testimonials/Edit/5
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

        // POST: /Testimonials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,UserName,Review,Name,CreatedDate,IsApproved")] Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testimonial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testimonial);
        }

        // GET: /Testimonials/Delete/5
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

        // POST: /Testimonials/Delete/5
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

        #region Frontend Methods

        [AcceptVerbs(HttpVerbs.Get)]
        [AllowAnonymous]
        [HttpPost]
        public JsonResult GetJobJsonResult(int n)
        {
            List<TestinomialFrontEndViewModel> testinomials = (
                (db.Testimonial.OrderByDescending(j => j.CreatedDate).Select(j => new TestinomialFrontEndViewModel
                {
                    Review = j.Review,
                    Name = j.Name
                    })).Take(n)).ToList();
            return Json(testinomials);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [AllowAnonymous]
        [HttpPost]
        public JsonResult GetJobDetailJsonResult(int? id)
        {
            if (id == null)
            {
                return Json(HttpStatusCode.BadRequest);
            }
            Testimonial testinomials = db.Testimonial.Find(id);
            if (testinomials == null)
            {
                return Json(HttpNotFound().ToString());
            }
            return Json(testinomials);
        }

        #endregion
    }
}
