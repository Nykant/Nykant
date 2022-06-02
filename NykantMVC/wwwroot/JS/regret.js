var regret_checksign = document.getElementById('regret-check-sign');
var regret_text = document.getElementById('regret-text');
var regret_button = document.getElementById('regret-button');
var regret_spinner = document.getElementById('regret-spinner');
var error_regret = document.getElementById('error-regret');

var regret_begin = function () {
    error_regret.style.display = 'none';
    regret_checksign.style.display = 'none';
    regret_text.style.display = 'none';
    regret_spinner.style.display = 'block';
}

var regret_succeed = function (response) {
    if (response == 'Error') {
        regret_spinner.style.display = 'none';
        regret_error.style.display = 'block';
        setTimeout(function () {
            regret_text.style.display = 'block';
            regret_error.style.display = 'none';
        }, 3000)
    }
    else {
        regret_spinner.style.display = 'none';
        regret_checksign.style.display = 'block';
    }
}

var regret_error = function (response) {
    regret_spinner.style.display = 'none';
    regret_error.style.display = 'block';
    setTimeout(function () {
        regret_text.style.display = 'block';
        regret_error.style.display = 'none';
    }, 3000)
}