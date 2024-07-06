using System;
using System.IO;

namespace A3.OOCalculator
{
    public abstract class UnaryOperator: Expression, IOperator
    {
        protected Expression Operand;

        // public UnaryOperator()
        // {
        //     // throw new NotImplementedException();
        // }

        public UnaryOperator(TextReader reader)
        {
            Operand = GetNextExpression(reader);
        }

        public sealed override string ToString() => $"{OperatorSymbol}({Operand})";

        public abstract string OperatorSymbol { get; }
    }
}