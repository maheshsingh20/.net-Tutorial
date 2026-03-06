using Microsoft.AspNetCore.Mvc;
using Calculator.Services;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly AdditionService _additionService;
        private readonly SubtractionService _subtractionService;
        private readonly MultiplicationService _multiplicationService;
        private readonly DivisionService _divisionService;
        private readonly ModuloService _moduloService;

        public CalculatorController(
            AdditionService additionService, 
            SubtractionService subtractionService,
            MultiplicationService multiplicationService,
            DivisionService divisionService,
            ModuloService moduloService)
        {
            _additionService = additionService;
            _subtractionService = subtractionService;
            _multiplicationService = multiplicationService;
            _divisionService = divisionService;
            _moduloService = moduloService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(double num1, double num2, string operation)
        {
            try
            {
                double result = operation switch
                {
                    "add" => _additionService.Execute(num1, num2),
                    "subtract" => _subtractionService.Execute(num1, num2),
                    "multiply" => _multiplicationService.Execute(num1, num2),
                    "divide" => _divisionService.Execute(num1, num2),
                    "modulo" => _moduloService.Execute(num1, num2),
                    _ => 0
                };

                ViewBag.Result = result;
                ViewBag.Num1 = num1;
                ViewBag.Num2 = num2;
                ViewBag.Operation = operation;
            }
            catch (DivideByZeroException ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Num1 = num1;
                ViewBag.Num2 = num2;
                ViewBag.Operation = operation;
            }
            
            return View("Index");
        }
    }
}
