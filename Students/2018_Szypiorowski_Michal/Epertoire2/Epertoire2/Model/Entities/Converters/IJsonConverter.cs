using System;

namespace Epertoire2.Model.Entities.Converters
{
    public interface IJsonConverter
    {
        object DeserializeObject(string json, Type type);
    }
}
