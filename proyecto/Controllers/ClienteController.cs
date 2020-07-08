using proyecto.Models;
using proyecto.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            List<ListClienteViewModel> lst;
            using (proyectoclaseEntities db = new proyectoclaseEntities())
            {
                lst = (from d in db.Cliente
                       select new ListClienteViewModel
                       {
                           id_cliente = d.id_cliente,
                           nombre = d.nombre,
                           celular = d.celular,
                           nit = d.nit,
                           dpi = d.dpi

                       }).ToList();

            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(ClienteViewModel model)
        {


            try
            {

                if (ModelState.IsValid)
                {
                    using (proyectoclaseEntities db = new proyectoclaseEntities())
                    {
                        var oCliente = new Cliente();
                        oCliente.nombre = model.nombre;
                        oCliente.celular = model.celular;
                        oCliente.nit = model.nit;
                        oCliente.dpi = model.dpi;
                        db.Cliente.Add(oCliente);
                        db.SaveChanges();


                    }
                    return Redirect("~/Cliente/");
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
            ClienteViewModel modelo = new ClienteViewModel();
            using (proyectoclaseEntities db = new proyectoclaseEntities())
            {
                var elemento = db.Cliente.Find(id);
                modelo.nombre = elemento.nombre;
                modelo.celular = elemento.celular;
                modelo.nit = elemento.nit;
                modelo.dpi = elemento.dpi;
                modelo.id_cliente = elemento.id_cliente;
            }
            return View(modelo);
        }
        [HttpPost]
        public ActionResult Editar(ClienteViewModel model)
        {


            try
            {

                if (ModelState.IsValid)
                {
                    using (proyectoclaseEntities db = new proyectoclaseEntities())
                    {
                        var oCliente = db.Cliente.Find(model.id_cliente);
                        oCliente.nombre = model.nombre;
                        oCliente.celular = model.celular;
                        oCliente.nit= model.nit;
                        oCliente.dpi= model.dpi;

                        db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();


                    }
                    return Redirect("~/Cliente/");
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

                var elemento = db.Cliente.Find(id);
                db.Cliente.Remove(elemento);
                db.SaveChanges();
            }
            return Redirect("~/Cliente/");
        }
    }
}