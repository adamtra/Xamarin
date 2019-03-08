using System.Collections.Generic;
using System.Threading.Tasks;
using Wizytówki.Models;

namespace Wizytówki.Services
{
    public interface IFileReadWrite
    {  
        void WriteData(string fileName, string data);
        string ReadData(string filename);
        void DeleteFile(string filename);
        List<Person> GetAll(); 
    }  
}