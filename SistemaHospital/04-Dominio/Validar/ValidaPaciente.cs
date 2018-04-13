using ProjetoC._03_MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoC._04_Dominio.Validar
{
    public static class ValidaPaciente
    {
        
        public static bool Validar(Paciente _paciente)
        {
           
            if (!String.IsNullOrEmpty(_paciente.Cpf) && _paciente.Cpf.Length == 11)
            {
                if (!String.IsNullOrEmpty(_paciente.Email) && Email(_paciente.Email))
                {
                    if(!String.IsNullOrEmpty(_paciente.Cep) && !String.IsNullOrEmpty(_paciente.Nome))
                    {
                    
                            return true;
                        
                         
                        

                        
                    }

                    return false;
                }
                else
                {


                    return false;
                }
            }
            else
            {

                return false;
            }

           
        }
        private static bool Email(string _email)
        {
            bool _emailvalidado = Regex.IsMatch(_email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return _emailvalidado;
        }
    }
}
