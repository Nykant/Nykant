var onlyEssential_error = document.getElementById('onlyEssential-error');
var onlyEssential_check_sign = document.getElementById('onlyEssential-check-sign');
var onlyEssential_spinner = document.getElementById('onlyEssential-spinner');
var onlyEssential_text = document.getElementById('onlyEssential-text');

var allowAll_error = document.getElementById('allowAll-error');
var allowAll_check_sign = document.getElementById('allowAll-check-sign');
var allowAll_spinner = document.getElementById('allowAll-spinner');
var allowAll_text = document.getElementById('allowAll-text');

var onlyEssential_begin = function () {
    allowAll_error.style.display = 'none';
    allowAll_check_sign.style.display = 'none';
    allowAll_spinner.style.display = 'none';
    allowAll_text.style.display = 'block';

    onlyEssential_error.style.display = 'none';
    onlyEssential_check_sign.style.display = 'none';
    onlyEssential_text.style.display = 'none';
    onlyEssential_spinner.style.display = 'block';
}

var onlyEssential_succeed = function (response) {
    onlyEssential_spinner.style.display = 'none';
    onlyEssential_check_sign.style.display = 'block';

}

var onlyEssential_failure = function (response) {
    onlyEssential_spinner.style.display = 'none';
    onlyEssential_error.style.display = 'block';

    setTimeout(function () {
        onlyEssential_text.style.display = 'block';
        onlyEssential_error.style.display = 'none';
    }, 3000)
}

var allowAll_begin = function () {
    onlyEssential_error.style.display = 'none';
    onlyEssential_check_sign.style.display = 'none';
    onlyEssential_spinner.style.display = 'none';
    onlyEssential_text.style.display = 'block';

    allowAll_error.style.display = 'none';
    allowAll_check_sign.style.display = 'none';
    allowAll_text.style.display = 'none';
    allowAll_spinner.style.display = 'block';
}

var allowAll_succeed = function (response) {
    allowAll_spinner.style.display = 'none';
    allowAll_check_sign.style.display = 'block';

}

var allowAll_failure = function (response) {
    allowAll_spinner.style.display = 'none';
    allowAll_error.style.display = 'block';

    setTimeout(function () {
        allowAll_text.style.display = 'block';
        allowAll_error.style.display = 'none';
    }, 3000)
}
