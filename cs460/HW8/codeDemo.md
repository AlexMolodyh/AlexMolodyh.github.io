# ASP.Net MVC 5 Giphy Web App

## I demonstrate Giphy search web app and how some of the functions work.

### The following are links to github for the code used in the Giphy web app.

[HomeController](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/Controllers/HomeController.cs)

[Home page](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/Views/Home/Index.cshtml)

[Custom Rout](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/App_Start/RouteConfig.cs)

[SQL Up Table](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/App_Data/db_UP.sql)

[SQL DOWN Table](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/App_Data/db_DOWN.sql)

[GiphyController](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/Controllers/GiphyController.cs)

[Shared Layout](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/Views/Shared/_Layout.cshtml)

[Gif Object](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/Models/Gif.cs)

[GifList](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/Models/GifList.cs)

[GifRequestContext](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/DAL/GifRequestContext.cs)

[GifRequest For Logging](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/Models/GifRequest.cs)

[GiphyObj for Json serialization](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/Models/GiphyObj.cs)

[Javascript File](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/Scripts/asyncWorker.js)

[CSS File](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/HW7/HW7/Content/myStyle.css)


#### **The Homepage**

###### The homepage contains a navbar with a button group for selecting an area to search in. Theres a serchbar and another button group for filtering the search results with such as: Rated G, PG, PG-13, and All.

![Homepage Index](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/img/home_page.PNG?raw=true)

##### **Homepage Expanded Searchbox**

![Homepage Index](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/img/expandable_search_bar.PNG?raw=true)


#### **Homepage Trending Rated All**

###### When a rating is selected, the searchbox disappears and the text to the right of the rating buttons changes to the currently selected rating to let the user keep track of their selection. The ideal thing here would be to color the current button darker but after fiddeling with it for a while I stopped as I'm short on time....

![Homepage Index Trending](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/img/trending_search_rated_all.PNG?raw=true)

###### Here we have the output from searching the trending area.

![Homepage Index Trending](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/img/trending_output.PNG?raw=true)

###### Here we have the output from the rated PG Trending.

![Homepage Index PG search](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/img/pg_rating_output.PNG?raw=true)

###### Here we have the output from the rated All search.

![Homepage Index PG search](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/img/all_rating_output(slow%20network).PNG?raw=true)

###### Here we have the database client request logs.

![Homepage Index PG search](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW7/img/database_logs.PNG?raw=true)


###### This is the code used for the custom routing.
```csharp
public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Giphy",
                url: "gif/search/{id}",
                defaults: new { conroller = "Giphy", action = "GetJsonGifs", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
```

##### **The GiphyController section to send GET requests**

```csharp
        [HttpGet]
        public JsonResult GetJsonGifs(string searchArea, string searchParams, string rating)
        {
            //Get the IP address and browser user agent for logging.
            string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            string userAgent = Request.Headers["User-Agent"].ToString();
            if(string.IsNullOrEmpty(ipAddress))
                ipAddress = Request.ServerVariables["REMOTE_ADDR"];

            //Get api key and build the GET request header.
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyKey"];
            string url = $"http://api.giphy.com{searchArea}?api_key={apiKey}&q={searchParams}";
            Debug.WriteLine($"Url is: {url}");
            GifList gl = new GifList();
            GiphyObj giphyObjs = null;

            /*Try to deserialize the json data into C# objects*/
            try
            {
                //Send request to Giphy.com
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "GET";
                httpRequest.ContentType = "application/json";

                //Handle response
                HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                var result = sr.ReadToEnd();
                Debug.WriteLine("Result is: " + result);

                giphyObjs = JsonConvert.DeserializeObject<GiphyObj>(result, Converter.Settings);
            }
            catch (Exception e){ Debug.WriteLine(e.StackTrace); }

            gl = GetGifs(gl, giphyObjs, rating);
            LogRequest(ipAddress, userAgent, searchArea, searchParams, rating);//Log user request

            return Json(gl, JsonRequestBehavior.AllowGet);
        }
```

##### Homepage view that include the javascript file via Script.

