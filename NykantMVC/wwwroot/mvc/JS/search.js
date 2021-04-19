
$('#search-form').on('submit', function () {
    loadingsearch(true);
});

searchcompleted = function () {
    loadingsearch(false);
};

var loadingsearch = function (isLoading) {
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
