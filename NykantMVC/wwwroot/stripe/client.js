// Set your publishable key: remember to change this to your live publishable key in production
// See your keys here: https://dashboard.stripe.com/account/apikeys
var stripe = Stripe('pk_test_51Hyy3eKS99T7pxPWSbrIYqKDcyKomhVp3hrXymvg8cPkupAmEcbeEoV26ckeJF9GZnfKdvTeQwyKdnwO6uNrIaih001cWPBSI2');
var elements = stripe.elements();

var style = {
    base: {
        backgroundColor: "transparent",
        textAlign: "left",
        color: "black",
        fontFamily: 'Lato, sans-serif',
        fontSmoothing: "antialiased",
        fontSize: "25px",
        "::placeholder": {
            color: "grey"
        },
        ":-webkit-autofill": {
            color: "black",
            backgroundColor: "transparent"
        }
    },
    invalid: {
        fontFamily: 'Lato, sans-serif',
        color: "orange",
        backgroundColor: "transparent",
        iconColor: "#fa755a"
    },
    complete: {
        backgroundColor: "transparent",
        color: "#8cffa4"
    },
    webkitAutoFill: {
        backgroundColor: "transparent"
    }
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
    event.preventDefault();
    loading(true);
    if (terms_and_conditions.checked == false) {
        showError("Du skal acceptere vores handelsbetingelser før du kan gennemføre betalingen.");
    }
    if (document.getElementById("shipping-form-complete").value == 0 || document.getElementById("customer-form-complete").value == 0) {
        showError("Du skal udfylde både kunde oplysninger og leveringsmetode formularerne før du kan færdiggøre ordren");
    }
    else {
        stripe.createPaymentMethod({
            type: 'card',
            card: cardNumber,
            billing_details: {
                name: document.getElementById('billing-name').value
            }
        }).then(stripePaymentMethodHandler)
    }
});

function stripePaymentMethodHandler(result) {
    if (result.error) {
        showError(result.error.message)
    } else {
        // Otherwise send paymentMethod.id to your server (see Step 4)
        fetch('/payment/payment', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(result.paymentMethod.id)
        }).then(function (result) {
            // Handle server response (see Step 4)
            result.json().then(function (json) {
                handleServerResponse(json);
            })
        });
    }
}

function handleServerResponse(response) {
    if (response.error) {
        showError(response.error.message);
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
        showError(result.error.message)
    } else {
        // The card action has been handled
        // The PaymentIntent can be confirmed again on the server
        fetch('/payment/confirmpayment', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(result.paymentIntent.id)
        }).then(function (confirmResult) {
            return confirmResult.json();
        }).then(handleServerResponse);
    }
}

/* Show the customer the error from Stripe if their card fails to charge*/
var showError = function (errorMsgText) {
    loading(false);
    document.getElementById("payment-error").style.display = "block";
    var errorMsg = document.querySelector("#card-error");
    errorMsg.textContent = errorMsgText;
    setTimeout(function () {
        errorMsg.textContent = "";
        document.getElementById("payment-error").style.display = "none";
    }, 10000);
};

var orderComplete = function (paymentIntentId) {
    fetch("/order/postorder", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(paymentIntentId)
    }).then(function (result) {
        if (result.ok) {
            location.replace("https://localhost:5002/checkout/success")
        }
    })
};

var loading = function (isLoading) {
    if (isLoading) {
        document.querySelector("#paymentspinner").classList.remove("hidden");
        document.getElementById("button-text").classList.remove("hidden");
    }
    else {
        document.querySelector("#paymentspinner").classList.add("hidden");
        document.getElementById("button-text").classList.add("hidden");
    }
};