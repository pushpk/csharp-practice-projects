using System;

namespace SimpleCalculator
{
    public class CalculatorEngine
    {
        public double calculate(double firstNumber, double secondNumber, string operation)
        {
            switch (operation)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                case "/":
                    return firstNumber / secondNumber;
                
                default:
                    throw new  ArgumentException("Wrong Operation!");
            }
        }
    }
}