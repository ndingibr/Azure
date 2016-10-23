using Newtonsoft.Json;
using ServiceStack.Common.Extensions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Data
{
    public class RedisCacheManager
    {
        #region Fields

        private readonly Lazy<ConnectionMultiplexer> _lazyConnection;
        private readonly IDatabase _cache;

        #endregion

        #region Ctor

        public RedisCacheManager(Lazy<ConnectionMultiplexer> lazyConnection,
            ConnectionMultiplexer connection)
        {
            this._lazyConnection = lazyConnection;
            this._cache = connection.GetDatabase();
        }

        #endregion

        #region Utilities

        public T Get<T>(string key)
        {
            string serializedObject = _cache.StringGet(key);
            if (!(serializedObject.IsNullOrEmpty()))
            {
                return JsonConvert.DeserializeObject<T>(serializedObject);
            }

            return default(T);
        }

        public object Get(string key)
        {
            string serializedObject = _cache.StringGet(key);
            if (!(serializedObject.IsNullOrEmpty()))
            {
                return JsonConvert.DeserializeObject<object>(serializedObject);
            }

            return null;
        }

        public void Set(string key, object value)
        {
            string serializedObject = JsonConvert.SerializeObject(value);
            _cache.StringSet(key, serializedObject);

        }

        public T GetSortedList<T>(string key, string order)
        {

            var sortedEntry = _cache.SortedSetRangeByRankWithScores(key, order: Order.Descending);
            if (sortedEntry.Count() > 0)
            {
                List<T> list = sortedEntry.Select(t =>
                JsonConvert.DeserializeObject<T>(t.Element)).ToList();
            }
            return default(T);

        }

        public void ClearCache(string[] keys)
        {
            foreach (var key in keys)
            {
                if (_cache.KeyExists(key))
                    _cache.KeyDelete(key);
            }
        }

    }

    #endregion
}



