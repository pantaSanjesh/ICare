using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ICare.Repository.Repository.SanctionScreeningRepository;
using ICare.Shared.Models;
using ICare.Shared.Models.SanctionScreeningModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ICare.Business.Business.SanctionScreeningBusiness
{
    public class SanctionScreeningBusiness : ISanctionScreeningBusiness
    {
        #region Fields
        private readonly ISanctionScreeningRepository _sanctionScreeningRepository;
        private readonly IConfiguration _configuration;
        #endregion

        #region Ctor
        public SanctionScreeningBusiness(ISanctionScreeningRepository sanctionScreeningRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _sanctionScreeningRepository = sanctionScreeningRepository;
        }

        #endregion

        #region Methods

        public async Task<CibScreeningBlackListDetailsResponseModel> GetDataFromCibSanctionList(PepAndOtherSanctionModel pepAndOtherSanctionModel)
        {
            try
            {
                CibScreeningBlackListDetailsRequestModel reqModel = new CibScreeningBlackListDetailsRequestModel();
                reqModel.ApiUrl = _configuration.GetSection("CibUrl:ApiUrl").Value;
                reqModel.MerchantId = _configuration.GetSection("CibUrl:MerchantId").Value;
                reqModel.SecretKey = _configuration.GetSection("CibUrl:SecretKey").Value;
                reqModel.MiddlewareUrl = _configuration.GetSection("CibUrl:MiddlewareUrl").Value;
                reqModel.Data = "<BlackListVerify><SerialNumber>121</SerialNumber><RequestType>" + pepAndOtherSanctionModel.ScanType + "</RequestType><Name>" + pepAndOtherSanctionModel.FullName + "</Name><CitizenshipNo></CitizenshipNo><FatherName></FatherName><CitizenshipIssuedDate></CitizenshipIssuedDate><CitizenshipIssuedDistrict></CitizenshipIssuedDistrict><ConsumerDOB></ConsumerDOB><PassportNo></PassportNo><IndianEmbassyNo></IndianEmbassyNo></BlackListVerify>";
                CibScreeningBlackListDetailsResponseModel resModel = new CibScreeningBlackListDetailsResponseModel();
                var requestBody = JsonConvert.SerializeObject(new
                {
                    MerchantId = reqModel.MerchantId,
                    ApiUrl = reqModel.ApiUrl,
                    SecretKey = reqModel.SecretKey,
                    Data = reqModel.Data,
                });

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    using (var http_response = await client.PostAsync(reqModel.MiddlewareUrl, new StringContent(requestBody, Encoding.UTF8, "application/json")))
                    {
                        string requestStr = http_response.RequestMessage.ToString();
                        string responseStr = await http_response.Content.ReadAsStringAsync();
                        if (http_response.IsSuccessStatusCode)
                        {

                            var jObject = Newtonsoft.Json.Linq.JObject.Parse(responseStr);
                            JToken token = jObject.SelectToken("BlackListVerify.BlackListDetails.BlackListStatus", errorWhenNoMatch: false);
                            string status = string.Empty;

                            if (token != null)
                            {
                                status = token.ToString().ToUpper();
                                if (status == "NO")
                                {
                                    resModel.BlackListVerify.BlackListDetails.Add(new BlackListDetail { BlackListStatus = status });
                                }
                            }                            
                            else
                            {
                                resModel = JsonConvert.DeserializeObject<CibScreeningBlackListDetailsResponseModel>(responseStr);
                                await _sanctionScreeningRepository.InsertBlackList(resModel);
                            }

                        }
                        return resModel;

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return null;
        }

        public async Task<List<PepAndOtherSanctionResponseModel>> GetSanctionDataBusiness(PepAndOtherSanctionModel pepAndOtherSanctionModel)
        {
            try
            {
                if (pepAndOtherSanctionModel == null)
                {
                    throw new ArgumentNullException(nameof(pepAndOtherSanctionModel));
                }
                var result = await _sanctionScreeningRepository.SelectSactionDataRepository(pepAndOtherSanctionModel);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
