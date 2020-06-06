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
    public class TIPO_EMPLEADOController : Controller
    {
        private DBCentro_medicoEntities db = new DBCentro_medicoEntities();

        // GET: TIPO_EMPLEADO
        public ActionResult Index()
        {
            return View(db.TIPO_EMPLEADO.ToList());
        }

        // GET: TIPO_EMPLEADO detalles
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_EMPLEADO tIPO_EMPLEADO = db.TIPO_EMPLEADO.Find(id);
            if (tIPO_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_EMPLEADO);
        }

        // GET: TIPO_EMPLEADO nuevo
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_EMPLEADO nuevo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "coidgoTipEmp,descripccionTipEmp,estadoTipEmp")] TIPO_EMPLEADO tIPO_EMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_EMPLEADO.Add(tIPO_EMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_EMPLEADO);
        }

        // GET: TIPO_EMPLEADO modificar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_EMPLEADO tIPO_EMPLEADO = db.TIPO_EMPLEADO.Find(id);
            if (tIPO_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_EMPLEADO);
        }

        // POST: TIPO_EMPLEADO modificar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "coidgoTipEmp,descripccionTipEmp,estadoTipEmp")] TIPO_EMPLEADO tIPO_EMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_EMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_EMPLEADO);
        }

        // GET: TIPO_EMPLEADO eliminar
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_EMPLEADO tIPO_EMPLEADO = db.TIPO_EMPLEADO.Find(id);
            if (tIPO_EMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_EMPLEADO);
        }

        // POST: TIPO_EMPLEADO eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_EMPLEADO tIPO_EMPLEADO = db.TIPO_EMPLEADO.Find(id);
            db.TIPO_EMPLEADO.Remove(tIPO_EMPLEADO);
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
