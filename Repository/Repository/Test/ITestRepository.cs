using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Repository.Repository.Test
{
    public interface ITestRepository
    {
        Task<List<TestModel>> GetAccountDetailRepo();
        Task<InfoModel> GetDataFromSp();
    }
}
