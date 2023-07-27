using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Shared.Models.SanctionScreeningModel
{
    public class CibScreeningBlackListDetailsResponseModel
    {
        public CibScreeningBlackListDetailsResponseModel()
        {
            BlackListVerify = new BlackListVerify();
        }
        public BlackListVerify BlackListVerify { get; set; }
        public BlackListError BlackListError { get; set; }
    }

    public class BlackListVerify
    {
        public BlackListVerify()
        {
            BlackListDetails = new List<BlackListDetail>();
        }
        public List<BlackListDetail> BlackListDetails { get; set; }        
    }

    public class BlackListDetail
    {
        public string SerialNumber { get; set; }
        public string BlackListStatus { get; set; }
        public string Type { get; set; }
        public string BlackListNo { get; set; }
        public string BlackListedDate { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string CitizenshipNumber { get; set; }
        public string PassportNumber { get; set; }
        public string IndianEmbassyNumber { get; set; }
    }

    public class BlackListError
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }



}
