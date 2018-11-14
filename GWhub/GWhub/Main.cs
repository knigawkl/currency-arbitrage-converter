using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWhub
{
    class Dupa
    {
        public static void Main(string[] args)
        {
            //its only temporary
            string inpucik = "# Waluty (id | symbol | pełna nazwa)\n" +
                "0 EUR euro\n" +
                "1 GBP funty brytyjski\n" +
                "2 USD dolar amerykański\n" +
                "# Kursy walut (id | symbol (waluta wejściowa) | symbol (waluta wyjściowa) | kurs | typ opłaty | opłata\n" +
                "0 EUR GBP 0.8889 PROC 0.0001\n" +
                "1 GBP USD 1.2795 PROC 0\n" +
                "2 EUR USD 1.1370 STAŁA 0.025\n" +
                "3 USD EUR 0.8795 STAŁA 0.01";
            Parser parser = new Parser();
            parser.Parse(inpucik);
            
        }
    }
}
