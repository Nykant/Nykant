
var payment_wrap = document.getElementById("payment-wrap");

var payment_header = document.getElementById("payment-header");
payment_header.addEventListener("click", function () {
    payment_wrap.style.display = "block";
    payment_wrap.style.transition = "transform 1s";
    payment_wrap.style.transform = "translateY(0%)";
});