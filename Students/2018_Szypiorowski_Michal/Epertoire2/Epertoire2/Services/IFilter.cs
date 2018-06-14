using Epertoire2.Model;
using System;

namespace Epertoire2.Services
{
    public interface IFilter
    {
        string Title { get; set; }
        TimeSpan EndTime { get; set; }
        TimeSpan StartTime { get; set; }

        bool Check(object movie);
        void Clear();
        Genre GetGenre(string name);
        void RefreshStatus();
    }
}
