using System.Collections.Generic;
using System.Linq;

namespace Epertoire2.Model
{
    public class Genre
    {
        private List<string> _aliases;

        public bool IsToggled { get; set; }
        public string Name { get; set; }

        public Genre(string name, List<string> aliases)
        {
            Name = name;
            _aliases = aliases;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool IsIn(List<string> names)
        {
            foreach (var alias in _aliases)
            {
                var query = from n in names where n.ToLower().Contains(alias.ToLower()) select n;
                if (query.Count() != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
