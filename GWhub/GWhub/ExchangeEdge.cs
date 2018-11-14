namespace GWhub
{
    public class ExchangeEdge
    {
        public ExchangeEdge(CurrencyVertex start, CurrencyVertex finish, double weight)
        {
            StartVertex = start;
            FinishVertex = finish;
            Weight = weight;
        }

        public double Weight { get; set; }
        public CurrencyVertex StartVertex { get; set; }
        public CurrencyVertex FinishVertex { get; set; }
    }
}
