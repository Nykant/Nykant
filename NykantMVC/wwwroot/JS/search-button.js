$('#search-button').on('click', function () {
    if ($('#search-container').css('display') == 'block') {
        $('#search-container').css('display', 'none');
    }
    else {
        $('#search-container').css('display', 'block');
    }
});
