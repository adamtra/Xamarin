using System;
using System.Collections.Generic;
using Xamarin.Forms;
using _42TextFileTryout;

[assembly: Dependency(typeof(_42TextFileTryout.UWP.FileHelper))]

namespace _42TextFileTryout.UWP
{
    class FileHelper : IFileHelper
    {
        public bool Exists(string filename)
        {
            return false;
        }

        public void WriteText(string filename, string text)
        {
            throw new NotImplementedException("Writing files is not implemented");
        }

        public string ReadText(string filename)
        {
            throw new NotImplementedException("Reading files is not implemented");
        }

        public IEnumerable<string> GetFiles()
        {
            return new string[0];
        }

        public void Delete(string filename)
        {
        }
    }
}
