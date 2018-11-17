using System;
using System.Collections.Generic;
using System.IO;

namespace GWhub
{
    public class Parser
    {
        public DirectedGraph Parse(string input)
        {
            DirectedGraph parsed = new DirectedGraph();

            try
            {
                var lines = new List<string>();
                using (var reader = new StreamReader(input))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                int secondCommentLine = lines.FindLastIndex(x => x.StartsWith("#"));
                
                for (int i = 1; i < secondCommentLine; i++)
                {
                    string[] words = lines[i].Split();
                    parsed.nodes.Add(new CurrencyVertex(words[1]));
                }
                for (int i = ++secondCommentLine; i < lines.Count; i++)
                {
                    string[] words = lines[i].Split();
                    parsed.edges.Add(new ExchangeEdge(parsed.nodes.Find(x => x.Symbol == words[1]), 
                        parsed.nodes.Find(x => x.Symbol == words[2]), 
                        double.Parse(words[3])));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return parsed;
        }
    }
}
