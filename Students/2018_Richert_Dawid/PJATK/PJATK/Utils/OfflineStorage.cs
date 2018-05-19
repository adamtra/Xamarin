using System.IO;
using System.Threading.Tasks;
using PJATK.Services;
using Xamarin.Forms;

namespace PJATK.Utils
{
    public static class OfflineStorage
    {
        public static async void SaveData<T>(string json)
        {
            await WriteToFile(json, GetFileName<T>());
        }

        public static async Task<string> GetData<T>()
        {
            return await ReadFile(GetFileName<T>());
        }

        private static async Task WriteToFile(string text, string fileName)
        {
            await DependencyService.Get<ISaveAndLoad>().SaveText(fileName, text);
        }

        private static async Task<string> ReadFile(string fileName)
        {
            return await DependencyService.Get<ISaveAndLoad>().LoadText(fileName);
        }

        private static string GetFileName<T>()
        {
            return $"{typeof(T).Name}.json";
        }
    }
}
