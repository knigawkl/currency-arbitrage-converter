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

        public void Find(CurrencyVertex from, CurrencyVertex to, double moneyAtStart)
        {
        
        }
    }
}
