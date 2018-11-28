using System;
using System.Collections.Generic;
using System.Text;

namespace GWhub
{
    public class BestExchange
    {
        private List<CurrencyVertex> vertices;
        private List<ExchangeEdge> edges;
        private List<CurrencyVertex> path;

        public BestExchange(Digraph graph)
        {  
            vertices = graph.nodes;
            edges = graph.edges;
            path = new List<CurrencyVertex>();
        }

        public List<CurrencyVertex> Find(CurrencyVertex src, CurrencyVertex to, double moneyAtStart, out double moneyAtFinish)
        {
            src.MoneyAt = moneyAtStart;
            src.MinDistance = 0;

            foreach (var edge in edges)
            {
                edge.FinishVertex.Prev = edge.StartVertex;
            }

            for (int i = 0; i < vertices.Count - 1; ++i)
            {
                foreach (var edge in edges)
                {
                    if (edge.StartVertex.MinDistance == int.MaxValue)
                    {
                        continue;
                    }

                    double newMoneyAtDest;
                    double newDistance;
                    if (edge.FeeType == (int)ExchangeEdge.ChargeType.Percent)
                    {
                        newMoneyAtDest = edge.StartVertex.MoneyAt * edge.Weight * (1 - edge.Charge);
                        newDistance = Inverse(newMoneyAtDest);
                        if (newDistance < edge.FinishVertex.MinDistance)
                        {
                            edge.FinishVertex.MinDistance = newDistance;
                            edge.FinishVertex.Prev = edge.StartVertex;
                            edge.FinishVertex.MoneyAt = newMoneyAtDest;
                        }
                    }
                    else if (edge.FeeType == (int)ExchangeEdge.ChargeType.Standing)
                    {
                        newMoneyAtDest = edge.StartVertex.MoneyAt * edge.Weight - edge.Charge;
                        newDistance = Inverse(newMoneyAtDest);
                        if (newDistance < edge.FinishVertex.MinDistance)
                        {
                            edge.FinishVertex.MinDistance = newDistance;
                            edge.FinishVertex.Prev = edge.StartVertex;
                            edge.FinishVertex.MoneyAt = newMoneyAtDest;
                        }
                    } 
                }
            }
            path.Add(to);
            CurrencyVertex last = vertices.Find(x => x.Equals(to));
            CurrencyVertex first = vertices.Find(x => x.Equals(src));
            while (last.Prev != first)
            {
                last = last.Prev;
                path.Add(last);
            }
            path.Add(src);
            path.Reverse();
            moneyAtFinish = vertices.Find(x => x.Equals(to)).MoneyAt;
            return path;
        }

        public string GenerateOutput(List<CurrencyVertex> path)
        {
            StringBuilder sb = new StringBuilder(path[0].MoneyAt.ToString());
            sb.Append(" ");
            for (int i = 0; i < path.Count - 1; i++)
            {
                sb.Append(path[i].Symbol);
                sb.Append(" -> ");
            }
            sb.Append(String.Format("{0:0.00}", path[path.Count - 1].MoneyAt));
            sb.Append(" ");
            sb.Append(path[path.Count - 1].Symbol);
            return sb.ToString();
        }

        public double Inverse(double money) => 1 / money;
    }
}
