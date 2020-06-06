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
    public class MedicosController : Controller
    {
        private DBCentro_medicoEntities db = new DBCentro_medicoEntities();

        // GET: Medicos
        public ActionResult Index()
        {
            var mEDICO = db.MEDICO.Include(m => m.EMPLEADO).Include(m => m.ESPECIALIDAD);
            return View(mEDICO.ToList());
        }

        // GET: Medicos detalles
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICO mEDICO = db.MEDICO.Find(id);
            if (mEDICO == null)
            {
                return HttpNotFound();
            }
            return View(mEDICO);
        }

        // GET: Medicos nuevo
        public ActionResult Create()
        {
            ViewBag.codigoEmp = new SelectList(db.EMPLEADO, "codigoEmp", "nombresEmp");
            ViewBag.codigoEsp = new SelectList(db.ESPECIALIDAD, "codigoEsp", "NombreEsp");
            return View();
        }

        // POST: Medicos nuevo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoM,codigoEmp,codigoEsp,estadoM")] MEDICO mEDICO)
        {
            if (ModelState.IsValid)
            {
                db.MEDICO.Add(mEDICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoEmp = new SelectList(db.EMPLEADO, "codigoEmp", "nombresEmp", mEDICO.codigoEmp);
            ViewBag.codigoEsp = new SelectList(db.ESPECIALIDAD, "codigoEsp", "NombreEsp", mEDICO.codigoEsp);
            return View(mEDICO);
        }

        // GET: Medicos modificar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICO mEDICO = db.MEDICO.Find(id);
            if (mEDICO == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoEmp = new SelectList(db.EMPLEADO, "codigoEmp", "nombresEmp", mEDICO.codigoEmp);
            ViewBag.codigoEsp = new SelectList(db.ESPECIALIDAD, "codigoEsp", "NombreEsp", mEDICO.codigoEsp);
            return View(mEDICO);
        }

        // POST: Medicos modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoM,codigoEmp,codigoEsp,estadoM")] MEDICO mEDICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEDICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoEmp = new SelectList(db.EMPLEADO, "codigoEmp", "nombresEmp", mEDICO.codigoEmp);
            ViewBag.codigoEsp = new SelectList(db.ESPECIALIDAD, "codigoEsp", "NombreEsp", mEDICO.codigoEsp);
            return View(mEDICO);
        }

        // GET: Medicos eliminar
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEDICO mEDICO = db.MEDICO.Find(id);
            if (mEDICO == null)
            {
                return HttpNotFound();
            }
            return View(mEDICO);
        }

        // POST: Medicos eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MEDICO mEDICO = db.MEDICO.Find(id);
            db.MEDICO.Remove(mEDICO);
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
