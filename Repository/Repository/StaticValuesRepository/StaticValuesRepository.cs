using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ICare.Repository.Repository.Common;
using ICare.Shared.Models.Common;
using ICare.Shared.Models.StaticValues;

namespace ICare.Repository.Repository.StaticValuesRepository
{
    public class StaticValuesRepository : IStaticValuesRepository
    {
        #region Fields

        private readonly IRepositoryDao _repository;

        #endregion
        
        #region Ctor
        public StaticValuesRepository(IRepositoryDao repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods    

        public async Task<DbResponse> DeleteStaticValues(int id)
        {
            try
            {
                string sql = string.Empty;
                sql = "spa_static_values_type";
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "d");
                param.Add("@static_Id", id);
                //var dbresponses = await _repository.RunStoredProcedure(sql, param);
                DbResponse dbresponse = _repository.GetDataWithParam<DbResponse>(sql, param);
                return await Task.FromResult(dbresponse);
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }
        public async Task<DbResponse> InsertStaticValues(StaticValuesModel modal)
        {
            try
            {
                string sql = string.Empty;                
                sql = "spa_static_values_type";
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "i");
                param.Add("@CATALOGUE_TYPE",modal.TypeId);
                param.Add("@VALUE", modal.Value);
                param.Add("@DATA", modal.Data);
                param.Add("@DESCRIPTION", modal.Description);
                param.Add("@ADDITIONAL_FIELD2", modal.AdditionalValue);                
                DbResponse dbresponse = _repository.GetDataWithParam<DbResponse>(sql, param);
                return await Task.FromResult(dbresponse);
                //if (dbresponse.ErrorCode == 0)
                //{
                //    return Task.FromResult(true);
                //}
                //else
                //{
                //    return Task.FromResult(false);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<StaticValuesModel>> SelectStaticValuesType()
        {
            try
            {
                string sql = string.Empty;
                sql = "spa_static_values_type";
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "s");                
                List<StaticValuesModel> dbresponse = _repository.GetDataListWithParam<StaticValuesModel>(sql, param);
                return await Task.FromResult(dbresponse);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }        
        public async Task<List<StaticValuesModel>> SelectStaticValuesByGroupId(StaticValuesModel modal)
        {
            try
            {
                string sql = string.Empty;
                sql = "spa_static_values_type";
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "g");
                param.Add("@CATALOGUE_TYPE", modal.TypeId);
                param.Add("@ADDITIONAL_FIELD1", string.IsNullOrEmpty(modal.AdditionalValue) ? null : modal.AdditionalValue);
                param.Add("@ADDITIONAL_FIELD2", string.IsNullOrEmpty(modal.AdditionalValue2) ? null : modal.AdditionalValue2);
                param.Add("@ADDITIONAL_FIELD3", string.IsNullOrEmpty(modal.AdditionalValue3) ? null : modal.AdditionalValue3);
                param.Add("@ADDITIONAL_FIELD4", string.IsNullOrEmpty(modal.AdditionalValue4) ? null : modal.AdditionalValue4);
                param.Add("@language", modal.Language);
                List<StaticValuesModel> dbresponse = _repository.GetDataListWithParam<StaticValuesModel>(sql, param);
                return await Task.FromResult(dbresponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      
        public async Task<DbResponse> UpdateStaticValues(StaticValuesModel modal)
        {
            try
            {
                string sql = string.Empty;
                sql = "spa_static_values_type";
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "u");
                param.Add("@static_id", modal.StaticId);
                param.Add("@CATALOGUE_TYPE", modal.TypeId);
                param.Add("@VALUE", modal.Value);
                param.Add("@DATA", modal.Data);
                param.Add("@DESCRIPTION", modal.Description);
                param.Add("@ADDITIONAL_FIELD2", modal.AdditionalValue);
                DbResponse dbresponse =_repository.GetDataWithParam<DbResponse>(sql, param);
                return await Task.FromResult(dbresponse);
                //if (dbresponse.ErrorCode == 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StaticValuesModel> SelectStaticValuesByStaticId(int id)
        {
            try
            {
                string sql = string.Empty;
                sql = "spa_static_values_type";
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", "p");
                param.Add("@static_Id", id);                
                StaticValuesModel dbresponse = _repository.GetDataWithParam<StaticValuesModel>(sql, param);
                return await Task.FromResult(dbresponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
