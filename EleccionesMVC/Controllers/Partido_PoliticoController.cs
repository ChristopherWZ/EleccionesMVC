using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EleccionesMVC;

namespace EleccionesMVC.Controllers
{
    public class Partido_PoliticoController : Controller
    {
        private ELECCIONESEntities db = new ELECCIONESEntities();

        // GET: Partido_Politico
        public ActionResult Index()
        {
            return View(db.Partido_Politico.ToList());
        }

        // GET: Partido_Politico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido_Politico partido_Politico = db.Partido_Politico.Find(id);
            if (partido_Politico == null)
            {
                return HttpNotFound();
            }
            return View(partido_Politico);
        }

        // GET: Partido_Politico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Partido_Politico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_partido,nombre_partido,ideales")] Partido_Politico partido_Politico)
        {
            if (ModelState.IsValid)
            {
                db.Partido_Politico.Add(partido_Politico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partido_Politico);
        }

        // GET: Partido_Politico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido_Politico partido_Politico = db.Partido_Politico.Find(id);
            if (partido_Politico == null)
            {
                return HttpNotFound();
            }
            return View(partido_Politico);
        }

        // POST: Partido_Politico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_partido,nombre_partido,ideales")] Partido_Politico partido_Politico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partido_Politico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partido_Politico);
        }

        // GET: Partido_Politico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido_Politico partido_Politico = db.Partido_Politico.Find(id);
            if (partido_Politico == null)
            {
                return HttpNotFound();
            }
            return View(partido_Politico);
        }

        // POST: Partido_Politico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Partido_Politico partido_Politico = db.Partido_Politico.Find(id);
            db.Partido_Politico.Remove(partido_Politico);
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
