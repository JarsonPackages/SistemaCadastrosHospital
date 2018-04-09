using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoC._01_INFRA
{
    class OLEDB : IConexao
    {
        private OleDbConnection _con;
        public OLEDB()
        {
            _con = new OleDbConnection("jhl");
        }
        public OLEDB(string con)
        {
            _con = new OleDbConnection(con);
        }
        public object execultaScala(string sql)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public IDbConnection GetConnection()
        {
            throw new NotImplementedException();
        }

        public DataSet Query(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
