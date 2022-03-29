

//var contents = document.getElementsByClassName("collapsible-content");
//var i, j;

//for (j = 0; j < contents.length; j++) {
//    var content = contents[j];
//    content.style.maxHeight = content.scrollHeight + "px";
//}

//var coll2 = document.getElementsByClassName("collapsible-button2");

//for (var i = 0; i < coll2.length; i++) {
//    coll2[i].addEventListener("click", function () {
//        this.classList.toggle("active");
//        var content = this.nextElementSibling;
//        if (content.style.maxHeight) {
//            content.style.maxHeight = null;
//        } else {
//            content.style.maxHeight = content.scrollHeight + "px";
//        }
//    });
//}

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
        gtag('event', 'conversion', {
            'send_to': 'AW-10853506642/8pSQCLHpq60DENK8rbco',
            'value': 1.0,
            'currency': 'DKK'
        });

        addToBag_spinner.style.display = 'none';
        addToBag_check_sign.style.display = 'block';

        $('#bagitem-added').css('display', 'block');
        $('#item-added-modal').css('display', 'block');
    }
};

$(document).mouseup(function (e) {
    if ($(e.target).closest("#bagitem-added").length === 0) {
        $('#bagitem-added').css('display', 'none');
        $('#item-added-modal').css('display', 'none');
    }
});


var sidestep_bodies = document.getElementById('sidestep-bodies').children;
var sidestep_headers = document.getElementById('sidestep-headers').children;

for (var i = 0; i < sidestep_headers.length; i++) {
    sidestep_headers[i].addEventListener('click', function (event) {
        for (var j = 0; j < sidestep_headers.length; j++) {
            sidestep_headers[j].removeAttribute('class');
            sidestep_bodies[j].removeAttribute('class');
        }
        event.target.setAttribute('class', 'active');
        var number = parseInt(event.target.getAttribute("data-number"));
        if (number == 3) {
            sidestep_bodies[number - 1].setAttribute('class', 'active text-center');
        }
        else {
            sidestep_bodies[number - 1].setAttribute('class', 'active');
        }
    });
}


var select = document.getElementById('length-select');
if (select != undefined) {
    select.addEventListener('change', function () {
        var opt = select.options[select.selectedIndex];
        var urlname = opt.getAttribute('data-product-urlname');
        document.getElementById('length-input').value = urlname;
        document.getElementById('length-form').submit();
    });
}

$("#product-counter-down").on('click', function () {
    var productcount = $('#product-counter-input').val();
    productcount = parseInt(productcount);
    if (productcount > 1) {
        productcount -= 1;
        $('#product-counter-input').val(productcount);
    }
});

$("#product-counter-up").on('click', function () {
    var productcount = $('#product-counter-input').val();
    productcount = parseInt(productcount);
    productcount += 1;
    $('#product-counter-input').val(productcount);
});



//$('#length-select').change(function () {

//    var selected = select.options
//    var productId = selectOption.
//});