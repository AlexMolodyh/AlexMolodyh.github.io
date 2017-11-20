# ASP.Net MVC 5 Online Store

## Here I demonstrate the nongeneral code used in the database. I include screenshots of the program to demonstrate how it would be used as well.

### The following are links to github for the code used in the web store. I didn't include the thank you page and the error page because they're 5 lines of code that is very typical code.

[HomeController](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/HW6/HW6/Controllers/HomeController.cs)

[Home page image](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/HW6/HW6/Views/Home/Index.cshtml)

[ProductController](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/HW6/HW6/Controllers/ProductController.cs)

[Shared Layout](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/HW6/HW6/Views/Shared/_Layout.cshtml)

[Product items display](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/HW6/HW6/Views/Product/ProductsDisplay.cshtml)

[Product information display](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/HW6/HW6/Views/Product/ProductInfo.cshtml)

[Write a reveiw page](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/HW6/HW6/Views/Product/WriteReview.cshtml)


#### **The Homepage**

###### I didn't do anything fancy for the homepage. I included a navbar in the shared layout and added it to every View. This way a customer can select a subcategory from any page instead of having to go back to the homepage everytime.

![Homepage Index](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/img/homepage.PNG?raw=true)

##### **Homepage with dropdown list**

![Homepage Index Dropdown](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/img/homepage2.PNG?raw=true)


#### **The Products Display Page**

###### I tried to nicely display the items with a large photo so a customer could see what the item is. I only allowed 12 items per page, which are in a paged list. To use the PagedList feature, I added a nuget package called PagedList.MVC. I generate each item in a foreach loop inside a View using razor. The following code demonstrates that code:
```html
@{
    ViewBag.Title = "ProductsDisplay";
    Layout = "~/Views/Shared/_Layout.cshtml";
    int counter = 0;
    <link rel="stylesheet" href="~/Content/myStyle.css"/>
}

@*Add a pagination list on top of the items*@
Page @(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber) of @Model.PageCount

@Html.PagedListPager(Model, page => Url.Action("ProductsDisplay",
    new { page, ViewBag.SubCategory }))

<div class="row">
    @*This foreach loop populates a list of Product items*@
    @foreach (var item in Model)
    {
        @*This checks to see if we have reached the end of one row and closes the row and opens another one*@
        if (counter != 0 && counter % 4 == 0)
        {
            @:</div>
            @:<div class="row">
        }
        <div class="col-md-3">
            <div class="item-tile">
                @*convert the images from the database to a byte string*@
                <div>
                    <img src="@String.Format("data:image/png;base64,{0}", Convert.ToBase64String(item.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto))" />
                </div>
                <div class="item-tile-description">
                    <!--Information goes here-->
                    <!--Product name here-->
                    <h4>@item.Name</h4>

                    <!--Price goes here-->
                    <h4><b>@item.ListPrice.ToString($"C")</b></h4>

                    @Html.ActionLink("Details", "ProductInfo", "Product", new { pID = item.ProductID }, new { @class = "btn btn-primary", @id = "product-button" })
                </div>
            </div>
        </div>
        counter++;
    }
</div>
<hr />
Page @(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber) of @Model.PageCount

@Html.PagedListPager(Model, page => Url.Action("ProductsDisplay",
    new { page, ViewBag.SubCategory }))
```

##### **Code to get the list of Products**

```csharp
public ViewResult ProductsDisplay(string subCategory, int? page)
        {
            if (subCategory == null)
                subCategory = "Mountain Bikes";
            
            ViewBag.SubCategory = subCategory;

            var subCater = db.ProductSubcategories.Where(ps => ps.Name == subCategory).Select(ps2 => ps2.ProductSubcategoryID);
            int psIndex = subCater.First();

            var productIE = db.Products.Where(p => p.ProductSubcategoryID == psIndex);
            productList = productIE.ToList<Product>();

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(productList.ToPagedList(pageNumber, pageSize));
        }
```

##### **Screenshot of ProductsDisplay View**

![Products Display](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/img/display_items_page.PNG?raw=true)

##### **Product Info Page**

###### I used a simple design to display the selected item and its image. The image is stretched to fit my particular design choice so it doesn't look to good if the image isn't a good quality to begin with. If the product contains reviews, I display them in a top-down manner with a for loop using razor.

