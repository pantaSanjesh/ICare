using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ICare.Business.Business.StaticValuesBusiness;
using ICare.Shared.Models.StaticValues;
using ICare.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticValuesController : ControllerBase
    {
        #region Fields
        private readonly IStaticValuesBusiness _staticValuesBusiness;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor
        public StaticValuesController(IStaticValuesBusiness staticValuesBusiness,IMapper mapper)
        {
            _staticValuesBusiness = staticValuesBusiness;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetStaticValuesType")]
        public async Task<IActionResult> GetStaticValuesType()
        {
            try
            {
                var staticValuesList = await _staticValuesBusiness.GetStaticValuesType();
                var staticValueList = _mapper.Map<List<StaticValuesViewModal>>(staticValuesList);
                return Ok(new { staticValueType = staticValueList });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        
        [HttpPost]
        [Route("GetStaticValuesByGroupId")]
        public async Task<IActionResult> GetStaticValuesByGroupId(StaticValuesViewModal modal)
        {
            try
            {
                var staticModal = _mapper.Map<StaticValuesModel>(modal);
                var staticValuesByGroupId = await _staticValuesBusiness.GetStaticValuesByGroupId(staticModal);
                var staticValuesByGroupIdList = _mapper.Map<List<StaticValuesViewModal>>(staticValuesByGroupId);
                return Ok(staticValuesByGroupId);
            }            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddStaticValues")]        
        public async Task<IActionResult> AddStaticValues(StaticValuesViewModal modal)
        {
            try
            {
                var staticModal = _mapper.Map<StaticValuesModel>(modal);
                var dbResponse = await _staticValuesBusiness.AddStaticValues(staticModal);
                if (dbResponse.ErrorCode=="0")
                {
                    return Ok(dbResponse);
                }
                else
                {
                    return BadRequest(dbResponse);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("GetStaticValuesByStaticId")]
        public async Task<IActionResult> GetStaticValuesByStaticId(int id)
        {
            try
            {
                StaticValuesModel modal = await _staticValuesBusiness.GetStaticValuesByStaticId(id);
                var staticValuesViewModal = _mapper.Map<StaticValuesViewModal>(modal);
                if (staticValuesViewModal != null)
                {
                    return Ok(staticValuesViewModal);
                }
                else
                {
                    return BadRequest();
                }
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("UpdateStaticValues")]        
        public async Task<IActionResult> UpdateStaticValues(StaticValuesViewModal modal)
        {
            try
            {
                var staticModal = _mapper.Map<StaticValuesModel>(modal);
                var dbResponse = await _staticValuesBusiness.UpdateStaticValues(staticModal);
                if (dbResponse.ErrorCode == "0")
                {
                    return Ok(dbResponse);
                }
                else
                {
                    return BadRequest(dbResponse);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("DeleteStaticValues")]        
        public async Task<IActionResult> DeleteStaticValues(int id)
        {
            try
            {
                var dbResponse = await _staticValuesBusiness.DeleteStaticValues(id);
                if (dbResponse.ErrorCode == "0")
                {
                    return Ok(dbResponse);
                }
                else
                {
                    return BadRequest(dbResponse);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        #endregion
    }
}
