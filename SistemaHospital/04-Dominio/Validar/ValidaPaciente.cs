

using ProjetoC._03_MODEL;
using SistemaHospital._04_Dominio.Ultil;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjetoC._04_Dominio.Validar
{
    public static class ValidaPaciente
    {
        public static List<Erro> erroMed = new List<Erro>();

        public static bool validar(Paciente _classe)
        {
            //Nome
            if (UltilStr.StrPadrao(_classe.Nome))
                Debug.WriteLine("nome ok");
            else
                erroMed.Add(new Erro("Nome", string.Format(UltilStr.exibirErros, "Nome")));
            //Email
            if (UltilStr.StrPadrao(_classe.Email,TiposDeDados.Email))
                Debug.WriteLine("email ok");
            else
                erroMed.Add(new Erro("Email", string.Format(UltilStr.exibirErros, "Email")));
            //Cpf
            if (UltilStr.StrPadrao(_classe.Cpf,TiposDeDados.Cpf))
                Debug.WriteLine("cpf ok");
            else
                erroMed.Add(new Erro("Cpf", string.Format(UltilStr.exibirErros, " Cpf")));
            //Cep
            if (UltilStr.StrPadrao(_classe.Cep,TiposDeDados.Cep))
                Debug.WriteLine("cep ok");
            else
                erroMed.Add(new Erro("Cep", string.Format(UltilStr.exibirErros, " Cep")));
            //Rua
            if (UltilStr.StrPadrao(_classe.Rua))
                Debug.WriteLine("rua ok");
            else
                erroMed.Add(new Erro("Rua", string.Format(UltilStr.exibirErros, " Rua")));
            //Bairro
            if (UltilStr.StrPadrao(_classe.Bairro))
                Debug.WriteLine("bairro ok");
            else
                erroMed.Add(new Erro("Bairro", string.Format(UltilStr.exibirErros, " Bairro")));
            //Uf
            if (UltilStr.StrPadrao(_classe.UF))
                Debug.WriteLine("uf ok");
            else
                erroMed.Add(new Erro("Uf", string.Format(UltilStr.exibirErros, " Uf")));
            //Cidade
            if (UltilStr.StrPadrao(_classe.Cidade))
                Debug.WriteLine("cidade ok");
            else
                erroMed.Add(new Erro("Cidade", string.Format(UltilStr.exibirErros, " Cidade")));
            //Medicos
            if (UltilStr.StrPadrao(_classe.IdMedico.ToString(),0,int.MaxValue))
                Debug.WriteLine("medico ok");
            else
                erroMed.Add(new Erro("IdMedico", " Não há Médicos cadastrados. *"));

            if (erroMed.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
