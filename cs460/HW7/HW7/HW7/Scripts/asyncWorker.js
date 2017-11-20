function search() {

    var searchP = $('#search-box').val();
    console.log("search param is: " + searchP);
    var currentSearchArea = "/v1/gifs/" + document.searchArea;
    console.log(currentSearchArea);
    var currentRating = "all";

    if (document.selectedRating) {
        currentRating = document.selectedRating;
    }


    $.ajax({
        type: "get",
        datatype: "json",
        url: "Giphy/GetJsonGifs",
        data: { searchArea: currentSearchArea, searchParams: searchP, rating: currentRating },
        success: function (data) {
            populateGifs(data);
        },
        error: function () {
            alert("didn't work!");
        }
    });
}

function populateGifs(gifList) {
    var container = $("#gif-container");
    container.empty();

    var gifListSize = gifList.Size;
    var imgPerUl = Math.ceil(gifListSize / 4);
   
    var row = $("<div></div>").attr("class", "row");
    for (var i = 0; i < gifList.Size; i++) {
        var ul = $("<ul></ul>").css("list-style-type", "none");/*ul for a single column*/
        var column = $("<div></div>").attr("class", "col-md-3").attr("id", "gif" + j);

        var j;
        for (j = i; j < i + imgPerUl && j < gifList.Size; j++) {
            var gif = gifList.Gifs[j];

            var gifImageUrl = gif.Url;
            var imgDiv = $("<div></div>").attr("class", "gif-image-div");
            var li = $("<li></li>");

            var gifImage = $("<img />")
                .attr("src", gifImageUrl)
                .attr("class", "gif-image")
                .attr("id", "img" + j)
                .css("max-width", "100%");

            var h5;
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

var num = null;
$(".btn-group > button.btn").on("click", function () {
    var buttonType = this.innerHTML.substring(0, 5);
    console.log(buttonType);

    if (buttonType.toLocaleLowerCase() === "rated") {
        document.selectedRating = this.innerHTML.substring(6).toLowerCase();
        $("#rating-h5").text("Current rating: " + this.innerHTML);
    }
    else {
        document.searchArea = this.innerHTML.toLowerCase();
        if (document.searchArea.toLowerCase() === "search") {
            $("#search-box").show();
        }
        else {
            $("#search-box").hide();
        }
    }

    console.log("search area: " + document.searchArea);
});