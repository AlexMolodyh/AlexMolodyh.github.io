function search() {

    var searchP = $('#search-box').val();
    console.log("search param is: " + searchP);

    $.ajax({
        type: "get",
        datatype: "json",
        url: "Home/GetJson",
        data: { searchArea: "/v1/gifs/search", searchParams: searchP },
        success: function (data) {
            var gif = data.Data[1];
            console.log("response is: " + gif.BitlyUrl);
            console.log("data count is: " + data.Pagination.Count);
            populateGifs(data);
        },
        error: function () {
            alert("didn't work!");
        }
    });
}

function populateGifs(gifList) {
    var container = $("#gif-container");

    console.log("data count is: " + gifList.Pagination.Count);
    
    var gif;
    for (var i = 0; i < gifList.Pagination.Count; i++){
        var row = $("<div></div>").attr("class", "row");
        var j;
        for (j = i; j < i + 4; j++) {
            var column = $("<div></div>").attr("class", "col-md-3").attr("id", "gif" + j);
            var gifImage = $("<img src=\"" + gifList.Data[j].BitlyUrl + "\"></img>");
            column.append(gifImage);
            row.append(column);
        }
        container.append(row);
        i = j;

        console.log("gif url is: " + gifList.Data[i].BitlyUrl);

    }
}