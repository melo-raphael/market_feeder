using Microsoft.Extensions.Caching.Distributed;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace projeto.tcc.market.feeder.api.v1.RabbitMQ
{
    public class RabbitMQMessengeQueuer
    {
        private readonly IDistributedCache _cache;

        public RabbitMQMessengeQueuer(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task GetEmployees(string quote, string symbol)
        {
            
            var cacheSettings = new DistributedCacheEntryOptions();
            await _cache.SetStringAsync(symbol, quote, cacheSettings);
        }

    }
}
