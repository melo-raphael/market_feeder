using projeto.tcc.market.feeder.application.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace projeto.tcc.market.feeder.infra.data.Proxies
{
    public class AlphavantageClient : IAlphavantageClient
    {
        public async Task<string> GetAssetQuotationFromAlphavantage(string symbol)
        {
            using (var client = new HttpClient())
            using (var response = await client.GetAsync($"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}.SA&apikey=990DW191GQ1YJHO4"))
            {
                var result = await response.Content.ReadAsStringAsync();

                var splitResult = result.Split(":")[6];

                var price = splitResult.Substring(2, 5);

                return price;

            }

        }
    }
}
