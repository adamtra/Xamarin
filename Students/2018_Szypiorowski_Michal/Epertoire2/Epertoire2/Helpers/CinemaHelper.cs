using Epertoire2.Model;
using Xamarin.Forms;

namespace Epertoire2.Helpers
{
    public static class CinemaHelper
    {
        public static Color TextColor(CinemaType type)
        {
            Color color = Color.Black;
            switch (type)
            {
                case CinemaType.CinemaCity:
                    color = Color.OrangeRed;
                    break;
                case CinemaType.Multikino:
                    color = Color.MediumVioletRed;
                    break;
                default:
                    color = Color.Black;
                    break;
            }

            return color;
        }

        public static CinemaType Type(string name)
        {
            CinemaType type;
            if (name.Contains("Cinema City"))
            {
                type = CinemaType.CinemaCity;
            }
            else
            {
                type = CinemaType.Multikino;
            }

            return type;
        }
    }
}
