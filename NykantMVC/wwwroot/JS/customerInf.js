document.getElementById("customer-wrap").style.transform = "translateY(-130%)";
var customer_check_sign = document.getElementById("customer-check-sign");
customer_completed = function () {
    customer_check_sign.style.display = "block";
    shipping_wrap.style.display = "block";
    shipping_wrap.style.transition = "transform 1s";
    shipping_wrap.style.transform = "translateY(0%)";
    document.getElementById("customer-wrap").style.transition = "transform 1s";
    document.getElementById("customer-wrap").style.transform = "translateY(-130%)";
    setTimeout(function () {
        document.getElementById("customer-wrap").style.display = "none";
    }, 1000)
};

var customer_header = document.getElementById("customerInf-header");
customer_header.addEventListener("click", function () {
    document.getElementById("customer-wrap").style.transition = "all 1s";
    if (document.getElementById("customer-wrap").style.transform == "translateY(-130%)") {
        document.getElementById("customer-wrap").style.transform = "translateY(0%)";
        document.getElementById("customer-form").style.height = "auto";
    }
    else {
        document.getElementById("customer-wrap").style.transform = "translateY(-130%)";
        document.getElementById("customer-form").style.height = "0px";
    }
});