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
    }
}