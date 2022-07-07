// Set your publishable key: remember to change this to your live publishable key in production

/*const { ajax } = require("jquery");*/

// See your keys here: https://dashboard.stripe.com/account/apikeys
var stripePKKey = document.getElementById('stripe-key').getAttribute('data-stripePKKey');
var stripe = Stripe(stripePKKey);
var elements = stripe.elements();
var url = document.getElementById('stage').dataset.url;

var style = {
    base: {
        backgroundColor: "#F7F5F2",
        textAlign: "left",
        color: "#777069",
        fontFamily: 'Lato, sans-serif',
        fontSmoothing: "antialiased",
        fontSize: "25px",
        "::placeholder": {
            color: "#777069"
        },
        ":-webkit-autofill": {
            color: "#777069",
            backgroundColor: "#F7F5F2"
        }
    },
    invalid: {
        fontFamily: 'Lato, sans-serif',
        color: "orange",
        backgroundColor: "#F7F5F2",
        iconColor: "#fa755a"
    }
    //complete: {
    //    backgroundColor: "#F7F5F2",
    //    color: "#8cffa4"
    //},
    //webkitAutoFill: {
    //    backgroundColor: "#F7F5F2"
    //}
};

var cardNumber = elements.create("cardNumber", { style: style });
var cardExpiry = elements.create("cardExpiry", { style: style });
var cardCvc = elements.create("cardCvc", { style: style });

// Stripe injects an iframe into the DOM
cardNumber.mount("#card-element-number");
cardExpiry.mount("#card-element-expiry");
cardCvc.mount("#card-element-cvc");

var terms_and_conditions = document.getElementById('terms-and-conditions-consent');
var form = document.getElementById("payment-form");
form.addEventListener("submit", function (event) {
    gtag('event', 'begin-purchase');
    event.preventDefault();
    if (!backbuttonclicked) {
        loading(true);
        if (terms_and_conditions.checked == false) {
            showError("Du skal acceptere vores handelsbetingelser før du kan gennemføre betalingen.");
        }
        if (document.getElementById("customer-form-complete").value == 0) {
            showError("Du skal udfylde både kunde oplysninger og leveringsmetode formularerne før du kan færdiggøre ordren");
        }
        else {
            $.ajax({
                type: "POST",
                url: '/Payment/PostConsent',
                data: AddAntiforgeryToken({
                    name: document.getElementById('customer-firstname-summary').textContent,
                    email: document.getElementById('customer-email-summary').textContent
                })
            }).then(function () {
                stripe.createPaymentMethod({
                    type: 'card',
                    card: cardNumber,
                    billing_details: {
                        name: document.getElementById('customer-firstname-summary').textContent,
                        email: document.getElementById('customer-email-summary').textContent
                        //phone: document.getElementById('customer-phone-summary').textContent,
                        //address: {
                        //    country: document.getElementById('customer-country-summary').textContent,
                        //    postal_code: document.getElementById('customer-postal-summary').textContent,
                        //    city: document.getElementById('customer-city-summary').textContent,
                        //    line1: document.getElementById('customer-address-summary').textContent
                        //}
                    }
                }).then(stripePaymentMethodHandler)
            });
        }
    }
});

function stripePaymentMethodHandler(result) {
    if (result.error) {
        showError(result.error)
    } else {
        // Otherwise send paymentMethod.id to your server (see Step 4)
        $.ajax({
            type: "POST",
            url: '/Payment/Payment',
            data: AddAntiforgeryToken ({
                paymentMethodId: result.paymentMethod.id
            })
        }).then(function (result) {
            // Handle server response (see Step 4)
            handleServerResponse(result);
        });
    }
}

function handleServerResponse(response) {
    if (response.error) {
        showError(response.error);
    } else if (response.requires_action) {
        // Use Stripe.js to handle required card action
        stripe.handleCardAction(
            response.payment_intent_client_secret
        ).then(handleStripeJsResult);
    } else {
        orderComplete(response.intentId);
    }
}

function handleStripeJsResult(result) {
    if (result.error) {
        showError(result.error)
    } else {
        // The card action has been handled
        // The PaymentIntent can be confirmed again on the server
        $.ajax({
            url: '/payment/confirmpayment',
            type: 'POST',
            data: AddAntiforgeryToken({
                paymentIntentId: result.paymentIntent.id
            })
        }).then(handleServerResponse);
    }
}

/* Show the customer the error from Stripe if their card fails to charge*/
var showError = function (errorMsgText) {
    var msg;
    if (errorMsgText.message != undefined) {
        msg = errorMsgText.message;
    }
    else if (errorMsgText.error != undefined) {
        msg = errorMsgText.error;
    }
    else {
        msg = errorMsgText;
    }
    var error = 'purchase-error: ' + msg;
    Log(error);
    loading(false);
    $('#checkout-modal').css('display', 'block');
    document.getElementById('checkout-error').textContent = msg;
    gtag('event', error);
};

var orderComplete = function (paymentIntentId) {
    try {
        gtag('event', 'purchase-complete');

        gtag('event', 'conversion', {
            'send_to': 'AW-10853506642/iWIVCLCt460DENK8rbco',
            'value': 1.0,
            'currency': 'DKK',
            'transaction_id': ''
        });
    }
    catch (err) {

    }
    finally {
        $.ajax({
            url: '/order/postorder',
            type: 'POST',
            data: AddAntiforgeryToken({
                paymentIntentId: paymentIntentId
            })
        }).then(function (result) {
            if (result.ok) {
                var urlstring = url + "/Bestilling-Gennemført";
                location.replace(urlstring);
            }
            else {
                showError(result.error);
            }
        })
    }
};

var loading = function (isLoading) {
    if (isLoading) {
        document.querySelector("#paymentspinner").classList.remove("hidden");
        document.getElementById("button-text").classList.add("hidden");
    }
    else {
        document.querySelector("#paymentspinner").classList.add("hidden");
        document.getElementById("button-text").classList.remove("hidden");
    }
};