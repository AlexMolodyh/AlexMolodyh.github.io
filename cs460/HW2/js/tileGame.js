/*gloval $, jQuery, alert*/


function generateClick() {
    var row = $("#rows").val().trim();
    var col = $("#columns").val().trim();
    //alert("Row: " + row + "\nColumn: " + col);
    
    if(isInteger(row) && isInteger(col)) {
        
    }
    else {
        
    }
}

function invalidInput(id){
    
}


function isInteger(x) {
    if(!isNaN(x) && x % 1 === 0)
        return true;
}