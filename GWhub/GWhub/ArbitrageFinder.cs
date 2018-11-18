using System;
using System.Collections.Generic;
using System.Text;

namespace GWhub
{
    public class ArbitrageFinder
    {
        private List<CurrencyVertex> cycle = new List<CurrencyVertex>();
        private List<CurrencyVertex> vertices;
        private List<ExchangeEdge> edges;
        double money;
        double moneyAfterExchange;

        public ArbitrageFinder(Digraph graph, double startMoneyAmount)
        {
            vertices = graph.nodes;
            edges = graph.edges;
            money = startMoneyAmount;
            foreach (var edge in edges)
            {
                edge.Weight = -Math.Log(edge.Weight);
            }
            Find(vertices[0]);
            PrintCycle();
        }

        public void Find(CurrencyVertex start)
        {
            start.MinDistance = 0;

            for (int i = 0; i < vertices.Count - 1; ++i)
            { 
                foreach (var edge in edges)
                {
                    if (edge.StartVertex.MinDistance == int.MaxValue)
                    {
                        continue;
                    }

                    double newDistance = edge.StartVertex.MinDistance + edge.Weight;

                    if (newDistance < edge.FinishVertex.MinDistance)
                    {
                        edge.FinishVertex.MinDistance = newDistance;
                        edge.FinishVertex.Prev = edge.StartVertex;
                    }
                }
            }

            foreach (var edge in edges)
            {
                if (edge.StartVertex.MinDistance != int.MaxValue && HasCycle(edge))
                {
                    CurrencyVertex vertex = edge.StartVertex;

                    while (!vertex.Equals(edge.FinishVertex))
                    {
                        cycle.Add(vertex);
                        vertex = vertex.Prev;
                    }

                    this.cycle.Add(edge.FinishVertex);
                    cycle.Reverse();
                    return;
                }
            }
        }

        private bool HasCycle(ExchangeEdge edge)
        {
            return edge.FinishVertex.MinDistance > edge.StartVertex.MinDistance + edge.Weight;
        }

        public string PrintCycle()
        {
            if (this.cycle != null)
            {
                StringBuilder sb = new StringBuilder(money.ToString());
                foreach (CurrencyVertex ver in cycle)
                {
                    sb.Append(' ');
                    sb.Append(ver.Symbol);
                    sb.Append(' ');
                    sb.Append("->");
                }
                if (cycle.Capacity > 0)
                {
                    sb.Append(' ');
                    sb.Append(cycle[0]);
                }
                return sb.ToString();
            }
            return "No arbitrage detected";
        }
    }
}