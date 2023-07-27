using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICare.Shared.Models.Common;
using ICare.Shared.Models.StaticValues;

namespace ICare.Business.Business.StaticValuesBusiness
{
    public interface IStaticValuesBusiness
    {
        Task<List<StaticValuesModel>> GetStaticValuesType();
        Task<List<StaticValuesModel>> GetStaticValuesByGroupId(StaticValuesModel modal);
        Task<DbResponse> AddStaticValues(StaticValuesModel modal);
        Task<DbResponse> UpdateStaticValues(StaticValuesModel modal);
        Task<DbResponse> DeleteStaticValues(int id);
        Task<StaticValuesModel> GetStaticValuesByStaticId(int id);
    }
}
