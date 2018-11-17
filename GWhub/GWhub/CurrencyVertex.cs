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
        public bool Visisted { get; set; } = false;
        public double MinDistance { get; set; } = int.MaxValue;
        public CurrencyVertex Prev { get; set; }
        public List<ExchangeEdge> Edges { get; }

        public void AddEdge(ExchangeEdge edge)
        {
            this.Edges.Add(edge);
        }

        public override string ToString()
        {
            return this.Symbol;
        }
    }
}
