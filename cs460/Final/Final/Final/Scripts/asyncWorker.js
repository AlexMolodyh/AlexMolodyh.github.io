﻿/**
 * Author: Alexander Molodyh
 * Date: 11/26/2017
 * Class: CS460
 * Assignment: HW8
 */

var interval = 5000;
window.setInterval(getBids, interval);

function getBids(btnObj) {
    console.log("Button clicked is: " + btnObj.value);
    var table = $("#genre-table");
    table.empty();

    $.ajax({
        type: "get",
        datatype: "json",
        url: "/Bids/GetBids",
        data: { itemID: btnObj.value },
        success: function (data) {
            populateTable(data);
        },
        error: function () {
            alert("didn't work!");
        }
    });
}


function populateTable(bidList) {
    hideSpinner();
    var table = $("#bidsTable");
    table.empty();

    var tr = $("<tr></tr>");
    var th1 = $("<th>ArtWork</th>");
    var th2 = $("<th>Genre</th>");
    tr.append(th1);
    tr.append(th2);

    //Builds the rest of the table.
    table.append(tr);
    for (var i = 0; i < bidList.Size; i++) {
        var tr1 = $("<tr></tr>");
        var tdArtWork = $("<td>" + bidList.ArtList[i] + "</td>");
        var tdGenre = $("<td>" + bidList.GenreName + "</td>");

        tr1.append(tdArtWork);
        tr1.append(tdGenre);
        table.append(tr1);
    }
}
