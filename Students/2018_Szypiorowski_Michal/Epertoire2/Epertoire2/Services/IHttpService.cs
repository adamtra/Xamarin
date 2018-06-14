using System.Net.Http;
using System.Threading.Tasks;

namespace Epertoire2.Services
{
    public interface IHttpService
    {
        Task<string> Get(string uri);
        Task<bool> Post(string uri, StringContent content);
    }
}
