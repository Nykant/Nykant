var customer_check_sign = document.getElementById("customer-check-sign");
/*var shipping_check_sign = document.getElementById("shipping-check-sign");*/
//var shipping_wrap = document.getElementById("shipping-wrap");
//var shipping_form = document.getElementById("shipping-form");
var payment_wrap = document.getElementById("payment-wrap");
var payment_form = document.getElementById("payment-form");
var customer_wrap = document.getElementById("customer-wrap");
var customer_form = document.getElementById("customer-form");
var customerinf_summary = document.getElementById("customerinf-summary");
var firstname_summary = document.getElementById("customer-firstname-summary");
var email_summary = document.getElementById("customer-email-summary");
var phone_summary = document.getElementById("customer-phone-summary");
var country_summary = document.getElementById("customer-country-summary");
var city_summary = document.getElementById("customer-city-summary");
var postal_summary = document.getElementById("customer-postal-summary");
var address_summary = document.getElementById("customer-address-summary");
var firstname_input = document.getElementById("customer-firstname-input");
var email_input = document.getElementById("customer-email-input");
var phone_input = document.getElementById("customer-phone-input");
var country_input = document.getElementById("customer-country-input");
var city_input = document.getElementById("customer-city-input");
var postal_input = document.getElementById("customer-postal-input");
var address_input = document.getElementById("customer-address-input");
var customer_edit_button = document.getElementById("customer-edit-button");
var customer_form_complete = document.getElementById("customer-form-complete");
/*var shipping_form_complete = document.getElementById("shipping-form-complete");*/
/*var shipping_method_summary = document.getElementById("shipping-method-summary");*/
/*var shipping_summary = document.getElementById("shipping-summary");*/
/*var shipping_edit_button = document.getElementById("shipping-edit-button");*/
//var shipping_delivery_type = document.getElementById("shipping-delivery-type");
//var shipping_price_summary = document.getElementById("shipping-price-summary");
var stage = document.getElementById("stage").dataset.stage;
var reuse_invoice = document.getElementById('reuse-invoice');
var shippingaddress_firstname = document.getElementById('shippingaddress-firstname');
var shippingaddress_city = document.getElementById('shippingaddress-city');
var shippingaddress_country = document.getElementById('shippingaddress-country');
var shippingaddress_postal = document.getElementById('shippingaddress-postal');
var shippingaddress_address = document.getElementById('shippingaddress-address');
var shippingaddress_firstname_summary = document.getElementById('shippingaddress-firstname-summary');
var shippingaddress_city_summary = document.getElementById('shippingaddress-city-summary');
var shippingaddress_country_summary = document.getElementById('shippingaddress-country-summary');
var shippingaddress_postal_summary = document.getElementById('shippingaddress-postal-summary');
var shippingaddress_address_summary = document.getElementById('shippingaddress-address-summary');
var shippingaddress_summary = document.getElementById('shippingaddress-summary');
var terms_and_conditions = document.getElementById('terms-and-conditions-consent');
//var parcelshop_companyname_summary = document.getElementById('parcelshop-companyname-summary');
//var parcelshop_cityname_summary = document.getElementById('parcelshop-cityname-summary');
//var parcelshop_countrycode_summary = document.getElementById('parcelshop-countrycode-summary');
//var parcelshop_streetname_summary = document.getElementById('parcelshop-streetname-summary');
//var parcelshop_streetname2_summary = document.getElementById('parcelshop-streetname2-summary');
//var parcelshop_zipcode_summary = document.getElementById('parcelshop-zipcode-summary');
//var parcelshop_CompanyName = document.getElementById("parcelshop-CompanyName");
//var parcelshop_StreetName = document.getElementById("parcelshop-StreetName");
//var parcelshop_StreetName2 = document.getElementById("parcelshop-StreetName2");
//var parcelshop_ZipCode = document.getElementById("parcelshop-ZipCode");
//var parcelshop_CityName = document.getElementById("parcelshop-CityName");
//var parcelshop_CountryCodeISO3166A2 = document.getElementById("parcelshop-CountryCodeISO3166A2");
//var parcelshop_summary = document.getElementById("parcelshop-summary");
var payment_options_list = document.getElementById('payment-options-list');
var payment_options_container = document.getElementById('payment-options');
var payment_options = payment_options_list.children;
var payment_card_option = document.getElementById('payment-card-option');
var back_button = document.getElementById('back-button');
var backbuttonclicked = false;

/*payment_form.style.display = "none";*/
history.scrollRestoration = "manual";

