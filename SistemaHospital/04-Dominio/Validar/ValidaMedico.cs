

using ProjetoC._03_MODEL;
using SistemaHospital._04_Dominio.Ultil;
using System.Collections.Generic;
using System.Diagnostics;

namespace SistemaHospital._04_Dominio.Validar
{
    public static class ValidaMedico
    {
        public static List<Erro> erroMed = new List<Erro>();

      

        public static bool validar(Medico _classe)
        {
            if (UltilStr.StrPadrao(_classe.CRM.ToString(), 4,10))
                Debug.WriteLine("crm ok");
            else   
                 erroMed.Add(new Erro("Crm", string.Format(UltilStr.exibirErros+" O Campo Tem que ter no minimo 4 caracteres e no maximo 10.", "Crm")));

            if (UltilStr.StrPadrao(_classe.Especializacao))
                Debug.WriteLine("especializacao ok");
            else
                erroMed.Add(new Erro("Especializacao", string.Format(UltilStr.exibirErros, "Especializacao")));

            if (UltilStr.StrPadrao(_classe.Nome))
                Debug.WriteLine("Nome ok");
            else
                erroMed.Add(new Erro("Nome", string.Format(UltilStr.exibirErros, "Nome")));

            if(erroMed.Count == 0)
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