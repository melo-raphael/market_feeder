using Microsoft.Extensions.Caching.Distributed;
using projeto.tcc.market.feeder.application.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.market.feeder.infra.data.RedisCache
{
    public class RedisCache : ICache
    {

        private readonly IDistributedCache _cache;

        public RedisCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetQuoteRedis(string symbol, string quote)
        {
            var cacheSettings = new DistributedCacheEntryOptions();
            await _cache.SetStringAsync(symbol, quote, cacheSettings);
        }
    }
}
