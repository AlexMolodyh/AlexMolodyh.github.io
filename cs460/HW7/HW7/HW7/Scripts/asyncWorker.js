function search() {

    var searchP = $('#search-box').val();
    console.log("search param is: " + searchP);

    $.ajax({
        type: "get",
        datatype: "json",
        url: "Home/GetJson",
        data: { searchArea: "/v1/gifs/search", searchParams: searchP },
        success: function (data) {
            //var gif = data.Gifs[0];
            //console.log("response is: " + gif.Url);
            //console.log("data count is: " + data.Gifs.Size);
            populateGifs3(data);
        },
        error: function () {
            alert("didn't work!");
        }
    });
}

function populateGifs3(gifList) {
    var container = $("#gif-container");
    container.empty();

    var gif;
    for (var i = 0; i < gifList.Size; i++) {
        var row = $("<div></div>").attr("class", "row");
        var j;
        for (j = i; j < i + 4; j++) {
            gif = gifList.Gifs[j];
            var gifImageUrl = gif.Url;
            var imgDiv = $("<div></div>").attr("class", "gif-image-div");

            var column = $("<div></div>").attr("class", "col-md-3").attr("id", "gif" + j);
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
            column.append(imgDiv);
            row.append(column);
        }
        container.append(row);
        i = j;
    }
}

function populateGifs(gifList) {
    var container = $("#gif-container");
    container.empty();
    
    var gif;
    for (var i = 0; i < gifList.Pagination.Count; i++){
        var row = $("<div></div>").attr("class", "row");
        var j;
        for (j = i; j < i + 4; j++) {
            gif = gifList.Data[j];
            var gifImageUrl = gif.Images.Original.Url;
            var imgDiv = $("<div></div>").attr("class", "gif-image-div");

            var column = $("<div></div>").attr("class", "col-md-3").attr("id", "gif" + j);
            var gifImage = $("<img />")
                .attr("src", gifImageUrl)
                .attr("class", "gif-image")
                .attr("id", "img" + j)
                .css("max-width", "100%");

            var h5;
            if (gif.User) {
                var username = gif.User.Username;
                var imgWidth = gif.Images.FixedHeight.Width;
                
                h5 = $("<h5>By: " + username + "</h5>")
                    .css("margin", "0px")
                    .css("padding", "6px");
            }

            imgDiv.append(gifImage);
            imgDiv.append(h5);
            column.append(imgDiv);
            row.append(column);
        }
        container.append(row);
        i = j;
    }
}

function populateGifs2(gifList) {
    var container = $("#gif-container");
    container.empty();
    
    for (var i = 0; i < gifList.Pagination.Count; i++) {
        var ul = $("<ul></ul>");
        var gif = gifList.Data[i];
        var gifImageUrl = gif.Images.Original.Url;
        var imgDiv = $("<div></div>").attr("class", "gif-image-div");

        var li = $("<li></li>").attr("id", "gif" + i);
        var gifImage = $("<img />")
            .attr("src", gifImageUrl)
            .attr("class", "gif-image")
            .attr("id", "img" + i);

        var h5;
        if (gif.User) {
            var username = gif.User.Username;
            var imgWidth = gif.Images.FixedHeight.Width;

            h5 = $("<h5><b>Posted By: </b> " + username + "</h5>")
                .css("margin", "0px")
                .css("padding", "6px");

        imgDiv.append(gifImage);
        imgDiv.append(h5);
        li.append(imgDiv);
        ul.append(li);
        }
        container.append(ul);

    }
}