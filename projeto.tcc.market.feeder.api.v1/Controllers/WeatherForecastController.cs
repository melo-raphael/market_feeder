using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace projeto.tcc.market.feeder.api.v1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
      
        private readonly ILogger<WeatherForecastController> _logger;
        //private readonly IHubContext<NotificationsHub> _hubContext;


        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //using (var client = new HttpClient())
            //{
            //    //var result = await client.GetAsync("https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=IBM&apikey=demo");
            //    ////TODO adicionar tratamento de erros
            //    //Console.WriteLine(NotificationsHub.users.Count());
            //    //NotificationsHub.users.ForEach(i => Console.WriteLine(i));

            //    //await _hubContext.Clients.All.SendAsync("teste", "teste");
            //    //return Ok(result.Content);
            //    return Ok();
            //}

            return Ok();

        }
    }
}
