using System;
using System.IO;
using System.Diagnostics;

namespace CalculatorLibrary
{
    public class Calculator
    {
        StreamWriter logToFile;
        // Constructor
        public Calculator()
        {
            logToFile = File.CreateText("calculator.log");
            Trace.Listeners.Add(new TextWriterTraceListener(logToFile));
            Trace.AutoFlush = true;
            Trace.WriteLine("Starting Calculator Log...");
            Trace.WriteLine(String.Format("Start at {0}", System.DateTime.Now.ToString()));
        }
        
        public double MathOperation(double num1, double num2, string operation)
        {
            // default value is "Not-a-Number" if an op e.g. division, results in an error
            double answer = double.NaN;

            //Use a switchcase to do the math
            switch (operation)
            {
                case "+":
                    answer = num1 + num2;
                    Trace.WriteLine(String.Format("{0} + {1} = {2}", num1, num2, answer));                    
                    break;
                case "-":
                    answer = num1 - num2;
                    Trace.WriteLine(String.Format("{0} - {1} = {2}", num1, num2, answer));
                    break;
                case "*":
                    answer = num1 * num2;
                    Trace.WriteLine(String.Format("{0} x {1} = {2}", num1, num2, answer));
                    break;
                case "/":
                    // In case use input 0 for num2
                    if (num2 != 0)
                    {
                        answer = num1 / num2;
                        Trace.WriteLine(String.Format("{0} / {1} = {2}", num1, num2, answer));
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
