using System;
using System.IO;

namespace A3.OOCalculator
{
    public class NumberExpression : Expression
    {
        protected double Number;
        public NumberExpression(string line)
        {
            Number = double.Parse(line);
        }

        public override double Evaluate() => this.Number;

        public override string ToString() => this.Number.ToString();
    }
}