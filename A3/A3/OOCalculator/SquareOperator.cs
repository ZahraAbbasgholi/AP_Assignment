using System;
using System.IO;

namespace A3.OOCalculator
{
    public class SquareOperator : UnaryOperator
    {
        string content;
        public SquareOperator(TextReader reader) : base(reader)
        {}

        public override string OperatorSymbol => "Square";

        public override double Evaluate() => Math.Pow(this.Operand.Evaluate(), 2);

        public string ToString() => base.ToString();
    }
}