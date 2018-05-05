using Books;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Books
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
