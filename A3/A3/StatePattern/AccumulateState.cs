using static System.Console;

namespace A3.StatePattern
{
    public class AccumulateState : CalculatorState
    {
        public AccumulateState(Calculator calc) : base(calc) { }

        // #7 لطفا
        public override IState EnterEqual() => null;
        public override IState EnterZeroDigit() => EnterNonZeroDigit('0');
        public override IState EnterNonZeroDigit(char c)
        {
            // #8 لطفا!
            if (this.Calc.Display != "0")
                this.Calc.Display += c;
            return this;
        }

        // #9 لطفا!
        public override IState EnterOperator(char c)
        {
            ComputeState com = new ComputeState(Calc);
            return com;
        }
        public override IState EnterPoint()
        {
            // #10 لطفا!
            PointState point = new PointState(Calc);
            if (this.Calc.Display.Contains('.'))
                return point;
            else
            {
                this.Calc.Display += '.';
                return point;
            }
        }
    }
}