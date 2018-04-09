﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoC._03_MODEL
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0,9999)]
        public int IdMedico { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        [StringLength(11,MinimumLength =10)]
        public string Cpf { get; set; }
        [Required]
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }    
        public string UF  { get; set; }
        public string Cidade { get; set; }
        

    }
}
