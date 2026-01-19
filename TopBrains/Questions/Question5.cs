using System;

namespace TopBrains.Questions
{
    public class Question5
    {
        public static string EvaluateExpression(string expression)
        {
            string[] parts = expression.Split(' ');
            
            if (parts.Length != 3)
                return "Error:InvalidExpression";
            
            string aStr = parts[0];
            string op = parts[1];
            string bStr = parts[2];
            
            if (!int.TryParse(aStr, out int a))
                return "Error:InvalidNumber";
            
            if (!int.TryParse(bStr, out int b))
                return "Error:InvalidNumber";
            
            switch (op)
            {
                case "+":
                    return (a + b).ToString();
                case "-":
                    return (a - b).ToString();
                case "*":
                    return (a * b).ToString();
                case "/":
                    if (b == 0)
                        return "Error:DivideByZero";
                    return (a / b).ToString();
                default:
                    return "Error:UnknownOperator";
            }
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter expression (a op b): ");
            string expression = Console.ReadLine();
            
            string result = EvaluateExpression(expression);
            Console.WriteLine($"Result: {result}");
        }
    }
}