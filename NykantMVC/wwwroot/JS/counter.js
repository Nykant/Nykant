var textnumber = document.getElementById("quantitynumber");
function countup() {
    var number = parseInt(textnumber.textContent);
    var result = number + 1;
    document.getElementById("quantitynumber").textContent = result;
}

function countdown() {
    var number = parseInt(textnumber.textContent);
    var result = number - 1;
    document.getElementById("quantitynumber").textContent = result;
}