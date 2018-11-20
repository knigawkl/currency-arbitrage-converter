using System.Collections.Generic;

namespace GWhub
{
    class BestExchange
    {
        private List<CurrencyVertex> vertices;
        private List<ExchangeEdge> edges;

        public BestExchange(Digraph graph)
        {  
            vertices = graph.nodes;
            edges = graph.edges;
        }

        public void Find(CurrencyVertex src, CurrencyVertex to, double moneyAtStart)
        {
            src.MoneyAt = moneyAtStart;
            src.MinDistance = 0;

            for (int i = 0; i < vertices.Count - 1; ++i)
            {
                foreach (var edge in edges)
                {
                    if (edge.StartVertex.MinDistance == int.MaxValue)
                    {
                        continue;
                    }

                    if (edge.FeeType == (int)ExchangeEdge.ChargeType.Percent)
                    {
                        
                    }
                }
            }
        }
    }
}
