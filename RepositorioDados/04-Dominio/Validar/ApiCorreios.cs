using ProjetoC.CorreiosCep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoC._04_Dominio.Validar
{
    class ApiCorreios
    {
        public static bool valida { get; set; }
        public static enderecoERP ApiConect(string _cep)
        {
            if (!String.IsNullOrEmpty(_cep) && _cep.Length == 8)
            {
                try
                {
                    AtendeClienteClient Cep = new AtendeClienteClient();
                    var _end = Cep.consultaCEP(_cep);
                    valida = true;
                    return _end;
                }
                catch (System.ServiceModel.FaultException)
                {
                    MessageBox.Show("Cep não encontrado");
                }

                return null;
            }

            return null;
        }
      
    }
}