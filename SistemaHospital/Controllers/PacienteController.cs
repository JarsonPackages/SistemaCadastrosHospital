using ProjetoC._03_MODEL;
using ProjetoC._04_Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaHospital.Controllers
{
    public class PacienteController : Controller
    {
        
        
        PacienteServices services = new PacienteServices();
        // GET: Paciente
        public ActionResult Index()
        {
           
                return View(services.GetAll().ToList<Paciente>());
           
           
           
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int id)
        {
            return View(services.Get(id));
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        [HttpPost]
        public ActionResult Create(Paciente _user)
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

        // GET: Paciente/Edit/5
        public ActionResult Edit(int id)
        {
            return View(services.Get(id));
        }

        // POST: Paciente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Paciente _user)
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

        // GET: Paciente/Delete/5
        public ActionResult Delete(int id)
        {
            return View(services.Get(id));
        }

        // POST: Paciente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Paciente _user)
        {
            try
            {
                services.Delete(_user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
