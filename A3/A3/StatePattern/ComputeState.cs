namespace A3.StatePattern
{
    /// <summary>
    /// ماشین حساب وقتی که جواب یک محاسبه
    /// را نشان میدهد وارد این وضعیت میشود
    /// </summary>
    public class ComputeState : CalculatorState
    {
        public ComputeState(Calculator calc) : base(calc) { }
        public string DisplayCompute { get; set; } = null;

        public override IState EnterEqual()
        {
            if (DisplayCompute == null)
            {
                Calc.DisplayError("Syntax Error");
                return new ErrorState(this.Calc);
            }
            else
            {
                double r = double.Parse(this.Calc.Display);

                if (this.Calc.PendingOperator == '+')
                    r += double.Parse(this.DisplayCompute);
                if (this.Calc.PendingOperator == '*')
                    r *= double.Parse(this.DisplayCompute);
                if (this.Calc.PendingOperator == '/')
                    r /= double.Parse(this.DisplayCompute);
                if (this.Calc.PendingOperator == '-')
                    r -= double.Parse(this.DisplayCompute);
                if (this.Calc.PendingOperator == '^')
                    r = Math.Pow(r, double.Parse(this.DisplayCompute));
                this.Calc.Display = r.ToString();
                DisplayCompute = null;
                return this;
            }
        }

        public override IState EnterNonZeroDigit(char c)
        {
            // #3 لطفا!
            this.DisplayCompute += c;
            return this;
        }

        public override IState EnterZeroDigit()
        {
            // #4 لطفا
            if (this.DisplayCompute != "0")
                this.DisplayCompute += "0";
            return this;
        }

        // #5 لطفا
        public override IState EnterOperator(char c)
        {
            int r = int.Parse(this.Calc.Display);

            if (c == '+')
                r += int.Parse(this.DisplayCompute);
            if (c == '*')
                r *= int.Parse(this.DisplayCompute);
            if (c == '/')
                r /= int.Parse(this.DisplayCompute);
            if (c == '-')
                r -= int.Parse(this.DisplayCompute);
            if (c == '^')
                r = (int)Math.Pow(r, int.Parse(this.DisplayCompute));
            this.Calc.Display = r.ToString();
            DisplayCompute = null;
            return this;
        }

        public override IState EnterPoint()
        {
            if (!this.DisplayCompute.Contains('.'))
                this.DisplayCompute += '.';
            return this;
        }
    }
}