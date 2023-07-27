using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ICare.Repository.Repository.Common;
using ICare.Shared.Models;
using ICare.Shared.Models.SanctionScreeningModel;

namespace ICare.Repository.Repository.SanctionScreeningRepository
{
    public class SanctionScreeningRepository:ISanctionScreeningRepository
    {

        #region Fields
        private readonly IRepositoryDao _repository;
        #endregion

        #region Ctor
        public SanctionScreeningRepository(IRepositoryDao repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public async Task InsertBlackList(CibScreeningBlackListDetailsResponseModel cibScreeningModel)
        {
            try
            {
                foreach (var model in cibScreeningModel.BlackListVerify.BlackListDetails)
                {
                    string sql = string.Empty;
                    sql = "INSERT_BLACK_LIST";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@flag", "I");
                    param.Add("@BLACK_LIST_STATUS", model.BlackListStatus);
                    param.Add("@SCRRENING_TYPE", model.Type);
                    param.Add("@NAME", model.Name);
                    param.Add("@FATHER_NAME", model.FatherName);
                    param.Add("@CITIZENSHIP_NO", model.CitizenshipNumber);
                    param.Add("@PASSPORT_NO", model.PassportNumber);
                    param.Add("@INDIAN_EMBASSY_NO", model.IndianEmbassyNumber);
                    param.Add("@BLACK_LIST_DATE", model.BlackListedDate);
                    param.Add("@BLACK_LIST_NO", model.BlackListNo);
                    //Branch Name which added data.
                    param.Add("@BRANCH", "Kathmandu");
                    //Data needs to be mapped.To be confirmed.
                    param.Add("@CUSTOMER_NO", "CustomerNo");
                    //Scan by user need to be mapped.
                    param.Add("@SCAN_BY", "user");
                    //ProcessId need to know
                    param.Add("@PROCESSID", null);
                    var dbresponse = _repository.RunStoredProcedure(sql, param);
                    await Task.FromResult(dbresponse);
                }                               

            }
            catch(SqlException sql)
            {
                throw sql;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<PepAndOtherSanctionResponseModel>> SelectSactionDataRepository(PepAndOtherSanctionModel pepAndOtherSanctionModel)
        {
            try
            {                
                string sql = string.Empty;
                sql = "spa_ofac_search_New";
                DynamicParameters param = new DynamicParameters();
                param.Add("@name", pepAndOtherSanctionModel.FullName);
                param.Add("@DOB", pepAndOtherSanctionModel.DateOfBirth);
                param.Add("@Nationality", null);
                param.Add("@matchPercent", null);
                param.Add("@unique_id", pepAndOtherSanctionModel.UniqueId);
                param.Add("@unique_id_value", pepAndOtherSanctionModel.UniqueIdType);
                param.Add("@sources", null);
                param.Add("@scanBy", null);
                List<PepAndOtherSanctionResponseModel> dbresponse = _repository.GetDataListWithParam<PepAndOtherSanctionResponseModel>(sql, param);
                return await Task.FromResult(dbresponse);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
