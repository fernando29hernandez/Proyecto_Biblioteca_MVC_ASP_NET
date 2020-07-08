using proyecto.Models;
using proyecto.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Controllers
{
    public class AutorController : Controller
    {
        
        public ActionResult Index()
        {
            List<ListAutorViewModel> lst;
            using (proyectoclaseEntities db = new proyectoclaseEntities())
            {
                lst = (from d in db.Autor
                       select new ListAutorViewModel
                       {
                           id_autor = d.id_autor,
                           nombre = d.nombre,

                       }).ToList();

            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(AutorViewModel model) {


            try {

                if (ModelState.IsValid)
                {
                    using (proyectoclaseEntities db = new proyectoclaseEntities())
                    {
                        var oAutor = new Autor();
                        oAutor.nombre = model.nombre;
                        db.Autor.Add(oAutor);
                        db.SaveChanges();


                    }
                    return Redirect("~/Autor/");
                }
                return View(model);
            } catch (Exception EX)
            {


            }
            return View();
        }
        public ActionResult Editar(int id)
        {
            AutorViewModel modelo = new AutorViewModel();
            using (proyectoclaseEntities db = new proyectoclaseEntities())
            {
                var elemento = db.Autor.Find(id);
                modelo.nombre = elemento.nombre;
                modelo.id_autor = elemento.id_autor;

            }
                return View(modelo);
        }
        [HttpPost]
        public ActionResult Editar(AutorViewModel model)
        {


            try
            {

                if (ModelState.IsValid)
                {
                    using (proyectoclaseEntities db = new proyectoclaseEntities())
                    {
                        var oAutor = db.Autor.Find(model.id_autor);
                        oAutor.nombre = model.nombre;
                        db.Entry(oAutor).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }
                    return Redirect("~/Autor/");
                }
                return View(model);
            }
            catch (Exception EX)
            {


            }
            return View();
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            AutorViewModel modelo = new AutorViewModel();
            using (proyectoclaseEntities db = new proyectoclaseEntities())
            {
                
                var elemento = db.Autor.Find(id);
                db.Autor.Remove(elemento);
                db.SaveChanges();
            }
            return Redirect("~/Autor/");
        }
    }


}