using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoC._01_INFRA
{
    class DBSServer : IConexao
    {
        private SqlConnection _con;
        public DBSServer()
        {
            Console.WriteLine("Contrutor Ok, Abrindo conexao");
            _con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename="+@"C:\Users\CDS\Desktop\HospitalSistemaCadastro-master\SistemaHospital\App_Data\AcessSql.mdf;"+"Integrated Security=True");
        }
        public DBSServer(string strCon)
        {
            _con = new  SqlConnection(strCon);
        }
        public object ExecultaScala(string sql)
        {
            object _scala;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, _con);
                _con.Open();
                _scala = cmd.ExecuteScalar();
                _con.Close();
                return _scala;
            }
            catch (Exception msg)
            {
                Console.WriteLine("Alert Alert, Erro: " + msg.Message);
                return -1;
            }
            finally
            {
                if(_con.State == ConnectionState.Open)
                {
                    _con.Close();
                }
               
            }
        }

        public bool ExecuteQuery(string sql)
        {
           
            try
            {
                SqlCommand cmd = new SqlCommand(sql, _con);
                _con.Open();
               
                cmd.ExecuteNonQuery();
                _con.Close();
                return true;
               
            }
            catch (Exception msg)
            {
                Console.WriteLine("Alert Alert, Erro: " + msg.Message);

                return false;
            }
            finally
            {
                if (_con.State == ConnectionState.Open)
                {
                    _con.Close();
                }

            }
        }

        public IDbConnection GetConnection()
        {
            return _con;
        }
      
        public DataSet Query(string sql)
        {
            try
            {
               

                SqlDataAdapter DA = new SqlDataAdapter(sql, _con);
                DataSet DS = new DataSet();
                _con.Open();
                DA.Fill(DS);
                _con.Close();
                return DS;

            }
            catch (Exception msg)
            {
                Console.WriteLine("Alert Alert, Erro: " + msg.Message);
                return  null;
            }
            finally
            {
                if (_con.State == ConnectionState.Open)
                {
                    _con.Close();
                }

            }
           
           
            
        }
      
    }
}