//if (parcelshop_CityName.value != '') {
//    parcelshop_summary.style.display = "block";
//    parcelshop_companyname_summary.textContent = parcelshop_CompanyName.dataset.value;
//    parcelshop_cityname_summary.textContent = parcelshop_CityName.dataset.value;
//    parcelshop_countrycode_summary.textContent = parcelshop_CountryCodeISO3166A2.dataset.value;
//    parcelshop_streetname_summary.textContent = parcelshop_StreetName.dataset.value;
//    parcelshop_streetname2_summary.textContent = parcelshop_StreetName2.dataset.value;
//    parcelshop_zipcode_summary.textContent = parcelshop_ZipCode.dataset.value;
//}

//if (shipping_delivery_type.value == 'Shop' || shipping_delivery_type.value == 'Butik') {
//    parcelshop_summary.style.display = "block";
//    parcelshop_companyname_summary.textContent = parcelshop_CompanyName.dataset.value;
//    parcelshop_cityname_summary.textContent = parcelshop_CityName.dataset.value;
//    parcelshop_countrycode_summary.textContent = parcelshop_CountryCodeISO3166A2.dataset.value;
//    parcelshop_streetname_summary.textContent = parcelshop_StreetName.dataset.value;
//    parcelshop_streetname2_summary.textContent = parcelshop_StreetName2.dataset.value;
//    parcelshop_zipcode_summary.textContent = parcelshop_ZipCode.dataset.value;
//}
//else {
//    parcelshop_summary.style.display = "none";
//}

//if (reuse_invoice.checked) {
//    document.getElementById('shipping-address-box').style.display = "none";
//    shippingaddress_summary.style.display = "none";
//}
//else {
//    document.getElementById('shipping-address-box').style.display = "block";
//    shippingaddress_summary.style.display = "block";
//}

if (stage == 1) {
    try {
        gtag('event', 'begin_checkout');
    }
    finally {
        customer_wrap.style.transition = "all 1s";
        customer_form.style.transition = "all 1s";
        customer_form.style.height = "auto";
        customer_wrap.style.transform = "translateY(0%)";

        $('html,body').animate({
            scrollTop: $("#customerInf-header").offset().top
        }, 'slow');
    }
}
//else if (stage == 2) {
//    shipping_wrap.style.transition = "all 1s";
//    shipping_form.style.transition = "all 1s";
//    shipping_form.style.height = "auto";
//    shipping_wrap.style.transform = "translateY(0%)";

//    customerinf_summary.style.display = "block";
//    customer_check_sign.style.display = "block";
//    customer_form_complete.value = 1;
//    customer_edit_button.style.display = "block";

//    $('html,body').animate({
//        scrollTop: $("#shipping-headerr").offset().top
//    }, 'slow');
//}
else if (stage == 2) {

    payment_wrap.style.transition = "all 1s";
    payment_form.style.transition = "all 1s";

    payment_form.style.height = "auto";
    payment_wrap.style.transform = "translateY(0%)";


    payment_options_list.style.display = "block";
    payment_options_container.style.display = "block";
    payment_card_option.style.display = "none";
    for (var i = 0; i < payment_options.length; i++) {
        payment_options[i].addEventListener('click', function () {
            if (this.dataset.paymentoption == 'card') {
                payment_options_list.style.display = "none";
                payment_options_container.style.display = "none";
                payment_card_option.style.display = "block";
                backbuttonclicked = false;
            }
        })
    }

    customerinf_summary.style.display = "block";
    customer_check_sign.style.display = "block";
    customer_form_complete.value = 1;
    customer_edit_button.style.display = "block";

    //shipping_summary.style.display = "block";
    //shipping_check_sign.style.display = "block";
    //shipping_form_complete.value = 1;
    //shipping_edit_button.style.display = "block";

    $('html,body').animate({
        scrollTop: $("#payment-header").offset().top
    }, 'slow');
};


back_button.addEventListener('click', function () {
    terms_and_conditions.checked = false;
    document.getElementById('submit-payment').disabled = true;
    backbuttonclicked = true;
    payment_options_container.style.display = "block";
    payment_options_list.style.display = "block";
    payment_card_option.style.display = "none";
})

customer_begin = function () {
    customerloading(true);

    //if (reuse_invoice) {
    //    shippingaddress_firstname.textContent = firstname_input.dataset.value;
    //    shippingaddress_city.textContent = city_input.dataset.value;
    //    shippingaddress_country.textContent = country_input.dataset.value;
    //    shippingaddress_postal.textContent = postal_input.dataset.value;
    //    shippingaddress_address.textContent = address_input.dataset.value;
    //}

}

