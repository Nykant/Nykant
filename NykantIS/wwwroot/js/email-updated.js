var changeemail_error_div = document.getElementById("changeemail-error-div");
var changeemail_error_text = document.getElementById("changeemail-error-text");
var changeemail_success_div = document.getElementById("changeemail-success-div");
var changeemail_success_text = document.getElementById("changeemail-success-text");

update_success = function (xhr) {
    if (xhr == "inUse") {
        changeemail_success_div.style.display = "none";
        changeemail_error_div.style.display = "block";
        changeemail_error_text.innerHTML = "Denne email er allerede i brug af en anden konto.";
    }
    else if (xhr == "sameEmail") {
        changeemail_success_div.style.display = "none";
        changeemail_error_div.style.display = "block";
        changeemail_error_text.innerHTML = "Du kan ikke ændre til den samme email.";
    }
    else if (xhr == "emailUpdated") {
        changeemail_error_div.style.display = "none";
        changeemail_success_div.style.display = "block";
        changeemail_success_text.innerHTML = "Din email er blevet ændret.";
    }
    else if (xhr == "fail") {
        changeemail_success_div.style.display = "none";
        changeemail_error_div.style.display = "block";
        changeemail_error_text.innerHTML = "Der er sket en fejl. prøv igen.";
    }
};
