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
            PacienteServices pac = new PacienteServices();
            MedicoServices med = new MedicoServices();

            ViewBag.qtdMedico = med.GetAll().Count;
            ViewBag.qtdPaciente = pac.GetAll().Count;
            return View();
        }
      
    }
}