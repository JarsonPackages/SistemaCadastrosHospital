
using SistemaHospital.ApiCorreiosCep;
using System;


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
                    return null;
                }

                
            }

            return null;
        }
      
    }
}