```html
@{
    ViewBag.Title = "Home Page";
}

<div class="container">
    <div class="row">
        <div class="col-md-12">
            <h1 id="search-gifs">Search Gifs</h1>
        </div>
    </div>
    <div class="row" id="search-box-row">
        <div class="col-md-8" id="search-box-col">
            <input type="text" name="search" placeholder="Search Something.." id="search-box">
            <button class="btn btn-primary" type="button" id="search-button" onclick="search()">Search</button>
        </div>
    </div>
    <div class="row">
        <div class="col-md-5 col-md-offset-2">
            <div class="btn-group rating-button-group">
                <button type="button" class="btn btn-primary">Rated All</button>
                <button type="button" class="btn btn-primary">Rated G</button>
                <button type="button" class="btn btn-primary">Rated PG</button>
                <button type="button" class="btn btn-primary">Rated PG-13</button>
            </div>
        </div>
        <div class="col-md-4">
            <h5 id="rating-h5">Current rating: Rated All</h5>
        </div>
    </div>
</div>

@*Section contains the unordered lists of gifs*@
<div id="gif-container">

</div>

@section CustomScripts{ 
    <script type="text/javascript" src="~/Scripts/asyncWorker.js"></script>
}
```

##### Shared layout with custom RenderSection
```html
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Styles.Render("~/Content/myStyle.css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
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
                <div class="nav navbar-nav">
                    <form class="navbar-form form-inline">
                        <div class="btn-group rating-button-group">
                            <button type="button" class="btn btn-primary">Search</button>
                            <button type="button" class="btn btn-primary">Trending</button>
                            <button type="button" class="btn btn-primary">Random</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required: false)
    @RenderSection("CustomScripts", required: false)
</body>
</html>
```

##### Method for logging gif requests
```csharp

//Inserts a client request into the database.
private void LogRequest(string ipAddress, string userAgent, string searchArea, string searchParams, string rating)
{
    GiphyRequest giphyRequest = new GiphyRequest()
    {
        IPAddress = ipAddress,
        BrowserType = userAgent,
        RequestDate = DateTime.Now,
        SearchType = searchArea,
        Rating = rating,
        KeyWord = searchParams
    };

    try
    {
        db.GiphyRequests.Add(giphyRequest);
        db.SaveChanges();
    }catch(Exception e) { Debug.WriteLine(e.StackTrace); }
}
```

##### Method for filtering gifs by rating
```csharp
/// <summary>
/// Filters the gifs based on the client rating selection.
/// </summary>
/// <param name="gifList">A GifList to populate with Gifs</param>
/// <param name="giphyObj">The GiphyObj containing Json gifs that were serialized</param>
/// <param name="rating">The rating to filter the gifs with</param>
/// <returns></returns>
private GifList GetGifs(GifList gifList, GiphyObj giphyObj, string rating)
{
    if (giphyObj == null)
        return null;

    int size = giphyObj.Data.Count;
    List<Gif> gifs = new List<Gif>(size);

    //filters the gifs
    for (int i = 0; i < giphyObj.Data.Count; i++)
    {
        if (rating.Equals("all"))
        {
            gifs = AddGif(giphyObj, i, gifs);
        }
        else
        {
            if(rating.Equals(giphyObj.Data[i].Rating))
            {
                gifs = AddGif(giphyObj, i, gifs);
            }
        }
    }

    //add the gif list to the GifList object
    gifList.Gifs = gifs;
    gifList.Size = gifList.Gifs.Count;
    return gifList;
}

//Adds a gif to the list of gifs
private List<Gif> AddGif(GiphyObj giphyObj, int i, List<Gif> gifs)
{
    Gif myGif = new Gif();
    myGif.Url = giphyObj.Data[i].Images.Original.Url;
    myGif.Username = (giphyObj.Data[i].User != null) ? giphyObj.Data[i].User.Username : null;
    gifs.Add(myGif);

    return gifs;
}
```

##### Javascript File

