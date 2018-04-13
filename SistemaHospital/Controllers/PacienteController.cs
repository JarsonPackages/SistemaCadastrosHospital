using ProjetoC._03_MODEL;
using ProjetoC._04_Dominio;
using SistemaHospital.ApiCorreiosCep;
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
        public ActionResult ExCreate()
        {
            return View();
        }
        // GET: Paciente/Create
        public ActionResult Create()
        {



            Paciente paciente = new Paciente(true);

            return View(paciente);
        }



        // POST: Paciente/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente _user)
        {
           
            Paciente paciente = new Paciente(true);

            if (services.Insert(_user))
            {
                return RedirectToAction("Index");
            }
            else
            {

                return View(paciente);
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
