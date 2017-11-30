# ASP.Net MVC 5 Artist Database

## I'll be demonstrating the artist database web app here. I'll cover what the pages are and how to use the artist management pages.

### The following are links to github for the code used in the artist database web app.

[ArtWorks Controller](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Controllers/ArtWorksController.cs)

[Artist Controller](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Controllers/ArtistsController.cs)

[Classification Controller](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Controllers/ClassificationsController.cs)

[Home Controller](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Controllers/HomeController.cs)

[ArtDBContext](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/DAL/ArtDBContext.cs)

[ArtList Model](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Models/ArtList.cs)

[Artist Model](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Models/Artist.cs)

[ArtWork Model](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Models/ArtWork.cs)

[Genre Model](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Models/Genre.cs)

[DateValidation Custom Attribute](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Models/DateValidationAtt.cs)

[JS Cutom Script](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Scripts/asyncWorker.js)

[CSS File](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Content/myStyle.css)

[Database Up Script](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/App_Data/HW8Database_UP.sql)

[Database Down Script](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/App_Data/HW8Database_DOWN.sql)

[Connection Config File](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/connections.config)

[Home Index View](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/HW8/HW8/Views/Home/Index.cshtml)

[Artist Views](https://github.com/AlexMolodyh/AlexMolodyh.github.io/tree/master/cs460/HW8/HW8/HW8/Views/Artists)

[ArtWork Views](https://github.com/AlexMolodyh/AlexMolodyh.github.io/tree/master/cs460/HW8/HW8/HW8/Views/ArtWorks)

[Classification Views](https://github.com/AlexMolodyh/AlexMolodyh.github.io/tree/master/cs460/HW8/HW8/HW8/Views/Classifications)

[Genre Views](https://github.com/AlexMolodyh/AlexMolodyh.github.io/tree/master/cs460/HW8/HW8/HW8/Views/Genres)

[Shared Views](https://github.com/AlexMolodyh/AlexMolodyh.github.io/tree/master/cs460/HW8/HW8/HW8/Views/Shared)


## **The Database ER Diagram**

#### I used Toad Data Modeler to create the ER Diagram.

![Database ER Diagram](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/HW8_ER_Diagram.PNG?raw=true)

## **The Homepage**

#### The homepage has a list of buttons with different genres. Each button will display a list of artworks by their genres. A loading spinner will display while the content is being retrieved so that you knwo it's doing something in the background. Once the artwork has been retrieved, it will be displayed using ajax.

![Homepage Index](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/home_page.PNG?raw=true)


## **The following will display the genre button functions**

#### After clicking a genre button a spinner pops up so the user knows it is working on the request. 

![Homepage spinner](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/spinner.PNG?raw=true)

#### List of portrait genres.

![Portrait Genre](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/portrait_genre.PNG?raw=true)

#### List of renaissance genres.

![Renaissance Genre](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/renaissance_list.PNG?raw=true)

#### List of surrealism genres.

![Surrealism Genre](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/surrealism_genre.PNG?raw=true)

#### List of tesselation genres.

![Tesselation Genre](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/tesselation_genre.PNG?raw=true)


#### This is the code used to populate the tables of genre artworks.
```javascript
function getArtWorkByGenre(btnObj) {
    console.log("Button clicked is: " + btnObj.value);
    var table = $("#genre-table");
    table.empty();

    document.tSpinner = setTimeout("showSpinner()", 300);

    $.ajax({
        type: "get",
        datatype: "json",
        url: "/Home/GenreArtWork",
        data: { genre: btnObj.value},
        success: function (data) {
            clearTimeout(document.tSpinner);
            populateTable(data);
        },
        error: function () {
            alert("didn't work!");
        }
    });
}


function populateTable(genreList) {
    hideSpinner();
    var table = $("#genre-table");
    table.empty();

    var tr = $("<tr></tr>");
    var th1 = $("<th>ArtWork</th>");
    var th2 = $("<th>Genre</th>");
    tr.append(th1);
    tr.append(th2);

    //Builds the rest of the table.
    table.append(tr);
    for (var i = 0; i < genreList.Size; i++) {
        var tr1 = $("<tr></tr>");
        var tdArtWork = $("<td>" + genreList.ArtList[i] + "</td>");
        var tdGenre = $("<td>" + genreList.GenreName + "</td>");

        tr1.append(tdArtWork);
        tr1.append(tdGenre);
        table.append(tr1);
    }
}
```

## **The following is a demonstration of the Artist creation and manipulation**

#### Creating an artist.

![Artist List](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artist_list.PNG?raw=true)


#### Entering invalid data into the name and place of birth.

![Create Artist Bad Name](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/create_new_artist_page_with_wrong_name_and_birth_city.png?raw=tru)


#### Entering invalid date.

![Artist Invalid Date](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/create_new_artist_page_with_future_date.png?raw=true)


#### Entering valid data for a user.

![Artist Good Input](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/create_new_artist_page_good_data.png?raw=true)


#### Artist list after creating John Birks.

![Artist John Birks](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artist_list_new_artists.PNG?raw=true)


#### Artist details page.

![Artist Details](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artist_details_page.PNG?raw=true)


#### Updating an artist.

![Artist Update](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/update_artist.PNG?raw=true)


#### Delete artist page.

![Artist Delete](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/delete_artist_page.PNG?raw=true)


#### After deleting Alexander Molodyh.

![Artist Deleted](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW8/img/screenshots/artist_deleted.PNG?raw=true)


#### Entering invalid date

![](?raw=true)


#### Entering invalid date

![](?raw=true)


#### Creating an artist 

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