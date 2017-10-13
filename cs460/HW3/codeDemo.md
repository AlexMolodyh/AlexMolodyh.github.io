# C# Calculator Translated Code from Java

### I will try to describe the differences that I have implemented in to the c# version of the app. 

### The node class
#### I have converted the prviously pubic fields into private fields and am utilizing the propertie feature in C# to access those private data types.
[Node class](https://goo.gl/q9N2Gz)

```c#
namespace Calculator
{
    //compile with: /doc:Node.xml
    
    /// <summary>
    /// A node to hold a piece of data and a referrence to the next node.
    /// It is made to act like a slot in a stack.
    /// </summary>
    public class Node
    {
        private object data;
        private Node next;

        public Node()
        {
            data = null;
            next = null;
        }

        public Node(object data, Node next)
        {
            Data = data;
            Next = next;
        }

        /// <summary>
        /// The data a node contains inside.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// The node next in line(like in a stack).
        /// </summary>
        public Node Next
        {
            get; set;
        }
    }
}
```

### The IStackADT interface
#### I have implemented the IStackADT interface using C# Generics.
[IStackADT class](https://goo.gl/noeHQ4)

```c#
using System;

namespace Calculator.Interface
{
    // compile with: /doc:IStackADT.xml

    /// <summary>
    /// IStackADT is meant to resemble a stack.
    /// </summary>
    /// <typeparam name="T">A Generic item place-holder</typeparam>
    public interface IStackADT<T>
    {
        /// <summary>
        /// Pushes an element on to the top of thr stack.
        /// </summary>
        /// <param name="newItem">The new item to push on to the stack</param>
        /// <returns>if successful, it returns the same item.</returns>
        T Push(T newItem);

        /// <summary>
        /// Removes the top item off of the stack.
        /// </summary>
        /// <returns>Returns the item from the top of the stack.</returns>
        T Pop();

        /// <summary>
        /// Checks to see what item lays at the top of the stack.
        /// </summary>
        /// <returns>returns the top item on the stack but doesn't remove it.</returns>
        T Peek();

        /// <summary>
        /// Checks to see if the stack is empty.
        /// </summary>
        /// <returns>If the stack is empty it returns true. 
        /// Otherwise it returns false</returns>
        bool IsEmpty();

        /// <summary>
        /// Clears the stack of all items.
        /// </summary>
        void Clear();
    }
}
```

### The LinkedStack
#### The LinkedStack ADT implements the IStackADT interface and uses C# Generics to implement the overriden methods. Some shorter methods are implemented using lambdas.
[LinkedStack class](https://goo.gl/gQqeay)

```c#


using Calculator.Interface;

namespace Calculator
{
    // compile with: /doc:LinkedStack.xml

    /// <summary>
    /// A data structure that acts like a stack. It uses C# Generics so it can 
    /// be used with many types.
    /// </summary>
    /// <typeparam name="T">A Generic type</typeparam>
    public class LinkedStack<T> : IStackADT<T>
    {
        private Node top;

        public LinkedStack() => top = null;

        /// <summary>
        /// Pushes an element on to the top of thr stack.
        /// </summary>
        /// <param name="newItem">The new item to push on to the stack</param>
        /// <returns>if successful, it returns the same item.</returns>
        public T Push(T newItem)
        {
            if (newItem == null)
            {
                return default(T);
            }

            Node NewNode = new Node(newItem, top);
            top = NewNode;
            return newItem;

        }

        /// <summary>
        /// Removes the top item off of the stack.
        /// </summary>
        /// <returns>Returns the item from the top of the stack.</returns>
        public T Pop()
        {
            if(IsEmpty())
            {
                return default(T);
            }
            object TopItem = top.Data;
            top = top.Next;
            return (T) TopItem;
        }

        /// <summary>
        /// Clears the stack of all items.
        /// </summary>
        public void Clear() => top = null;

        /// <summary>
        /// Checks to see if the stack is empty.
        /// </summary>
        /// <returns>If the stack is empty it returns true. 
        /// Otherwise it returns false</returns>
        public bool IsEmpty() =>  (top == null);

        /// <summary>
        /// Checks to see what item lays at the top of the stack.
        /// </summary>
        /// <returns>returns the top item on the stack but doesn't remove it.</returns>
        public T Peek()
        {
            if (IsEmpty())
                return default(T);
            return (T) top.Data;
        }
    }
}
```

### The Calculator
#### The calculator class has been modified a bit from its Java implementation. Some objects like Java's Scanner class had to be replaced by a foreach loop. All private and local variables have been camelcased and methods and public fields are Pascal cased.
[Calculator class](https://goo.gl/cPsKjr)

```c#
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
            Calculator calcApp = new Calculator();

            //As long as playAgain is true the calculator will keep asking for more input
            bool playAgain = true;
            Console.WriteLine("\nPostfix Calculator, Recognizes these operators: + - * /");
            while (playAgain)
            {
                playAgain = calcApp.DoCalculation();
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

            string lineInput = Console.ReadLine();

            //sets character to lower case so we don't have to check agains 'q' and 'Q'
            string CheckQuit = lineInput.ToLower();

            if (CheckQuit.StartsWith("q"))
            {
                return false;
            }

            string Output = "";
            try
            {
                Output = EvaluatePostFixInput(lineInput);
            }
            catch (Exception e)
            {
                Output = e.Message;
            }
            Console.WriteLine("\n\t" + lineInput + " = " + Output);
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

```

### The Output
#### The following screen is the output of the program doing calculations.
![Output](img/Calculator.png)