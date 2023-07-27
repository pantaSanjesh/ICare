using Dapper;
using ICare.Repository.Repository.Common;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Repository.Repository.Test
{
    public class TestRepository:ITestRepository
    {
        private readonly IRepositoryDao _repo;
        public TestRepository(IRepositoryDao repo)
        {
            _repo = repo;
        }
        public async Task<List<TestModel>> GetAccountDetailRepo()
        {
            try
            {
                List<TestModel> acc = new List<TestModel>();
                string sql6 = "spa_Test";
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "v");
                acc = _repo.GetDataListWithParam<TestModel>(sql6, param);
                return await Task.FromResult(acc);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<InfoModel> GetDataFromSp()
        {
            try
            {
                string sql = "spa_Test";
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "c");
                InfoModel info = _repo.GetDataWithParam<InfoModel>(sql, param);
                return await Task.FromResult(info);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
