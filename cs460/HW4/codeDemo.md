# ASP.NET MVC 5 Project

### This page demonstrates some of the code used in this project. Such as calculations, views, and controller code.

### The index page
##### The index page contains links to pages 1, 2, and 3
[Index Page](https://goo.gl/Yv7982)

```html
@{
    ViewBag.Title = "Home Page";
}

<div class="jumbotron">
    <h1>ASP.NET</h1>
    <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
    <p><a href="https://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
</div>

<div class="row">
    <div class="col-md-4">
        <ul>
            <li>@Html.ActionLink("Page 1", "PageOne", "Home")</li>
            <li>@Html.ActionLink("Page 2", "PageTwo", "Home")</li>
            <li>@Html.ActionLink("Page 3", "PageThree", "Home")</li>
        </ul>
    </div>
</div>
```

### Page One Controller Section
##### Here it simply checks for the type of temperature the user wants to convert their temperature amount into and then stores the result into a ViewBag parameter.
[HomeController](https://goo.gl/TrbAL2)

```csharp
public ActionResult PageOne()
{
    string temperature = Request.Form["temperature"];//temperature entered
    string temp_type = Request.Form["temp_type"];//the type of temperature to convert to
    double tempToConvert = 0.0;//the converted temperature entered so we can do computations


    if (Double.TryParse(temperature, out tempToConvert))
    {
        if (temp_type.Equals("C", StringComparison.InvariantCultureIgnoreCase))
            ViewBag.converted = (((tempToConvert - 32) * 5) / 9);//converted to celsius
        else if (temp_type.Equals("F", StringComparison.InvariantCultureIgnoreCase))
            ViewBag.converted = (((tempToConvert * 9) / 5) + 32);//converted to fahrenheit
        else
            ViewBag.converted = "Incorrect Input!";//incorrect temperature type was entered
    }
    else if(temperature != null && temp_type != null)//incorrect distance was entered
    {
        ViewBag.converted = "Incorrect Input!";
    }

    return View();
}
```

### The PageOne View
[PageOne View](https://goo.gl/SyqbBW)

```html
@{
    ViewBag.Title = "Page One";
}

<div class="container">
    <div class="row">
        <div class="col-md-6">
            <form method="post" class="form-group">
                
                <!--this input takes the temperature amount-->
                <label for="temperature">Temperature:</label>
                <input type="text" class="form-control" name="temperature" value="">
                
                <!--takes a parameter such as "F" for fahrenheit conversion and
                    "C" for celcius conversion.-->
                <label for="temp_type">Select Temperature Type:</label>
                <input type="text" class="form-control" name="temp_type" maxlength="1" value="" />

                <button type="submit" name="submit" class="btn btn-primary">Submit</button>
            </form>
        </div>
        <div class="col-md-6">
            <h3>Temperature converter</h3>
            <ol type="1">
                <li>Enter the temperature into the temperature box</li>
                <li>Enter (C)Celsius or (F)Fahrenheit</li>
                <li>Click the Submit button to convert temperature</li>
            </ol>
        </div>
    </div>
</div>

<!--displays the converted tempereature amount-->
@if (ViewBag.converted != null)
{
    <h3>Your converted temperature is: @ViewBag.converted</h3>
}
```

### PageOne Screenshots

#### Input screenshot
![PageOne input](https://goo.gl/dEagHw)

#### Output screenshot
![PageOne output](https://goo.gl/Lmsu6h)


### The Calculator
##### The calculator class has been modified a bit from its Java implementation. Some objects like Java's Scanner class had to be replaced by a foreach loop. All private and local variables have been camelcased and methods and public fields are Pascal cased.
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
##### The following screen is the output of the program doing calculations.
![Output](img/Calculator.png)