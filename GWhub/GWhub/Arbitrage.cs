﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GWhub
{
    public class Arbitrage
    {
        private readonly Digraph digraph;
        private List<CurrencyVertex> vertices;
        private List<ExchangeEdge> edges;

        public Arbitrage(Digraph graph)
        {
            digraph = graph;
            vertices = graph.nodes;
            edges = graph.edges;
        }

        public List<CurrencyVertex> Find(double moneyAtStart)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].MinDistance = 0;
                vertices[i].MoneyAt = moneyAtStart;

                for (int j = 0; j < vertices.Count - 1; ++j)
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

                foreach (var edge in edges)
                {   
                    if (edge.FeeType == (int)ExchangeEdge.ChargeType.Percent)
                    {
                        double moneyAtFinish = 0;
                        moneyAtFinish = edge.StartVertex.MoneyAt * edge.Weight * (1 - edge.Charge);
                        edge.ArbWeight = -Math.Log(moneyAtFinish / edge.StartVertex.MoneyAt);
                        edge.Weight = edge.ArbWeight;
                    }
                    else if (edge.FeeType == (int)ExchangeEdge.ChargeType.Standing)
                    {
                        double moneyAtFinish = 0;
                        moneyAtFinish = edge.StartVertex.MoneyAt * edge.Weight - edge.Charge;
                        edge.ArbWeight = -Math.Log(moneyAtFinish / edge.StartVertex.MoneyAt);
                        edge.Weight = edge.ArbWeight;
                    }                    
                }

                
                vertices[i].ArbMinDistance = 0;

                for (int k = 0; k < vertices.Count - 1; ++k)
                {
                    foreach (var edge in edges)
                    {
                        if (edge.StartVertex.ArbMinDistance == int.MaxValue)
                        {
                            continue;
                        }

                        double newArbDistance = edge.StartVertex.ArbMinDistance + edge.Weight;

                        if (newArbDistance < edge.FinishVertex.ArbMinDistance)
                        {
                            edge.FinishVertex.ArbMinDistance = newArbDistance;
                            edge.FinishVertex.ArbPrev = edge.StartVertex;
                        }
                    }
                }

                List<CurrencyVertex> cycle = new List<CurrencyVertex>();

                foreach (var edge in edges)
                {
                    if (HasCycle(edge) && edge.StartVertex.ArbMinDistance != int.MaxValue)
                    {
                        CurrencyVertex vertex = edge.StartVertex;

                        while (!vertex.Equals(edge.FinishVertex) && !vertex.Visited)
                        {
                            cycle.Add(vertex);
                            vertex.Visited = true;
                            vertex = vertex.ArbPrev;
                        }
                        cycle.Add(edge.FinishVertex);
                        cycle.Reverse();
                        return cycle;
                    }
                }

            }
            return null;
        }

        private bool HasCycle(ExchangeEdge edge)
        {
            return edge.FinishVertex.ArbMinDistance > edge.StartVertex.ArbMinDistance + edge.Weight;
        }

        public string GenerateOutput(List<CurrencyVertex> path, double startMoney)
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