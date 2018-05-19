using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PJATK.Droid.Services;
using PJATK.Services;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace PJATK.Droid.Services
{
    public class SaveAndLoad : ISaveAndLoad
    {
        public Task SaveText(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);

            return Task.CompletedTask;
        }
        public Task<string> LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return Task.FromResult(System.IO.File.ReadAllText(filePath));
        }
    }
}