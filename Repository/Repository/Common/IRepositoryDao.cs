using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Repository.Repository.Common
{
    public interface IRepositoryDao
    {
        string GetConnectionString();
        T GetDataWithParam<T>(string sql, DynamicParameters param);
        List<T> GetDataListWithParam<T>(string sql, DynamicParameters param);
        int RunSQLWithParam<T>(string sql, DynamicParameters param);
        int RunSql(string sql, DynamicParameters param);
        int RunStoredProcedure(string sql, DynamicParameters param);
    }
}
