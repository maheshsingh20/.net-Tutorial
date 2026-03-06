namespace Calculator.Services
{
    public class SubtractionService : ICalculatorService
    {
        public double Execute(double a, double b)
        {
            return a - b;
        }
    }
}
