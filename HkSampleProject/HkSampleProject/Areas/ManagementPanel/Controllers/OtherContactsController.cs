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
    public class OtherContactsController : Controller
    {
        private SampleContext db = new SampleContext();

        // GET: ManagementPanel/OtherContacts
        public ActionResult Index()
        {
            return View(db.OtherContacts.ToList());
        }

        // GET: ManagementPanel/OtherContacts/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherContacts otherContacts = db.OtherContacts.Find(id);
            if (otherContacts == null)
            {
                return HttpNotFound();
            }
            return View(otherContacts);
        }

        // GET: ManagementPanel/OtherContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/OtherContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactId,Name,Icon,Value,IsActive")] OtherContacts otherContacts)
        {
            if (ModelState.IsValid)
            {
                db.OtherContacts.Add(otherContacts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(otherContacts);
        }

        // GET: ManagementPanel/OtherContacts/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherContacts otherContacts = db.OtherContacts.Find(id);
            if (otherContacts == null)
            {
                return HttpNotFound();
            }
            return View(otherContacts);
        }

        // POST: ManagementPanel/OtherContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactId,Name,Icon,Value,IsActive")] OtherContacts otherContacts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otherContacts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(otherContacts);
        }

        // GET: ManagementPanel/OtherContacts/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherContacts otherContacts = db.OtherContacts.Find(id);
            if (otherContacts == null)
            {
                return HttpNotFound();
            }
            return View(otherContacts);
        }

        // POST: ManagementPanel/OtherContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            OtherContacts otherContacts = db.OtherContacts.Find(id);
            db.OtherContacts.Remove(otherContacts);
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
