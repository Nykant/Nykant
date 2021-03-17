
var shipping_wrap = document.getElementById("shipping-wrap");
var shipping_check_sign = document.getElementById("shipping-check-sign");
shipping_completed = function () {
    document.getElementById("shipping-form-complete").value = 1;
    shipping_check_sign.style.display = "block";
    shipping_wrap.style.transition = "transform 1s";
    shipping_wrap.style.transform = "translateY(-130%)";
    setTimeout(function () {
        shipping_wrap.style.display = "none";
    }, 1000)
};

var shipping_header = document.getElementById("shipping-header");
shipping_header.addEventListener("click", function () {
    shipping_wrap.style.display = "block";
    shipping_wrap.style.transition = "transform 1s";
    shipping_wrap.style.transform = "translateY(0%)";
});