
$('#search-form').on('submit', function () {
    loading(true);
});

searchcompleted = function () {
    loading(false);
};

var loading = function (isLoading) {
    if (isLoading) {
        document.querySelector("#searchspinner").classList.remove("hidden");
    }
    else {
        document.querySelector("#searchspinner").classList.add("hidden");
    }
};

$(document).mouseup(function (e) {
    if ($(e.target).closest("#search-container").length === 0 && $(e.target).closest("#search-button").length === 0 ) {
        $('#search-container').css('display', 'none');
    }
});
