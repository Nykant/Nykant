

register_complete = function () {
    $('#register-complete').css('display', 'block');
    $('#register-modal').css('display', 'block');
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