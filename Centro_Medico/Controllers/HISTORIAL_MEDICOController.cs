using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Centro_Medico.Models;

namespace Centro_Medico.Controllers
{
    public class HISTORIAL_MEDICOController : Controller
    {
        private DBCentro_medicoEntities db = new DBCentro_medicoEntities();

        // GET: HISTORIAL_MEDICO
        public ActionResult Index()
        {
            var hISTORIAL_MEDICO = db.HISTORIAL_MEDICO.Include(h => h.PACIENTE);
            return View(hISTORIAL_MEDICO.ToList());
        }

        // GET: HISTORIAL_MEDICO detalles
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL_MEDICO hISTORIAL_MEDICO = db.HISTORIAL_MEDICO.Find(id);
            if (hISTORIAL_MEDICO == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIAL_MEDICO);
        }

        // GET: HISTORIAL_MEDICO nuevo
        public ActionResult Create()
        {
            ViewBag.codigoP = new SelectList(db.PACIENTE, "codigoP", "nombresP");
            return View();
        }

        // POST: HISTORIAL_MEDICO nuevo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoHM,codigoP,fechaCreacion,estado")] HISTORIAL_MEDICO hISTORIAL_MEDICO)
        {
            if (ModelState.IsValid)
            {
                db.HISTORIAL_MEDICO.Add(hISTORIAL_MEDICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoP = new SelectList(db.PACIENTE, "codigoP", "nombresP", hISTORIAL_MEDICO.codigoP);
            return View(hISTORIAL_MEDICO);
        }

        // GET: HISTORIAL_MEDICO modificar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL_MEDICO hISTORIAL_MEDICO = db.HISTORIAL_MEDICO.Find(id);
            if (hISTORIAL_MEDICO == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoP = new SelectList(db.PACIENTE, "codigoP", "nombresP", hISTORIAL_MEDICO.codigoP);
            return View(hISTORIAL_MEDICO);
        }

        // POST: HISTORIAL_MEDICO modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoHM,codigoP,fechaCreacion,estado")] HISTORIAL_MEDICO hISTORIAL_MEDICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hISTORIAL_MEDICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoP = new SelectList(db.PACIENTE, "codigoP", "nombresP", hISTORIAL_MEDICO.codigoP);
            return View(hISTORIAL_MEDICO);
        }

        // GET: HISTORIAL_MEDICO eliminar
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HISTORIAL_MEDICO hISTORIAL_MEDICO = db.HISTORIAL_MEDICO.Find(id);
            if (hISTORIAL_MEDICO == null)
            {
                return HttpNotFound();
            }
            return View(hISTORIAL_MEDICO);
        }

        // POST: HISTORIAL_MEDICO eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HISTORIAL_MEDICO hISTORIAL_MEDICO = db.HISTORIAL_MEDICO.Find(id);
            db.HISTORIAL_MEDICO.Remove(hISTORIAL_MEDICO);
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
