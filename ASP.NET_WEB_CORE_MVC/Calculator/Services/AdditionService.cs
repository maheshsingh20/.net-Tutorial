namespace Calculator.Services
{
    public class AdditionService : ICalculatorService
    {
        public double Execute(double a, double b)
        {
            return a + b;
        }
    }
}
