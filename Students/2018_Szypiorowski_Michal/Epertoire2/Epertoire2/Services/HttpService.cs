using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Epertoire2.Services.HttpService))]
namespace Epertoire2.Services
{
    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> Get(string uri)
        {
            var responseMessage = await _httpClient.GetAsync(uri);
            responseMessage.EnsureSuccessStatusCode();
            var contentAsString = await responseMessage.Content.ReadAsStringAsync();
            return contentAsString;
        }

        public async Task<bool> Post(string uri, StringContent content)
        {
            var responseMessage = await _httpClient.PostAsync(uri, content);
            return responseMessage.IsSuccessStatusCode;
        }
    }
}
