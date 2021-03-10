var email_updated = document.getElementById("email-updated");
var email_updated_button = document.getElementById("email-updated-button");
var email_updated_text = document.getElementById("email-updated-text");
email_updated_button.disabled = true;

complete = function (xhr) {
    email_updated.style.display = "block";
    email_updated_button.disabled = false;
    email_updated_text.innerHTML = xhr.responseText;
};

email_updated_button.addEventListener("click", function () {
    location.replace("https://localhost:5002/account/logout");
});