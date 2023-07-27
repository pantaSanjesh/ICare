using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Repository.Repository.Common
{
    public class RepositoryDao:IRepositoryDao
    {
        private readonly IConfiguration _configuration;

        public RepositoryDao(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            try
            {
                return _configuration.GetConnectionString("DBConnString");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public T GetDataWithParam<T>(string sql, DynamicParameters param)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Query<T>(sql, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<T> GetDataListWithParam<T>(string sql, DynamicParameters param)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Query<T>(sql, param, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int RunSQLWithParam<T>(string sql, DynamicParameters param)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Execute(sql, param);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RunSql(string sql, DynamicParameters param)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Execute(sql, param);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
        public int RunStoredProcedure(string sql, DynamicParameters param)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(GetConnectionString()))
                {
                    return conn.Execute(sql, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }        
    }
}
