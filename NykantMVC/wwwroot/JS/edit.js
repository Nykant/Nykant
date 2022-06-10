var edit_error = document.getElementById('edit-error');
var edit_check_sign = document.getElementById('edit-check-sign');
var edit_spinner = document.getElementById('edit-spinner');
var edit_text = document.getElementById('edit-text');

var edit_begin = function () {
    edit_error.style.display = 'none';
    edit_check_sign.style.display = 'none';
    edit_text.style.display = 'none';
    edit_spinner.style.display = 'block';
}

var edit_failure = function (response) {
    edit_spinner.style.display = 'none';
    edit_error.style.display = 'block';

    setTimeout(function () {
        edit_text.style.display = 'block';
        edit_error.style.display = 'none';
    }, 3000)
}

var edit_success = function (response) {
    edit_spinner.style.display = 'none';
    edit_check_sign.style.display = 'block';

    setTimeout(function () {
        edit_text.style.display = 'block';
        edit_check_sign.style.display = 'none';
    }, 3000)
};