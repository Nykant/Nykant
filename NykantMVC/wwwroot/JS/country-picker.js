var country_picker = document.getElementById("country-picker");
var country_input = document.getElementById("customer-country-input");
var country_option = document.getElementById('customer-country-option');
var customer_wrap = document.getElementById("customer-form");
var country_error = document.getElementById("country-error");
var reuse_invoice = document.getElementById('reuse-invoice');
var shippingaddress_country_picker = document.getElementById("shippingaddress-country-picker");
var shippingaddress_country = document.getElementById("shippingaddress-country");
var shipping_country_option = document.getElementById('shipping-country-option');
var shippingaddress_country_error = document.getElementById("shippingaddress-country-error");

country_picker.selectedIndex = 0;
country_picker.style.color = "black";
country_picker.style.border = "2px solid black";
country_input.value = country_option.textContent;

shippingaddress_country_picker.selectedIndex = 0;
shippingaddress_country_picker.style.color = "black";
shippingaddress_country_picker.style.border = "2px solid black";
shippingaddress_country.value = shipping_country_option.textContent;


//if (country_input.value != null) {
//    var options = country_picker.children;
//    for (var i = 0; i < options.length; i++) {
//        if (options[i].value == country_input.value && country_input.value != '') {
            //country_picker.selectedIndex = i;
            //country_picker.style.color = "black";
            //country_picker.style.border = "2px solid black";
//        }
//    }
//}

//country_picker.addEventListener("change", function () {
//    var x = country_picker.selectedIndex;
//    var options = country_picker.children;
//    country_input.value = options[x].value;
//    country_picker.style.color = "black";
//    country_picker.style.border = "2px solid black";
//});

//customer_wrap.addEventListener("submit", function (event) {
//    if (country_input.value === "" || country_input.value === "Vælg Land" || country_input.value === "Choose Country") {
//        event.preventDefault();
//        country_error.style.display = "block";
//        setTimeout(function () {
//            country_error.style.display = "none";
//        }, 6000);
//    };
//    if (reuse_invoice.checked == false) {
//        if (shippingaddress_country.value === "" || shippingaddress_country.value === "Vælg Land" || shippingaddress_country.value === "Choose Country") {
//            event.preventDefault();
//            shippingaddress_country_error.style.display = "block";
//            setTimeout(function () {
//                shippingaddress_country_error.style.display = "none";
//            }, 6000);
//        };
//    }
//});

//if (shippingaddress_country.value != null) {
//    var options = shippingaddress_country_picker.children;
//    for (var i = 0; i < options.length; i++) {
//        if (options[i].value == shippingaddress_country.value && shippingaddress_country.value != '') {
//            shippingaddress_country_picker.selectedIndex = i;
//            shippingaddress_country_picker.style.color = "black";
//            shippingaddress_country_picker.style.border = "2px solid black";
//        }
//    }
//}

//shippingaddress_country_picker.addEventListener("change", function () {
//    var x = shippingaddress_country_picker.selectedIndex;
//    var options = shippingaddress_country_picker.children;
//    shippingaddress_country.value = options[x].value;
//    shippingaddress_country_picker.style.color = "black";
//    shippingaddress_country_picker.style.border = "2px solid black";
//});
