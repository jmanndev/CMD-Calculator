using System;

namespace CalculatorProgram
{
    class Program
    {
        static int CALCULATIONINPUT = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Calculator by J Mann 11393269\n");

            if (args.Length == 1)
            {
                RunCalculator(args[CALCULATIONINPUT]);
            }
            else DisplayError("Must have exactly 1 argument for calculation (don't use spaces)\nExample: 2+3*4-1");
        }

        static private void RunCalculator(string inputString)
        {
            try
            {
                Calculator calc = new Calculator();
                calc.Calculate(inputString);
            }
            catch (FormatException)
            {
                DisplayError("Invalid input format");
            }
            catch (DivideByZeroException)
            {
                DisplayError("Attempting to divide by zero");
            }
            catch (OverflowException)
            {
                DisplayError("Calculation is out of range");
            }
            catch (Exception)
            {
                DisplayError("Unexpected error");
            }
               
        }

        static private void DisplayError(string errorMessage)
        {
            Console.WriteLine("Calculator failed with the following error:");
            Console.WriteLine(errorMessage);
        }
    }
}
