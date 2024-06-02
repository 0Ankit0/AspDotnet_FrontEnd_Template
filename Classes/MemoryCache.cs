namespace Template.Classes{
     public interface IMemoryCache
    {
        T Get<T>(string key);
        void Set<T>(string key, T value);
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
            var options = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(slidingExpiration ?? TimeSpan.FromMinutes(2))
                .SetAbsoluteExpiration(absoluteExpiration ?? DateTimeOffset.Now.AddMinutes(5));

            _memoryCache.Set(key, value, options);
        }
        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
     
}