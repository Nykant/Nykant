var theInterval = undefined;
var slidebuttons = document.getElementById('slide-buttons').children;
var slidecontainer = document.getElementById('slide-container');
var aboutus = document.getElementById('about-us');
var slideshow = document.getElementById('slideshow');
var slidenumber = 0;
slidecontainer.style.left = '-0%';

var startInterval = function () {
    theInterval = setInterval(function () {
        slidenumber++;
        if (slidenumber > 3) {
            slidenumber = 0;
        }
        slidebuttons[slidenumber].click();
    }, 5000)
}

$(document).ready(function () {
    startInterval();

    for (var i = 0; i < slidebuttons.length; i++) {
        if (i == 0) {
            slidebuttons[i].addEventListener('click', function () {
                clearInterval(theInterval);
                slidecontainer.style.left = '-0%';
                slidenumber = 0;
                startInterval();
            });
        }
        else if (i == 1) {
            slidebuttons[i].addEventListener('click', function () {
                clearInterval(theInterval);
                slidecontainer.style.left = '-100%';
                slidenumber = 1;
                startInterval();
            });
        }
        else if (i == 2) {
            slidebuttons[i].addEventListener('click', function () {
                clearInterval(theInterval);
                slidecontainer.style.left = '-200%';
                slidenumber = 2;
                startInterval();
            });
        }
        else if (i == 3) {
            slidebuttons[i].addEventListener('click', function () {
                clearInterval(theInterval);
                slidecontainer.style.left = '-300%';
                slidenumber = 3;
                startInterval();
            });
        }
    }

    slideshow.addEventListener('swiped-right', function () {
        if (slidenumber > 0) {
            slidenumber--;
            slidebuttons[slidenumber].click();
        }
        else {
            slidenumber = 3;
            slidebuttons[slidenumber].click();
        }
    });

    slideshow.addEventListener('swiped-left', function () {
        if (slidenumber < slidebuttons.length - 1) {
            slidenumber++;
            slidebuttons[slidenumber].click();
        }
        else {
            slidenumber = 0;
            slidebuttons[slidenumber].click();
        }
    });

    $('#slideshow-next').click(function () {
        if (slidenumber < slidebuttons.length - 1) {
            slidenumber++;
            slidebuttons[slidenumber].click();
        }
        else {
            slidenumber = 0;
            slidebuttons[slidenumber].click();
        }
    });

    $('#slideshow-prev').click(function () {
        if (slidenumber > 0) {
            slidenumber--;
            slidebuttons[slidenumber].click();
        }
        else {
            slidenumber = 3;
            slidebuttons[slidenumber].click();
        }
    });

});


function CategoryClick() {
    gtag('event', 'frontpage-category-click');
}

function AboutClick() {
    gtag('event', 'frontpage-about-click');
}

function DiscountClick() {
    gtag('event', 'frontpage-discount-click');
}

function VideoClick() {
    gtag('event', 'frontpage-video-click');
}

function FavoriteClick() {
    gtag('event', 'frontpage-favorite-click');
}