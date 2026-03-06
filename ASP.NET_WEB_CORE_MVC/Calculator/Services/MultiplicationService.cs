namespace Calculator.Services
{
    public class MultiplicationService : ICalculatorService
    {
        public double Execute(double a, double b)
        {
            return a * b;
        }
    }
}
