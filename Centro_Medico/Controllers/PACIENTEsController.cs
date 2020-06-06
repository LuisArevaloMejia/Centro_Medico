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
    public class PACIENTEsController : Controller
    {
        private DBCentro_medicoEntities db = new DBCentro_medicoEntities();

        // GET: PACIENTEs
        public ActionResult Index()
        {
            return View(db.PACIENTE.ToList());
        }

        // GET: PACIENTE detalles
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            if (pACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(pACIENTE);
        }

        // GET: PACIENTE nuevo
        public ActionResult Create()
        {
            return View();
        }

        // POST: PACIENTE nuevo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoP,nombresP,apPaterno,apMaterno,fechaNacimientoP,sexoP,dpiP,direccionP,telefonoP,estado")] PACIENTE pACIENTE)
        {
            if (ModelState.IsValid)
            {
                db.PACIENTE.Add(pACIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pACIENTE);
        }

        // GET: PACIENTEs modificar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            if (pACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(pACIENTE);
        }

        // POST: PACIENTEs modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoP,nombresP,apPaterno,apMaterno,fechaNacimientoP,sexoP,dpiP,direccionP,telefonoP,estado")] PACIENTE pACIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pACIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pACIENTE);
        }

        // GET: PACIENTEs eliminar
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            if (pACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(pACIENTE);
        }

        // POST: PACIENTEs eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PACIENTE pACIENTE = db.PACIENTE.Find(id);
            db.PACIENTE.Remove(pACIENTE);
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
