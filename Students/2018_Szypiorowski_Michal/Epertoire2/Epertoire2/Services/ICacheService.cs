using System;

namespace Epertoire2.Services
{
    public interface ICacheService
    {
        T Get<T>(string key) where T : class;
        void Set<T>(string key, T value, DateTimeOffset absoluteExpiry) where T : class;
    }
}
