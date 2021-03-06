﻿/**
 * Author: Alexander Molodyh
 * Date: 11/26/2017
 * Class: CS460
 * Assignment: HW8
 */

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

/**
 * Section opening and closing the spinner when the page loads
 */
//$(".navLink").click(function () {
//    console.log("Artist clicked");
//    showSpinner();
//});

$(window).on("beforeunload", function () {
    showSpinner();
});

$(window).on("unload", function () {
    console.log("hello");
    hideSpinner();
});

$(window).load(hideSpinner());


function showSpinner() {
    $(".overlay").show();
    $(".loader").show();
}

function hideSpinner() {
    $(".overlay").hide();
    $(".loader").hide();
}