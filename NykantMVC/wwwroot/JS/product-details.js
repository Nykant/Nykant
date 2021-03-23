item_added = function () {
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