using System.Collections.Generic;

namespace GWhub
{
    public class CurrencyVertex
    {
        public CurrencyVertex(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }
        public double MoneyAt { get; set; } = 0;
        public double ArbMoneyAt { get; set; } = 0;
        public double MinDistance { get; set; } = int.MaxValue;
        public double ArbitrageMinDistance { get; set; } = int.MaxValue;
        public CurrencyVertex Prev { get; set; }
        public CurrencyVertex ArbPrev { get; set; }
        public bool Visited { get; set; }

        public override string ToString() => this.Symbol;
    }
}
