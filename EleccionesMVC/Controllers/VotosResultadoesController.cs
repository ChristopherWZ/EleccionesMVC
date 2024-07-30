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
    public class VotosResultadoesController : Controller
    {
        private ELECCIONESEntities db = new ELECCIONESEntities();

        // GET: VotosResultadoes
        public ActionResult Index()
        {
            var votosResultados = db.VotosResultados.Include(v => v.Candidato).Include(v => v.Votante);
            return View(votosResultados.ToList());
        }

        // GET: VotosResultadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotosResultado votosResultado = db.VotosResultados.Find(id);
            if (votosResultado == null)
            {
                return HttpNotFound();
            }
            return View(votosResultado);
        }

        // GET: VotosResultadoes/Create
        public ActionResult Create()
        {
            ViewBag.id_candidato = new SelectList(db.Candidatos, "id_candidato", "plataforma");
            ViewBag.id_votante = new SelectList(db.Votantes, "id_votante", "nombre");
            return View();
        }

        // POST: VotosResultadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_voto,id_candidato,fecha,id_votante")] VotosResultado votosResultado)
        {
            if (ModelState.IsValid)
            {
                db.VotosResultados.Add(votosResultado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_candidato = new SelectList(db.Candidatos, "id_candidato", "plataforma", votosResultado.id_candidato);
            ViewBag.id_votante = new SelectList(db.Votantes, "id_votante", "nombre", votosResultado.id_votante);
            return View(votosResultado);
        }

        // GET: VotosResultadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotosResultado votosResultado = db.VotosResultados.Find(id);
            if (votosResultado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_candidato = new SelectList(db.Candidatos, "id_candidato", "plataforma", votosResultado.id_candidato);
            ViewBag.id_votante = new SelectList(db.Votantes, "id_votante", "nombre", votosResultado.id_votante);
            return View(votosResultado);
        }

        // POST: VotosResultadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_voto,id_candidato,fecha,id_votante")] VotosResultado votosResultado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(votosResultado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_candidato = new SelectList(db.Candidatos, "id_candidato", "plataforma", votosResultado.id_candidato);
            ViewBag.id_votante = new SelectList(db.Votantes, "id_votante", "nombre", votosResultado.id_votante);
            return View(votosResultado);
        }

        // GET: VotosResultadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VotosResultado votosResultado = db.VotosResultados.Find(id);
            if (votosResultado == null)
            {
                return HttpNotFound();
            }
            return View(votosResultado);
        }

        // POST: VotosResultadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VotosResultado votosResultado = db.VotosResultados.Find(id);
            db.VotosResultados.Remove(votosResultado);
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
