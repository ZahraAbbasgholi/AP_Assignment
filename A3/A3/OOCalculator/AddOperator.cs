using System;
using System.IO;

namespace A3.OOCalculator
{
    public class AddOperator : BinaryOperator
    {
        public AddOperator(TextReader reader) : base(reader)
        {}

        public override string OperatorSymbol => "+";

        public override double Evaluate() => this.LHS.Evaluate() + this.RHS.Evaluate();
        
        public string ToString() =>  base.ToString();
    }
}