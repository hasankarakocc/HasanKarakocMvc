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
    public class ContactSetsController : Controller
    {
        private SampleContext db = new SampleContext();

        // GET: ManagementPanel/ContactSets
        public ActionResult Index()
        {
            return View(db.ContactSets.ToList());
        }

        // GET: ManagementPanel/ContactSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactSets contactSets = db.ContactSets.Find(id);
            if (contactSets == null)
            {
                return HttpNotFound();
            }
            return View(contactSets);
        }

        // GET: ManagementPanel/ContactSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/ContactSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SetId,Phone,Email,Adress,IsActive")] ContactSets contactSets)
        {
            if (ModelState.IsValid)
            {
                if (contactSets.IsActive)
                {
                    foreach (var set in db.ContactSets.ToList())
                    {
                        set.IsActive = false;
                    }
                }
                db.ContactSets.Add(contactSets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactSets);
        }

        // GET: ManagementPanel/ContactSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactSets contactSets = db.ContactSets.Find(id);
            if (contactSets == null)
            {
                return HttpNotFound();
            }
            return View(contactSets);
        }

        // POST: ManagementPanel/ContactSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SetId,Phone,Email,Adress,IsActive")] ContactSets contactSets)
        {
            if (ModelState.IsValid)
            {
                if (contactSets.IsActive)
                {
                    foreach (var set in db.ContactSets.ToList())
                    {
                        if (set!=contactSets)
                        {

                        set.IsActive = false;
                        }
                    }
                }
                ContactSets old = db.ContactSets.Find(contactSets.SetId);
                old.Phone = contactSets.Phone;
                old.Email = contactSets.Email;
                old.IsActive = contactSets.IsActive;
                old.Adress = contactSets.Adress;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactSets);
        }

        // GET: ManagementPanel/ContactSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactSets contactSets = db.ContactSets.Find(id);
            if (contactSets == null)
            {
                return HttpNotFound();
            }
            return View(contactSets);
        }

        // POST: ManagementPanel/ContactSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactSets contactSets = db.ContactSets.Find(id);
            db.ContactSets.Remove(contactSets);
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
