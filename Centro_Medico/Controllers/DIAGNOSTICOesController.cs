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
    public class DIAGNOSTICOesController : Controller
    {
        private DBCentro_medicoEntities db = new DBCentro_medicoEntities();

        // GET: DIAGNOSTICOes
        public ActionResult Index()
        {
            var dIAGNOSTICO = db.DIAGNOSTICO.Include(d => d.CITA);
            return View(dIAGNOSTICO.ToList());
        }

        // GET: DIAGNOSTICO Detalles
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIAGNOSTICO dIAGNOSTICO = db.DIAGNOSTICO.Find(id);
            if (dIAGNOSTICO == null)
            {
                return HttpNotFound();
            }
            return View(dIAGNOSTICO);
        }

        // GET: DIAGNOSTICOes/Create
        public ActionResult Create()
        {
            ViewBag.codigoCita = new SelectList(db.CITA, "codigoCita", "estadoCita");
            return View();
        }

        // POST: DIAGNOSTICO Nuevo
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoDiag,codigoCita,nombreDiag,tipoDiag,Observaciones,fotografias,medicamentos,fechaEmision")] DIAGNOSTICO dIAGNOSTICO)
        {
            if (ModelState.IsValid)
            {
                db.DIAGNOSTICO.Add(dIAGNOSTICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoCita = new SelectList(db.CITA, "codigoCita", "estadoCita", dIAGNOSTICO.codigoCita);
            return View(dIAGNOSTICO);
        }

        // GET: DIAGNOSTICO Modificar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIAGNOSTICO dIAGNOSTICO = db.DIAGNOSTICO.Find(id);
            if (dIAGNOSTICO == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoCita = new SelectList(db.CITA, "codigoCita", "estadoCita", dIAGNOSTICO.codigoCita);
            return View(dIAGNOSTICO);
        }

        // POST: DIAGNOSTICO Modificar
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoDiag,codigoCita,nombreDiag,tipoDiag,Observaciones,fotografias,medicamentos,fechaEmision")] DIAGNOSTICO dIAGNOSTICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIAGNOSTICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoCita = new SelectList(db.CITA, "codigoCita", "estadoCita", dIAGNOSTICO.codigoCita);
            return View(dIAGNOSTICO);
        }

        // GET: DIAGNOSTICO Eliminar
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIAGNOSTICO dIAGNOSTICO = db.DIAGNOSTICO.Find(id);
            if (dIAGNOSTICO == null)
            {
                return HttpNotFound();
            }
            return View(dIAGNOSTICO);
        }

        // POST: DIAGNOSTICO Eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIAGNOSTICO dIAGNOSTICO = db.DIAGNOSTICO.Find(id);
            db.DIAGNOSTICO.Remove(dIAGNOSTICO);
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
