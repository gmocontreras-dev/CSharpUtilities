
using System.Runtime.Caching;
using System;
namespace Matios
{
    public enum CacheItemAbsoluteExpirationEnum
    {
        Second,
        Minute,
        Hour,
        Day,
        Month,
        Year
    }
    public static class CacheItemHelper
    {

        private static ObjectCache objectCache;
        /// <summary>
        /// Remove item from cache
        /// </summary>
        /// <param name="key">Name of cached item</param>
        public static void Clear(string key)
        {
            if (objectCache == null)
            {
                objectCache = MemoryCache.Default;
                return;
            }
            objectCache.Remove(key);
        }

        public static T Get<T>(object p)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert value into the cache using
        /// appropriate name/value pairs
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="entity">item cached</param>
        /// <param name="key">Name of item</param>
        /// <param name="cacheItemAbsoluteExpirationEnum">Enum of CacheItemAbsoluteExpirationEnum</param>
        /// <param name="cacheExpiration">Number second, minute, hour, day, month, year</param>
        public static void Add<T>(T entity, string key, CacheItemAbsoluteExpirationEnum cacheItemAbsoluteExpirationEnum, int cacheExpiration) where T : class
        {
            if (objectCache == null)
            {
                objectCache = MemoryCache.Default;
            }
            if (objectCache.Contains(key))
                objectCache.Remove(key);
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            if (cacheItemAbsoluteExpirationEnum == CacheItemAbsoluteExpirationEnum.Day)
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddDays(cacheExpiration);
            else if (cacheItemAbsoluteExpirationEnum == CacheItemAbsoluteExpirationEnum.Hour)
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(cacheExpiration);
            else if (cacheItemAbsoluteExpirationEnum == CacheItemAbsoluteExpirationEnum.Minute)
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(cacheExpiration);
            else if (cacheItemAbsoluteExpirationEnum == CacheItemAbsoluteExpirationEnum.Month)
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMonths(cacheExpiration);
            else if (cacheItemAbsoluteExpirationEnum == CacheItemAbsoluteExpirationEnum.Second)
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddSeconds(cacheExpiration);
            else if (cacheItemAbsoluteExpirationEnum == CacheItemAbsoluteExpirationEnum.Year)
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddYears(cacheExpiration);
            objectCache.Set(key, entity, cacheItemPolicy);
        }// public static void Add<T>(T entity, string key, CacheItemAbsoluteExpirationEnum cacheItemAbsoluteExpirationEnum,int cacheExpiration) where T : class

        /// <summary>
        /// Retrieve cached item
        /// </summary>
        /// <typeparam name="T">Type of cached item</typeparam>
        /// <param name="key">Name of cached item</param>
        /// <returns>Cached item as type</returns>
        public static T Get<T>(string key) where T : class
        {
            if (objectCache == null)
            {
                objectCache = MemoryCache.Default;
            }
            try
            {
                return (T)objectCache.Get(key);
            }
            catch
            {
                return null;
            }
        }
    }
}
