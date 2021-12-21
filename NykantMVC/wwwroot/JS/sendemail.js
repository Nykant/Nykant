var sendemail_checksign = document.getElementById('sendemail-check-sign');
var sendemail_text = document.getElementById('sendemail-text');
var sendemail_spinner = document.getElementById('sendemail-spinner');
var sendemail_error = document.getElementById('sendemail-error');

var sendemail_begin = function () {
    sendemail_error.style.display = 'none';
    sendemail_checksign.style.display = 'none';
    sendemail_text.style.display = 'none';
    sendemail_spinner.style.display = 'block';
}

var sendemail_complete = function (response) {
    sendemail_text.style.display = 'none';
    if (response.responseJSON == 'Error') {
        sendemail_spinner.style.display = 'none';
        sendemail_error.style.display = 'block';

        setTimeout(function () {
            sendemail_text.style.display = 'block';
            sendemail_error.style.display = 'none';
        }, 3000)
    }
    else {
        sendemail_spinner.style.display = 'none';
        sendemail_checksign.style.display = 'block';
    }
}