using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using FormsTest;

namespace FormsTest.Services
{
    public class GetDate
    {

        private const string Url = "https://api.pvpallday.com/v1/private/next_visit";

        private HttpClient _client = new HttpClient();

        public async Task<Date> GetInfo() {

            var response = await _client.GetAsync(Url);

            if (response.StatusCode == HttpStatusCode.NotFound) {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Date>(content);
            
        }
    }
}
