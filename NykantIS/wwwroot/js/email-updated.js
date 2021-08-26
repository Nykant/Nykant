var email_updated = document.getElementById("email-updated");
var email_updated_button = document.getElementById("email-updated-button");
var email_updated_text = document.getElementById("email-updated-text");
var email_updated_error = document.getElementById("email-updated-error");
var email_updated_error_button = document.getElementById("email-updated-error-button");
var email_updated_text_error = document.getElementById("email-updated-text-error");
email_updated_button.disabled = true;
email_updated_error_button.disabled = true;

update_success = function (xhr) {
    if (xhr == "inUse") {
        email_updated_error.style.display = "block";
        email_updated_error_button.disabled = false;
        email_updated_text_error.innerHTML = "Denne email er allerede i brug af en anden konto.";
    }
    else if (xhr == "sameEmail") {
        email_updated_error.style.display = "block";
        email_updated_error_button.disabled = false;
        email_updated_text_error.innerHTML = "Du kan ikke ændre til den samme email.";
    }
    else if (xhr == "emailUpdated") {
        email_updated.style.display = "block";
        email_updated_button.disabled = false;
        email_updated_text.innerHTML = "Email er opdateret. En aktiverings email er blevet sendt til den nye email konto.";
    }
    else if (xhr == "fail") {
        email_updated_error.style.display = "block";
        email_updated_error_button.disabled = false;
        email_updated_text_error.innerHTML = "Der er sket en fejl. prøv igen.";
    }
};

email_updated_button.addEventListener("click", function () {
    location.replace("https://localhost:5002/account/logout");
});

email_updated_error_button.addEventListener("click", function () {
    email_updated_error.style.display = "none";
    email_updated_error_button.disabled = true;
});