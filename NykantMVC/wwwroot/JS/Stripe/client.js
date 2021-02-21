// Set your publishable key: remember to change this to your live publishable key in production
// See your keys here: https://dashboard.stripe.com/account/apikeys
var stripe = Stripe('pk_test_51Hyy3eKS99T7pxPWSbrIYqKDcyKomhVp3hrXymvg8cPkupAmEcbeEoV26ckeJF9GZnfKdvTeQwyKdnwO6uNrIaih001cWPBSI2');

document.querySelector(".button").disabled = true;

fetch("/paymentintent/createpaymentintent", {
    method: "POST",
    headers: {
        "Content-Type": "application/json"
    }
}).then(function (response) {
    if (response.status !== 200) {
        console.Log('fetch returned not ok' + response.status)
    }
    if (response.status === 200) {
        return response.json();
    }
}).then(function (data) {
    var elements = stripe.elements();

    var style = {
        base: {
            textAlign: "center",
            color: "white",
            fontFamily: 'Arial, sans-serif',
            fontSmoothing: "antialiased",
            fontSize: "25px",
            "::placeholder": {
                color: "#c1c1c1"
            },
            ":-webkit-autofill": {
                color: "#e39f48",
                backgroundColor: "#474747"
            }
        },
        invalid: {
            fontFamily: 'Arial, sans-serif',
            color: "#fa755a",
            iconColor: "#fa755a"
        },
    
    };

    var cardNumber = elements.create("cardNumber", { style: style });
    var cardExpiry = elements.create("cardExpiry", { style: style });
    var cardCvc = elements.create("cardCvc", { style: style });

    // Stripe injects an iframe into the DOM
    cardNumber.mount("#card-element-number");
    cardExpiry.mount("#card-element-expiry");
    cardCvc.mount("#card-element-cvc");
    cardNumber.on("change", function (event) {
        // Disable the Pay button if there are no card details in the Element
        document.querySelector(".button").disabled = event.empty;
        document.querySelector("#card-error").textContent = event.error ? event.error.message : "";
    });
    var form = document.getElementById("payment-form");
    form.addEventListener("submit", function (event) {
        event.preventDefault();
        // Complete payment when the submit button is clicked
        payWithCard(stripe, cardNumber, data.clientSecret);
    });
});

// Calls stripe.confirmCardPayment
// If the card requires authentication Stripe shows a pop-up modal to
// prompt the user to enter authentication details without leaving your page.
var payWithCard = function (stripe, card, clientSecret) {
    loading(true);
    fetch("/paymentintent/getcardinformation", {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    }).then(function (response) {
        return response.json();
    }).then(function (data) {
        stripe.confirmCardPayment(clientSecret, {
            receipt_email: data.email,
            payment_method: {
                card: card,
                billing_details: {
                    name: data.name,
                    address: {
                        line1: data.address,
                        city: data.city,
                        country: "DK",
                        postal_code: data.postal
                    },
                    email: data.email,
                    phone: data.phone,
                }
            }
        }).then(function (result) {
            if (result.error) {
                // Show error to your customer
                showError(result.error.message);
            } else {
                // The payment succeeded!
                orderComplete(result.paymentIntent.id);
            }
        });   
    }) 
};

/* ------- UI helpers ------- */
// Shows a success message when the payment is complete
var orderComplete = function (paymentIntentId) {
    fetch("/order/postorder", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(paymentIntentId)
    }).then(function () {
        location.replace("https://localhost:5002/checkout/success");
    })
};

// Show the customer the error from Stripe if their card fails to charge
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

// Show a spinner on payment submission
var loading = function (isLoading) {
    if (isLoading) {
        // Disable the button and show a spinner
        document.querySelector(".button").disabled = true;
        document.querySelector("#spinner").classList.remove("hidden");
        document.querySelector("#button-text").classList.add("hidden");
    } else {
        document.querySelector(".button").disabled = false;
        document.querySelector("#spinner").classList.add("hidden");
        document.querySelector("#button-text").classList.remove("hidden");
    }
};
