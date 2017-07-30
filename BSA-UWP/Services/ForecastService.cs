using BSA_UWP.Models.OpenWeatherMap;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BSA_UWP.Services
{
    public class ForecastService
    {
        private readonly string apiURL = "http://localhost:58066/api/forecast";

        public async Task<Weather> GetForecast(string city, int days = 7)
        {
            string json = null;

            using (var client = new HttpClient())
            {
                json = await client.GetStringAsync($"{apiURL}?city={city}&days={days}");
            }

            return JsonConvert.DeserializeObject<Weather>(json);
        }
    }
}
