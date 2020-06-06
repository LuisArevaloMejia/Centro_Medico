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
    public class CITAsController : Controller
    {
        private DBCentro_medicoEntities db = new DBCentro_medicoEntities();

        // GET: CITAs
        public ActionResult Index()
        {
            var cITA = db.CITA.Include(c => c.MEDICO).Include(c => c.PACIENTE);
            return View(cITA.ToList());
        }

        // GET: CITA Detalles
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            return View(cITA);
        }

        // GET: CITA Nueva
        public ActionResult Create()
        {
            ViewBag.codigoM = new SelectList(db.MEDICO, "codigoM", "codigoM");
            ViewBag.codigoP = new SelectList(db.PACIENTE, "codigoP", "nombresP");
            return View();
        }

        // POST: CITA Nueva
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoCita,codigoM,codigoP,fechaInicio,fechaFin,estadoCita,fechaProximaCita")] CITA cITA)
        {
            if (ModelState.IsValid)
            {
                db.CITA.Add(cITA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoM = new SelectList(db.MEDICO, "codigoM", "codigoM", cITA.codigoM);
            ViewBag.codigoP = new SelectList(db.PACIENTE, "codigoP", "nombresP", cITA.codigoP);
            return View(cITA);
        }

        // GET: CITA Modificar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoM = new SelectList(db.MEDICO, "codigoM", "codigoM", cITA.codigoM);
            ViewBag.codigoP = new SelectList(db.PACIENTE, "codigoP", "nombresP", cITA.codigoP);
            return View(cITA);
        }

        // POST: CITA Modificar
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoCita,codigoM,codigoP,fechaInicio,fechaFin,estadoCita,fechaProximaCita")] CITA cITA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cITA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoM = new SelectList(db.MEDICO, "codigoM", "codigoM", cITA.codigoM);
            ViewBag.codigoP = new SelectList(db.PACIENTE, "codigoP", "nombresP", cITA.codigoP);
            return View(cITA);
        }

        // GET: CITA Eliminar
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CITA cITA = db.CITA.Find(id);
            if (cITA == null)
            {
                return HttpNotFound();
            }
            return View(cITA);
        }

        // POST: CITA Eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CITA cITA = db.CITA.Find(id);
            db.CITA.Remove(cITA);
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
