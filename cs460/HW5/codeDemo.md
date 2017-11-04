# HW5 ASP.NET MVC 5 Project

### This page demonstrates some of the code used in HW5. 

### NOTE! screenshots are not showing up here so please visit the the page below.
[Code Demo](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/codeDemo.md)


### The HomeController index page
##### The index page contains links to the change address and view requests pages.
[Index Page](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/HW5/Views/Home/Index.cshtml)

```html
<div class="jumbotron">
    <div class="row">
        <div class="col-lg-12">
            <h1>Welcome to the DMV website</h1>
            <p class="lead">Here you can create a request to change your address and view current address change requests (Not really safe to show everyone who is changing their address but this is a school project so who cares).</p>
        </div>
    </div>
    <!--a couple of simple buttons that take you to the address change request and record display pages-->
    <div class="row">
        <div class="col-lg-3">
            @Html.ActionLink("Change Address", "CreateNewAddress", "Customers", null, new { @class = "btn btn-primary btn-lg" })
        </div>
        <div class="col-lg-3">
            <!--We add a null for the 4th parameter because without it the ActionLink thinks the fourth value is a routevalue. 
                by adding the null in the 4th place forces it to use the proper overloads. If we put the null where the btn class is
                it won't load the class and ActionLink won't become a button.-->
            @Html.ActionLink("Current Requests", "Index", "Customers", null, new { @class = "btn btn-primary btn-lg" })
        </div>
    </div>
</div>
```
### Home page screenshot
![Home page](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/img/home_page_index.PNG)

### CustomersController Section
##### The Customers controller Index() returns a View with a table populated with address change requests.
[CustomersControler](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/HW5/Controllers/CustomersController.cs)

```csharp
    public class CustomersController : Controller
    {
        private CustomerContext db = new CustomerContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        [HttpGet]
        public ActionResult CreateNewAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewAddress([Bind(Include = "CustomerNumber,FirstName,MiddleName,LastName,DOB,NewAddress,NewCity,NewState,NewZip,NewCounty,ChangeDate")] Customer customer)
        {
            if(ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
```


### The Create New Address Section
[CreateNewAddress View](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/HW5/Views/Customers/CreateNewAddress.cshtml)

