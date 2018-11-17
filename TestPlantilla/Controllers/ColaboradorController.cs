using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestPlantilla.Models;

namespace TestPlantilla.Controllers
{
    public class ColaboradorController : Controller
    {
        dimacodevEntities dd = new dimacodevEntities();
        // GET: Colaborador
        public ActionResult Index()
        {
            ViewBag.Title = "Colaboradores";
            return View();
        }

        public JsonResult GetColaboradores()
        {
            List<ColaboradorView> colaborador = dd.colaborador.Select(c => new ColaboradorView
            {
                run = c.run,
                rut = c.rut,
                nombre = c.nombre,
                apellidoPaterno = c.apellidoPaterno,
                apellidoMaterno = c.apellidoMaterno,
                edad = c.edad,
                cargo = c.cargo,
                telefono = c.telefono,
                valorHoraExtra = c.valorHoraExtra
            }).ToList();
            return Json(new { data = colaborador }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Guardar(int run)
        {
            var cb = dd.colaborador.Where(c => c.run == run).FirstOrDefault();
            return View(cb);
        }

        [HttpPost]
        public ActionResult Guardar(colaborador col)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                    if (col.run > 0)
                    {
                        //Edit 
                        var cb = dd.colaborador.Where(c => c.run == col.run).FirstOrDefault();
                        if (cb != null)
                        {
                            cb.run = col.run;
                            cb.rut = col.rut;
                            cb.nombre = col.nombre;
                            cb.apellidoPaterno = col.apellidoPaterno;
                            cb.apellidoMaterno = col.apellidoMaterno;
                            cb.edad = col.edad;
                            cb.cargo = col.cargo;
                            cb.telefono = col.telefono;
                            cb.valorHoraExtra = col.valorHoraExtra;
                        }   
                    }
                    else
                    {
                        //Save
                        dd.colaborador.Add(col);
                    }
                    dd.SaveChanges();
                    status = true;
                
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Eliminar(int run)
        {
            var cb = dd.colaborador.Where(c => c.run == run).FirstOrDefault();
            if (cb!= null)
                {
                    return View(cb);
                }
                else
                {
                    return HttpNotFound();
                }
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult EliminarColaborador(int run)
        {
            bool status = false;
                var cb = dd.colaborador.Where(c => c.run == run).FirstOrDefault();
                if (cb != null)
                {
                    dd.colaborador.Remove(cb);
                    dd.SaveChanges();
                    status = true;
                }
            return new JsonResult { Data = new { status = status } };
        }
    }
}