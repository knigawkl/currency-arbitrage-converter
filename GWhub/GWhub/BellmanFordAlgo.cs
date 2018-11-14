using System;
using System.Collections.Generic;

namespace GWhub
{
    public class BellmanFordAlgo
    {
        private List<CurrencyVertex> vertices;
        private List<ExchangeEdge> edges;
        private List<CurrencyVertex> cycles;

        public BellmanFordAlgo(List<CurrencyVertex> _vertexes, List<ExchangeEdge> _edges)
        {
            vertices = _vertexes;
            edges = _edges;
            cycles = new  List<CurrencyVertex>();
        }

        public void Find(CurrencyVertex start)
        {
            start.MinDistance = 0;

            for (int i = 0; i < vertices.Capacity - 1; ++i)
            {
                foreach (ExchangeEdge edge in edges)
                {
                    if (edge.StartVertex.MinDistance == int.MaxValue)
                    {
                        continue;
                    }

                    double newDistance = edge.StartVertex.MinDistance + edge.Weight;

                    if (newDistance < edge.FinishVertex.MinDistance)
                    {
                        edge.FinishVertex.MinDistance = newDistance;
                        edge.FinishVertex.Prev = start;
                    }
                }
            }
            //tu sie konczy wlasciwy bellman-ford


            foreach (ExchangeEdge edge in edges)
            {
                //jesli hascycle jest true to znaczy ze musi byc negative cycle - ujemny cykl
                if (edge.StartVertex.MinDistance != int.MaxValue && HasCycle(edge))
                {
                    CurrencyVertex vertex = edge.StartVertex;

                    while(!vertex.Equals(edge.FinishVertex))
                    {
                        this.cycles.Add(vertex);
                        vertex = vertex.Prev;
                    }

                    this.cycles.Add(edge.FinishVertex);

                    return;
                }
            }
        }

        private bool HasCycle(ExchangeEdge edge)
        {
            return edge.FinishVertex.MinDistance > edge.StartVertex.MinDistance + edge.Weight;
        }

        public void PrintCycle()
        {
            if(this.cycles != null)
            {
                foreach (CurrencyVertex ver in vertices)
                {
                    Console.WriteLine(ver);
                }
            }
            else
            {
                Console.WriteLine("NO ARBITRAGE");
            }
        }

        
    }
}