using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                    throw new Exception("The 2nd comment line not correct. Expected: # Kursy walut (id | symbol (waluta wejściowa) | symbol (waluta wyjściowa) | kurs | typ opłaty | opłata");
                }

                int secondCommentLine = lines.FindLastIndex(x => x.StartsWith("#"));
                
                for (int i = 1; i < secondCommentLine; i++)
                {                   
                    string[] words = lines[i].Split();

                    for (int j = 2; j < words.Length; j++)
                    {
                        if (!words[j].Equals(words[j].ToLower()))
                        {
                            throw new Exception("Currency long name has to be all lowercase. Line: " + (i + 1));
                        }
                        if (words[j].Any(c => char.IsDigit(c)))
                        {
                            throw new Exception("Currency long name cannot contain digits. Line: " + (i + 1));
                        }
                    }

                    if (words.Length < 3)
                    {
                        throw new Exception("There are " + words.Length + " elements in line " + (i + 1) + ". There should be at least 3.");
                    }
                    else if (words[1].Length != 3)
                    {
                        throw new Exception("Impossible currency symbol at line " + (i + 1) + ": " + words[1]);
                    }
                    else if (!words[1].Equals(words[1].ToUpper()))
                    {
                        throw new Exception("Currency symbol has to be uppercase. Invalid symbol: " + words[1] + ", at line: " + (i + 1));
                    }
                    else if (!int.TryParse(words[0], out var res))
                    {
                        throw new Exception("IDs have to be integers. Line: " + (i + 1));
                    }
                    else if (int.Parse(words[0]) != i - 1)
                    {
                        throw new Exception("IDs in input file have to be in ascending order, unique, starting from 0.");
                    }

                    parsed.nodes.Add(new CurrencyVertex(words[1]));
                }

                for (int i = ++secondCommentLine; i < lines.Count; i++)
                {
                    string[] words = lines[i].Split();
                    double rate = 0, fee = 0;

                    if (parsed.nodes.Find(x => x.Symbol.Equals(words[1])) == null)
                    {
                        throw new Exception("At line "+ (i + 1) + ": " + "There is no such currency symbol as: " + words[1]);
                    }
                    else if (parsed.nodes.Find(x => x.Symbol.Equals(words[2])) == null)
                    {
                        throw new Exception("At line " + (i + 1) + ": " + "There is no such currency symbol as: " + words[2]);
                    }
                    else if (words.Length < 6)
                    {
                        throw new Exception("Not enough words in line: " + (i + 1) + ". There should be 6 words, instead of: " + words.Length);
                    }
                    else if (words.Length > 6)
                    {
                        throw new Exception("Too many words in line: " + (i + 1) + ". There should be 6 words, instead of: " + words.Length);
                    }
                    else if (!double.TryParse(words[3], out rate))
                    {
                        throw new Exception("Exchange rate cannot be read from: " + words[3] + ". Line: " + (i + 1));
                    }
                    else if (!double.TryParse(words[5], out fee))
                    {
                        throw new Exception("Exchange fee cannot be read from: " + words[5] + ". Line: " + (i + 1));
                    }
                    else if (!int.TryParse(words[0], out var res))
                    {
                        throw new Exception("IDs have to be integers. Line: " + (i + 1));
                    }
                    else if (int.Parse(words[0]) != i - secondCommentLine)
                    {
                        throw new Exception("IDs in input file have to be in ascending order, unique, starting from 0. Invalid line: " + (i + 1));
                    }

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
                        rate,
                        feeType,
                        fee));
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