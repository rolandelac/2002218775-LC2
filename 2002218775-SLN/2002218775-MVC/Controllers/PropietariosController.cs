using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2002218775_ENT;
using _2002218775_PER;

namespace _2002218775_MVC.Controllers
{
    public class PropietariosController : Controller
    {
        private _2002218775DbContext db = new _2002218775DbContext();

        // GET: Propietarios
        public ActionResult Index()
        {
            var propietarios = db.Propietarios.Include(p => p.Carro);
            return View(propietarios.ToList());
        }

        // GET: Propietarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // GET: Propietarios/Create
        public ActionResult Create()
        {
            ViewBag.PropietarioId = new SelectList(db.Carros, "CarroId", "NumSerieMotor");
            return View();
        }

        // POST: Propietarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropietarioId,DNI,Nombres,Apellidos,LicenciaConducir,CarroId")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                db.Propietarios.Add(propietario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropietarioId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", propietario.PropietarioId);
            return View(propietario);
        }

        // GET: Propietarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropietarioId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", propietario.PropietarioId);
            return View(propietario);
        }

        // POST: Propietarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropietarioId,DNI,Nombres,Apellidos,LicenciaConducir,CarroId")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propietario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropietarioId = new SelectList(db.Carros, "CarroId", "NumSerieMotor", propietario.PropietarioId);
            return View(propietario);
        }

        // GET: Propietarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propietario propietario = db.Propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // POST: Propietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Propietario propietario = db.Propietarios.Find(id);
            db.Propietarios.Remove(propietario);
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
