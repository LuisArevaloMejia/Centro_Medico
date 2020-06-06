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
    public class ESPECIALIDADsController : Controller
    {
        private DBCentro_medicoEntities db = new DBCentro_medicoEntities();

        // GET: ESPECIALIDADs
        public ActionResult Index()
        {
            return View(db.ESPECIALIDAD.ToList());
        }

        // GET: ESPECIALIDAD detalles
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD eSPECIALIDAD = db.ESPECIALIDAD.Find(id);
            if (eSPECIALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(eSPECIALIDAD);
        }

        // GET: ESPECIALIDAD nuevo
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESPECIALIDAD nuevo
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoEsp,esatadoEsp,NombreEsp,descripccionEsp")] ESPECIALIDAD eSPECIALIDAD)
        {
            if (ModelState.IsValid)
            {
                db.ESPECIALIDAD.Add(eSPECIALIDAD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSPECIALIDAD);
        }

        // GET: ESPECIALIDAD modificar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD eSPECIALIDAD = db.ESPECIALIDAD.Find(id);
            if (eSPECIALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(eSPECIALIDAD);
        }

        // POST: ESPECIALIDAD modificar
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoEsp,esatadoEsp,NombreEsp,descripccionEsp")] ESPECIALIDAD eSPECIALIDAD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSPECIALIDAD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSPECIALIDAD);
        }

        // GET: ESPECIALIDAD eliminar
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESPECIALIDAD eSPECIALIDAD = db.ESPECIALIDAD.Find(id);
            if (eSPECIALIDAD == null)
            {
                return HttpNotFound();
            }
            return View(eSPECIALIDAD);
        }

        // POST: ESPECIALIDAD eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESPECIALIDAD eSPECIALIDAD = db.ESPECIALIDAD.Find(id);
            db.ESPECIALIDAD.Remove(eSPECIALIDAD);
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
