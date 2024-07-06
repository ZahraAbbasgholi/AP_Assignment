using System;
using System.IO;

namespace A3.OOCalculator
{
    public class NegateOperator : UnaryOperator
    {

        public NegateOperator(TextReader reader) : base(reader)
        {}

        public override string OperatorSymbol => "-";

        public override double Evaluate() => -1 * this.Operand.Evaluate(); 

        public string ToString() => base.ToString();

    }
}