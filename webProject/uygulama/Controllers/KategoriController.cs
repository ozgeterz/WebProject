﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using uygulama.Entity;

namespace uygulama.Controllers
{
    public class KategoriController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Kategori
        public ActionResult Index()
        {
            return View(db.kategoriBilgileris.ToList());
        }

        // GET: Kategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriBilgileri kategoriBilgileri = db.kategoriBilgileris.Find(id);
            if (kategoriBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(kategoriBilgileri);
        }

        // GET: Kategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KategoriID,KategoriIsmi")] KategoriBilgileri kategoriBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.kategoriBilgileris.Add(kategoriBilgileri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoriBilgileri);
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriBilgileri kategoriBilgileri = db.kategoriBilgileris.Find(id);
            if (kategoriBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(kategoriBilgileri);
        }

        // POST: Kategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KategoriID,KategoriIsmi")] KategoriBilgileri kategoriBilgileri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoriBilgileri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoriBilgileri);
        }

        // GET: Kategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KategoriBilgileri kategoriBilgileri = db.kategoriBilgileris.Find(id);
            if (kategoriBilgileri == null)
            {
                return HttpNotFound();
            }
            return View(kategoriBilgileri);
        }

        // POST: Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KategoriBilgileri kategoriBilgileri = db.kategoriBilgileris.Find(id);
            db.kategoriBilgileris.Remove(kategoriBilgileri);
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
