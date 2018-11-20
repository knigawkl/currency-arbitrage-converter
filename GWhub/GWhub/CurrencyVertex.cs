using System.Collections.Generic;

namespace GWhub
{
    public class CurrencyVertex
    {
        public CurrencyVertex(string symbol)
        {
            Symbol = symbol;
            Edges = new List<ExchangeEdge>();
        }

        public string Symbol { get; }
        public double MoneyAt { get; set; } = int.MaxValue;
        public CurrencyVertex Prev { get; set; }
        public List<ExchangeEdge> Edges { get; }

        public void AddEdge(ExchangeEdge edge)
        {
            this.Edges.Add(edge);
        }

        public double InverseMoney() => 1 / this.MoneyAt;

        public override string ToString() => this.Symbol;
    }
}
