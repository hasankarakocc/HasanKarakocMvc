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
    public class ClientsController : Controller
    {
        private SampleContext db = new SampleContext();

        // GET: ManagementPanel/Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: ManagementPanel/Clients/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // GET: ManagementPanel/Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagementPanel/Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,Name,ImageUrl,IsActive")] Clients clients, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {
                clients.ImageUrl = ImageHelper.SaveImage(img);
                db.Clients.Add(clients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clients);
        }

        // GET: ManagementPanel/Clients/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: ManagementPanel/Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Name,ImageUrl,IsActive")] Clients clients, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Clients old = db.Clients.Find(clients.ClientId);
                if (image != null)
                {
                    ImageHelper.DeleteImage(old.ImageUrl);
                    clients.ImageUrl = ImageHelper.SaveImage(image);
                }
                db.Entry(clients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clients);
        }

        // GET: ManagementPanel/Clients/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: ManagementPanel/Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Clients clients = db.Clients.Find(id);
            ImageHelper.DeleteImage(clients.ImageUrl);
            db.Clients.Remove(clients);
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
