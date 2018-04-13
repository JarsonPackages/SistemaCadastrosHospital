﻿using ProjetoC._04_Dominio;
using System;
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
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string Cep { get; set; }
        [Required]
        [Display(Name = "Médico")]
        public int IdMedico { get; set; }  
        public string Rua { get; set; }
        public string Bairro { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string UF { get; set; }
        public string Cidade { get; set; }
        public List<Medico> Medicos { get; set; }

        public Paciente(bool prmCarregarMedicos)
        {
            if (prmCarregarMedicos)
            {
                MedicoServices Servico = new MedicoServices();
                this.Medicos = Servico.GetAll();
            }
        }

        public Paciente()
        {
            
        }
    }
}
