using System.Data;

namespace SistemaHospital._02_REPOSITORIO._01_INFRA
{
    interface IConexao
    {
        IDbConnection GetConnection();
        bool ExecuteQuery(string sql);
        object ExecultaScala(string sql);
        DataSet Query(string sql);
    }
}
