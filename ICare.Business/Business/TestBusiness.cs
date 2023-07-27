using ICare.Business.Commons;
using ICare.Repository.Repository.Common;
using ICare.Repository.Repository.Test;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Business.Business
{
    public class TestBusiness:ITestBusiness
    {
        public readonly ITestRepository _repo;
        public TestBusiness(ITestRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<TestModel>> GetDatas()
        {
            return await _repo.GetAccountDetailRepo();
        }

        public async Task<InfoModel> GetXmlData()
        {
            return await _repo.GetDataFromSp(); 
        }
        public async Task<string> GetDataToXML()
        {
            var datafromrepo = await _repo.GetDataFromSp();
            return GenerateXML.ToXML(datafromrepo);
        }

        public async Task<string> GetDataToXMLWithoutJson()
        {
            var datafromrepo = await _repo.GetDataFromSp();
            return GenerateXML.ObjectToXmlString(datafromrepo);
        }
        public async Task<string> GetDataToXMLForProperties()
        {
            var datafromrepo = await _repo.GetDataFromSp();            
            return GenerateXML.PropertiesToXml(datafromrepo);
        }
    }
}
