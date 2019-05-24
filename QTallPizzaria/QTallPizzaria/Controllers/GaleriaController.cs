﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QTallPizzaria.Models;

namespace QTallPizzaria.Controllers
{
    public class GaleriaController : Controller
    {
        private DBQtallEntities db = new DBQtallEntities();

        // GET: Galeria
        public ActionResult Index()
        {
            return View(db.Foto.ToList());
        }

        // GET: Galeria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foto foto = db.Foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        // GET: Galeria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Galeria/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFoto,descricao,img")] Foto foto)
        {
            if (ModelState.IsValid)
            {
                db.Foto.Add(foto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foto);
        }

        // GET: Galeria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foto foto = db.Foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        // POST: Galeria/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFoto,descricao,img")] Foto foto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foto);
        }

        // GET: Galeria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Foto foto = db.Foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        // POST: Galeria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Foto foto = db.Foto.Find(id);
            db.Foto.Remove(foto);
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
