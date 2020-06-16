namespace projeto.tcc.market.feeder.api.v1.Dto
{
    public class AssetsDto
    {
        public AssetsDto(string symbol, string price, string variation)
        {
            Symbol = symbol;
            Price = price;
            Variation = variation;
        }

        public string Symbol { get; set; }
        public string Price { get; set; }
        public string Variation { get; set; } 
    }
}