```html
@model HW5.Models.Customer

@{
    ViewBag.Title = "Create New Address";
}

<head>
    <link href="@Url.Content("~/Content/myStyles.css")" rel="stylesheet"/>
</head>


<div class="row margin-top">
    <!--Column Containing Form-->
    <div class="col-lg-6">
        @using (Html.BeginForm())
        {
            @Html.AntiForgeryToken()
            <form class="my-form">
                <div class="form-group">
                    @Html.ValidationSummary(true, "", new { @class = "text-danger" })
                    <div class="row">
                        <div class="col-lg-3">
                            <img class="image" src="@Url.Content("~/Content/dmv.png")" alt="image"/>
                        </div>
                        <div class="col-lg-9">
                            <h3><b>CHANGE OF ADDRESS NOTICE FOR DMV RECORDS</b></h3>
                        </div>
                    </div>
                    <ul>
                        <!--List Item containing NOTE for REQUIRED information-->
                        <li>
                            <h4><b>Note:</b> <b>ALL</b> information is <b>REQUIRED</b> to change your address.</h4>
                            <!--CustomerID # and DOB Section-->
                            <div class="row">
                                <div class="col-lg-4">
                                    @Html.LabelFor(model => model.CustomerNumber, htmlAttributes: new { @class = "control-label" })
                                    @Html.EditorFor(model => model.CustomerNumber, new { htmlAttributes = new { @class = "form-control"} })
                                    @Html.ValidationMessageFor(model => model.CustomerNumber, "", new { @class = "text-danger" })
                                </div>

                                <div class="col-lg-4">
                                    @Html.LabelFor(model => model.DOB, htmlAttributes: new { @class = "control-label" })
                                    @Html.EditorFor(model => model.DOB, new { htmlAttributes = new { @class = "form-control" } })
                                    @Html.ValidationMessageFor(model => model.DOB, "", new { @class = "text-danger" })
                                </div>
                            </div>
                            <!--Row for Last, First, and Middle names-->
                            <div class="row">
                                <div class="form-group">
                                    <div class="col-lg-4">
                                        @Html.LabelFor(model => model.LastName, htmlAttributes: new { @class = "control-label" })
                                        @Html.EditorFor(model => model.LastName, new { htmlAttributes = new { @class = "form-control" } })
                                        @Html.ValidationMessageFor(model => model.LastName, "", new { @class = "text-danger" })
                                    </div>
                                    <div class="col-lg-4">
                                        @Html.LabelFor(model => model.FirstName, htmlAttributes: new { @class = "control-label" })
                                        @Html.EditorFor(model => model.FirstName, new { htmlAttributes = new { @class = "form-control" } })
                                        @Html.ValidationMessageFor(model => model.FirstName, "", new { @class = "text-danger" })
                                    </div>
                                    <div class="col-lg-4">
                                        @Html.LabelFor(model => model.MiddleName, htmlAttributes: new { @class = "control-label" })
                                        @Html.EditorFor(model => model.MiddleName, new { htmlAttributes = new { @class = "form-control" } })
                                        @Html.ValidationMessageFor(model => model.MiddleName, "", new { @class = "text-danger" })
                                    </div>
                                </div>
                            </div>
                        </li>
                        <!--New Residence Address section-->
                        <li>
                            <h4><b>NEW MAILING ADDRESS</b> (No Post Office Box Number or mail forwarding adress)</h4>
                            <div class="row">
                                <div class="col-lg-12">
                                    @Html.LabelFor(model => model.NewAddress, htmlAttributes: new { @class = "control-label", @id = "address-field" })
                                    @Html.EditorFor(model => model.NewAddress, new { htmlAttributes = new { @class = "form-control" } })
                                    @Html.ValidationMessageFor(model => model.NewAddress, "", new { @class = "text-danger" })
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-4">
                                    @Html.LabelFor(model => model.NewCity, htmlAttributes: new { @class = "control-label" })
                                    @Html.EditorFor(model => model.NewCity, new { htmlAttributes = new { @class = "form-control" } })
                                    @Html.ValidationMessageFor(model => model.NewCity, "", new { @class = "text-danger" })
                                </div>
                                <div class="col-lg-2">
                                    @Html.LabelFor(model => model.NewState, htmlAttributes: new { @class = "control-label" })
                                    @Html.EditorFor(model => model.NewState, new { htmlAttributes = new { @class = "form-control"} })
                                    @Html.ValidationMessageFor(model => model.NewState, "", new { @class = "text-danger" })
                                </div>
                                <div class="col-lg-3">
                                    @Html.LabelFor(model => model.NewZip, htmlAttributes: new { @class = "control-label" })
                                    @Html.EditorFor(model => model.NewZip, new { htmlAttributes = new { @class = "form-control"} })
                                    @Html.ValidationMessageFor(model => model.NewZip, "", new { @class = "text-danger" })
                                </div>
                                <div class="col-lg-3">
                                    @Html.LabelFor(model => model.NewCounty, htmlAttributes: new { @class = "control-label" })
                                    @Html.EditorFor(model => model.NewCounty, new { htmlAttributes = new { @class = "form-control" } })
                                    @Html.ValidationMessageFor(model => model.NewCounty, "", new { @class = "text-danger" })
                                </div>
                            </div>
                        </li>
                        <li>
                            <h4><b>Please</b> enter date to confirm address change.</h4>
                            @Html.LabelFor(model => model.ChangeDate, htmlAttributes: new { @class = "control-label" })
                            @Html.EditorFor(model => model.ChangeDate, new { htmlAttributes = new { @class = "form-control" } })
                            @Html.ValidationMessageFor(model => model.ChangeDate, "", new { @class = "text-danger" })
                        </li>
                        <li>
                            <h4>Click SUBMIT button to send notice of address change></h4>
                            <input type="submit" value="SUBMIT" class="btn btn-default" />
                        </li>
                    </ul>
                </div>
            </form>
        }
    </div>
    <div class="col-lg-6">
        <!--Instructions Section-->
        <div class="row">
            <div class="col-lg-6">
                <p id="oregon-law-p">Oregon Law requires you to notify DMV of any change of address within 30 days.</p>

                <h3><b>INSTRUCTIONS:</b></h3>
                <ul>
                    <li><h4>Read the information on the back of this form.</h4></li>
                    <li><h4><b>Please PRINT.</b></h4></li>
                    <li><h4>You MUST include <b>all</b> information or DMV may not be able to update the address.</h4></li>
                    <li><h4>Remove the envolope where indicated below, place the address change form in the envelope and mail to : DMV, 1905 Lana Ave NE, Salem OR 97314</h4></li>
                </ul>
            </div>
        </div>
    </div>
</div>
```


