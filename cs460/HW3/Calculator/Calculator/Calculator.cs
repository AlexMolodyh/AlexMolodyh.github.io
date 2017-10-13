using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    // compile with: /doc:Calculator.xml

    /// <summary>
    /// A postfix calculator program that reads variables first and 
    /// modifiers later. 
    /// </summary>
    class Calculator
    {
        private IStackADT<double> calcStack = new LinkedStack<double>();

        static void Main(string[] args)
        {
            Calculator CalcApp = new Calculator();

            //As long as playAgain is true the calculator will keep asking for more input
            bool playAgain = true;
            Console.WriteLine("\nPostfix Calculator, Recognizes these operators: + - * /");
            while (playAgain)
            {
                playAgain = CalcApp.DoCalculation();
            }
            Console.WriteLine("Bye.");
        }

        /// <summary>
        /// Asks the user for an expression in the format of numbers first separated by spaces
        /// and then the operators separated by spaces.
        /// </summary>
        /// <returns>If the user does not enter "q" to quit then it returns true.
        /// Otherwise it returns false.</returns>
        private bool DoCalculation()
        {
            Console.WriteLine("Please enter q to quit\n");
            Console.Write(">");

            string Input = Console.ReadLine();

            //sets character to lower case so we don't have to check agains 'q' and 'Q'
            string CheckQuit = Input.ToLower();

            if (CheckQuit.StartsWith("q"))
            {
                return false;
            }

            string Output = "";
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

        /// <summary>
        /// Loops through the whole input list and calculates an output. 
        /// </summary>
        /// <param name="input">A string of characters representing numbers and operators.</param>
        /// <returns>Once done calculating all numbers, it then returns 
        /// a string representing the result of the calculation.</returns>
        public string EvaluatePostFixInput(string input)
        {
            if(input == null || input.Equals(""))
            {
                throw new Exception("Illegal argument");
            }

            calcStack.Clear();
            
            //place holders for the input and output numbers
            double a = 0.0;
            double b = 0.0;
            double c = 0.0;

            string[] words = input.Split();

            //loops through the input string
            foreach(string word in words)
            {
                double inputDouble;

                Console.WriteLine("Current word is: " + word);

                if(double.TryParse(word, out inputDouble))
                {
                    calcStack.Push(inputDouble);
                }
                else
                {

                    if (word.Length > 1)
                        throw new Exception("Input Error: " + word + " is not an allowed number or operator");

                    if (calcStack.IsEmpty())
                        throw new Exception("Improper input format. Stack became empty when expecting second operand.");

                    b = calcStack.Pop();
                    if (calcStack.IsEmpty())
                        throw new Exception("Improper input format. Stack became empty when expecting first operand.");

                    a = calcStack.Pop();
                    c = DoOperation(a, b, word);

                    //store the result back on top of the stack for next calculation
                    calcStack.Push(c);
                }
            }
            return calcStack.Pop().ToString();
        }


        /// <summary>
        /// Calculates a result based on the input numbers and the operator string given.
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="s">Operator for calculation</param>
        /// <returns>The sum of a and b.</returns>
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
                    //checks to see if a or b is a zero
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
