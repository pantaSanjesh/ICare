using System.Threading.Tasks;
using ICare.Business.Business;
using Microsoft.AspNetCore.Mvc;

namespace ICare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home : ControllerBase
    {
        private readonly ITestBusiness _testBusiness;
        public Home(ITestBusiness testBusiness)
        {
            _testBusiness = testBusiness;
        }
        [HttpGet]
        [Route("GetDataForTest")]
        public async Task<IActionResult> Test()
        {
            return base.Ok(await _testBusiness.GetDatas());
        }
        [HttpGet]
        [Produces("application/xml")]
        [Route("GetXmlOutputData")]
        public async Task<IActionResult> GetTestXmlData()
        {            
            return base.Ok(await _testBusiness.GetXmlData());
        }
        [HttpGet]
        [Route("GetXmlDataWithoutHeaders")]
        public async Task<IActionResult> GetTestXmlData1()
        {
            return base.Ok(await _testBusiness.GetDataToXML());
        }

        [HttpGet]
        [Route("GetDataWithEscape")]
        public async Task<IActionResult> GetTestXmlData2()
        {
            return base.Ok(new { Response = await _testBusiness.GetDataToXML() });
        }
        [HttpGet]
        [Route("GetDataWithoutEscape")]
        public async Task<IActionResult> GetTestXmlData3()
        {
            return base.Ok(new { Response = await _testBusiness.GetDataToXMLWithoutJson() });
        }

        [HttpGet]
        [Route("GetXMLForProperties")]
        public async Task<IActionResult> GetXMLForProperties()
        {
            return base.Ok(new { Response = await _testBusiness.GetDataToXMLForProperties() });
        }

    }
}
