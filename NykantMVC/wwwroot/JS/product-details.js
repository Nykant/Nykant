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

var coll2 = document.getElementsByClassName("collapsible-button2");
var i;

for (i = 0; i < coll2.length; i++) {
    coll2[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.maxHeight) {
            content.style.maxHeight = null;
        } else {
            content.style.maxHeight = content.scrollHeight + "px";
        }
    });
}

var select = document.getElementById('length-select');
select.addEventListener('change', function () {
    var opt = select.options[select.selectedIndex];
    var id = opt.getAttribute('data-product-id');
    document.getElementById('length-input').value = parseInt(id);
    document.getElementById('length-form').submit();
});


//$('#length-select').change(function () {

//    var selected = select.options
//    var productId = selectOption.
//});