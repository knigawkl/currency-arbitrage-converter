namespace GWhub
{
    public class ExchangeEdge
    {
        public enum ChargeType { Standing, Percent };

        public ExchangeEdge(CurrencyVertex start, CurrencyVertex finish, double weight, int chargeType, double charge)
        {
            StartVertex = start;
            FinishVertex = finish;
            FeeType = chargeType;
            Charge = charge;
            Weight = weight;
        }

        public double ArbWeight { get; set; }
        public double Weight { get; set; }
        public CurrencyVertex StartVertex { get; set; }
        public CurrencyVertex FinishVertex { get; set; }
        public int FeeType { get; set; } 
        public double Charge { get; set; }
    }
}