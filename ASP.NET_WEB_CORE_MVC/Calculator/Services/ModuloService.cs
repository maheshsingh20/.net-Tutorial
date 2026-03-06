namespace Calculator.Services
{
    public class ModuloService : ICalculatorService
    {
        public double Execute(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot perform modulo with zero");
            return a % b;
        }
    }
}
