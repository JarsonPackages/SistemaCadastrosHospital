using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoC._03_MODEL
{
    public class Medico
    {
        public int ID { get; set; }
        public int CRM { get; set; }  
        public string Especializacao { get; set; }     
        public string Nome { get; set; }
    }
}
