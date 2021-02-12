// Set your publishable key: remember to change this to your live publishable key in production
// See your keys here: https://dashboard.stripe.com/account/apikeys
var stripe = Stripe('pk_test_51Hyy3eKS99T7pxPWSbrIYqKDcyKomhVp3hrXymvg8cPkupAmEcbeEoV26ckeJF9GZnfKdvTeQwyKdnwO6uNrIaih001cWPBSI2');
// Set up Stripe.js and Elements to use in checkout form
var elements = stripe.elements();

var style = {
    base: {
        color: "",
    }
};

var cardElement = elements.create("card", { style: style });
cardElement.mount("#card-element");

cardElement.on("change", function (event) {
    var displayError = document.getElementById("card-errors");
    if (event.error) {
        displayError.textContent = event.error.message;
    } else {
        displayError.textContent = '';
    }
});

var secret = document.getElementById("clientSecret").value;
var form = document.getElementById("payment-form");
var email = document.getElementById("email-input").value;

form.addEventListener("submit", function (ev) {
    stripe.confirmCardPayment(secret, {
        payment_method: {
            card: cardElement,
            billing_details: {
                name: "Jenny Rosen"
            }
        }
    }).then(function (result) {
        if (result.error) {
            ev.preventDefault();
            // Show error to your customer (e.g., insufficient funds)
            alert("payment failed")
        } else {
            // The payment has been processed!
            if (result.paymentIntent.status === "succeeded") {
                // Show a success message to your customer
                //alert("payment succeeded")
                var url = "https://localhost:5002/checkout/paymentsuccess/" + email;
                window.location.replace(url)
                // There's a risk of the customer closing the window before callback
                // execution. Set up a webhook or plugin to listen for the
                // payment_intent.succeeded event that handles any business critical
                // post-payment actions.
            }
        }
    });
});