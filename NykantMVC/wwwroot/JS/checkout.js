var customer_check_sign = document.getElementById("customer-check-sign");
var shipping_check_sign = document.getElementById("shipping-check-sign");
var shipping_wrap = document.getElementById("shipping-wrap");
var shipping_form = document.getElementById("shipping-form");
var payment_wrap = document.getElementById("payment-wrap");
var payment_form = document.getElementById("payment-form");
var customer_wrap = document.getElementById("customer-wrap");
var customer_form = document.getElementById("customer-form");
var customerinf_summary = document.getElementById("customerinf-summary");
var firstname_summary = document.getElementById("customer-firstname-summary");
var lastname_summary = document.getElementById("customer-lastname-summary");
var email_summary = document.getElementById("customer-email-summary");
var phone_summary = document.getElementById("customer-phone-summary");
var country_summary = document.getElementById("customer-country-summary");
var city_summary = document.getElementById("customer-city-summary");
var postal_summary = document.getElementById("customer-postal-summary");
var address_summary = document.getElementById("customer-address-summary");
var firstname_input = document.getElementById("customer-firstname-input");
var lastname_input = document.getElementById("customer-lastname-input");
var email_input = document.getElementById("customer-email-input");
var phone_input = document.getElementById("customer-phone-input");
var country_input = document.getElementById("customer-country-input");
var city_input = document.getElementById("customer-city-input");
var postal_input = document.getElementById("customer-postal-input");
var address_input = document.getElementById("customer-address-input");
var customer_edit_button = document.getElementById("customer-edit-button");
var customer_form_complete = document.getElementById("customer-form-complete");
var shipping_form_complete = document.getElementById("shipping-form-complete");
var shipping_method_summary = document.getElementById("shipping-method-summary");
var shipping_summary = document.getElementById("shipping-summary");
var shipping_edit_button = document.getElementById("shipping-edit-button");
var shipping_delivery_name = document.getElementById("shipping-delivery-name");
var stage_value = document.getElementById("stage").value;

if (stage_value == 1) {
    customer_wrap.style.transition = "all 1s";
    customer_form.style.transition = "all 1s";
    customer_form.style.height = "auto";
    customer_wrap.style.transform = "translateY(0%)";
}
else if (stage_value == 2) {
    shipping_wrap.style.transition = "all 1s";
    shipping_form.style.transition = "all 1s";
    shipping_form.style.height = "auto";
    shipping_wrap.style.transform = "translateY(0%)";

    customerinf_summary.style.display = "block";
    customer_check_sign.style.display = "block";
    customer_form_complete.value = 1;
    customer_edit_button.style.display = "block";
}
else if (stage_value == 3) {
    payment_wrap.style.transition = "all 1s";
    payment_form.style.transition = "all 1s";
    payment_form.style.height = "auto";
    payment_wrap.style.transform = "translateY(0%)";

    customerinf_summary.style.display = "block";
    customer_check_sign.style.display = "block";
    customer_form_complete.value = 1;
    customer_edit_button.style.display = "block";

    shipping_summary.style.display = "block";
    shipping_check_sign.style.display = "block";
    shipping_form_complete.value = 1;
    shipping_edit_button.style.display = "block";
};

customer_completed = function () {
    document.getElementById("edit-customer").value = false;
    customer_check_sign.style.display = "block";
    customer_form_complete.value = 1;
    customerinf_summary.style.display = "block";
    shipping_wrap.style.transition = "all 1s";
    shipping_form.style.transition = "all 1s";
    customer_wrap.style.transition = "all 1s";
    customer_form.style.transition = "all 1s";

    customer_edit_button.style.display = "block";
    firstname_summary.innerHTML = firstname_input.value;
    lastname_summary.innerHTML = lastname_input.value;
    email_summary.innerHTML = email_input.value;
    phone_summary.innerHTML = phone_input.value;
    country_summary.innerHTML = country_input.value;
    city_summary.innerHTML = city_input.value;
    postal_summary.innerHTML = postal_input.value;
    address_summary.innerHTML = address_input.value;

    customer_wrap.style.transform = "translateY(-100%)";
    customer_form.style.height = "0px";

    if (shipping_form_complete.value == 0) {
        shipping_form.style.height = "auto";
        shipping_wrap.style.transform = "translateY(0%)";
    };



    $('html,body').animate({
        scrollTop: $("#shipping-header").offset().top
    }, 'slow');
};

shipping_completed = function () {
    document.getElementById("edit-shipping").value = false;
    shipping_check_sign.style.display = "block";
    shipping_form_complete.value = 1;
    shipping_summary.style.display = "block";
    shipping_form.style.transition = "all 1s";
    shipping_wrap.style.transition = "all 1s";
    payment_wrap.style.transition = "all 1s";
    payment_form.style.transition = "all 1s";

    shipping_edit_button.style.display = "block";
    shipping_method_summary.innerHTML = shipping_delivery_name.value;

    shipping_form.style.height = "0px";
    shipping_wrap.style.transform = "translateY(-100%)";
    payment_form.style.height = "auto";
    payment_wrap.style.transform = "translateY(0%)";


        $('html,body').animate({
            scrollTop: $("#payment-header").offset().top
        }, 'slow');

};

shipping_edit_button.addEventListener("click", function () {
    document.getElementById("edit-shipping").value = true;

    shipping_wrap.style.transition = "all 1s";
    shipping_form.style.transition = "all 1s";

    shipping_form_complete.value = 0;
    shipping_check_sign.style.display = "none";
    shipping_summary.style.display = "none";
    shipping_edit_button.style.display = "none";

    shipping_form.style.height = "auto";
    shipping_wrap.style.transform = "translateY(0%)";
});

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
    if (document.getElementById('terms-and-conditions-consent').value == "true") {
        document.getElementById('terms-and-conditions-consent').value = "false";
        document.getElementById('terms-and-conditions-input').value = null;
        document.getElementById('submit-payment').disabled = true;
    }
    else {
        document.getElementById('terms-and-conditions-consent').value = "true";
        document.getElementById('terms-and-conditions-input').value = "true";
        document.getElementById('submit-payment').disabled = false;
    }
});