customer_completed = function (response) {
    customerloading(false);
    if (response.responseJSON == undefined) {
        firstname_input.dataset.value = firstname_input.value;
        email_input.dataset.value = email_input.value;
        phone_input.dataset.value = phone_input.value;
        country_input.dataset.value = country_input.value;
        city_input.dataset.value = city_input.value;
        postal_input.dataset.value = postal_input.value;
        address_input.dataset.value = address_input.value;


        if (reuse_invoice.checked) {
            shippingaddress_summary.style.display = "block";
            shippingaddress_address.dataset.value = address_input.dataset.value;
            shippingaddress_city.dataset.value = city_input.dataset.value;
            shippingaddress_country.dataset.value = country_input.dataset.value;
            shippingaddress_firstname.dataset.value = firstname_input.dataset.value;
            shippingaddress_postal.dataset.value = postal_input.dataset.value;

            shippingaddress_address_summary.textContent = address_input.dataset.value;
            shippingaddress_city_summary.textContent = city_input.dataset.value;
            shippingaddress_country_summary.textContent = country_input.dataset.value;
            shippingaddress_firstname_summary.textContent = firstname_input.dataset.value;
            shippingaddress_postal_summary.textContent = postal_input.dataset.value;
           /* shippingaddress_summary.style.display = "none";*/
        }
        else {
            shippingaddress_summary.style.display = "block";
            shippingaddress_address.dataset.value = shippingaddress_address.value;
            shippingaddress_city.dataset.value = shippingaddress_city.value;
            shippingaddress_country.dataset.value = shippingaddress_country.value;
            shippingaddress_firstname.dataset.value = shippingaddress_firstname.value;
            shippingaddress_postal.dataset.value = shippingaddress_postal.value;

            shippingaddress_address_summary.textContent = shippingaddress_address.dataset.value;
            shippingaddress_city_summary.textContent = shippingaddress_city.dataset.value;
            shippingaddress_country_summary.textContent = shippingaddress_country.dataset.value;
            shippingaddress_firstname_summary.textContent = shippingaddress_firstname.dataset.value;
            shippingaddress_postal_summary.textContent = shippingaddress_postal.dataset.value;
        }

        document.getElementById("edit-customer").value = false;
        customer_check_sign.style.display = "block";
        customer_form_complete.value = 1;
        customerinf_summary.style.display = "block";
        //shipping_wrap.style.transition = "all 1s";
        //shipping_form.style.transition = "all 1s";
        customer_wrap.style.transition = "all 1s";
        customer_form.style.transition = "all 1s";

        customer_edit_button.style.display = "block";
        firstname_summary.textContent = firstname_input.dataset.value;
        email_summary.textContent = email_input.dataset.value;
        phone_summary.textContent = phone_input.dataset.value;
        country_summary.textContent = country_input.dataset.value;
        city_summary.textContent = city_input.dataset.value;
        postal_summary.textContent = postal_input.dataset.value;
        address_summary.textContent = address_input.dataset.value;

        customer_wrap.style.transform = "translateY(-100%)";
        customer_form.style.height = "0px";

        //if (shipping_form_complete.value == 0) {
        //    shipping_form.style.height = "auto";
        //    shipping_wrap.style.transform = "translateY(0%)";
        //};

        //$('html,body').animate({
        //    scrollTop: $("#shipping-headerr").offset().top
        //}, 'slow');

                payment_wrap.style.transition = "all 1s";
        payment_form.style.transition = "all 1s";
        payment_options_container.style.transition = "all 1s";
        payment_form.style.height = "auto";
        payment_wrap.style.transform = "translateY(0%)";

        payment_options_list.style.display = "block";
        payment_options_container.style.display = "block";
        payment_card_option.style.display = "none";
        for (var i = 0; i < payment_options.length; i++) {
            payment_options[i].addEventListener('click', function () {
                if (this.dataset.paymentoption == 'card') {
                    payment_options_list.style.display = "none";
                    payment_options_container.style.display = "none";
                    payment_card_option.style.display = "block";
                    backbuttonclicked = false;
                }
            })
        }
        payment_form.style.height = "auto";
        payment_wrap.style.transform = "translateY(0%)";


        $('html,body').animate({
            scrollTop: $("#payment-header").offset().top
        }, 'slow');
    }
    else {
        $('#checkout-modal').css('display', 'block');
        document.getElementById('checkout-error').textContent = response.responseJSON.error + ' --- sorry: you will have to restart checkout process';
        setTimeout(function () {
            location.replace("https://localhost:5002/checkout/cancelcheckout")
        }, 5000);
    }
};

$(document).mouseup(function (e) {
    if ($(e.target).closest("#checkout-error").length === 0) {
        $('#checkout-modal').css('display', 'none');
    }
});

//shipping_completed = function (response) {
//    if (response.responseJSON.shippingPrice != undefined) {
//        document.getElementById("edit-shipping").value = false;
//        shipping_check_sign.style.display = "block";
//        shipping_form_complete.value = 1;
//        shipping_summary.style.display = "block";
//        shipping_form.style.transition = "all 1s";
//        shipping_wrap.style.transition = "all 1s";
//        payment_wrap.style.transition = "all 1s";
//        payment_form.style.transition = "all 1s";

//        shipping_edit_button.style.display = "block";

