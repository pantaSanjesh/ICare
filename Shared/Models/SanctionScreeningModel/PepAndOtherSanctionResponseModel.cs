using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Shared.Models
{
    public class PepAndOtherSanctionResponseModel
    {
        //public PepAndOtherSanctionResponseModel()
        //{
        //    CibScreeningBlackListDetails = new List<CibScreeningBlackListDetailsModel>();
        //}
        public string MatchName { get; set; }
        public string MatchedId { get; set; }
        public string Remarks { get; set; }
        public string Source { get; set; }
        //public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string MatchPercent { get; set; }
        //public List<CibScreeningBlackListDetailsModel> CibScreeningBlackListDetails { get; set; }
    }        
}
