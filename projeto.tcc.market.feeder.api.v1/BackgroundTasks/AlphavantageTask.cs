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
        decimal variation = 20.60M;
        decimal variation2 = 20.20M;

        public AlphavantageTask(ILogger<AlphavantageTask> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            variation += 0.1M;
            variation2 += 0.2M;


            stoppingToken.Register(() => _logger.LogDebug("#1 AlphavantageTask background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogDebug("GracePeriodManagerService background task is doing background work.");

                var quote = await GetAssetQuotationFromAlphavantage();

                RabbitMQMessengeQueuer rb = new RabbitMQMessengeQueuer(_cache);

                Console.WriteLine("BACKGROUND");

                await rb.GetEmployees(variation.ToString(), "PETR4");

                await rb.GetEmployees(variation2.ToString(), "AMBEV");


                await Task.CompletedTask;
            }
        }

        public async Task<dynamic> GetAssetQuotationFromAlphavantage()
        {
            dynamic resutlt;

            using (var client = new HttpClient())
            using (var response = await client.GetAsync("https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=PETR4.SA&apikey=990DW191GQ1YJHO4"))
            {
                //TODO adicionar tratamento de erros
                resutlt = await response.Content.ReadAsAsync<dynamic>();
            }

            return resutlt;
        }

  
    }
}
