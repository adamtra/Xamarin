using System.Threading.Tasks;

namespace PJATK.Services
{
    public interface ISaveAndLoad
    {
        Task SaveText(string filename, string text);
        Task<string> LoadText(string filename);
    }
}
