using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using projeto.tcc.market.feeder.api.v1.RabbitMQ;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace projeto.tcc.market.feeder.api.v1.BackgroundTasks
{
    public class AlphavantageTask : BackgroundService
    {
        private readonly ILogger<AlphavantageTask> _logger;
        private readonly IDistributedCache _cache;

        public AlphavantageTask(ILogger<AlphavantageTask> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.Register(() => _logger.LogDebug("#1 AlphavantageTask background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug("GracePeriodManagerService background task is doing background work.");

                var quote = await GetAssetQuotationFromAlphavantage();

                RabbitMQMessengeQueuer rb = new RabbitMQMessengeQueuer(_cache);

                Console.WriteLine("BACKGROUND");

                await rb.GetEmployees("a", "b");

                await Task.CompletedTask;
            }
        }

        public async Task<dynamic> GetAssetQuotationFromAlphavantage()
        {
            dynamic resutlt;

            using (var client = new HttpClient())
            using (var response = await client.GetAsync("https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=IBM&apikey=demo"))
            {
                //TODO adicionar tratamento de erros
                resutlt = await response.Content.ReadAsAsync<dynamic>();
            }

            return resutlt;
        }
    }
}
