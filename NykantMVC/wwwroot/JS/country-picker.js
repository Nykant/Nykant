var country_picker = document.getElementById("country-picker");
var country_input = document.getElementById("country-input");
var customer_form = document.getElementById("customer-form");
var country_error = document.getElementById("country-error");

country_picker.addEventListener("change", function () {
    var x = country_picker.selectedIndex;
    country_input.value = document.getElementsByTagName("option")[x].value;
});

customer_form.addEventListener("submit", function (event) {
    if (country_input.value === "") {
        event.preventDefault();
        country_error.style.display = "block";
        setTimeout(function () {
            country_error.style.display = "none";
        }, 5000);
    }
});