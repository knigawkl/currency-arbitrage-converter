using System;
using System.Collections.Generic;
using System.Text;

namespace GWhub
{
    public class Arbitrage
    {
        private List<CurrencyVertex> vertices;
        private List<ExchangeEdge> edges;
        

        public Arbitrage(Digraph graph)
        {
            vertices = graph.nodes;
            edges = graph.edges;
            
        }

        public List<CurrencyVertex> Find(double moneyAtStart)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                var predecessors = new List<CurrencyVertex>();
                foreach (var edge in edges)
                {
                    if (edge.FinishVertex.Equals(vertices[i]))
                    {
                        predecessors.Add(edge.StartVertex);
                    }
                }






            }
            
        }

        private bool HasCycle(ExchangeEdge edge)
        {
            return edge.FinishVertex.ArbitrageMinDistance > edge.StartVertex.ArbitrageMinDistance + edge.Weight;
        }

        public string PrintOutput(List<CurrencyVertex> path, double startMoney)
        {
            StringBuilder sb = new StringBuilder();
            if (path.Count != 0)
            {
                sb.Append(String.Format("{0:0.00}", startMoney.ToString()));
                sb.Append(" ");
                for (int i = 0; i < path.Count; i++)
                {
                    sb.Append(path[i].Symbol);
                    sb.Append(" -> ");
                }

                decimal weightsMultiplied = 1;
                int j = 1;
                for (int i = 0; i < path.Count - 1; i++)
                {
                    var e = edges.Find(x => (x.StartVertex.Equals(path[i])) && (x.FinishVertex.Equals(path[j])));
                    j++;
                    weightsMultiplied *= (decimal)Math.Exp(-e.Weight);
                }

                var ed = edges.Find(x => (x.StartVertex.Equals(path[path.Count - 1])) && (x.FinishVertex.Equals(path[0])));
                weightsMultiplied *= (decimal)Math.Exp(-ed.Weight);

                sb.Append(String.Format("{0:0.00}", weightsMultiplied * (decimal)startMoney));

                sb.Append(" ");
                sb.Append(path[0].Symbol);
            }

            return sb.ToString();
        }

        public double Inverse(double money) => 1 / money;
    }
}