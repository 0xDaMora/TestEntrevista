using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestTrabajo;

namespace TestTrabajo.Controllers
{

    //Crud
    public class registrosController : Controller
    {

        //Uso el modelo de entity framework de la bd de sql server local.
        private TestEntrevistaEntities db = new TestEntrevistaEntities();

        // GET: registros
        public ActionResult Index()
        {
            
            return View(db.registros.ToList());
        }

        // GET: registros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registros registros = db.registros.Find(id);
            if (registros == null)
            {
                return HttpNotFound();
            }
            return View(registros);
        }

        // GET: registros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: registros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,idioma,descripcion")] registros registros)
        {
            if (ModelState.IsValid)
            {
                //Si el nombre ,idioma o descripcion se encuentran nulos se agrego el error al Modelo.
                if (string.IsNullOrEmpty(registros.nombre) ||
                    string.IsNullOrEmpty(registros.idioma) ||
                    string.IsNullOrEmpty(registros.descripcion))
                {
                    ModelState.AddModelError("", "Todos los campos son requeridos.");
                    return View(registros);
                }

                // Validar que no exista un registro previamente guardado del mismo nombre con el mismo idioma
                if (db.registros.Any(r => r.nombre == registros.nombre && r.idioma == registros.idioma))
                {
                    ModelState.AddModelError("", "Ya existe un registro con este nombre e idioma.");
                    return View(registros);
                }

                db.registros.Add(registros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registros);
        }

        // GET: registros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registros registros = db.registros.Find(id);
            if (registros == null)
            {
                return HttpNotFound();
            }
            return View(registros);
        }

        // POST: registros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,idioma,descripcion")] registros registros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registros);
        }

        // GET: registros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registros registros = db.registros.Find(id);
            if (registros == null)
            {
                return HttpNotFound();
            }
            return View(registros);
        }

        // POST: registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registros registros = db.registros.Find(id);
            db.registros.Remove(registros);
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
