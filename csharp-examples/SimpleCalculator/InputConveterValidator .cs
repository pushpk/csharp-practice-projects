using System;

namespace SimpleCalculator
{
    public class InputConveterValidator
    {
        public double ConvertInputtoNumeric(string textInput)
        {
            double convertedNumber = 0;
            bool valid = false;

            do
            {
                valid = double.TryParse(textInput, out convertedNumber);

                if (!valid)
                {
                    Console.WriteLine("Please enter number!");
                    textInput = Console.ReadLine();
                }

            } while (!valid);

            return convertedNumber;
        }
    }
}