### CreateNewAddress Screenshots

#### CreateNewAddress without input
![CreateNewAddress without input](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/img/dmv_form_no_input.PNG)


#### CreateNewAddress with bad input
![CreateNewAddress with bad input](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/img/dmv_form_bad_input.PNG)


### Change Requests View
##### In this view, the change requests are displayed in a nice looking table. The view is the Index page of CustomersController.
[Index page](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/HW5/Views/Customers/Index.cshtml)

```html
@model IEnumerable<HW5.Models.Customer>

@{
    ViewBag.Title = "Change Requests";
}

<head>
    <link href="@Url.Content("~/Content/tableStyle.css")" rel="stylesheet" />
</head>

<h2><b>Address change requests</b></h2>
<br />
<div class="table-div">
    <!--table to display records in the database-->
    <table>
        <tr>
            <th>@Html.DisplayNameFor(model => model.CustomerNumber)</th>
            <th>@Html.DisplayNameFor(model => model.FirstName)</th>
            <th>@Html.DisplayNameFor(model => model.MiddleName)</th>
            <th>@Html.DisplayNameFor(model => model.LastName)</th>
            <th>@Html.DisplayNameFor(model => model.DOB)</th>
            <th>@Html.DisplayNameFor(model => model.NewAddress)</th>
            <th>@Html.DisplayNameFor(model => model.NewCity)</th>
            <th>@Html.DisplayNameFor(model => model.NewState)</th>
            <th>@Html.DisplayNameFor(model => model.NewZip)</th>
            <th>@Html.DisplayNameFor(model => model.NewCounty)</th>
            <th>@Html.DisplayNameFor(model => model.ChangeDate)</th>
        </tr>

        <!--here we populate each row of the table from the database-->
        @foreach (var item in Model)
        {
            <tr>
                <td>@Html.DisplayFor(modelItem => item.CustomerNumber)</td>
                <td>@Html.DisplayFor(modelItem => item.FirstName)</td>
                <td>@Html.DisplayFor(modelItem => item.MiddleName)</td>
                <td>@Html.DisplayFor(modelItem => item.LastName)</td>
                <td>@Html.DisplayFor(modelItem => item.DOB)</td>
                <td>@Html.DisplayFor(modelItem => item.NewAddress)</td>
                <td>@Html.DisplayFor(modelItem => item.NewCity)</td>
                <td>@Html.DisplayFor(modelItem => item.NewState)</td>
                <td>@Html.DisplayFor(modelItem => item.NewZip)</td>
                <td>@Html.DisplayFor(modelItem => item.NewCounty)</td>
                <td>@Html.DisplayFor(modelItem => item.ChangeDate)</td>
            </tr>
        }
    </table>
</div>
```

### Display Change Requests Screenshots

#### Initial 5 request populated when table was created
![Index Page](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/img/initial_database.PNG)


#### Address change request table after adding a record
![Index page after adding a record](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/img/data_added_database.PNG)



### Customer Class
##### Customer model contains data for an address change request.
[Customer](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/HW5/Models/Customer.cs)

