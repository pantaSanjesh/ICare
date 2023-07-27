using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Shared.Models
{
    public class CibScreeningBlackListDetailsRequestModel
    {        
        public string MerchantId { get; set; }
        public string ApiUrl { get; set; }
        public string MiddlewareUrl { get; set; }
        public string SecretKey { get; set; }
        public string Data { get; set; }

    }

}
