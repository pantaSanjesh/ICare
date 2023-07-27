using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICare.Shared.Models.Common;
using ICare.Shared.Models.StaticValues;

namespace ICare.Repository.Repository.StaticValuesRepository
{
    public interface IStaticValuesRepository
    {
        Task<List<StaticValuesModel>> SelectStaticValuesType();
        Task<List<StaticValuesModel>> SelectStaticValuesByGroupId(StaticValuesModel modal);
        Task<DbResponse> InsertStaticValues(StaticValuesModel modal);
        Task<DbResponse> DeleteStaticValues(int id);
        Task<DbResponse> UpdateStaticValues(StaticValuesModel modal);
        Task<StaticValuesModel> SelectStaticValuesByStaticId(int id);
    }
}
