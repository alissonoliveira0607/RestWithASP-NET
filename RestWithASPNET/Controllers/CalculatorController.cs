using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RestWithASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {


        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }


        /*
         Endpoint receber dois parametros e retorna o resultado da soma
         */
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            //Valida os dados de entrada e realiza a soma
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }


            return BadRequest("Invalid output");
        }

        /*
         Endpoint receber dois parametros e retorna o resultado da subtração
         */
        [HttpGet("sub/{subFirstNumber}/{subSecondNumber}")]
        public IActionResult GetSub(string subFirstNumber, string subSecondNumber)
        {

            if (IsNumeric(subFirstNumber) && IsNumeric(subSecondNumber))
            {
                var sub = ConvertToDecimal(subFirstNumber) - ConvertToDecimal(subSecondNumber);

                return Ok(sub.ToString());
            }

            return BadRequest("Operação invalida");
        }


        [HttpGet("div/{divFirstNumber}/{divSecondNumber}")]
        public IActionResult GetDiv(string divFirstNumber, string divSecondNumber)
        {
            if (IsNumeric(divFirstNumber) && IsNumeric(divSecondNumber))
            {
                var div = ConvertToDecimal(divFirstNumber) / ConvertToDecimal(divSecondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Operação invalida");
        }


        [HttpGet("mul/{mulFirstNumber}/{mulSecondNumber}")]
        public IActionResult GetMul(string mulFirstNumber, string mulSecondNumber) 
        {
            if (IsNumeric(mulFirstNumber) && IsNumeric(mulSecondNumber))
            {

                var mul = ConvertToDecimal(mulFirstNumber) * ConvertToDecimal(mulSecondNumber);
                return Ok(mul.ToString());
            }
            return BadRequest("Operação inválida");
           
                    
         }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }


            return 0;
        }


        private bool IsNumeric(string strNumber)
        {

            double number;
            bool isNumber = double.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);


            return isNumber;

        }
    }
}