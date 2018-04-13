﻿using ProjetoC._01_INFRA;
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

            _verifica = BD.ExecuteQuery("DELETE FROM MEDICO WHERE ID=" +_item.ID + "; ");
            return _verifica;
        }



        public List<Medico> GetAll()
        {
            List<Medico> LP = new List<Medico>();
            DataSet DS = BD.Query("SELECT * FROM MEDICO ORDER BY NOME,CRM; ");
           if(DS.Tables[0].Rows == null)
            {
                return null;
            }
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
            DataSet DS = BD.Query("SELECT * FROM MEDICO WHERE ID= "+id+" ");
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
                string sql = "INSERT INTO MEDICO(CRM,NOME,ESPECIALIZACAO) VALUES(" + _item.CRM + ",'" + _item.Nome + "','" + _item.Especializacao + "')";
                BD.ExecuteQuery(sql);
                return true;
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
            string sql = "UPDATE  MEDICO SET NOME='"+_item.Nome+"', ESPECIALIZACAO='"+_item.Especializacao+"'  WHERE ID = " + _item.ID + "  ";
            _verifica = BD.ExecuteQuery(sql);
            return _verifica;
        }


    }
}
