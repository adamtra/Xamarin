using System;
using System.Collections.Generic;
using System.Text;

namespace Books
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