//        if (shipping_delivery_type.value == 'Shop' || shipping_delivery_type.value == 'Butik') {
//            parcelshop_summary.style.display = "block";
//            parcelshop_companyname_summary.textContent = parcelshop_CompanyName.dataset.value;
//            parcelshop_cityname_summary.textContent = parcelshop_CityName.dataset.value;
//            parcelshop_countrycode_summary.textContent = parcelshop_CountryCodeISO3166A2.dataset.value;
//            parcelshop_streetname_summary.textContent = parcelshop_StreetName.dataset.value;
//            parcelshop_streetname2_summary.textContent = parcelshop_StreetName2.dataset.value;
//            parcelshop_zipcode_summary.textContent = parcelshop_ZipCode.dataset.value;
//        }
//        else {
//            parcelshop_summary.style.display = "none";
//        }

//        //var totalelem = document.getElementById('checkout-total');

//        //var total = parseInt(totalelem.dataset.totalprice);
//        //document.getElementById('checkout-taxes').textContent = total / 5;

//        shipping_form.style.height = "0px";
//        shipping_wrap.style.transform = "translateY(-100%)";

//        payment_wrap.style.transition = "all 1s";
//        payment_form.style.transition = "all 1s";
//        payment_options_container.style.transition = "all 1s";
//        payment_form.style.height = "auto";
//        payment_wrap.style.transform = "translateY(0%)";

//        payment_options_list.style.display = "block";
//        payment_options_container.style.display = "block";
//        payment_card_option.style.display = "none";
//        for (var i = 0; i < payment_options.length; i++) {
//            payment_options[i].addEventListener('click', function () {
//                if (this.dataset.paymentoption == 'card') {
//                    payment_options_list.style.display = "none";
//                    payment_options_container.style.display = "none";
//                    payment_card_option.style.display = "block";
//                    backbuttonclicked = false;
//                }
//            })
//        }
//        payment_form.style.height = "auto";
//        payment_wrap.style.transform = "translateY(0%)";


//        $('html,body').animate({
//            scrollTop: $("#payment-header").offset().top
//        }, 'slow');

//    }
//    else{
//        $('#checkout-modal').css('display', 'block');
//        document.getElementById('checkout-error').textContent = response.responseJSON.error + ' --- sorry: you will have to restart checkout process';
//        setTimeout(function () {
//            location.replace("https://localhost:5002/checkout/cancelcheckout")
//        }, 5000);
//    }
//};

//shipping_edit_button.addEventListener("click", function () {
//    document.getElementById("edit-shipping").value = true;

//    shipping_wrap.style.transition = "all 1s";
//    shipping_form.style.transition = "all 1s";

//    shipping_form_complete.value = 0;
//    shipping_check_sign.style.display = "none";
//    shipping_summary.style.display = "none";
//    shipping_edit_button.style.display = "none";

//    shipping_form.style.height = "auto";
//    shipping_wrap.style.transform = "translateY(0%)";
//});

customer_edit_button.addEventListener("click", function () {
    document.getElementById("edit-customer").value = true;
    customer_form.style.transition = "all 0s";
    $("#customer-form").css("transform", "translateY(0%)");

    $("#customer-wrap").css("transition", "all 1s");
    customer_form.style.transition = "all 1s";

    customer_form_complete.value = 0;
    customer_check_sign.style.display = "none";
    customerinf_summary.style.display = "none";
    customer_edit_button.style.display = "none";

    customer_form.style.height = "auto";
    $("#customer-wrap").css("transform", "translateY(0%)");
});

$('#privacy-policy-consent').on('click', function () {
    if (document.getElementById('privacy-policy-consent').value == "true") {
        document.getElementById('privacy-policy-consent').value = "false";
        document.getElementById('privacy-policy-input').value = null;
        document.getElementById('customerInf-submit').disabled = true;
    }
    else {
        document.getElementById('privacy-policy-consent').value = "true";
        document.getElementById('privacy-policy-input').value = "true";
        document.getElementById('customerInf-submit').disabled = false;
    }
});


$('#terms-and-conditions-consent').on('click', function () {
    if (terms_and_conditions.checked == false) {
        document.getElementById('submit-payment').disabled = true;
    }
    else {
        document.getElementById('submit-payment').disabled = false;
    }
});

reuse_invoice.onclick = function() {
    if (this.checked) {
        document.getElementById('shipping-address-box').style.display = "none";
    }
    else {
        document.getElementById('shipping-address-box').style.display = "block";
    }
}

var customerloading = function (isLoading) {
    if (isLoading) {
        document.querySelector("#customerspinner").classList.remove("hidden");
        document.getElementById("customer-button-text").classList.add("hidden");
    }
    else {
        document.querySelector("#customerspinner").classList.add("hidden");
        document.getElementById("customer-button-text").classList.remove("hidden");
    }
};