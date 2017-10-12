# Random 'O' Game Code

### Here lies the code behind my random 'O' game that I have created for Homework 2

#### I will run throught the life cycle of the program from generating the table to finding the random box or not.

##### You can find the code for homework two page in the following links:
[Homework two](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW2/index.html) and 
[Game Javascript](https://github.com/AlexMolodyh/AlexMolodyh.github.io/blob/master/cs460/HW2/js/tileGame.js)

##### When the page initially loads the user must chose a column and row size. 
##### Columns and rows must be between 3 and 10 inclusive.

##### Code for the two form column, rows and the Generate button.
```html
<form>
    <label for="rows" id="rowsLabel">
        <span class="inputSpan">Rows</span>
        <input class="form-control" type="text" id="rows" maxlength="2" name="tableRows" required>
        <h6 id="rowsLabelError"></h6>
    </label>
    <label for="columns" id="columnsLabel">
        <span class="inputSpan">Columns</span>
        <input class="form-control" type="text" id="columns" maxlength="2" name="tableColumns" required>
        <h6 id="columnsLabelError"></h6>
    </label>
    <label for="generateButton" id="generateBtnLabel">
        <button type="button" onclick="generateClick()" class="btn btn-primary form-control" id="generateButton">GENERATE</button>
    </label>
</form>
```

##### When the button is clicked, the following code executes and builds the table if the input is valid.
##### The smaller functions below are helper methods to check if input is an integer as well as show and hide elements.
```javascript
function generateClick() {
    initialize();
}

/*the starting of the game*/
function initialize() {
    var row = $("#rows").val().trim();
    var col = $("#columns").val().trim();

    /*This part checks to see if the input is valid. Meaning the input
    is an integer bretween 3 and 10. */
    if (isInputValid(row, col)) {
        attempts = calculateAttempsAllowed(row, col);
        randomIndex = randomizeOBox(row, col);
        if (attemptsAvailable()) {
            displayTable(row, col);
            updateAttempts();
        }
    } else {
        clearTable();
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

```

##### The following code calculates the attempts a user has based on their choice of column and row sizes.
```javascript

/*returns the amount of attemps a user has based on the row and column count*/
function calculateAttempsAllowed(row, col) {
    var sum = (parseInt(row) + parseInt(col));

    var attempts = Math.floor((sum - 6) / 2) + 1; //6, 2, and 1 are just chosen numbers for the calculation
    return attempts;
}

```

##### I used the code below to randomize the column and row index 
```javascript

/*returns an array with a random row and column index*/
function randomizeOBox(row, col) {
    var index = new Object();
    index[0] = Math.floor((Math.random() * row)) + 1;
    index[1] = Math.floor((Math.random() * col)) + 1;
    return index;
}

```

##### To display the table the following function is used.
```javascript

/*creates a table and adds id's to each cell*/
function createTable(row, col) {
    var tableHead = $('<thead></thead>');
    var tableHeadRow = $('<tr></tr>');

    /*populate the header row with column indexes */
    for (var i = 0; i <= col; i++) {
        var tableCol = $('<th> ' + i + '</th>');
        $(tableCol).css("text-align", "center")
            .css("color", "#3F51B5")
            .css("background-color", "white");
        tableHeadRow.append(tableCol);
    }

    tableHead.append(tableHeadRow);

    /*pupulate each row and set column 0 to act as row index */
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

                /*set an onclick listener to each cell */
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

```

##### When a cell is clicked, a function checks if the cell is a valid cell before executing the process of checking for the 'O'.
```javascript
/*checks to see if the current cell is valid */
function clickedCell(row, col) {
    if(isValidCell(row, col) && attemptsAvailable()) {
        checkCell(row, col);
    }
}

/*checks to see if the current cell contains the "O". The first check
is redundant but I want it there just for security purposes just in case
the function is called without checking if the cell clicked is valid.*/
function checkCell(row, col) {
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

```