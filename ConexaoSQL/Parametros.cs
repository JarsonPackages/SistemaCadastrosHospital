using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConexaoSQL
{
   internal class Parametros
    {
       public string Name {  get; set; }
        public object Value { get; set; }
        public Parametros(string nome, object value)
        {
            this.Name = nome;
            this.Value = value;
        }
    }
}