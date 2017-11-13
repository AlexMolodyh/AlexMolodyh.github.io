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