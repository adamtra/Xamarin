using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using Xamarin.Forms;

[assembly: Dependency(typeof(Epertoire2.Model.Entities.Converters.JsonConverter))]
namespace Epertoire2.Model.Entities.Converters
{
    public class JsonConverter : IJsonConverter
    {
        private readonly JsonSerializerSettings _settings;

        public JsonConverter()
        {
            _settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Culture = new CultureInfo("en-US"),
                Converters =
                {
                    new IsoDateTimeConverter
                    {
                        DateTimeStyles = DateTimeStyles.AssumeLocal
                    }
                }
            };
        }

        public object DeserializeObject(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type, _settings);
        }
    }
}
