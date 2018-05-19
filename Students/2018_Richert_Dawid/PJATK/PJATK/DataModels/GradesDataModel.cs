using System.Collections.Generic;
using PJATK.Models;

namespace PJATK.DataModels
{
    public class GradesDataModel
    {
        public string Name { get; set; }
        public ICollection<Oceny> Grades { get; set; }
    }
}
