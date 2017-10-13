using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        private IStackADT<double> CalcStack = new LinkedStack<double>();

        static void Main(string[] args)
        {
            Calculator CalcApp = new Calculator();

            bool PlayAgain = true;
            Console.WriteLine("\nPostfix Calculator, Recognizes these operators: + - * /");
            while (PlayAgain)
            {
                PlayAgain = CalcApp.DoCalculation();
            }
            Console.WriteLine("Bye.");
        }

        private bool DoCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            string Input = "2 2 +";
            Console.Write("> ");

            Input = Console.ReadLine();
            string CheckQuit = Input.ToLower();

            if (CheckQuit.StartsWith("q"))
            {
                return false;
            }

            string Output = "4";
            try
            {
                Output = EvaluatePostFixInput(Input);
            }
            catch (Exception e)
            {
                Output = e.Message;
            }
            Console.WriteLine("\n\t" + Input + " = " + Output);
            return true;
        }

        public string EvaluatePostFixInput(string input)
        {
            if(input == null || input.Equals(""))
            {
                throw new Exception("Illegal argument");
            }

            CalcStack.Clear();
            
            double a = 0.0;
            double b = 0.0;
            double c = 0.0;

            string[] Words = input.Split();

            foreach(string word in Words)
            {
                double InputDouble;

                if(double.TryParse(word, out InputDouble))
                {
                    CalcStack.Push(InputDouble);
                }
                else
                {

                    if (word.Length > 1)
                        throw new Exception("Input Error: " + word + " is not an allowed number or operator");

                    if (CalcStack.IsEmpty())
                        throw new Exception("Improper input format. Stack became empty when expecting second operand.");

                    b = CalcStack.Pop();
                    if (CalcStack.IsEmpty())
                        throw new Exception("Improper input format. Stack became empty when expecting first operand.");

                    a = CalcStack.Pop();
                    c = DoOperation(a, b, word);

                    CalcStack.Push(c);
                }
            }
            return CalcStack.Pop().ToString();
        }

        public double DoOperation(double a, double b, string s)
        {
            double c = 0.0;
            if (s.Equals("+"))
                c = (a + b);
            else if (s.Equals("-"))
                c = (a - b);
            else if (s.Equals("*"))
                c = (a * b);
            else if(s.Equals("/"))
            {
                try
                {
                    c = (a / b);
                    if (double.IsNegativeInfinity(c) || double.IsPositiveInfinity(c))
                        throw new Exception("Can't divide by zero");
                }
                catch(ArithmeticException e)
                {
                    throw new ArgumentException(e.Message);
                }
            }
            else
            {
                throw new ArgumentException("Improper operator: " + s + ", is not one of +, -, *, or /");
            }

            return c;
        }
    }
}
