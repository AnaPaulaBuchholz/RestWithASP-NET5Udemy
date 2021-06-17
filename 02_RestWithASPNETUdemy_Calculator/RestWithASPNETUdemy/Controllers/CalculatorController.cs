using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
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

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]

        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {

                var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
                return BadRequest("Invalid input");

        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div (string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                return Ok(div.ToString()); 
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var media = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) / 2;
                return Ok(media.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("square-root/{firstNumber}/{secondNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (isNumeric(firstNumber))
            { 
                var squareRoot = Math.Sqrt((double) ConvertToDecimal(firstNumber));
                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid input");
        }
    }
        
}
       


