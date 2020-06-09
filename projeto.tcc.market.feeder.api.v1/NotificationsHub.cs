//using Microsoft.AspNetCore.SignalR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace projeto.tcc.market.feeder.api.v1
//{
//    public class NotificationsHub : Hub
//    {

//        public static List<string> users = new List<string>();

//        public override async Task OnConnectedAsync()
//        {
//            await Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
//            await base.OnConnectedAsync();
//            users.Add(Context.ConnectionId);
//        }

//        public override async Task OnDisconnectedAsync(Exception ex)
//        {
//            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
//            await base.OnDisconnectedAsync(ex);
//        }
//    }
//}
