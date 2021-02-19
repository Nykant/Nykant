var input = document.getElementById("quantityInput");

function countup() {
    var number = parseInt(document.getElementById("quantitynumber").textContent)
    var result = number + 1;
    document.getElementById("quantitynumber").textContent = result;
    input.value = result;
}

function countdown() {
    var number = parseInt(document.getElementById("quantitynumber").textContent)
    var result = number - 1;
    document.getElementById("quantitynumber").textContent = result;
    input.value = result;
}