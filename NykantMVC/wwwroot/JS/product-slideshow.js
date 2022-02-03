var product_theInterval = undefined;
var product_slidebuttons = document.getElementById('product-slide-buttons').children;
var product_slidecontainer = document.getElementById('product-slide-container');
var product_slideshow = document.getElementById('product-slideshow');
var product_slides = document.getElementsByClassName('product-slide');
var product_slidenumber = 0;
product_slidecontainer.style.left = '-0%';

for (var i = 0; i < product_slidebuttons.length; i++) {
    if (i == 0) {
        product_slidebuttons[i].addEventListener('click', function () {
            product_slidecontainer.style.left = '-0%';
            product_slidenumber = 0;

        });
    }
    else if (i == 1) {
        product_slidebuttons[i].addEventListener('click', function () {

            product_slidecontainer.style.left = '-100%';
            product_slidenumber = 1;

        });
    }
    else if (i == 2) {
        product_slidebuttons[i].addEventListener('click', function () {

            product_slidecontainer.style.left = '-200%';
            product_slidenumber = 2;

        });
    }
    else if (i == 3) {
        product_slidebuttons[i].addEventListener('click', function () {

            product_slidecontainer.style.left = '-300%';
            product_slidenumber = 3;

        });
    }
    else if (i == 4) {
        product_slidebuttons[i].addEventListener('click', function () {

            product_slidecontainer.style.left = '-400%';
            product_slidenumber = 4;

        });
    }
    else if (i == 5) {
        product_slidebuttons[i].addEventListener('click', function () {

            product_slidecontainer.style.left = '-500%';
            product_slidenumber = 5;

        });
    }
    else if (i == 6) {
        product_slidebuttons[i].addEventListener('click', function () {

            product_slidecontainer.style.left = '-600%';
            product_slidenumber = 6;

        });
    }
}

product_slideshow.addEventListener('swiped-right', function () {
    if (product_slidenumber != 0) {
        product_slidenumber--;
        product_slidebuttons[product_slidenumber].click();
    }
});

product_slideshow.addEventListener('swiped-left', function () {
    if (product_slidenumber != 6) {
        product_slidenumber++;
        product_slidebuttons[product_slidenumber].click();
    }
});

window.addEventListener("load", function () {
    var pop = document.getElementById('pop');
    var bigImg = document.getElementById('bigImg');
    var close = document.getElementById('close-pop');

    var product_slides = document.getElementsByClassName('product-slide');
    for (var i = 0; i < product_slides.length; i++) {
        var children = product_slides[i].children;
        var img = children[0];
        img.addEventListener('click', function (event) {
            bigImg.src = event.currentTarget.getAttribute("data-fullscreensrc");
            pop.style.display = 'flex';
        });
    }

    pop.addEventListener('click', function () {
        pop.style.display = 'none';
    });

    close.addEventListener('click', function () {
        pop.style.display = 'none';
    });
});


