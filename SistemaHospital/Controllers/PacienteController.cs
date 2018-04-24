using ProjetoC._03_MODEL;
using ProjetoC._04_Dominio;
using ProjetoC._04_Dominio.Validar;
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

        // GET: Paciente/Create
       
        public ActionResult Create()
        {
         
            return View();
        }


        public PacienteController()
        {
            MedicoServices med = new MedicoServices();
            Paciente paciente = new Paciente();
            ViewBag.IdMedico = new SelectList(med.GetAll(), "Id", "Nome");
            ViewBag.qtdMedico = med.GetAll().Count;
            ViewBag.qtdPaciente = services.GetAll().Count;
        }


        // POST: Paciente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paciente _user)
        {

            if (services.Insert(_user))
            {

                return RedirectToAction("Index");

            }
            else
            {
                foreach (var erro in ValidaPaciente.erroMed)
                {

                    ModelState.AddModelError(erro.campo, erro.msg);


                }
                ValidaPaciente.erroMed.Clear();
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Paciente _user)
        {
            if (services.Update(_user))
            {

                return RedirectToAction("Index");

            }
            else
            {
                foreach (var erro in ValidaPaciente.erroMed)
                {

                    ModelState.AddModelError(erro.campo, erro.msg);


                }
                ValidaPaciente.erroMed.Clear();
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
        [ValidateAntiForgeryToken]
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
