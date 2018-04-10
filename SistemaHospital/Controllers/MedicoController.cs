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
        public ActionResult Delete(int id, Medico _user)
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
