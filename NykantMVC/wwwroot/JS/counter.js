
function countup(quantityid) {
    var number = parseInt(document.getElementById("{ quantityid }").textContent);
    var result = number + 1;
    document.getElementById("quantitynumber").textContent = result;
}

function countdown(quantityid) {
    var number = parseInt(document.getElementById(quantityid).textContent);
    var result = number - 1;
    document.getElementById("quantitynumber").textContent = result;
}