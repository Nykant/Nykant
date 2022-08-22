
$('#nav-burger').on('click', function () {
    var x = document.getElementById("nav-links");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
    }
});

$('#burger-close').on('click', function () {
    $('#nav-links').css('display', 'none');
});

$('#product-link').hover(function () {
    $('#navbar-product-filter').css('display', 'block');
});

$('#navbar').mouseleave(function () {
    $('#navbar-product-filter').css('display', 'none');
});

var newsletter_checksign = document.getElementById('newsletter-check-sign');
var newsletter_text = document.getElementById('newsletter-text');
var button = document.getElementById('newsletter-button');
var spinner = document.getElementById('newsletter-spinner');
var newsletter_error = document.getElementById('newsletter-error');

var newssub_begin = function () {
    newsletter_error.style.display = 'none';
    newsletter_checksign.style.display = 'none';
    newsletter_text.style.display = 'none';
    spinner.style.display = 'block';
}

var newssub_succeed = function (response) {
    if (response == 'Error') {
        spinner.style.display = 'none';
        newsletter_error.style.display = 'block';

        setTimeout(function () {
            newsletter_text.style.display = 'block';
            newsletter_error.style.display = 'none';
        }, 3000)
    }
    else {
        spinner.style.display = 'none';
        newsletter_checksign.style.display = 'block';
    }

}

var newssub_error = function (response) {
    spinner.style.display = 'none';
    newsletter_error.style.display = 'block';

    setTimeout(function () {
        newsletter_text.style.display = 'block';
        newsletter_error.style.display = 'none';
    }, 3000)
}





window.noop = function ()
{ return null; };

$('#search-button').on('click', function () {
    if ($('#search-container').css('display') == 'block') {
        $('#search-container').css('display', 'none');
    }
    else {
        $('#search-container').css('display', 'block');
    }
});
