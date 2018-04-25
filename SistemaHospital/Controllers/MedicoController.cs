using ProjetoC._03_MODEL;
using ProjetoC._04_Dominio;
using SistemaHospital._04_Dominio.Ultil;
using SistemaHospital._04_Dominio.Validar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ActionResult Details(int id)
        {
           
            return View(services.Get(id));
        }   
        public ActionResult Create()
        {
            return View();
        }     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Medico _user)
        {
            if (services.Insert(_user))
            {
                return RedirectToAction("Index");
               
            }
            else
            {
              
                foreach (var erro in ValidaMedico.erroMed)
                {
                    
                        ModelState.AddModelError(erro.campo,erro.msg);
                   
                }
                SistemaHospital._04_Dominio.Validar.ValidaMedico.erroMed.Clear();
                return View();
            }
                

               
            
           
        }    
        public ActionResult Edit(int id)
        {

            return View(services.Get(id));
        }   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Medico _user)
        {
            if (services.Update(_user))
            {
                return RedirectToAction("Index");

            }
            else
            {

                foreach (var erro in ValidaMedico.erroMed)
                {

                    ModelState.AddModelError(erro.campo, erro.msg);

                }
                SistemaHospital._04_Dominio.Validar.ValidaMedico.erroMed.Clear();
                return View();
            }
        }   
        public ActionResult Delete(int id)
        {
            return View(services.Get(id));
        }    
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
