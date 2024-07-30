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
    public class CandidatoesController : Controller
    {
        private ELECCIONESEntities db = new ELECCIONESEntities();

        // GET: Candidatoes
        public ActionResult Index()
        {
            var candidatos = db.Candidatos.Include(c => c.Partido_Politico);
            return View(candidatos.ToList());
        }

        // GET: Candidatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // GET: Candidatoes/Create
        public ActionResult Create()
        {
            ViewBag.id_partido = new SelectList(db.Partido_Politico, "id_partido", "nombre_partido");
            return View();
        }

        // POST: Candidatoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_candidato,id_partido,plataforma,nombre_candidato")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Candidatos.Add(candidato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_partido = new SelectList(db.Partido_Politico, "id_partido", "nombre_partido", candidato.id_partido);
            return View(candidato);
        }

        // GET: Candidatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_partido = new SelectList(db.Partido_Politico, "id_partido", "nombre_partido", candidato.id_partido);
            return View(candidato);
        }

        // POST: Candidatoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_candidato,id_partido,plataforma,nombre_candidato")] Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_partido = new SelectList(db.Partido_Politico, "id_partido", "nombre_partido", candidato.id_partido);
            return View(candidato);
        }

        // GET: Candidatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidato candidato = db.Candidatos.Find(id);
            if (candidato == null)
            {
                return HttpNotFound();
            }
            return View(candidato);
        }

        // POST: Candidatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidato candidato = db.Candidatos.Find(id);
            db.Candidatos.Remove(candidato);
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
