using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool stopApp = false;

            // Display the title as Console Calculator App
            Console.WriteLine("Basic Console Calculator in C#\r");
            Console.WriteLine("------------------------------\r");

            while (!stopApp)
            {
                // Declare the variables and initialise them to 0
                string inputNumber1 = "";
                string inputNumber2 = "";
                double answer = 0;

                // Request the user to type the first input
                Console.Write("Type a number, and press Enter: ");
                inputNumber1 = Console.ReadLine();

                double validInputNumber1 = 0;
                while (!double.TryParse(inputNumber1, out validInputNumber1))
                {
                    Console.WriteLine("Please enter a valid number: ");
                    inputNumber1 = Console.ReadLine();
                }

                // Request the user to type the second input
                Console.Write("Type another number, and press Enter: ");
                inputNumber2 = Console.ReadLine();

                double validInputNumber2 = 0;
                while (!double.TryParse(inputNumber2, out validInputNumber2))
                {
                    Console.WriteLine("Please enter another number: ");
                    inputNumber2 = Console.ReadLine();
                }

                // Request the user to choose an math operator
                Console.WriteLine("Choose a math operator: ");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("Option chosen: ");

                string operation = Console.ReadLine();

                try
                {
                    answer = Calculator.MathOperation(validInputNumber1, validInputNumber2, operation);
                    if (double.IsNaN(answer))
                    {
                        Console.WriteLine("Mathematical error!\n");
                    }
                    else Console.WriteLine("Answer: {0:0.###}\n", answer);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception error - Details: " + e.Message);
                }

                Console.WriteLine("----------------------\n");

                // Wait for instructions before closing
                Console.WriteLine("Press 'q' and Enter to close the Calculator console app, or press any keys and Enter to continute:");
                if (Console.ReadLine() == "q") stopApp = true;
                
                Console.WriteLine("\n");    // Empty line space
            }

            return;
        }
    }
}
