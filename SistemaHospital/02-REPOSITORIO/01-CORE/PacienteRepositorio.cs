﻿
using ProjetoC._03_MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProjetoC._01_INFRA;

namespace ProjetoC._02_REPOSITORIO._01_CORE
{
    class PacienteRepositorio : IRepositorio<Paciente>, IDisposable
    {
        DBSServer BD = new DBSServer();

        public bool Delete(Paciente _item)
        {

            bool _verifica;

            _verifica = BD.ExecuteQuery("DELETE FROM PACIENTE WHERE ID= " + _item.Id + " ; ");
            return _verifica;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Paciente> GetAll()
        {
            List<Paciente> LP = new List<Paciente>();
            DataSet DS = BD.Query("SELECT * FROM PACIENTE ORDER BY NOME ; ");
            if (DS == null)
            {
                return null;
            }
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
                    UF = DR["UF"].ToString(),
                    IdMedico = int.Parse(DR["IdMedico"].ToString())


                });
            }
            return LP;
        }

        public Paciente GetById(int id)
        {

            Paciente paciente = null;
            DataSet DS = BD.Query("Select * from  Paciente where id = " + id + " ");
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
                    UF = DR["UF"].ToString(),
                    IdMedico = int.Parse(DR["IdMedico"].ToString())

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
                string sql = " INSERT INTO PACIENTE(NOME, EMAIL, CPF, CEP, RUA, BAIRRO, UF, CIDADE, IdMedico) VALUES('" + _item.Nome + "', '" + _item.Email + "', '" + _item.Cpf + "', '" + _item.Cep + "', '" + _item.Rua + "', '" + _item.Bairro + "', '" + _item.UF + "',  '" + _item.Cidade + "',  " + _item.IdMedico + ");";
                //string sql = " INSERT INTO PACIENTE(NOME, EMAIL, CPF, CEP, RUA, BAIRRO, UF, CIDADE, IdMedico) VALUES('@NOME', '@EMAIL', '@CPF', '@CEP', '@RUA', '@BAIRRO', '@UF', '@CIDADE', @IDMEDICO);";
                //cmd.CommandText = sql;
                //cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Add(new SqlParameter("@NOME",_item.Nome));
                //cmd.Parameters.Add(new SqlParameter("@EMAIL", _item.Email));
                //cmd.Parameters.Add(new SqlParameter("@CPF", _item.Cpf));
                //cmd.Parameters.Add(new SqlParameter("@CEP", _item.Cep));
                //cmd.Parameters.Add(new SqlParameter("@RUA", _item.Rua));
                //cmd.Parameters.Add(new SqlParameter("@BAIRRO", _item.Bairro));
                //cmd.Parameters.Add(new SqlParameter("@UF", _item.UF));
                //cmd.Parameters.Add(new SqlParameter("@CIDADE", _item.Cidade));
                //cmd.Parameters.Add(new SqlParameter("@IDMEDICO", _item.IdMedico));

                BD.ExecuteQuery(sql);


                return true;
            }
            catch (Exception msg)
            {
                Console.WriteLine("Alert Alert, Erro: " + msg.Message);
                return false;
            }

        }



        public bool Update(Paciente _item)
        {
            DBSServer BD = new DBSServer();
            bool _verifica;
            string sql = "UPDATE  PACIENTE SET NOME ='" + _item.Nome + "', EMAIL ='" + _item.Email + "',BAIRRO = '" + _item.Bairro + "', CEP ='" + _item.Cep + "',CIDADE = '" + _item.Cidade + "', CPF = '" + _item.Cpf + "',RUA = '" + _item.Rua + "', UF = '" + _item.UF + "',IdMedico= '" + _item.IdMedico + "'   WHERE ID = " + _item.Id + "  ";
            _verifica = BD.ExecuteQuery(sql);
            return _verifica;
        }
    }
}
