using SistemaHospital._02_REPOSITORIO._01_CORE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
            _con = new SqlConnection("server=COMERCIAL-02; database=HOSPITAL;User Id=sa ; Password=123;");
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
                Debug.WriteLine("Alert Alert, Erro:  " + msg.Message);
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

       
        public bool ExecuteQuery(string sql, List<Parametros> parametros)
        {

            try
            {
                SqlCommand cmd = new SqlCommand(sql, _con);
                foreach(var _ass in parametros)
                {
                    cmd.Parameters.AddWithValue(_ass.Name, _ass.Value);
                    
                }
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
               Debug.WriteLine("Alert Alert, Erro: " + msg.Message);
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
