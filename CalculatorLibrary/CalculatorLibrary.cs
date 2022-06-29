using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        StreamWriter logToFile;
        JsonWriter logWriter;

        // Constructor
        public Calculator()
        {
            logToFile = File.CreateText("calculatorLogJSON.json");
            logToFile.AutoFlush = true;

            logWriter = new JsonTextWriter(logToFile);
            logWriter.Formatting = Formatting.Indented;
            logWriter.WriteStartObject();
            logWriter.WritePropertyName("Operations");
            logWriter.WriteStartArray();

            //Trace.Listeners.Add(new TextWriterTraceListener(logToFile));
            //Trace.AutoFlush = true;
            //Trace.WriteLine("Starting Calculator Log...");
            //Trace.WriteLine(String.Format("Start at {0}", System.DateTime.Now.ToString()));
        }

        public double MathOperation(double num1, double num2, string operation)
        {
            // default value is "Not-a-Number" if an op e.g. division, results in an error
            double answer = double.NaN;

            logWriter.WriteStartObject();
            logWriter.WritePropertyName("Operand 1");
            logWriter.WriteValue(num1);
            logWriter.WritePropertyName("Operand 2");
            logWriter.WriteValue(num2);
            logWriter.WritePropertyName("Operation");

            //Use a switchcase to do the math
            switch (operation)
            {
                case "+":
                    answer = num1 + num2;
                    logWriter.WriteValue("Add");
                    //Trace.WriteLine(String.Format("{0} + {1} = {2}", num1, num2, answer));                    
                    break;
                case "-":
                    answer = num1 - num2;
                    logWriter.WriteValue("Subtract");
                    //Trace.WriteLine(String.Format("{0} - {1} = {2}", num1, num2, answer));
                    break;
                case "*":
                    answer = num1 * num2;
                    logWriter.WriteValue("Multiply");
                    //Trace.WriteLine(String.Format("{0} x {1} = {2}", num1, num2, answer));
                    break;
                case "/":
                    // In case use input 0 for num2
                    if (num2 != 0)
                    {
                        answer = num1 / num2;
                        logWriter.WriteValue("Divide");
                        //Trace.WriteLine(String.Format("{0} / {1} = {2}", num1, num2, answer));
                    }
                    break;
                // Return text for entering wrong option
                default:
                    break;
            }

            logWriter.WritePropertyName("Answer");
            logWriter.WriteValue(answer);
            logWriter.WriteEndObject();

            return answer;
        }

        public void Complete()
        {
            logWriter.WriteEndArray();
            logWriter.WriteEndObject();
            logWriter.Close();
        }
    }
}
