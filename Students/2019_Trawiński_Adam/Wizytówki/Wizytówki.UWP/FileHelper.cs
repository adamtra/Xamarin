using System;  
using System.IO;
using Windows.Storage;
using Xamarin.Forms;  
using Wizytówki.UWP;  
using Wizytówki.Services;
using Wizytówki.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

[assembly: Dependency(typeof(FileHelper))]  
namespace Wizytówki.UWP
{  
    public class FileHelper: IFileReadWrite
    {
        public void WriteData(string filename, string data)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, data);
        }  
        public string ReadData(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);  
            var filePath = Path.Combine(documentsPath, filename);  
            return File.ReadAllText(filePath);
        }
        public void DeleteFile(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filePath = Path.Combine(documentsPath, filename);
            File.Delete(filePath);
        }
        public List<Person> GetAll()
        {
            List<Person> people = new List<Person>();
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var files = Directory.GetFiles(documentsPath);
            foreach (var file in files)
            {
                string allData = ReadData(file);
                string[] lines = allData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                Person person = new Person
                {
                    Id = lines[0],
                    FirstName = lines[1],
                    LastName = lines[2],
                    PhoneNumber = lines[3],
                    EmailAddress = lines[4]
                };
                people.Add(person);
            }
            return people;
        }
    }  
}  