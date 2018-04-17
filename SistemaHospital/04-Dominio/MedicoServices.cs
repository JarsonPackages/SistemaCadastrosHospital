using ProjetoC._02_REPOSITORIO;
using ProjetoC._02_REPOSITORIO._01_CORE;
using ProjetoC._03_MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoC._04_Dominio
{
    class MedicoServices : IServices<Medico>,IDisposable
    { 
        MedicoRepositorio repositorio = new MedicoRepositorio();     
        public Medico Get(int _user)
        {     
            var _medico = repositorio.GetById(_user);    
            return _medico;
        }
        public List<Medico> GetAll()
        {
            List<Medico> pacientes = new List<Medico>();
            pacientes = repositorio.GetAll();
           
            return pacientes;
        }       
        public bool Insert(Medico _user)
        {
            
                
            return     repositorio.Insert(_user);
             
           
          
        }
        public bool Delete(Medico _user)
        {
          
            
           return     repositorio.Delete(_user);
              
            

        }
        public bool Update(Medico _user)
        {
           return  repositorio.Update(_user);
        }
        public void Dispose()
        {
           //disposable
        }     
    }
}
