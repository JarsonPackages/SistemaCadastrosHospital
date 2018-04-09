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
            _paciente.isValido = false;
            if (!String.IsNullOrEmpty(_paciente.Cpf) && _paciente.Cpf.Length == 14)
            {
                if (!String.IsNullOrEmpty(_paciente.Email) && Email(_paciente.Email))
                {
                    if(!String.IsNullOrEmpty(_paciente.Cep) && !String.IsNullOrEmpty(_paciente.Nome))
                    {
                        _paciente.isValido = true;
                        return _paciente.isValido;
                    }

                    return _paciente.isValido;
                }
                else
                {

                    System.Windows.Forms.MessageBox.Show("Email ínvalido ");
                    return _paciente.isValido;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Cpf Invalido");
                return _paciente.isValido;
            }

           
        }
        private static bool Email(string _email)
        {
            bool _emailvalidado = Regex.IsMatch(_email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return _emailvalidado;
        }
    }
}
