var createinvoice_error = document.getElementById('edit-error');
var createinvoice_check_sign = document.getElementById('edit-check-sign');
var createinvoice_spinner = document.getElementById('edit-spinner');
var createinvoice_text = document.getElementById('edit-text');

var edit_begin = function () {
    createinvoice_error.style.display = 'none';
    createinvoice_check_sign.style.display = 'none';
    createinvoice_text.style.display = 'none';
    createinvoice_spinner.style.display = 'block';
}

var edit_failure = function (response) {
    createinvoice_spinner.style.display = 'none';
    createinvoice_error.style.display = 'block';

    setTimeout(function () {
        createinvoice_text.style.display = 'block';
        createinvoice_error.style.display = 'none';
    }, 3000)
}

var edit_success = function (response) {
    createinvoice_spinner.style.display = 'none';
    createinvoice_check_sign.style.display = 'block';

    setTimeout(function () {
        createinvoice_text.style.display = 'block';
        createinvoice_check_sign.style.display = 'none';
    }, 3000)
};