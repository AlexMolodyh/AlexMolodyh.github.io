﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.DAL;
using HW8.Model;

namespace HW8.Controllers
{
    public class ArtWorksController : Controller
    {
        private ArtDBContext db = new ArtDBContext();

        // GET: ArtWorks
        public ActionResult Index()
        {
            var artWorks = db.ArtWorks.Include(a => a.Artist1);
            return View(artWorks.ToList());
        }

        // GET: ArtWorks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtWork artWork = db.ArtWorks.Find(id);
            if (artWork == null)
            {
                return HttpNotFound();
            }
            return View(artWork);
        }

        // GET: ArtWorks/Create
        public ActionResult Create()
        {
            ViewBag.Artist = new SelectList(db.Artists, "ArtistName", "BirthCity");
            return View();
        }

        // POST: ArtWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtWorkTitle,Artist")] ArtWork artWork)
        {
            if (ModelState.IsValid)
            {
                db.ArtWorks.Add(artWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Artist = new SelectList(db.Artists, "ArtistName", "BirthCity", artWork.Artist);
            return View(artWork);
        }

        // GET: ArtWorks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtWork artWork = db.ArtWorks.Find(id);
            if (artWork == null)
            {
                return HttpNotFound();
            }
            ViewBag.Artist = new SelectList(db.Artists, "ArtistName", "BirthCity", artWork.Artist);
            return View(artWork);
        }

        // POST: ArtWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtWorkTitle,Artist")] ArtWork artWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Artist = new SelectList(db.Artists, "ArtistName", "BirthCity", artWork.Artist);
            return View(artWork);
        }

        // GET: ArtWorks/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtWork artWork = db.ArtWorks.Find(id);
            if (artWork == null)
            {
                return HttpNotFound();
            }
            return View(artWork);
        }

        // POST: ArtWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ArtWork artWork = db.ArtWorks.Find(id);
            db.ArtWorks.Remove(artWork);
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
