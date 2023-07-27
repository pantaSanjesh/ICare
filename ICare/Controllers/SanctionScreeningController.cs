using System;
using System.Threading.Tasks;
using AutoMapper;
using ICare.Business.Business.SanctionScreeningBusiness;
using ICare.Shared.Models;
using ICare.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ICare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class SanctionScreeningController : ControllerBase
    {
        #region Fields
        private readonly ISanctionScreeningBusiness _screeningBusiness;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public SanctionScreeningController(ISanctionScreeningBusiness screeningBusiness, IMapper mapper)
        {
            _screeningBusiness = screeningBusiness;
            _mapper = mapper;
        }
        #endregion

        #region Methods

        //For Pep and other entity sanction screening
        [HttpPost]
        [Route("GetPepAndOtherSanctionData")]
        [Produces("application/json")]
        public async Task<IActionResult> GetPepAndOtherSanctionData(PepAndOtherSactionViewModel model)
        {
            try
            {
                var pepAndOtherSanctionModel = _mapper.Map<PepAndOtherSanctionModel>(model);

                //screen data from ofac table.
                var pepSanctionList = await _screeningBusiness.GetSanctionDataBusiness(pepAndOtherSanctionModel);

                //Get data from CIB API for screening.

                //var cibBlackList = await _screeningBusiness.GetDataFromCibSanctionList(pepAndOtherSanctionModel);

                //return Ok(new { result=new { pepSanctionList, cibBlackList } });
                return Ok(pepSanctionList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
