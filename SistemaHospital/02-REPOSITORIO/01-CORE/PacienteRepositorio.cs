
using ProjetoC._03_MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProjetoC._01_INFRA;

namespace ProjetoC._02_REPOSITORIO._01_CORE
{
    class PacienteRepositorio : IRepositorio<Paciente>
    {
        private DBSServer BD = new DBSServer();
        public bool Delete(Paciente _item)
        {
            bool _verifica;

            _verifica = BD.ExecuteQuery("DELETE FROM PACIENTE WHERE ID='" + _item.Id + "'; ");
            return _verifica;

        }
        public int QtdCad()
        {
            object _total = BD.ExecultaScala("SELECT * FROM PACIENTE;");
            int _totalfinal = int.Parse(_total.ToString());
            return _totalfinal;

        }

        public List<Paciente> GetAll()
        {
            List<Paciente> LP = new List<Paciente>();
            DataSet DS = BD.Query("SELECT * FROM PACIENTE; ");
            foreach (DataRow DR in DS.Tables[0].Rows)
            {
                LP.Add(new Paciente()
                {
                    Id = int.Parse(DR["ID"].ToString()),
                    Nome = DR["NOME"].ToString(),
                    Email = DR["EMAIL"].ToString(),
                    Bairro = DR["BAIRRO"].ToString(),
                    Cep = DR["CEP"].ToString(),  
                    Cidade = DR["CIDADE"].ToString(),
                    Cpf = DR["CPF"].ToString(),
                    Rua = DR["RUA"].ToString(),
                    UF =DR["UF"].ToString()
                });
            }
            return LP;
        }

        public Paciente GetById(int id)
        {
            Paciente paciente = null;
            DataSet DS = BD.Query("Select * from  Paciente where id = '"+id+"'" );
            foreach (DataRow DR in DS.Tables[0].Rows)
            {
               paciente = new Paciente()
               {
                   Id = int.Parse(DR["ID"].ToString()),
                   Nome = DR["NOME"].ToString(),
                   Email = DR["EMAIL"].ToString(),
                   Bairro = DR["BAIRRO"].ToString(),
                   Cep = DR["CEP"].ToString(),
                   Cidade = DR["CIDADE"].ToString(),
                   Cpf = DR["CPF"].ToString(),
                   Rua = DR["RUA"].ToString(),
                   UF = DR["UF"].ToString()
               };
            }
            return paciente;
        }

        public DataSet GetMigraDGV(string _item)
        {           
            DataSet DS = BD.Query(_item);        
            return DS;
        }

        public bool Insert(Paciente _item)
        {
            try
            {
                string sql = "INSERT INTO PACIENTE (NOME,EMAIL,BAIRRO,CEP,CIDADE,CPF,RUA,UF) VALUES('" +_item.Nome + "','" + _item.Email + "','" + _item.Bairro + "','" + _item.Cep + "','" + _item.Cidade + "','" + _item.Cpf + "','" + _item.Rua + "','" + _item.UF + "'); ";
                BD.ExecuteQuery(sql);
                return true;
            }
            catch (Exception msg)
            {
               
                return false;
            }
          
        }



        public bool Update(Paciente _item)
        {
            bool _verifica;
            string sql = "UPDATE  PACIENTE SET NOME ='" + _item.Nome + "', EMAIL ='" + _item.Email + "',BAIRRO = '" + _item.Bairro + "', CEP ='" + _item.Cep + "',CIDADE = '" + _item.Cidade + "', CPF = '" + _item.Cpf + "',RUA = '" + _item.Rua + "', UF = '" + _item.UF + "' WHERE ID = "+ _item.Id+"  ";
            _verifica = BD.ExecuteQuery(sql);
            return _verifica;
        }
    }
}
