using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using PJATK.iOS.Services;
using PJATK.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad))]
namespace PJATK.iOS.Services
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