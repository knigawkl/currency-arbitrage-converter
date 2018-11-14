using System;
using System.Collections.Generic;
using System.IO;

namespace GWhub
{
    public class Parser
    {
        private enum LineType {CurrencyLine=1, RateLine=2};

        public void Parse(string input)
        {
            try
            {
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(input))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!line.StartsWith("#"))
                        {
                            lines.Add(line);
                            Console.WriteLine(line);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        
    }
}
