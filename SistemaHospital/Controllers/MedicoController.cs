using ProjetoC._03_MODEL;
using ProjetoC._04_Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaHospital.Controllers
{
    public class MedicoController : Controller
    {
        MedicoServices services = new MedicoServices();
        // GET: Medico
        public ActionResult Index()
        {
           
            return View(services.GetAll().ToList<Medico>());
        }
        public MedicoController()
        {
            using (var medico = new MedicoServices())
            {
                ViewBag.qtdMedico = medico.GetAll().Count;
            }
            using (var paciente = new PacienteServices())
            {
                ViewBag.qtdPaciente = paciente.GetAll().Count;
            }
        }

        // GET: Medico/Details/5
        public ActionResult Details(int id)
        {
           
            return View(services.Get(id));
        }

        // GET: Medico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medico/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medico _user)
        {
            try
            {
                services.Insert(_user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medico/Edit/5
        public ActionResult Edit(int id)
        {

            return View(services.Get(id));
        }

        // POST: Medico/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medico _user)
        {
            try
            {
                services.Update(_user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Medico/Delete/5
        public ActionResult Delete(int id)
        {
            return View(services.Get(id));
        }

        // POST: Medico/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Medico _user)
        {
            try
            {
                var med = services.Get(id);
                services.Delete(med);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
