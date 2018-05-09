using PatientsStory.Droid.Helpers;
using PatientsStory.Helpers;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace PatientsStory.Droid.Helpers
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), fileName);
        }
    }
}