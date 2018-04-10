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
        [Required(ErrorMessage ="Digite seu CRM", AllowEmptyStrings =false)]
        public int CRM { get; set; }
        [Required(ErrorMessage ="É obrigstório fornecer sua Especialização!", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string Especializacao { get; set; }
        public string Nome { get; set; }
       

    }
}
