using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICare.Business.Business
{
    public interface ITestBusiness
    {
        Task<List<TestModel>> GetDatas();
        Task<InfoModel> GetXmlData();
        Task<string> GetDataToXML();
        Task<string> GetDataToXMLWithoutJson();
        Task<string> GetDataToXMLForProperties();
    }
}
