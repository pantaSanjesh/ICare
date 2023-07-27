using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICare.Repository.Repository.StaticValuesRepository;
using ICare.Shared.Models.Common;
using ICare.Shared.Models.StaticValues;

namespace ICare.Business.Business.StaticValuesBusiness
{
    public class StaticValuesBusiness : IStaticValuesBusiness
    {

        #region Fields

        private readonly IStaticValuesRepository _staticValuesRepository;

        #endregion


        #region Ctor
        public StaticValuesBusiness(IStaticValuesRepository staticValuesRepository)
        {
            _staticValuesRepository = staticValuesRepository;
        }
        #endregion


        #region Methods

        public async Task<DbResponse> AddStaticValues(StaticValuesModel modal)
        {
            try
            {
                return await _staticValuesRepository.InsertStaticValues(modal);
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<DbResponse> DeleteStaticValues(int id)
        {
            try
            {
                return await _staticValuesRepository.DeleteStaticValues(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<StaticValuesModel>> GetStaticValuesType()
        {
            try
            {
                return await _staticValuesRepository.SelectStaticValuesType();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<StaticValuesModel>> GetStaticValuesByGroupId(StaticValuesModel modal)
        {
            try
            {
                return await _staticValuesRepository.SelectStaticValuesByGroupId(modal);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DbResponse> UpdateStaticValues(StaticValuesModel modal)
        {
            try
            {
                return await _staticValuesRepository.UpdateStaticValues(modal);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<StaticValuesModel> GetStaticValuesByStaticId(int id)
        {
            try
            {
                return await _staticValuesRepository.SelectStaticValuesByStaticId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
