
function countup() {
    var number = parseInt(document.getElementById("quantitynumber").value)
    if (number >= 1) {
        var result = number + 1;
        document.getElementById("quantitynumber").value = result;
    }
}

function countdown() {
    var number = parseInt(document.getElementById("quantitynumber").value)
    if (number > 1) {
        var result = number - 1;
        document.getElementById("quantitynumber").value = result;
    }

}