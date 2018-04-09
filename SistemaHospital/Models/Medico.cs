using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoC._03_MODEL
{
    class Medico
    {
        [Required]
        public int CRM { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Especializacao { get; set; }
        public string Nome { get; set; }
       

    }
}
