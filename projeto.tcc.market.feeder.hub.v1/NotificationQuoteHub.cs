using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto.tcc.market.feeder.api.v1
{
    public class NotificationQuoteHub : Hub
    {
        private readonly List<string> users;
        private readonly IDistributedCache _cache;

        public NotificationQuoteHub(IDistributedCache cache)
        {
            users = new List<string>();
            _cache = cache;
        }

        public override Task OnConnectedAsync()
        {
            users.Add(Context.ConnectionId);

            //Ao usar o método All eu estou enviando a mensagem para todos os usuários conectados no meu Hub
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(System.Exception exception)
        {
            users.Remove(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }

    }
}
