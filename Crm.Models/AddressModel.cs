using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Models
{
    public class AddressModel
    {
        public int? Id { get; set; }
        public int? CountryId { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string PostalCode { get; set; }
    }
}
