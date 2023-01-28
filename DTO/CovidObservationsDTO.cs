namespace DTO
{
    public class CovidObservationsDTO
    {
        public int SNo { get; set; }
        public DateTime ObservationDate { get; set; }
        public string? ProvinceState { get; set; }
        public string? CountryRegion { get; set; }
        public DateTime LastUpdate { get; set; }
        public decimal Confirmed { get; set; }
        public decimal Deaths { get; set; }
        public decimal Recovered { get; set; }
    }
}
