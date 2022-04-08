using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HkSampleProject.Areas.ManagementPanel.Helpers;
using HkSampleProject.Models.Entities;

namespace HkSampleProject.Areas.ManagementPanel.Controllers
{
    [Auth]
    public class AboutsController : Controller
    {
        private SampleContext db = new SampleContext();

        // GET: ManagementPanel/Abouts
        public ActionResult Index()
        {
            return View(db.Abouts.ToList());
        }

        // GET: ManagementPanel/Abouts/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abouts abouts = db.Abouts.Find(id);
            if (abouts == null)
            {
                return HttpNotFound();
            }
            return View(abouts);
        }

        // GET: ManagementPanel/Abouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Create([Bind(Include = "AboutsId,Image,Text,IsActive")] Abouts abouts, HttpPostedFileBase image, string text)
        {
            if (ModelState.IsValid)
            {
                if (abouts.IsActive)
                {
                    foreach (var about in db.Abouts.ToList())
                    {
                        about.IsActive = false;
                    }
                }
                if (image != null)
                {
                    abouts.Image = ImageHelper.SaveImage(image);
                }
                db.Abouts.Add(abouts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abouts);
        }

        // GET: ManagementPanel/Abouts/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abouts abouts = db.Abouts.Find(id);
            if (abouts == null)
            {
                return HttpNotFound();
            }
            return View(abouts);
        }

        // POST: ManagementPanel/Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "AboutsId,Image,Text,IsActive")] Abouts abouts, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {

                if (abouts.IsActive)
                {
                    foreach (var about in db.Abouts.ToList())
                    {
                        about.IsActive = false;
                    }
                }

                Abouts old = db.Abouts.Find(abouts.AboutsId);
                if (image != null)
                {
                    ImageHelper.DeleteImage(old.Image);
                    old.Image = ImageHelper.SaveImage(image);
                }

                old.Text = abouts.Text;
                old.IsActive = abouts.IsActive;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abouts);
        }

        // GET: ManagementPanel/Abouts/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abouts abouts = db.Abouts.Find(id);
            if (abouts == null)
            {
                return HttpNotFound();
            }
            return View(abouts);
        }

        // POST: ManagementPanel/Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Abouts abouts = db.Abouts.Find(id);
            if (abouts.IsActive)
            {
                Abouts another = db.Abouts.FirstOrDefault(a => !a.IsActive);
                if (another != null)
                {
                    another.IsActive = true;
                }
            }
            ImageHelper.DeleteImage(abouts.Image);
            db.Abouts.Remove(abouts);
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
