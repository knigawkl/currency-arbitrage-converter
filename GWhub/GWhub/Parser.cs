using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GWhub
{
    public class Parser
    {
        public Digraph Parse(string input, ref TextBox outputTxt)
        {
            Digraph parsed = new Digraph();

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

                int hashCounter = 0;
                foreach (var line in lines)
                {
                    if (line.StartsWith("#"))
                    {
                        hashCounter++;
                    }
                }
                if (hashCounter != 2)
                {
                    throw new Exception("There should be two comment lines, each starting with a hash symbol. " +
                        "Currently there are " + hashCounter + " such lines");
                }

                if (!lines.Find(x => x.StartsWith("#")).Equals("# Waluty (id | symbol | pełna nazwa)")) 
                {
                    throw new Exception("The 1st comment line not correct. Expected: # Waluty (id | symbol | pełna nazwa)");
                }
                else if (!lines.FindLast(x => x.StartsWith("#")).Equals("# Kursy walut (id | symbol (waluta wejściowa) | symbol (waluta wyjściowa) | kurs | typ opłaty | opłata"))
                {
                    throw new Exception("The 2nd comment line not correct. Expected: # Waluty (id | symbol | pełna nazwa)");
                }


                int secondCommentLine = lines.FindLastIndex(x => x.StartsWith("#"));
                
                for (int i = 1; i < secondCommentLine; i++)
                {                   
                    string[] words = lines[i].Split();
                    if (words.Length < 3)
                    {
                        throw new Exception("There are " + words.Length + " elements in line " + i + ". There should be at least 3.");
                    }
                    else if (words[1].Length != 3)
                    {
                        throw new Exception("Impossible currency symbol at line " + i + ": " + words[1]);
                    }
                    else if (!words[1].Equals(words[1].ToUpper()))
                    {
                        throw new Exception("Currency symbol has to be uppercase. Invalid symbol: " + words[1] + ", at line: " + i);
                    }
                    parsed.nodes.Add(new CurrencyVertex(words[1]));
                }

                for (int i = ++secondCommentLine; i < lines.Count; i++)
                {
                    string[] words = lines[i].Split();
                    int feeType;
                    if (words[4].Equals("STAŁA")) {
                        feeType = (int)ExchangeEdge.ChargeType.Standing;
                    }
                    else if (words[4].Equals("PROC"))
                    {
                        feeType = (int)ExchangeEdge.ChargeType.Percent;
                    }
                    else
                    {
                        throw new Exception("Unknown charge type: " + words[4] + ". Could not load the whole graph!");
                    }

                    parsed.edges.Add(new ExchangeEdge(parsed.nodes.Find(x => x.Symbol == words[1]), 
                        parsed.nodes.Find(x => x.Symbol == words[2]), 
                        double.Parse(words[3]),
                        feeType,
                        double.Parse(words[5])));
                }
            }
            catch (Exception e)
            {
                outputTxt.Text = "Exception: " + e.Message;
            }
            return parsed;
        }
    }
}