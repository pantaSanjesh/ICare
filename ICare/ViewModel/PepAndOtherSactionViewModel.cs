using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.ViewModel
{
    public class PepAndOtherSactionViewModel
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        //[Required(ErrorMessage = "Scan Type is required.")]
        public string ScanType { get; set; }
        //represents the identification document number.
        public string UniqueId { get; set; }
        //represents the identifiaction document type like citizenship,passport etc.
        public string UniqueIdType { get; set; }
        public string Nationality { get; set; }
    }
}
