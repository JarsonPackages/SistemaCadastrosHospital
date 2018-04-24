
using ProjetoC._03_MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ProjetoC._01_INFRA;
using SistemaHospital._02_REPOSITORIO._01_CORE;

namespace ProjetoC._02_REPOSITORIO._01_CORE
{
    class PacienteRepositorio : IRepositorio<Paciente>, IDisposable
    {
        DBSServer BD = new DBSServer();

        public bool Delete(Paciente _item)
        {
            string sql = "DELETE FROM PACIENTE WHERE ID= @ID ; ";
            List<Parametros> parametros = new List<Parametros>();
            parametros.Add(new Parametros("@ID",_item.Id));
            return BD.ExecuteQuery(sql, parametros);
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
            DataSet DS = BD.Query("Select * from  Paciente where id = " + id + "; ");
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
                string sql = " INSERT INTO PACIENTE(NOME, EMAIL, CPF, CEP, RUA, BAIRRO, UF, CIDADE, IdMedico) VALUES(@NOME, @EMAIL, @CPF, @CEP, @RUA, @BAIRRO, @UF, @CIDADE, @IDMEDICO);";
                List<Parametros> parametros = new List<Parametros>();

                parametros.Add(new Parametros("@ID", _item.Id));
                parametros.Add(new Parametros("@NOME", _item.Nome));
                parametros.Add(new Parametros("@EMAIL", _item.Email));
                parametros.Add(new Parametros("@CPF", _item.Cpf));
                parametros.Add(new Parametros("@CEP", _item.Cep));
                parametros.Add(new Parametros("@RUA", _item.Rua));
                parametros.Add(new Parametros("@BAIRRO", _item.Bairro));
                parametros.Add(new Parametros("@UF", _item.UF));
                parametros.Add(new Parametros("@CIDADE", _item.Cidade));
                parametros.Add(new Parametros("@IDMEDICO", _item.IdMedico));
                return BD.ExecuteQuery(sql, parametros);
            }
            catch (Exception msg)
            {
                Console.WriteLine("Alert Alert, Erro: " + msg.Message);
                return false;
            }

        }
        public bool Update(Paciente _item)
        {
            string sql = "UPDATE  PACIENTE SET NOME =@Nome, EMAIL =@Email ,BAIRRO = @Bairro, CEP = @Cep ,CIDADE = @Cidade , CPF = @Cpf ,RUA = @Rua, UF = @Uf ,IdMedico= @IdMEdico   WHERE ID = @ID ";
            try
            {
                List<Parametros> parametros = new List<Parametros>();

                parametros.Add(new Parametros("@ID", _item.Id));
                parametros.Add(new Parametros("@NOME", _item.Nome));
               parametros.Add(new Parametros("@EMAIL", _item.Email));
                parametros.Add(new Parametros("@CPF", _item.Cpf));
                parametros.Add(new Parametros("@CEP", _item.Cep));
                parametros.Add(new Parametros("@RUA", _item.Rua));
               parametros.Add(new Parametros("@BAIRRO", _item.Bairro));
                parametros.Add(new Parametros("@UF", _item.UF));
               parametros.Add(new Parametros("@CIDADE", _item.Cidade));
                parametros.Add(new Parametros("@IDMEDICO", _item.IdMedico));
                return BD.ExecuteQuery(sql, parametros);
            }
            catch
            {
                return false;
            }
        
           
           
        }
      
    }
}