##### **The View**
```html
<div>
    <div class="row">
        <div class="col-md-8">
            <div class="product-info-container">
                <!--section for product photo-->
                <img src="@String.Format("data:image/png;base64,{0}", Convert.ToBase64String(Model.ProductProductPhotoes.First().ProductPhoto.LargePhoto))" />
            </div>
        </div>
        <div class="col-md-4 review-button-col">
            <!--section for product name, price, and description-->
            <h4><b>Product Name: </b>@Model.Name</h4>
            <h4><b>Price: </b>@Model.ListPrice.ToString($"C")</h4>
            <h4><b>Weight: </b>@(Model.Weight ?? 0)</h4>

            @Html.ActionLink("Write Review", "WriteReview", "Product", new { pID = Model.ProductID, product = Model }, new { @class = "btn btn-primary", @id = "write-review-button" })
        </div>
    </div>

    <div class="product-review">
        <!--Builds reviews from a list by laying the reviews in a top down order-->
        @if (Model.ProductReviews.Count > 0)
        {
            foreach (var review in Model.ProductReviews)
            {
                <hr />

                <h4>Customer Name: @review.ReviewerName</h4>
                <h4>Review Date: @review.ReviewDate</h4>
                <p>@review.Comments</p>
            }
        }
    </div>
</div>
```

##### **The Controller side**
```csharp
public ActionResult ProductInfo(int? pID)
{
    return View(GetProduct(pID));
}

//I use this method in many places, that's why I chose to write it this way.
public Product GetProduct(int? pID)
{
    int productID = pID ?? 1;
    return db.Products.Where(p => p.ProductID == productID).First();
}
```

##### **The Product Info Page**

![Product Info](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/img/product_info_page.PNG?raw=true)

##### **After a review has been submitted**

![Product Info with Review](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/img/after_writing_review.PNG?raw=true)


##### **Product Review Page**

###### I included the ProductID in the review page so that a customer can use it to select a different product by ID if they choose to. I didn't include the dates because when a user creates a review, it is on today's date. We don't have a section for a user to modify a review so I didn't include the EditDate either. The View code is simple and boring so no need to include it here, it can be found at the top at one of the product review link. The following code is from the ProductController:

```csharp
        /// <summary>
        /// Prepares a ProductReview object to capture the users review of an item.
        /// </summary>
        /// <param name="pID">The Product that the customer wants to add a review to.</param>
        /// <returns>A ProductReview object.</returns>
        [HttpGet]
        public ActionResult WriteReview(int? pID)
        {
            ProductReview productReview = new ProductReview();
            productReview.ProductID = pID ?? 0;

            ViewBag.CurrentProductName = GetProduct(pID).Name;
            return View(productReview);
        }

        /// <summary>
        /// WriteReview takes in a ProductReview object and saves it to the database.
        /// </summary>
        /// <param name="productReview">A ProductReview that needs to be saved 
        /// to the database.</param>
        /// <returns>A view thanking the user for the review or an error page if the user
        /// input bad data.</returns>
        [HttpPost]
        public ActionResult WriteReview(ProductReview productReview)
        {
            try
            {
                productReview.ModifiedDate = DateTime.Now;
                productReview.ReviewDate = DateTime.Now;

                db.Products.Select(p => p.ProductReviews).First().Add(productReview);
                db.ProductReviews.Add(productReview);
                db.SaveChanges();
                return View("ThankYou", productReview);
            }
            catch(Exception e)
            {
                return View("BadInput", productReview.ReviewerName);
            }
        }
```

##### **Product Review Screenshots**

![Product Review](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/img/write_review_page.PNG?raw=true)

##### **Product Review With Bad Input**

![Product Review Bad Input](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/img/write_reveiw_page_bad_input.PNG?raw=true)


##### **Thank You Page**

![Thank You](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW6/img/thank_you_page.PNG?raw=true)


##### **Code For Shared Layout**