```javascript
/**
 * Author: Alexander Molodyh
 * Date: 11/19/2017
 * Class: CS460
 * Assignment: HW7
 */


/*Performs a GET request to the GiphyController and populates the page with 
 *gifs uppon success.*/
function search() {
    //search parameters
    var searchP = $('#search-box').val();

    //area to search in such as: /v1/gifs/search, /v1/gifs/trending, or /v1/gifs/random
    var currentSearchArea = "/v1/gifs/search";

    //the rating to filter the return gifs with
    var currentRating = "all";

    //check if the search area has been modified. If yes then change the currentSearchArea
    if (document.searchArea)
        currentSearchArea = "/v1/gifs/" + document.searchArea;

    //if the rating has been modified then set currentRating to the chosen rating.
    if (document.selectedRating) {
        currentRating = document.selectedRating;
    }

    //call the controller with the search parameters
    $.ajax({
        type: "get",
        datatype: "json",
        url: "Giphy/GetJsonGifs",
        data: { searchArea: currentSearchArea, searchParams: searchP, rating: currentRating },
        success: function (data) {
            if (data.Size > 0)
                populateGifs(data);//populate gifs onto the page
            else
                alert("No results found!");
        },
        error: function () {
            alert("didn't work!");
        }
    });
}


/**
 * Builds a row with unordered lists of gifs and displays them on the Index page.
 * @param {any} gifList Is a Json object that represents a GifList. A GifList contains a list of Gif objects
 * that have a Url for the gif and a username.
 */
function populateGifs(gifList) {
    var container = $("#gif-container");
    container.empty();

    var gifListSize = gifList.Size;
    var imgPerUl = Math.ceil(gifListSize / 4);//The amount of gifs each <ul> should have

    //the first loop builds columns containing an unordered list of gifs
    var row = $("<div></div>").attr("class", "row");
    for (var i = 0; i < gifList.Size; i++) {
        var ul = $("<ul></ul>").css("list-style-type", "none");/*ul for a single column*/
        var column = $("<div></div>").attr("class", "col-md-3").attr("id", "gif" + j);

        //second loop populates each unordered list with gifs
        var j;
        for (j = i; j < i + imgPerUl && j < gifList.Size; j++) {
            var gif = gifList.Gifs[j];//get the current gif

            var gifImageUrl = gif.Url;//get the gif url
            var imgDiv = $("<div></div>").attr("class", "gif-image-div");//holds the gif and username
            var li = $("<li></li>");

            //holds the gif image
            var gifImage = $("<img />")
                .attr("src", gifImageUrl)
                .attr("class", "gif-image")
                .attr("id", "img" + j)
                .css("max-width", "100%");

            var h5;//checks if the usernaem isn't null and populates the usename section
            if (gif.Username) {
                h5 = $("<h5>By " + gif.Username + "</h5>")
                    .css("max-width", "100%")
                    .css("margin", "0px")
                    .css("padding", "6px");
            }

            imgDiv.append(gifImage);
            imgDiv.append(h5);
            li.append(imgDiv);
            ul.append(li);
        }
        column.append(ul);
        row.append(column);
        i = j - 1;
    }
    container.append(row);
}

/*This function registers the Rating and Search Area selections*/
$(".btn-group > button.btn").on("click", function () {
    var buttonType = this.innerHTML.substring(0, 5);

    if (buttonType.toLocaleLowerCase() === "rated") {
        document.selectedRating = this.innerHTML.substring(6).toLowerCase();
        $("#rating-h5").text("Current rating: " + this.innerHTML);
    }
    else {
        document.searchArea = this.innerHTML.toLowerCase();
        if (document.searchArea.toLowerCase() === "search") {
            $("#search-box").show();
            $("#search-button").css("min-width", "110px");
            $("#search-gifs").text("Search Gifs");
        }
        else {
            $("#search-box").hide();
            $("#search-button").css("min-width", "240px");
            $("#search-gifs").text("Search " + this.innerHTML + " Gifs");
        }
    }
});
```

###### CSS file used

```css
body {
    background-color: darkslategray;
}

input[type=text] {
    width: 140px;
    -webkit-transition: width 0.4s ease-in-out;
    transition: width 0.4s ease-in-out;
}

/* When the input field gets focus, change its width to 100% */
input[type=text]:focus {
   width: 100%;
   border: 1px solid;
   border-color: dimgray;
   border-radius: 20px;
   box-shadow: #888888; 
}


#search-gifs {
    margin-top: 50px;
    font-size: 40px;
    text-align: center;
    color: white;
}

#search-box {
    height: 45px;
    border: 1px solid;
    border-color: dimgray;
    border-radius: 23px;
    padding-left: 10px;
    margin-right: 20px;
}


#search-box-col {
    margin-left: 37%;
}

#search-button {
    height: 45px;
    min-width: 110px;
    padding-left: 25px;
    padding-right: 25px;
    border-radius: 23px;
    border-color: #4527A0;
    color: white;
    background-color: #673AB7;
}

#search-box-row {
    margin-top: 20px !important;
    margin-bottom: 40px !important;
}


.gif-image {
    max-width: 100%;
    height: auto;
    margin-top: 20px;
}

.gif-image-div {
    padding-bottom: 5px;
    background-color: #E0E0E0;
    box-shadow: 2px 2px 8px 2px #888888;
    margin-top: 20px;
    border-radius: 3px;
}

.btn-group.rating-button-group button.btn.btn-primary {
    background-color: #673AB7;
    border-color: #4527A0;
    min-height: 43px;
}

.btn-group.rating-button-group button.btn.btn-primary:visited {
    background-color: #4527A0;
}

#rating-h5 {
    color: white;
    font-size: 16px;
}
```