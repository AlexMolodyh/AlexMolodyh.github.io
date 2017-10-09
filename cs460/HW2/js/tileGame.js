/*gloval $, jQuery, alert*/

window.attempts = 0;
window.randomIndex = new Object();

function generateClick() {
    initialize();
}

/*the starting of the game*/
function initialize() {
    var row = $("#rows").val().trim();
    var col = $("#columns").val().trim();

    if (isInputValid(row, col)) {
        attempts = calculateAttempsAllowed(row, col);
        randomIndex = randomizeO(row, col);
        if (attemptsAvailable()) {
            displayTable(row, col);
            updateAttempts();
        }
    } else {
        clearTable();
    }
}

/*checks to see if there are any attempts left*/
function attemptsAvailable() {
    return attempts > 0;
}

/*displays the tile table*/
function displayTable(row, col) {
    var table = createTable(row, col);
    clearTable();
    $("#tileTable").append(table);
}

function clearTable() {
    $("#tileTable").empty();
}

/*updates the user attempts available*/
function updateAttempts() {
    $('#attemptsLabel').text(attempts);

}

/*creates a table and adds id's to each cell*/
function createTable(row, col) {
    var tableHead = $('<thead></thead>');
    var tableHeadRow = $('<tr></tr>');

    for (var i = 0; i <= col; i++) {
        var tableCol = $('<th> ' + i + '</th>');
        $(tableCol).css("text-align", "center")
            .css("color", "#3F51B5")
            .css("background-color", "white");
        tableHeadRow.append(tableCol);
    }

    tableHead.append(tableHeadRow);

    for (var ri = 0; ri < row; ri++) {
        var tableRow = $('<tr></tr>').attr("id", "r" + (ri + 1));

        for (var ci = 0; ci <= col; ci++) {
            var cell;
            var id = "r" + (ri + 1) + "c" + ci;
            if (ci === 0) {
                cell = $('<td>' + (ri + 1) + '</td>')
                    .attr("id", id)
                    .css("background-color", "white").css("color", "#3F51B5");
            } else {

                cell = $('<td></td>')
                    .attr("id", id)
                    .css("background-color", "#3F51B5").css("color", "#3F51B5");

                cell.on("click", function () {
                    var colClicked = $(this).parent().children().index($(this));
                    var rowClicked = $(this).parent().parent().children().index($(this).parent());
                    clickedCell(rowClicked, colClicked);
                });
            }

            tableRow.append(cell);
        }
        tableHead.append(tableRow);
    }
    return tableHead;
}

/*checks to see if the current cell contains the "O"*/
function clickedCell(row, col) {
    if (attemptsAvailable() && isValidCell(row, col)) {
        $('#r' + row + 'c' + col).css("background-color", "white").text('X');
        attempts--;
        updateAttempts();
    }

    /*checks to see if the user won or lost*/
    if (isWinner(row, col)) {
        attempts = 0;
        updateAttempts();
        alert("You win!!!");
        exposeWinner(randomIndex[0], randomIndex[1]);
    } else if (!isWinner(row, col) && !attemptsAvailable()) {
        alert("Out of attempts. You lose!!");
        exposeWinner(randomIndex[0], randomIndex[1]);
    }
}

/*exposes the winning cell*/
function exposeWinner(row, col) {
    $('#r' + row + 'c' + col).css("background-color", "white").text("O");
}

/*check if chosen cell is the winer*/
function isWinner(row, col) {
    if (row == randomIndex[0] && col == randomIndex[1]) {
        return true;
    } else {
        return false;
    }
}

/*checks if the selected cell has been chosen already*/
function isValidCell(row, col) {
    var cellColor = $('#r' + row + 'c' + col).css("background-color");
    var invalidCellColor = 'rgb(255, 255, 255)';

    if (cellColor != invalidCellColor) {
        return true;
    } else {
        return false;
    }
}

/*checks if the row and column inputs have valid values*/
function isInputValid(row, col) {
    var validRow = false;
    var validCol = false;
    if (isInteger(row) && row >= 3 && row <= 10) {
        hideElementById("#rowsLabelError");
        validRow = true;
    } else {
        showElementById("#rowsLabelError");
        showInvalidInput("#rowsLabel");
        validRow = false;
    }

    if (isInteger(col) && col >= 3 && col <= 10) {
        hideElementById("#columnsLabelError");
        validCol = true;
    } else {
        showElementById("#columnsLabelError");
        showInvalidInput("#columnsLabel");
        validCol = false;
    }

    return (validRow && validCol);
}

/*returns an array with a random row and column index*/
function randomizeO(row, col) {
    var index = new Object();
    index[0] = Math.floor((Math.random() * row)) + 1;
    index[1] = Math.floor((Math.random() * col)) + 1;
    return index;
}

/*returns the amount of attemps a user has based on the row and column count*/
function calculateAttempsAllowed(row, col) {
    var sum = (parseInt(row) + parseInt(col));

    var attempts = Math.floor((sum - 6) / 2) + 1; //6, 2, and 1 are just chosen numbers for the calculation
    return attempts;
}

function hideElementById(id) {
    $(id).hide();
}

function showElementById(id) {
    $(id).show();
}

/*displays red text below the input areas if input isn't valid*/
function showInvalidInput(id) {
    $(id + "Error").text("Must be an integer between 3-10").css("color", "red");
}

/*checks to see if the value is an integer*/
function isInteger(x) {
    if (!isNaN(x) && x % 1 === 0)
        return true;
}