```html
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    <link rel="stylesheet" href="~/Content/myStyle.css"/>
</head>
<body>

    @{
        int defaultPage = 1;
    }
    <div class="navbar navbar-default navbar-fixed-top gradient">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Application name", "Index", "Home", new { area = "" }, new { @class = "navbar-brand" })
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <!--Dropdown for Bikes category-->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Bikes<span class="caret"></span></a>
                        <ul class="dropdown-menu gradient">
                            <li>@Html.ActionLink("Mountain Bikes", "ProductsDisplay", "Product", new { subCategory = "Mountain Bikes", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Road Bikes", "ProductsDisplay", "Product", new { subCategory = "Road Bikes", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Touring Bikes", "ProductsDisplay", "Product", new { subCategory = "Touring Bikes", defaultPage }, null)</li>
                        </ul>
                    </li>
                    <!--Dropdown for Clothing category-->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Clothing<span class="caret"></span></a>
                        <ul class="dropdown-menu gradient">
                            <li>@Html.ActionLink("Bib Shorts", "ProductsDisplay", "Product", new { subCategory = "Bib-Shorts", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Caps", "ProductsDisplay", "Product", new { subCategory = "Caps", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Gloves", "ProductsDisplay", "Product", new { subCategory = "Gloves", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Jerseys", "ProductsDisplay", "Product", new { subCategory = "Jerseys", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Shorts", "ProductsDisplay", "Product", new { subCategory = "Shorts", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Socks", "ProductsDisplay", "Product", new { subCategory = "Socks", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Tights", "ProductsDisplay", "Product", new { subCategory = "Tights", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Vests", "ProductsDisplay", "Product", new { subCategory = "Vests", defaultPage }, null)</li>
                        </ul>
                    </li>
                    <!--Dropdown for Accessories category-->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Accessories<span class="caret"></span></a>
                        <ul class="dropdown-menu gradient">
                            <li>@Html.ActionLink("Bike Racks", "ProductsDisplay", "Product", new { subCategory = "Bike Racks", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Bike Stands", "ProductsDisplay", "Product", new { subCategory = "Bike Stands", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Bottles and Cages", "ProductsDisplay", "Product", new { subCategory = "Bottles and Cages", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Cleaners", "ProductsDisplay", "Product", new { subCategory = "Cleaners", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Fenders", "ProductsDisplay", "Product", new { subCategory = "Fenders", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Helmets", "ProductsDisplay", "Product", new { subCategory = "Helmets", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Hydration Packs", "ProductsDisplay", "Product", new { subCategory = "Hydration Packs", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Lights", "ProductsDisplay", "Product", new { subCategory = "Lights", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Locks", "ProductsDisplay", "Product", new { subCategory = "Locks", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Panniers", "ProductsDisplay", "Product", new { subCategory = "Panniers", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Pumps", "ProductsDisplay", "Product", new { subCategory = "Pumps", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Tires and Tubes", "ProductsDisplay", "Product", new { subCategory = "Tires and Tubes", defaultPage }, null)</li>
                        </ul>
                        <!--Dropdown for Components category-->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Components<span class="caret"></span></a>
                        <ul class="dropdown-menu gradient">
                            <li>@Html.ActionLink("Handlebars", "ProductsDisplay", "Product", new { subCategory = "Handlebars", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Bottom Brackets", "ProductsDisplay", "Product", new { subCategory = "Bottom Brackets", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Brakes", "ProductsDisplay", "Product", new { subCategory = "Brakes", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Chains", "ProductsDisplay", "Product", new { subCategory = "Chains", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Cranksets", "ProductsDisplay", "Product", new { subCategory = "Cranksets", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Derailleurs", "ProductsDisplay", "Product", new { subCategory = "Derailleurs", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Forks", "ProductsDisplay", "Product", new { subCategory = "Forks", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Headsets", "ProductsDisplay", "Product", new { subCategory = "Headsets", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Mountain Frames", "ProductsDisplay", "Product", new { subCategory = "Mountain Frames", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Pedals", "ProductsDisplay", "Product", new { subCategory = "Pedals", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Road Frames", "ProductsDisplay", "Product", new { subCategory = "Road Frames", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Saddles", "ProductsDisplay", "Product", new { subCategory = "Saddles", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Touring Frames", "ProductsDisplay", "Product", new { subCategory = "Touring Frames", defaultPage }, null)</li>
                            <li>@Html.ActionLink("Wheels", "ProductsDisplay", "Product", new { subCategory = "Wheels", defaultPage }, null)</li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container body-content" id="shared-layout-body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required: false)
    @RenderSection("MyScripts", required: false)    @*Load our custom script*@
</body>
</html>
```

##### **CSS Used**

