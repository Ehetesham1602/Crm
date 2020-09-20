using Crm.Entities;

namespace AccountErp.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int? CountryId { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string PostalCode { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
    }
}
