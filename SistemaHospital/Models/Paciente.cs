using ProjetoC._04_Dominio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProjetoC._03_MODEL
{
    public class Paciente
    {     
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public int IdMedico { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }

        public List<Medico> Medicos
        {
            get
            {
              using(var med = new MedicoServices())
                {
                    return med.GetAll();
                }
               
            }
           private set
            {

            }
        }
        
    }
}
