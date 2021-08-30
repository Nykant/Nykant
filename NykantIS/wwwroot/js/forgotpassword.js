var forgotpassword_success_div = document.getElementById("forgotpassword-success-div");
var forgotpassword_success_text = document.getElementById("forgotpassword-success-text");
var forgotpassword_error_div = document.getElementById("forgotpassword-error-div");
var forgotpassword_error_text = document.getElementById("forgotpassword-error-text");

forgotpassword_success = function (jsonObject) {
    if (jsonObject.text == "invalid") {
        forgotpassword_success_div.style.display = "none";
        forgotpassword_error_div.style.display = "block";
        forgotpassword_error_text.innerHTML = "modelstate er invalid.";
    }
    else if (jsonObject.text == "notExist") {
        forgotpassword_success_div.style.display = "none";
        forgotpassword_error_div.style.display = "block";
        forgotpassword_error_text.innerHTML = "Kan ikke indlæse brugeren med Id'et: " + jsonObject.userid;
    }
    else if (jsonObject.text == "success") {
        changepassword_error_div.style.display = "none";
        changepassword_success_div.style.display = "block";
        changepassword_success_text.innerHTML = "Dit password er blevet ændret.";
    }
    else if (jsonObject.text == "failed") {
        changepassword_success_div.style.display = "none";
        changepassword_error_div.style.display = "block";
        changepassword_error_text.innerHTML = "Der skete en fejl: " + jsonObject.errormessage;
    }
};
