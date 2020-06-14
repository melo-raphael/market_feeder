//using microsoft.aspnetcore.signalr;
//using system;
//using system.collections.generic;
//using system.linq;
//using system.threading.tasks;

//namespace projeto.tcc.market.feeder.api.v1
//{
//    public class notificationshub : hub
//    {

//        public static list<string> users = new list<string>();

//        public override async task onconnectedasync()
//        {
//            await groups.addtogroupasync(context.connectionid, context.user.identity.name);
//            await base.onconnectedasync();
//            users.add(context.connectionid);
//        }

//        public override async task ondisconnectedasync(exception ex)
//        {
//            await groups.removefromgroupasync(context.connectionid, context.user.identity.name);
//            await base.ondisconnectedasync(ex);
//        }
//    }
//}
