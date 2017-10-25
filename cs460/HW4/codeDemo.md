# ASP.NET MVC 5 Project

### This page demonstrates some of the code used in this project. Such as calculations, views, and controller code.

### NOTE! screenshots are not showing up here so please visit the the page below
[Code Demo](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW4/codeDemo.md)


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
![PageOne input](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW4/img/page_one_input.PNG)


#### Output screenshot
![PageOne output](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW4/img/page_one_output.PNG)


### Page Two Controller Section
##### Here it simply checks for the type of distance the user wants to convert their distance amount into and then stores the result into a ViewBag parameter. The structure is basically the same as in the PageOne ActionMethod.
[HomeController](https://goo.gl/TrbAL2)

```csharp
public ActionResult PageTwo(FormCollection form)
{
    ValueProviderResult distance = form.GetValue("distance");//distance entered
    ValueProviderResult distType = form.GetValue("dist_type");//miles or kilometers to convert to
    double distToConvert = 0.0;//the converted distance entered so we can do computations


    if (Double.TryParse(distance.AttemptedValue, out distToConvert))
    {
        ViewBag.distance = distance.AttemptedValue;

        //converting into miles
        if (distType.AttemptedValue.Equals("M", StringComparison.InvariantCultureIgnoreCase))
        {
            ViewBag.convertFrom = "Kilometers";
            ViewBag.convertTo = "Miles";
            ViewBag.converted = distToConvert * .62;
        }
        else if (distType.AttemptedValue.Equals("K", StringComparison.InvariantCultureIgnoreCase))
        {
             //converting into kilometers
            ViewBag.convertFrom = "Miles";
            ViewBag.convertTo = "Kilometers";
            ViewBag.converted = distToConvert * 1.609;
        }
        else
        {
            ViewBag.error = "Incorrect Input!!";//wrong input for conversion type
        }
    }
    else if (distance != null && distType != null)
    {
        //incorrect distance was entered, as in not a number
        ViewBag.converted = "Incorrect Input!";
    }

    return View();
}
```

### The PageTwo View
[PageTwo View](https://goo.gl/whghXU)

```html
@{
    ViewBag.Title = "Page Two";
}


<div class="container">
    <div class="row">
        <div class="col-md-6">
            <form method="post" class="form-group">
                <!--input to enter the distance to be converted-->
                <label for="distance">Distance:</label>
                <input type="text" class="form-control" name="distance" value="">
                
                <!--input to enter either Miles or Kilometers to convert -->
                <label for="dist_type">Select Distance Type:</label>
                <input type="text" class="form-control" name="dist_type" maxlength="1" value="" />

                <button type="submit" name="submit" class="btn btn-primary">Submit</button>
            </form>
        </div>
        <div class="col-md-6">
            <h3>Mile Kilometer Converter</h3>
            <ol type="1">
                <li>Enter the distance into the distance box</li>
                <li>Enter (M)Miles or (K)Kilometers</li>
                <li>Click the Submit button to convert the distance</li>
            </ol>
        </div>
    </div>
</div>

@*if "error" isn't null then the input wasn't correct. Otherwise we can populate 
    the converted results.*@
@if (ViewBag.converted != null || ViewBag.error != null)
{
    if (ViewBag.error != null)
    {
        <h3>@ViewBag.error</h3>
    }
    else
    {
        <h3>@ViewBag.distance @ViewBag.convertFrom converted into @ViewBag.convertTo is: @ViewBag.converted @ViewBag.convertTo</h3>
    }
}
```


### PageTwo Screenshots

#### PageTwo input
![PageTwo input](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW4/img/page_two_input.PNG)


#### PageTwo Output
![PageTwo output](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW4/img/page_two_output.PNG)



### Page Three Controller Section
##### The HttpGet aciton method does nothing besides return the default view. We do the calculation in the HttpPost method and then call a different view called PageThreePost.
[HomeController](https://goo.gl/TrbAL2)

```csharp
[HttpGet]
public ActionResult PageThree()
{
    return View();
}

[HttpPost]
public ActionResult PageThree(int? loanAmount, double? interestRate, int? months)
{
    double percentage = (interestRate / 100) / 12 ?? 0;//convert percentage to calculate for months

    double monthsAsDouble = months * 1.0 ?? 1;//convert months into a double for Pow method

    //we use this calculation twice so I just made it for simplicity
    double partOfD = Math.Pow((1 + percentage), monthsAsDouble);

    double d = ((partOfD - 1) / (percentage * partOfD));//total calculation that we divide total amount by

    double montlyPyment = loanAmount / d ?? 0;//total montly payment

    double paymentSum = montlyPyment * monthsAsDouble;//loan amount plus interest 

    ViewBag.totalMonths = months ?? 0;
    ViewBag.monthPayment = $"{montlyPyment:C2}";
    ViewBag.paySum = $"{paymentSum:C2}";
    ViewBag.totalInterest = $"{paymentSum - monthsAsDouble:C2}";
            

    return View("PageThreePost");
}
```


### The PageThree View
##### The PageThree view sets up a form to get parameters for a loan calculation.
[PageThree View](https://goo.gl/oUH7zp)

```html
@{
    ViewBag.Title = "Page Three";
}

<div class="container">
    <div class="row">
        <div class="col-md-6">
            <form method="post" class="form-group">
                <!--input to enter the distance to be converted-->
                <label for="loanAmount">Loan:</label>
                <input type="number" class="form-control" name="loanAmount" value="">

                <!--input to enter either Miles or Kilometers to convert -->
                <label for="interestRate">Interest Rate:</label>
                <input type="number" step="any" class="form-control" name="interestRate" maxlength="1" value="" />

                <!--input to enter either Miles or Kilometers to convert -->
                <label for="months">Months:</label>
                <input type="number" class="form-control" name="months" maxlength="1" value="" />

                <button type="submit" name="submit" class="btn btn-primary">Submit</button>
            </form>
        </div>
        <div class="col-md-6">
            <h3>Loan Calculator</h3>
            <ol type="1">
                <li>Enter the loan amount</li>
                <li>Enter the percentage amount such as: 6.2 for 6.2%</li>
                <li>Enter the amount of months you want to calculate for</li>
                <li>Click the Submit button to calculate the loan</li>
            </ol>
        </div>
    </div>
</div>
```


### The PageThreePost View
##### The PageThreePost view displays the loan calculated payments and interest amount.
[PageThree View](https://goo.gl/oUH7zp)

```html
@{
    ViewBag.Title = "Page three post";
}

<!--after the pageThree post method is called, it populates this view with 
    the montly payments, the sum of payments, and the total interest that will be paid.-->
@if (ViewBag.monthPayment != null)
{
    <h3>Your monthly payments are: @ViewBag.monthPayment for @ViewBag.totalMonths months</h3>
    <h3>The sum of your payments is: @ViewBag.paySum</h3>
    <h3>Total interest is: @ViewBag.totalInterest</h3>
}
```


### PageThree Screenshots

#### PageThree input
![PageThree input](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW4/img/page_three_inputt.PNG)


#### PageThree Output
![PageTwo output](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW4/img/page_three_output.PNG)