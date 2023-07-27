using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ICare.Shared.Models
{
    public class PepAndOtherSanctionModel
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Scan Type is required.")]
        public string ScanType { get; set; }
        //represents the identification document number.
        public string UniqueId { get; set; }
        //represents the identifiaction document type like citizenship,passport etc.
        public string UniqueIdType { get; set; }
        //public string Nationality { get; set; }
        //public string User { get; set; }
        //public string Sources { get; set; }
        //public string MatchPercent { get; set; } = "80";
    }
}