```csharp
namespace HW5.Models
{
    // compile with: /doc:DocFileName.xml 

    public class Customer
    {
        public int ID { get; set; }

        /// <summary>
        /// CustomerNumber represents an ID, License, or any type of identification number for a person.
        /// </summary>
        [Required, RegularExpression("([0-9]{7})", ErrorMessage = "Customer # must be 7 digits")]
        [Display(Name = "Customer #")]
        public int CustomerNumber { get; set; }

        /// <summary>
        /// A customers first name.
        /// </summary>
        [Required, StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// A customers middle name that is not required for the form.
        /// </summary>
        [StringLength(100)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// A customers last name that is required for an address change.
        /// </summary>
        [Required, StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// A customers date of birth that is required for an address change.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        /// <summary>
        /// The customers new address that is required for an address change.
        /// </summary>
        [Required, StringLength(300)]
        [Display(Name = "New Address")]
        public string NewAddress { get; set; }

        /// <summary>
        /// The city for the new address that is required for an address change.
        /// </summary>
        [Required, StringLength(80)]
        [Display(Name = "City")]
        public string NewCity { get; set; }

        /// <summary>
        /// The US state for the new address that is required for an address change.
        /// </summary>
        [Required, StringLength(2)]
        [Display(Name = "State")]
        public string NewState { get; set; }

        /// <summary>
        /// The zip code for the new address that is required for an address change.
        /// </summary>
        [Required, RegularExpression("([0-9]{5})", ErrorMessage = "Zip code must be 5 digits")]
        [Display(Name = "Zip Code")]
        public int NewZip { get; set; }

        /// <summary>
        /// The county for the new address that is required for an address change.
        /// </summary>
        [Required, StringLength(50)]
        [Display(Name = "County")]
        public string NewCounty { get; set; }

        /// <summary>
        /// The date of the address change that is required for an address change.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name = "Date of Change")]
        public DateTime ChangeDate { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {MiddleName} {LastName} DOB = {DOB}";
        }
    }
}
```

### DAL CustomerContext

[CustomerContext](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/HW5/DAL/CustomerContext.cs)

```csharp
 public class CustomerContext : DbContext
    {
        public CustomerContext() : base("name=CustomerDBContext")
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
    }
```


### SQL Scripts

#### Up script

[db_UP.SQL](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/HW5/App_Data/db_UP.sql)

```SQL
CREATE TABLE dbo.Customers
(
	ID INT IDENTITY (1, 1) NOT NULL,
	CustomerNumber INT NOT NULL,
	FirstName NVARCHAR(100) NOT NULL,
	MiddleName NVARCHAR(100) NULL,
	LastName NVARCHAR(100) NOT NULL,
	DOB DATETIME NOT NULL,
	NewAddress NVARCHAR(300) NOT NULL,
	NewCity NVARCHAR(80) NOT NULL,
	NewState NVARCHAR(2) NOT NULL,
	NewZip INT NOT NULL,
	NewCounty NVARCHAR(50) NOT NULL,
	ChangeDate DATETIME NOT NULL,
	CONSTRAINT [PK_dbo.Customers] PRIMARY KEY CLUSTERED (ID ASC)
);
GO

INSERT INTO dbo.Customers
        ( CustomerNumber ,
          FirstName ,
          MiddleName ,
          LastName ,
          DOB ,
          NewAddress ,
          NewCity ,
          NewState ,
          NewZip ,
          NewCounty ,
          ChangeDate
        )
VALUES  ( 1563259 , 'Homer' , 'J' , 'Simpson' , '1958' , '12345 New Springfield St' , 'New Springfield' , 'OR' , 97403 , 'Lane County' , GETDATE()),
		( 1763259 , 'Marge' , '' , 'Simpson' , '1960' , '12345 New Springfield St' , 'New Springfield' , 'OR' , 97403 , 'Lane County' , GETDATE()),
		( 1504259 , 'Bart' , '' , 'Simpson' , '1980' , '12345 New Springfield St' , 'New Springfield' , 'OR' , 97403 , 'Lane County' , GETDATE()),
		( 9463259 , 'Lisa' , '' , 'Simpson' , '1982' , '12345 New Springfield St' , 'New Springfield' , 'OR' , 97403 , 'Lane County' , GETDATE()),
		( 9487259 , 'Maggie' , '' , 'Simpson' , '1989' , '12345 New Springfield St' , 'New Springfield' , 'OR' , 97403 , 'Lane County' , GETDATE());

GO
```

#### Down script

[db_DOWN.SQL](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/HW5/App_Data/db_DOWN.sql)

```SQL
ALTER TABLE dbo.Customers DROP CONSTRAINT [PK_dbo.Customers];

GO

DROP TABLE dbo.Customers;
GO
```


### CSS Used
[tableStyle](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW5/HW5/Content/tableStyle.css)

```css
#oregon-law-p {
    border-style: solid;
    border-width: 1px;
    border-color: black;
    border-radius: 5px;
    padding: 5px;
    margin-top: 10px;
}

.image-col {
    display: inline-block;
}

.image {
    margin-top: 14px;
}

.margin-top {
    margin-top: 15px;
}

.btn.btn-default {
    background-color: deepskyblue;
}
```


