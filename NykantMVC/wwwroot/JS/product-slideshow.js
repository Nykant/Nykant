var product_theInterval = undefined;
var product_slidebuttons = document.getElementById('product-slide-buttons').children;
var product_slidecontainer = document.getElementById('product-slide-container');
var product_slideshow = document.getElementById('product-slideshow');
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
            bigImg.src = event.currentTarget.src;
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




//function imageZoom(img, result) {
//    var lens, cx, cy;
//    /*create lens:*/
//    lens = document.createElement("DIV");
//    lens.setAttribute("class", "img-zoom-lens");
//    /*insert lens:*/
//    img.parentElement.insertBefore(lens, img);
//    /*calculate the ratio between result DIV and lens:*/
//    cx = result.offsetWidth / lens.offsetWidth;
//    cy = result.offsetHeight / lens.offsetHeight;
//    /*set background properties for the result DIV:*/
//    result.style.backgroundImage = "url('" + img.src + "')";
//    result.style.backgroundSize = (img.width * cx) + "px " + (img.height * cy) + "px";
//    /*execute a function when someone moves the cursor over the image, or the lens:*/
//    lens.addEventListener("mousemove", moveLens);
//    img.addEventListener("mousemove", moveLens);
//    /*and also for touch screens:*/
//    lens.addEventListener("touchmove", moveLens);
//    img.addEventListener("touchmove", moveLens);
//    function moveLens(e) {
//        var pos, x, y;
//        /*prevent any other actions that may occur when moving over the image:*/
//        e.preventDefault();
//        /*get the cursor's x and y positions:*/
//        pos = getCursorPos(e);
//        /*calculate the position of the lens:*/
//        x = pos.x - (lens.offsetWidth / 2);
//        y = pos.y - (lens.offsetHeight / 2);
//        /*prevent the lens from being positioned outside the image:*/
//        if (x > img.width - lens.offsetWidth) { x = img.width - lens.offsetWidth; }
//        if (x < 0) { x = 0; }
//        if (y > img.height - lens.offsetHeight) { y = img.height - lens.offsetHeight; }
//        if (y < 0) { y = 0; }
//        /*set the position of the lens:*/
//        lens.style.left = x + "px";
//        lens.style.top = y + "px";
//        /*display what the lens "sees":*/
//        result.style.backgroundPosition = "-" + (x * cx) + "px -" + (y * cy) + "px";
//    }
//    function getCursorPos(e) {
//        var a, x = 0, y = 0;
//        e = e || window.event;
//        /*get the x and y positions of the image:*/
//        a = img.getBoundingClientRect();
//        /*calculate the cursor's x and y coordinates, relative to the image:*/
//        x = e.pageX - a.left;
//        y = e.pageY - a.top;
//        /*consider any page scrolling:*/
//        x = x - window.pageXOffset;
//        y = y - window.pageYOffset;
//        return { x: x, y: y };
//    }
//}





//$(document).ready(function () {
//    product_theInterval = setInterval(function () {
//        product_slidebuttons[product_slidenumber].click();
//        product_slidenumber++;
//        if (product_slidenumber > 6) {
//            product_slidenumber = 0;
//        }
//    }, 3000)
//});

//window.onbeforeunload = function (e) {
//    clearInterval(product_theInterval);
//}