```css
body {
    font-family: -apple-system, system-ui, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif;
}

.item-tile {
    text-align: center;
    padding: 5px;
    margin-bottom: 50px;
}

#product-button.btn.btn-primary {
    min-width: 55%;
    color: dimgrey;
    background-color: white;
    border-color: dimgray;
}

.item-tile hr {
    border: solid .3px;
}

.item-tile-description > h4:first-child {
    min-height: 40px;
}


/**********************************home page stuff*************************************/

.home-page-container h1 {
    font-size: 80px;
}

#main-page-image {
    width: 100%;
}

.home-page-container img {
    width: 100%;
    height: auto;
    max-height: 100%;
}



/**********************************product info page*************************************/


#write-review-button.btn-primary {
    min-width: 45%;
    background-color: #00897B;
    border-color: #00796B;
}

.row {
    margin-top: 30px;
}

.product-info-container img {
    min-width: 100%;
}

.product-info-container {
    margin-bottom: 30px;
}

.product-review p {
    padding: 10px;
    font-size: 16px;
    border: 1px solid;
    border-color: #4DB6AC;
    border-radius: 5px;
}

.product-review hr {
    margin-bottom: 20px;
}


/**********************************write reveiw page*************************************/

#submit-review-button.btn-default {
    min-width: 60%;
    background-color: #00897B;
    border-color: #00796B;
    color: white;
}

#write-review-comment-box {
    min-height: 100px;
    min-width: 100%;
}

#create-review-form.form-horizontal .form-group {
    margin-left: 0px;
    margin-right: 0px;
}



/**********************************navbar section*************************************/

/*Class section on navbar*/
.navbar {
    background: #00695C;
    padding-top: 10px;
    padding-bottom: 10px;
    min-height: 60px;
    margin-bottom: 0px;
    border: none;
}


.gradient {
    background: #00695C; /* For browsers that do not support gradients */
    background: -webkit-linear-gradient(left top, #00695C, #009688); /* For Safari 5.1 to 6.0 */
    background: -o-linear-gradient(bottom right, #00695C, #009688); /* For Opera 11.1 to 12.0 */
    background: -moz-linear-gradient(bottom right, #00695C, #009688); /* For Firefox 3.6 to 15 */
    background: linear-gradient(to bottom right, #00695C, #009688); /* Standard syntax */
}


/*change the navbar-brand font*/
.navbar-default .navbar-brand {
    color: #f3f1f1;
}

/*change the color of the navbar-brand text so it stays white when hovering over it*/
.navbar-default .navbar-brand:hover {
    color: #f3f1f1;
}

/*change the color of the navbar item font*/
.nav.navbar-nav li a {
    color: #f3f1f1;
    font-size: 16px;
}

/*when hovering over a dropdown tab, the font color is changed*/
.nav.navbar-nav li a:hover {
    color: #d2b0b0;
}

/*when hovering over a dropdown menuitem, the background color is changed as well as the font*/
.dropdown .dropdown-menu li a:hover {
    background-color: #004D40;
    color: #f3f1f1;
}

/*when a dropdown tab is selected, the background is changed*/
.navbar-default .navbar-nav .dropdown.open a:focus {
    background-color: #009688;
    color: #f3f1f1;
}

/*when a dropdown tab is selected, the background is changed*/
.navbar-default .navbar-nav .active a {
    background-color: #009688; /*dropdown button background when it is active*/
    color: #f3f1f1;
}

/*this colors the dropdown menu background*/
.dropdown-menu {
    background-color: #009688;
}

/*this colors the font in the dropdown menu*/
.dropdown-menu li a {
    color: #f3f1f1;
    margin: 8px;
    padding: 5px;
    font-size: 14px;
}

/*this makes the dropdown menu taller*/
.dropdown-menu li {
    min-height: 30px;
}

/*navbar dropdown caret*/
.navbar-default .navbar-nav > .dropdown > a .caret {
    border-top-color: darkgray;
    border-bottom-color: darkgray;
}

.dropdown {
    margin-right: 10px;
    margin-left: 10px;
}

/*************************this is for the homepage exclusively***************************/

/*removes the margins in the home page for the image to fill the whole screen*/
#shared-layout-body-content.container {
    margin-left: 0px;
    margin-right: 0px;
    padding: 0px;
    max-width: 100%;
}
```