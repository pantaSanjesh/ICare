using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICare.Shared.Models;
using ICare.Shared.Models.SanctionScreeningModel;

namespace ICare.Business.Business.SanctionScreeningBusiness
{
    //represents inteface for sanctionscreeningbusiness
    public interface ISanctionScreeningBusiness
    {
        Task<List<PepAndOtherSanctionResponseModel>> GetSanctionDataBusiness(PepAndOtherSanctionModel pepAndOtherSanctionModel);
        Task<CibScreeningBlackListDetailsResponseModel> GetDataFromCibSanctionList(PepAndOtherSanctionModel pepAndOtherSanctionModel);
    }
}
