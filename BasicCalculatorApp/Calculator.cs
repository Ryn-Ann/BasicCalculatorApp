using System;

namespace Calculator
{
    // References:
    // https://docs.microsoft.com/en-gb/visualstudio/get-started/csharp/tutorial-console?view=vs-2022
    // https://codeasy.net/lesson/input_validation

    class Calculator
    {
        public static double MathOperation(double num1, double num2, string operation)
        {
            // default value is "Not-a-Number" if an op e.g. division, results in an error
            double answer = double.NaN;

            //Use a switchcase to do the math
            switch (operation)
            {
                case "a":
                    answer = num1 + num2;
                    break;
                case "s":
                    answer = num1 - num2;
                    break;
                case "m":
                    answer = num1 * num2;
                    break;
                case "d":
                    // In case use input 0 for num2
                    if (num2 != 0)
                    {
                        answer = num1 / num2;
                    }
                    break;
                // Return text for entering wrong option
                default:
                    break;
            }
            return answer;
        }

    }
}

