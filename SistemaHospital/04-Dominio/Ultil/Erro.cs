using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHospital._04_Dominio.Ultil
{
    public class Erro
    {
        public string campo { get; set; }
        public string msg { get; set; }
        public Erro(string _campo, string _msg)
        {
            campo = _campo;
            msg = _msg;
        }
    }
}