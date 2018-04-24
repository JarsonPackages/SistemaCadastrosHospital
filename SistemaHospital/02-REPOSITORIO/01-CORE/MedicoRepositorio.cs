using ProjetoC._01_INFRA;
using ProjetoC._03_MODEL;
using SistemaHospital._02_REPOSITORIO._01_CORE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace ProjetoC._02_REPOSITORIO._01_CORE
{
    class MedicoRepositorio : IRepositorio<Medico>,IDisposable
    {
        private DBSServer BD = new DBSServer();
        public bool Delete(Medico _item)
        {
            bool _verifica;
            string sql = "DELETE FROM MEDICO WHERE ID= @ID  ";
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("@ID", _item.ID));
           
            _verifica = BD.ExecuteQuery(sql , parametros);
            return _verifica;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Medico> GetAll()
        {
            List<Medico> LP = new List<Medico>();
            DataSet DS = BD.Query("SELECT * FROM MEDICO ORDER BY NOME,CRM; ");
           
            foreach (DataRow DR in DS.Tables[0].Rows)
            {
                LP.Add(new Medico()
                {
                    ID= int.Parse(DR["ID"].ToString()),
                    CRM = int.Parse(DR["CRM"].ToString()),
                    Nome = DR["NOME"].ToString(),
                    Especializacao = DR["ESPECIALIZACAO"].ToString(),

                });
            }
            return LP;
        }

        public Medico GetById(int id)
        {
            Medico LP = new Medico();
            DataSet DS = BD.Query("SELECT * FROM MEDICO WHERE ID= "+id+" ; ");
            foreach (DataRow DR in DS.Tables[0].Rows)
            {
               LP =  new Medico()
                {
                    ID= int.Parse(DR["ID"].ToString()),
                    CRM = int.Parse(DR["CRM"].ToString()),
                    Nome = DR["NOME"].ToString(),
                    Especializacao = DR["ESPECIALIZACAO"].ToString(),

                };
            }
            return LP;
        }

        public DataSet GetMigraDGV(string _item)
        {
            DataSet DS = BD.Query(_item);
            return DS;
        }

        public bool Insert(Medico _item)
        {
            try
            {
                List<Parametros> parametros = new List<Parametros>();
                string sql = "INSERT INTO MEDICO(CRM,NOME,ESPECIALIZACAO) VALUES(@CRM, @NOME , @ESPECIALIZACAO) ;";
                parametros.Add(new Parametros("@CRM", _item.CRM));
                parametros.Add(new Parametros("@NOME", _item.Nome));
                parametros.Add(new Parametros("@ESPECIALIZACAO", _item.Especializacao));
             

                return BD.ExecuteQuery(sql, parametros);
            }
            catch (Exception msg)
            {
                Console.WriteLine("Alert Alert, Erro: " + msg.Message);
                return false;
            }
        }

        public bool Update(Medico _item)
        {
            bool _verifica;
            string sql = "UPDATE  MEDICO SET NOME= @NOME, ESPECIALIZACAO=@Especializacao  WHERE ID = @ID   ";
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("@NOME", _item.Nome));
            parametros.Add(new Parametros("@Especializacao", _item.Especializacao));
            parametros.Add(new Parametros("@ID", _item.ID));

            _verifica = BD.ExecuteQuery(sql,parametros);
            return _verifica;
        }

       
    }
}
