using ProjetoC._01_INFRA;
using ProjetoC._03_MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoC._02_REPOSITORIO._01_CORE
{
    class MedicoRepositorio : IRepositorio<Medico>
    {
        private DBSServer BD = new DBSServer();
        public bool Delete(Medico _item)
        {
            bool _verifica;

            _verifica = BD.ExecuteQuery("DELETE FROM MEDICO WHERE ID='" + _item.CRM + "'; ");
            return _verifica;
        }



        public List<Medico> GetAll()
        {
            List<Medico> LP = new List<Medico>();
            DataSet DS = BD.Query("SELECT * FROM MEDICO; ");
            foreach (DataRow DR in DS.Tables[0].Rows)
            {
                LP.Add(new Medico()
                {
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
            DataSet DS = BD.Query("SELECT * FROM MEDICO; ");
            foreach (DataRow DR in DS.Tables[0].Rows)
            {
                new Medico()
                {
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
                string sql = "INSERT INTO MEDICO VALUES(" + _item.CRM + ",'" + _item.Nome + "','" + _item.Especializacao + "')";
                BD.ExecuteQuery(sql);
                return true;
            }
            catch (Exception msg)
            {
               
                return false;
            }
        }

        public bool Update(Medico _item)
        {
            bool _verifica;
            string sql = "UPDATE  MEDICO SET '"+_item.Nome+"', ESPECIALIZACAO='"+_item.Especializacao+"'  WHERE ID = " + _item.CRM + "  ";
            _verifica = BD.ExecuteQuery(sql);
            return _verifica;
        }


    }
}
