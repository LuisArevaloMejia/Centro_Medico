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
    public class EMPLEADOesController : Controller
    {
        private DBCentro_medicoEntities db = new DBCentro_medicoEntities();

        // GET: EMPLEADO
        public ActionResult Index()
        {
            var eMPLEADO = db.EMPLEADO.Include(e => e.TIPO_EMPLEADO);
            return View(eMPLEADO.ToList());
        }

        // GET: EMPLEADO detalles
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // GET: EMPLEADOes nuevo
        public ActionResult Create()
        {
            ViewBag.codigoTipEmp = new SelectList(db.TIPO_EMPLEADO, "coidgoTipEmp", "descripccionTipEmp");
            return View();
        }

        // POST: EMPLEADO nuevo
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoEmp,codigoTipEmp,nombresEmp,apPaternoEmp,apMaternoEmp,dpiEmp,Colegiago,sexoEmp,fechaNacimientoEmp")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.EMPLEADO.Add(eMPLEADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoTipEmp = new SelectList(db.TIPO_EMPLEADO, "coidgoTipEmp", "descripccionTipEmp", eMPLEADO.codigoTipEmp);
            return View(eMPLEADO);
        }

        // GET: EMPLEADO modificar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoTipEmp = new SelectList(db.TIPO_EMPLEADO, "coidgoTipEmp", "descripccionTipEmp", eMPLEADO.codigoTipEmp);
            return View(eMPLEADO);
        }

        // POST: EMPLEADO modificar
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoEmp,codigoTipEmp,nombresEmp,apPaternoEmp,apMaternoEmp,dpiEmp,Colegiago,sexoEmp,fechaNacimientoEmp")] EMPLEADO eMPLEADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLEADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoTipEmp = new SelectList(db.TIPO_EMPLEADO, "coidgoTipEmp", "descripccionTipEmp", eMPLEADO.codigoTipEmp);
            return View(eMPLEADO);
        }

        // GET: EMPLEADO eliminar
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return HttpNotFound();
            }
            return View(eMPLEADO);
        }

        // POST: EMPLEADOes eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            db.EMPLEADO.Remove(eMPLEADO);
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
