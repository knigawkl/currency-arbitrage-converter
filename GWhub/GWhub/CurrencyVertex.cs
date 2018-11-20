﻿using System.Collections.Generic;

namespace GWhub
{
    public class CurrencyVertex
    {
        public CurrencyVertex(string symbol)
        {
            Symbol = symbol;
        }

        public string Symbol { get; }
        public double MoneyAt { get; set; } = 0;
        public double MinDistance { get; set; } = int.MaxValue;
        public CurrencyVertex Prev { get; set; }

        public double InverseMoney() => 1 / this.MoneyAt;

        public override string ToString() => this.Symbol;
    }
}