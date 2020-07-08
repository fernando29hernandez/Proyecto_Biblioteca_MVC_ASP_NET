using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using proyecto.Models;

namespace proyecto.Controllers
{
    public class LibroController : Controller
    {
        private proyectoclaseEntities db = new proyectoclaseEntities();

        // GET: Libro
        public ActionResult Index(string autor,string categoria)
        {
            var libro = db.Libro.Include(l => l.Autor).Include(l => l.Categoria);
            if (!String.IsNullOrEmpty(autor))
            {
                libro = libro.Where(s => s.Autor.nombre.Contains(autor));
            }
            if (!String.IsNullOrEmpty(categoria))
            {
                libro = libro.Where(s => s.Categoria.categoria1.Contains(categoria));
            }
            return View(libro.ToList());
        }

        // GET: Libro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            ViewBag.id_autor = new SelectList(db.Autor, "id_autor", "nombre");
            ViewBag.id_categoria = new SelectList(db.Categoria, "id_categoria", "categoria1");
            return View();
        }

        // POST: Libro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_libro,titulo,publicacion,id_categoria,id_autor")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Libro.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_autor = new SelectList(db.Autor, "id_autor", "nombre", libro.id_autor);
            ViewBag.id_categoria = new SelectList(db.Categoria, "id_categoria", "categoria1", libro.id_categoria);
            return View(libro);
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_autor = new SelectList(db.Autor, "id_autor", "nombre", libro.id_autor);
            ViewBag.id_categoria = new SelectList(db.Categoria, "id_categoria", "categoria1", libro.id_categoria);
            return View(libro);
        }

        // POST: Libro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_libro,titulo,publicacion,id_categoria,id_autor")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_autor = new SelectList(db.Autor, "id_autor", "nombre", libro.id_autor);
            ViewBag.id_categoria = new SelectList(db.Categoria, "id_categoria", "categoria1", libro.id_categoria);
            return View(libro);
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = db.Libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Libro libro = db.Libro.Find(id);
            db.Libro.Remove(libro);
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
