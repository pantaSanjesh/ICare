using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Shared.Models
{
	[XmlRoot(ElementName = "")]
	public class InfoModel
    {		
			public int Sno { get; set; }
			public string branch { get; set; }
			public string submission_code { get; set; }
			public string report_code { get; set; }
			public string submission_date { get; set; }
			public string currency_code_local { get; set; }
			public string gender { get; set; }
			public string title { get; set; }
			public string first_name { get; set; }
			public string LastName { get; set; }
			public string nationality { get; set; }
			public string contact_type { get; set; }
			public string communicationType { get; set; }
			public string country_prefix { get; set; }
			public string number { get; set; }
			public string address_type { get; set; }
			public string address { get; set; }
			public string town { get; set; }
			public string city { get; set; }
			public string zip { get; set; }
			public string country_code { get; set; }
			public string state { get; set; }
			public string email { get; set; }
			public string L_address_type { get; set; }
			public string L_address { get; set; }
			public string L_city { get; set; }
			public string L_zip { get; set; }
			public string L_country_code { get; set; }
			public string l_state { get; set; }
			public string reason { get; set; }
			public string action { get; set; }
		}
}
