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
    public class PortfolioCategoriesController : Controller
    {
        private SampleContext db = new SampleContext();

        // GET: ManagementPanel/PortfolioCategories
        public ActionResult Index()
        {
            return View(db.PortfolioCategories.ToList());
        }

        // GET: ManagementPanel/PortfolioCategories/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioCategories portfolioCategories = db.PortfolioCategories.Find(id);
            if (portfolioCategories == null)
            {
                return HttpNotFound();
            }
            return View(portfolioCategories);
        }

        // GET: ManagementPanel/PortfolioCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/PortfolioCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Name,IsActive")] PortfolioCategories portfolioCategories)
        {
            if (ModelState.IsValid)
            {
                db.PortfolioCategories.Add(portfolioCategories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolioCategories);
        }

        // GET: ManagementPanel/PortfolioCategories/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioCategories portfolioCategories = db.PortfolioCategories.Find(id);
            if (portfolioCategories == null)
            {
                return HttpNotFound();
            }
            return View(portfolioCategories);
        }

        // POST: ManagementPanel/PortfolioCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Name,IsActive")] PortfolioCategories portfolioCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolioCategories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolioCategories);
        }

        // GET: ManagementPanel/PortfolioCategories/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PortfolioCategories portfolioCategories = db.PortfolioCategories.Find(id);
            if (portfolioCategories == null)
            {
                return HttpNotFound();
            }
            return View(portfolioCategories);
        }

        // POST: ManagementPanel/PortfolioCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            PortfolioCategories portfolioCategories = db.PortfolioCategories.Find(id);
            db.PortfolioCategories.Remove(portfolioCategories);
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
