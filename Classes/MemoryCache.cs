using Microsoft.Extensions.Caching.Memory;

namespace Template.Classes{
     public interface IMemoryCache
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan? slidingExpiration = null, DateTimeOffset? absoluteExpiration = null);
        void Remove(string key);
    } 
 public class MemoryCache : IMemoryCache
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }
      public void Set<T>(string key, T value, TimeSpan? slidingExpiration = null, DateTimeOffset? absoluteExpiration = null)
        {
            slidingExpiration = slidingExpiration ?? TimeSpan.FromMinutes(2);
            absoluteExpiration=absoluteExpiration??DateTimeOffset.Now.AddMinutes(2);
            _memoryCache.Set(key, value, slidingExpiration,absoluteExpiration);

        }
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
     
}