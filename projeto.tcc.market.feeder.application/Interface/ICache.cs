using System.Threading.Tasks;

namespace projeto.tcc.market.feeder.application.Interface
{
    public interface ICache
    {
        Task SetQuoteRedis(string symbol, string quote);
    }
}
