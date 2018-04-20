using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SistemaHospital._04_Dominio.Ultil
{
    public static  class UltilStr
    {
        public const string exibirErros = "Preencha o campo {0} ";
        public static bool StrPadrao(string value)
        {
            return !String.IsNullOrEmpty(value) && !String.IsNullOrWhiteSpace(value);
        }
        public static bool StrPadrao(string value, int tamanho_fixo)
        {
            if (value.Length == tamanho_fixo)
            {
                return StrPadrao(value);
            }
            else
            {
                return false;
            }
        }
        public static bool StrPadrao(string value, int tamanho_minimo, int tamanho_maximo)
        {
            if(value.Length >= tamanho_minimo && value.Length <= tamanho_maximo)
            {
                return StrPadrao(value);
            }
            else
            {
                return false;
            }
        }
        public static bool StrPadrao(object _input, TiposDeDados tipo)
        {
            if (_input == null)
                return false;

            bool valid = false;
            switch (Convert.ToInt32(tipo))
            {
                case 0:
                    //email
                     valid= Regex.IsMatch(_input.ToString(), @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") && StrPadrao(_input.ToString());
                    break;
                    
                   
                case 1:
                    //numerico
                    break;
                case 2:
                    valid = StrPadrao(_input.ToString(), 8);
                    //cep
                    break;
                case 3:
                    //telefone
                    break;
                case 4:
                    //Cpf
                    valid = StrPadrao(_input.ToString(), 11);
                    break;
                default:
                    valid = false;
                    break;
                    

            }
            return valid;
          
        }
        

    }
    public enum TiposDeDados
    {
        Email ,
        Numerico,
        Cep,
        Telefone,
        Cpf

    }
}