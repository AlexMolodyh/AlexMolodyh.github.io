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
            var li = $("<li></li>").attr("class", "img-li");

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