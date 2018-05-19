using Newtonsoft.Json.Converters;

namespace PJATK.Utils
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            DateTimeFormat = "dd-MM-yyyy";
        }
    }
}
