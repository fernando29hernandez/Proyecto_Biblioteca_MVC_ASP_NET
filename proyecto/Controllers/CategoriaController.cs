using proyecto.Models;
using proyecto.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Controllers
{
    public class CategoriaController : Controller
    {

        public ActionResult Index()
        {
            List<ListCategoriaViewModel> lst;
            using (proyectoclaseEntities db = new proyectoclaseEntities())
            {
                lst = (from d in db.Categoria
                       select new ListCategoriaViewModel
                       {
                           id_categoria = d.id_categoria,
                           categoria = d.categoria1,

                       }).ToList();

            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(CategoriaViewModel model)
        {


            try
            {

                if (ModelState.IsValid)
                {
                    using (proyectoclaseEntities db = new proyectoclaseEntities())
                    {
                        var oCategoria = new Categoria();
                        oCategoria.categoria1 = model.categoria;
                        db.Categoria.Add(oCategoria);
                        db.SaveChanges();


                    }
                    return Redirect("~/Categoria/");
                }
                return View(model);
            }
            catch (Exception EX)
            {


            }
            return View();
        }
        public ActionResult Editar(int id)
        {
            CategoriaViewModel modelo = new CategoriaViewModel();
            using (proyectoclaseEntities db = new proyectoclaseEntities())
            {
                var elemento = db.Categoria.Find(id);
                modelo.categoria = elemento.categoria1;
                modelo.id_categoria = elemento.id_categoria;

            }
            return View(modelo);
        }
        [HttpPost]
        public ActionResult Editar(CategoriaViewModel model)
        {


            try
            {

                if (ModelState.IsValid)
                {
                    using (proyectoclaseEntities db = new proyectoclaseEntities())
                    {
                        var oAutor = db.Categoria.Find(model.id_categoria);
                        oAutor.categoria1 = model.categoria;
                        db.Entry(oAutor).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }
                    return Redirect("~/Categoria/");
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
            ClienteViewModel modelo = new ClienteViewModel();
            using (proyectoclaseEntities db = new proyectoclaseEntities())
            {

                var elemento = db.Categoria.Find(id);
                db.Categoria.Remove(elemento);
                db.SaveChanges();
            }
            return Redirect("~/Categoria/");
        }
    }
}