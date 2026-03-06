namespace Calculator.Services
{
    public class DivisionService : ICalculatorService
    {
        public double Execute(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            return a / b;
        }
    }
}
