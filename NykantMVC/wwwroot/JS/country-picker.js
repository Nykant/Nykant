var country_picker = document.getElementById("country-picker");
var country_input = document.getElementById("customer-country-input");
var customer_wrap = document.getElementById("customer-form");
var country_error = document.getElementById("country-error");

country_picker.addEventListener("change", function () {
    var x = country_picker.selectedIndex;
    country_input.value = document.getElementsByTagName("option")[x].value;
    country_picker.style.color = "black";
    country_picker.style.border = "2px solid black";
});

customer_wrap.addEventListener("submit", function (event) {
    if (country_input.value === "" || country_input.value === "Vælg Land") {
        event.preventDefault();
        country_error.style.display = "block";
        setTimeout(function () {
            country_error.style.display = "none";
        }, 6000);
    }
});