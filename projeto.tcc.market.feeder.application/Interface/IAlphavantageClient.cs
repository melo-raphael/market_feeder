using System.Threading.Tasks;

namespace projeto.tcc.market.feeder.application.Interface
{
    public interface IAlphavantageClient
    {
        Task<string> GetAssetQuotationFromAlphavantage(string symbol);
    }
}
