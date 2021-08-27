

register_complete = function (result) {
    if (result == "success") {
        $('#register-complete').css('display', 'block');
        $('#register-modal').css('display', 'block');
    }
    else if (result == "unknownError") {
        $('#register-error-div').css('display', 'block');
        $('#register-error-text').html("der skete en fejl, prøv igen.");
    }
    else if (result == "userExist") {
        $('#register-error-div').css('display', 'block');
        $('#register-error-text').html("en bruger med denne email findes allerede.");
    }
    else if (result == "emailError") {
        $('#register-error-div').css('display', 'block');
        $('#register-error-text').html("der skete en fejl da vi skulle sende en aktiverings email :(. hvis du skriver en besked til mail@nykant.dk, så kan vi aktivere den.");
    }
    else if (result.succeeded == false) {
        $('#register-error-div').css('display', 'block');
        $('#register-error-text').html("der skete en fejl: " + result.errors[0]);
    }
};


$('#register-complete-close').on('click', function () {
    $('#register-complete').css('display', 'none');
    $('#register-modal').css('display', 'none');
});


$('#privacy-policy-consent').on('click', function () {
    if (document.getElementById('privacy-policy-consent').value == "true") {
        document.getElementById('privacy-policy-consent').value = "false";
        document.getElementById('privacy-policy-input').value = null;
        document.getElementById('register-button').disabled = true;
    }
    else {
        document.getElementById('privacy-policy-consent').value = "true";
        document.getElementById('privacy-policy-input').value = "true";
        document.getElementById('register-button').disabled = false;
    }
});