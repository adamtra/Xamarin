using Microsoft.Extensions.Caching.Memory;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(Epertoire2.Services.CacheService))]
namespace Epertoire2.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        public T Get<T>(string key) where T : class
        {
            if (_memoryCache.TryGetValue(key, out T value))
            {
                return value;
            }
            else
            {
                return default(T);
            }
        }

        public void Set<T>(string key, T value, DateTimeOffset absoluteExpiration) where T : class
        {
            _memoryCache.Set<T>(key, value, absoluteExpiration);
        }
    }
}
