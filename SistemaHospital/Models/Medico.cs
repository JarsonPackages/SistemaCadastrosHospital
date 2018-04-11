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
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Digite seu CRM", AllowEmptyStrings =false)]
        public int CRM { get; set; }
        [Required(ErrorMessage ="É obrigatório fornecer sua Especialização!", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string Especializacao { get; set; }
        [Required]
        public string Nome { get; set; }
       

    }
}
