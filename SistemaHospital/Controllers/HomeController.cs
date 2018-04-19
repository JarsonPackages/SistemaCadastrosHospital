using ProjetoC._03_MODEL;
using ProjetoC._04_Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaHospital.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ModelState.AddModelError("oi.....................",new Exception());
            using(var medico = new MedicoServices())
            {
                ViewBag.qtdMedico = medico.GetAll().Count;
            }
            

            using (var paciente = new PacienteServices())
            {
                ViewBag.qtdPaciente = paciente.GetAll().Count;
            }

             
            return View();
        }
      
    }
}