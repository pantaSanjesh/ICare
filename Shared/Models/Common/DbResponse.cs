using System;
using System.Collections.Generic;
using System.Text;

namespace ICare.Shared.Models.Common
{
    public class DbResponse
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Id { get; set; }
        public string Extra { get; set; }
    }
}
