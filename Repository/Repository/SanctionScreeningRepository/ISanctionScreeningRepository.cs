using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICare.Shared.Models;
using ICare.Shared.Models.SanctionScreeningModel;

namespace ICare.Repository.Repository.SanctionScreeningRepository
{
    //represents interface for sanctionscreeningrepository
    public interface ISanctionScreeningRepository
    {
        Task<List<PepAndOtherSanctionResponseModel>> SelectSactionDataRepository(PepAndOtherSanctionModel pepAndOtherSanctionModel);
        Task InsertBlackList(CibScreeningBlackListDetailsResponseModel resModel);
    }
}
