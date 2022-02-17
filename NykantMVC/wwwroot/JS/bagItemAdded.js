var addToBag_error = document.getElementById('addToBag-error');
var addToBag_check_sign = document.getElementById('addToBag-check-sign');
var addToBag_spinner = document.getElementById('addToBag-spinner');
var addToBag_text = document.getElementById('addToBag-text');

var addToBag_begin = function () {
    addToBag_error.style.display = 'none';
    addToBag_check_sign.style.display = 'none';
    addToBag_text.style.display = 'none';
    addToBag_spinner.style.display = 'block';
}

var addToBag_failure = function (response) {
    addToBag_spinner.style.display = 'none';
    addToBag_error.style.display = 'block';

    setTimeout(function () {
        addToBag_text.style.display = 'block';
        addToBag_error.style.display = 'none';
    }, 3000)
}

item_added = function (response) {
    if (response == 'Error') {
        addToBag_spinner.style.display = 'none';
        addToBag_error.style.display = 'block';

        setTimeout(function () {
            addToBag_text.style.display = 'block';
            addToBag_error.style.display = 'none';
        }, 3000)
    }
    else {
        addToBag_spinner.style.display = 'none';
        addToBag_check_sign.style.display = 'block';
    }

    $('#bagitem-added').css('display', 'block');
    $('#item-added-modal').css('display', 'block');
};

$('#bagitem-added-close').on('click', function () {
    $('#bagitem-added').css('display', 'none');
    $('#item-added-modal').css('display', 'none');
});

$(document).mouseup(function (e) {
    if ($(e.target).closest("#bagitem-added").length === 0) {
        $('#bagitem-added').css('display', 'none');
        $('#item-added-modal').css('display', 'none');
    }
});

