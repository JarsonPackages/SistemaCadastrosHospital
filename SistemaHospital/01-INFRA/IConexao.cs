using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoC._01_INFRA
{
    internal interface IConexao
    {
        IDbConnection GetConnection(); 
        bool ExecuteQuery(string sql);
        object execultaScala(string sql);
        DataSet Query(string sql);
    }
}
