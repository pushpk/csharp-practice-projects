using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
     





        static void Main(string[] args)
        {
            try
            {
                //use depedency injection instead
                InputConveterValidator inputConveterValidator = new InputConveterValidator();
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                Console.WriteLine("Please enter first number:");
                double firstNumber = inputConveterValidator.ConvertInputtoNumeric(Console.ReadLine());

                Console.WriteLine("Please enter second number:");
                double secondNumber = inputConveterValidator.ConvertInputtoNumeric(Console.ReadLine());

                Console.WriteLine("Please enter operator[+,-,*,/]");
                string operation = Console.ReadLine();

                double output = calculatorEngine.calculate(firstNumber, secondNumber, operation);

                Console.WriteLine(output);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                //In real-world - exceptions should be logged to db
                Console.WriteLine(ex.Message);
                
            }

            Console.ReadLine();
        }
    }
}
