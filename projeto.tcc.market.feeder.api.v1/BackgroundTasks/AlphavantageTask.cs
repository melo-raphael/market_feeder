using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using projeto.tcc.market.feeder.api.v1.Dto;
using projeto.tcc.market.feeder.application.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace projeto.tcc.market.feeder.api.v1.BackgroundTasks
{
    public class AlphavantageTask : BackgroundService
    {
        private readonly ILogger<AlphavantageTask> _logger;
        private readonly IHubContext<NotificationQuoteHub> _hubContext;
        private readonly IAlphavantageClient _alphaVantageClient;
        private readonly ICache _cache;
        public AlphavantageTask(ILogger<AlphavantageTask> logger, IHubContext<NotificationQuoteHub> hubContext, IAlphavantageClient alphavantageClient, ICache cache)
        {
            _logger = logger;
            _hubContext = hubContext;
            _alphaVantageClient = alphavantageClient;
            _cache = cache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            stoppingToken.Register(() => _logger.LogDebug("#1 AlphavantageTask background task is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {
                    var assetValues = Enum.GetValues(typeof(AssetsEnum));
                    List<AssetsDto> list = new List<AssetsDto>();

                    foreach (var value in assetValues)
                    {
                        string symbol = Enum.GetName(typeof(AssetsEnum), value);

                        var quote = await _alphaVantageClient.GetAssetQuotationFromAlphavantage(symbol);

                        await _cache.SetQuoteRedis(symbol, quote);

                        list.Add(new AssetsDto(symbol, String.Format("{0:0.##}", quote), "15.00%"));

                        if (list.Count() == 5)
                        {
                            await _hubContext.Clients.All.SendAsync("Quote", list, "15.00%");
                            Thread.Sleep(200000);
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }



    }
}
