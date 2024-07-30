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
    public class VotantesController : Controller
    {
        private ELECCIONESEntities db = new ELECCIONESEntities();

        // GET: Votantes
        public ActionResult Index()
        {
            var votantes = db.Votantes.Include(v => v.Candidato);
            return View(votantes.ToList());
        }

        // GET: Votantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Votante votante = db.Votantes.Find(id);
            if (votante == null)
            {
                return HttpNotFound();
            }
            return View(votante);
        }

        // GET: Votantes/Create
        public ActionResult Create()
        {
            ViewBag.Eleccion = new SelectList(db.Candidatos, "id_candidato", "plataforma");
            return View();
        }

        // POST: Votantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_votante,nombre,apellido,edad,Eleccion")] Votante votante)
        {
            if (ModelState.IsValid)
            {
                db.Votantes.Add(votante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Eleccion = new SelectList(db.Candidatos, "id_candidato", "plataforma", votante.Eleccion);
            return View(votante);
        }

        // GET: Votantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Votante votante = db.Votantes.Find(id);
            if (votante == null)
            {
                return HttpNotFound();
            }
            ViewBag.Eleccion = new SelectList(db.Candidatos, "id_candidato", "plataforma", votante.Eleccion);
            return View(votante);
        }

        // POST: Votantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_votante,nombre,apellido,edad,Eleccion")] Votante votante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(votante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Eleccion = new SelectList(db.Candidatos, "id_candidato", "plataforma", votante.Eleccion);
            return View(votante);
        }

        // GET: Votantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Votante votante = db.Votantes.Find(id);
            if (votante == null)
            {
                return HttpNotFound();
            }
            return View(votante);
        }

        // POST: Votantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Votante votante = db.Votantes.Find(id);
            db.Votantes.Remove(votante);
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
