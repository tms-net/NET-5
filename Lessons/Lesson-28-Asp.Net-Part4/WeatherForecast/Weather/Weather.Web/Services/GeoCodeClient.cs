
namespace Weather.Web.Services
{
    public class GeoCodeClient
    {
        private HttpClient _httpClient = new HttpClient();

        public async Task<GeoCodeLookupResult> LookupAsync(string location)
        {
            var response = await _httpClient.GetAsync($"https://geocode.xyz/{location}?geoit=json");

            // TODO: Check response status

            var json = await response.Content.ReadAsStringAsync();

            // TODO: Parse response to object

            return new GeoCodeLookupResult();
        }
    }

    public class GeoCodeLookupResult
    {
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public GeoCodeLocation Location { get; set; }
    }

    public class GeoCodeLocation
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
    }
}
