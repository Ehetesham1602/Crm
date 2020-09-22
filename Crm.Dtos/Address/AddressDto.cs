namespace AccountErp.Dtos.Address
{
    public class AddressDto
    {
        public int? Id { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string CountryName { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string PostalCode { get; set; }
    }
}
