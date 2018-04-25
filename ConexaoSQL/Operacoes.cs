using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoSQL
{
    public class Operacoes :IConexao
    {

        private SqlConnection _con;
        public Operacoes()
        {
            Console.WriteLine("Contrutor Ok, Abrindo conexao");
            _con = new SqlConnection("server=COMERCIAL-02; database=HOSPITAL;User Id=sa ; Password=123;");
        }
        public Operacoes(string strCon)
        {
            _con = new SqlConnection(strCon);
        }
        public object ExecultaScala(string sql, List<Parametros> parametros)
        {
            object _scala;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, _con);
                foreach(var item in parametros) { }
                _con.Open();
                _scala = cmd.ExecuteScalar();
                _con.Close();
                return _scala;
            }
            catch (Exception msg)
            {
                System.Diagnostics.Debug.WriteLine("Alert Alert, Erro:  " + msg.Message);
                return -1;
            }
            finally
            {
                if (_con.State == System.Data.ConnectionState.Open)
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
                foreach (var _ass in parametros)
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
                if (_con.State == System.Data.ConnectionState.Open)
                {
                    _con.Close();
                }

            }
        }

        public System.Data.IDbConnection GetConnection()
        {
            return _con;
        }

        public System.Data.DataSet Query(string sql)
        {
            try
            {


                SqlDataAdapter DA = new SqlDataAdapter(sql, _con);
                System.Data.DataSet DS = new System.Data.DataSet();
                _con.Open();
                DA.Fill(DS);
                _con.Close();
                return DS;

            }
            catch (Exception msg)
            {
                System.Diagnostics.Debug.WriteLine("Alert Alert, Erro: " + msg.Message);
                return null;
            }
            finally
            {
                if (_con.State == System.Data.ConnectionState.Open)
                {
                    _con.Close();
                }

            }
        }

    }



    internal interface IConexao
    {
        System.Data.IDbConnection GetConnection();
        bool ExecuteQuery(string sql, List<Parametros> parametros);
        object ExecultaScala(string sql, List<Parametros> parametros);
        System.Data.DataSet Query(string sql);
    }
}
