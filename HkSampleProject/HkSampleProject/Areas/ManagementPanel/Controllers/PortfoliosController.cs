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
    public class PortfoliosController : Controller
    {
        private SampleContext db = new SampleContext();

        // GET: ManagementPanel/Portfolios
        public ActionResult Index()
        {
            var portfolios = db.Portfolios.Include(p => p.PortfolioCategories).Include(p => p.PortfolioDetails);
            return View(portfolios.ToList());
        }

        // GET: ManagementPanel/Portfolios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolios portfolios = db.Portfolios.Find(id);
            if (portfolios == null)
            {
                return HttpNotFound();
            }
            return View(portfolios);
        }

        // GET: ManagementPanel/Portfolios/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.PortfolioCategories, "CategoryId", "Name");
            ViewBag.PortfolioId = new SelectList(db.PortfolioDetails, "PortfolioId", "Header");
            return View();
        }

        // POST: ManagementPanel/Portfolios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PortfolioId,Name,ImageUrl,IsActive,CategoryId,PortfolioDetails")] Portfolios portfolios, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                portfolios.ImageUrl = ImageHelper.SaveImage(image);
                db.Portfolios.Add(portfolios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.PortfolioCategories, "CategoryId", "Name", portfolios.CategoryId);
            ViewBag.PortfolioId = new SelectList(db.PortfolioDetails, "PortfolioId", "Header", portfolios.PortfolioId);
            return View(portfolios);
        }

        // GET: ManagementPanel/Portfolios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolios portfolios = db.Portfolios.Find(id);
            if (portfolios == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.PortfolioCategories, "CategoryId", "Name", portfolios.CategoryId);
            ViewBag.PortfolioId = new SelectList(db.PortfolioDetails, "PortfolioId", "Header", portfolios.PortfolioId);
            return View(portfolios);
        }

        // POST: ManagementPanel/Portfolios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PortfolioId,Name,ImageUrl,IsActive,CategoryId,PortfolioDetails")] Portfolios portfolios, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Portfolios old = db.Portfolios.Find(portfolios.PortfolioId);

                if (image!=null)
                {
                    ImageHelper.DeleteImage(old.ImageUrl);
                    old.ImageUrl = ImageHelper.SaveImage(image);
                }

                old.Name = portfolios.Name;
                old.PortfolioDetails.Header = portfolios.PortfolioDetails.Header;
                old.PortfolioDetails.Client = portfolios.PortfolioDetails.Client;
                old.PortfolioDetails.Description = portfolios.PortfolioDetails.Description;
                old.PortfolioDetails.ProjectUrl = portfolios.PortfolioDetails.ProjectUrl;
                
                old.IsActive = portfolios.IsActive;
                old.PortfolioCategories = db.PortfolioCategories.Find(portfolios.CategoryId);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.PortfolioCategories, "CategoryId", "Name", portfolios.CategoryId);
            ViewBag.PortfolioId = new SelectList(db.PortfolioDetails, "PortfolioId", "Header", portfolios.PortfolioId);
            return View(portfolios);
        }

        // GET: ManagementPanel/Portfolios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolios portfolios = db.Portfolios.Find(id);
            if (portfolios == null)
            {
                return HttpNotFound();
            }
            return View(portfolios);
        }

        // POST: ManagementPanel/Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolios portfolios = db.Portfolios.Find(id);
            ImageHelper.DeleteImage(portfolios.ImageUrl);
            db.Portfolios.Remove(portfolios);
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
