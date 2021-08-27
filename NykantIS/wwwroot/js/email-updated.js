var email_updated = document.getElementById("email-updated");
var email_updated_button = document.getElementById("email-updated-button");
var email_updated_text = document.getElementById("email-updated-text");
var changeemail_error_div = document.getElementById("changeemail-error-div");
var changeemail_error_text = document.getElementById("changeemail-error-text");
email_updated_button.disabled = true;

update_success = function (xhr) {
    if (xhr == "inUse") {
        changeemail_error_div.style.display = "block";
        changeemail_error_text.innerHTML = "Denne email er allerede i brug af en anden konto.";
    }
    else if (xhr == "sameEmail") {
        changeemail_error_div.style.display = "block";
        changeemail_error_text.innerHTML = "Du kan ikke ændre til den samme email.";
    }
    else if (xhr == "emailUpdated") {
        email_updated.style.display = "block";
        email_updated_button.disabled = false;
        email_updated_text.innerHTML = "Email er opdateret. En aktiverings email er blevet sendt til den nye email konto.";
    }
    else if (xhr == "fail") {
        changeemail_error_div.style.display = "block";
        changeemail_error_text.innerHTML = "Der er sket en fejl. prøv igen.";
    }
};

email_updated_button.addEventListener("click", function () {
    location.replace("https://localhost:5002/account/logout");
});
