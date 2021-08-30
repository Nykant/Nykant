var changepassword_success_div = document.getElementById("changepassword-success-div");
var changepassword_success_text = document.getElementById("changepassword-success-text");
var changepassword_error_div = document.getElementById("changepassword-error-div");
var changepassword_error_text = document.getElementById("changepassword-error-text");

password_update_success = function (jsonObject) {
    if (jsonObject.text == "invalid") {
        changepassword_success_div.style.display = "none";
        changepassword_error_div.style.display = "block";
        changepassword_error_text.innerHTML = "modelstate er invalid.";
    }
    else if (jsonObject.text == "notExist") {
        changepassword_success_div.style.display = "none";
        changepassword_error_div.style.display = "block";
        changepassword_error_text.innerHTML = "Kan ikke indlæse brugeren med Id'et: " + jsonObject.userid;
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
