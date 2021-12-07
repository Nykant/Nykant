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


function magnify(img, zoom) {
    var prevglasses = document.getElementsByClassName('img-magnifier-glass');
    for (var i = 0; i < prevglasses.length; i++) {
        prevglasses[i].remove();
    }
    var glass, w, h, bw;

    /* Create magnifier glass: */
    glass = document.createElement("DIV");
    glass.setAttribute("class", "img-magnifier-glass");

    /* Insert magnifier glass: */
    img.parentElement.insertBefore(glass, img);

    /* Set background properties for the magnifier glass: */
    glass.style.backgroundImage = "url('" + img.src + "')";
    glass.style.backgroundRepeat = "no-repeat";
    glass.style.backgroundSize = (img.width * zoom) + "px " + (img.height * zoom) + "px";
    bw = 3;
    w = glass.offsetWidth / 2;
    h = glass.offsetHeight / 2;

    /* Execute a function when someone moves the magnifier glass over the image: */
    glass.addEventListener("mousemove", moveMagnifier);
    img.addEventListener("mousemove", moveMagnifier);

    /*and also for touch screens:*/
    glass.addEventListener("touchmove", moveMagnifier);
    img.addEventListener("touchmove", moveMagnifier);
    function moveMagnifier(e) {
        var pos, x, y;
        /* Prevent any other actions that may occur when moving over the image */
        e.preventDefault();
        /* Get the cursor's x and y positions: */
        pos = getCursorPos(e);
        x = pos.x;
        y = pos.y;
        /* Prevent the magnifier glass from being positioned outside the image: */
        if (x > img.width - (w / zoom)) { x = img.width - (w / zoom); }
        if (x < w / zoom) { x = w / zoom; }
        if (y > img.height - (h / zoom)) { y = img.height - (h / zoom); }
        if (y < h / zoom) { y = h / zoom; }
        /* Set the position of the magnifier glass: */
        var style = window.getComputedStyle(img);
        style.marginLeft
        var text = 'translateX(' + style.marginLeft + ')'
        glass.style.left = (x - w) + "px";
        glass.style.top = (y - h) + "px";
        glass.style.transform = text;
        /* Display what the magnifier glass "sees": */
        glass.style.backgroundPosition = "-" + ((x * zoom) - w + bw) + "px -" + ((y * zoom) - h + bw) + "px";
    }

    function getCursorPos(e) {
        var a, x = 0, y = 0;
        e = e || window.event;
        /* Get the x and y positions of the image: */
        a = img.getBoundingClientRect();
        /* Calculate the cursor's x and y coordinates, relative to the image: */
        x = e.pageX - a.left;
        y = e.pageY - a.top;
        /* Consider any page scrolling: */
        x = x - window.pageXOffset;
        y = y - window.pageYOffset;
        return { x: x, y: y };
    }
}



// Magnifying glass

//var zoom = document.querySelector("#zoom");
//var zoomImg = document.querySelector("#zoom-img");
var product_slides = document.getElementsByClassName('product-slide');
//var enterTL = new TimelineMax({ paused: true });
//var timer = TweenLite.delayedCall(1, () => enterTL.reverse()).pause();
//var cx, cy, ratio;

//function init(img) {
//    zoomImg.src = img.src;
//    ratio = img.naturalWidth / img.width;
//    resize(img);

//    TweenLite.set(zoomImg, { xPercent: -50, yPercent: -50 });
//    TweenLite.set(zoom, { autoAlpha: 0, scale: 0, xPercent: -75, yPercent: -150 });

//    enterTL
//        .to(
//            img,
//            0.5,
//            { filter: "grayscale(1)", "-webkit-filter": "grayscale(1)" },
//            0
//        )
//        .to(zoom, 0.5, { autoAlpha: 1, scale: 1.5 }, 1);

//    window.addEventListener("resize", resize(img));
//    img.addEventListener("mouseleave", leaveAction);
//    img.addEventListener("mousemove", moveAction);
//}

//function leaveAction() {
//    enterTL.reverse();
//}

//function moveAction(e) {
//    enterTL.play();
//    timer.restart(true);
//    TweenLite.set(zoom, { x: e.x, y: e.y });
//    TweenLite.set(zoomImg, { x: (cx - e.x) * ratio, y: (cy - e.y) * ratio });
//}

//function resize(img) {
//    var rect = img.getBoundingClientRect();
//    cx = rect.left + rect.width / 2;
//    cy = rect.top + rect.height / 2;
//}

for (var i = 0; i < product_slides.length; i++) {
    var children = product_slides[i].children;
    var img = children[0];
    img.addEventListener('mouseover', function (event) {
        magnify(event.currentTarget, 4);
    });
}


// -------------------






//window.addEventListener("load", function () {
//    var pop = document.getElementById('pop');
//    var bigImg = document.getElementById('bigImg');
//    var close = document.getElementById('close-pop');

//    var product_slides = document.getElementsByClassName('product-slide');
//    for (var i = 0; i < product_slides.length; i++) {
//        var children = product_slides[i].children;
//        var img = children[0];
//        img.addEventListener('click', function (event) {
//            bigImg.src = event.currentTarget.src;
//            pop.style.display = 'flex';
//        });
//    }

//    pop.addEventListener('click', function () {
//        pop.style.display = 'none';
//    });

//    close.addEventListener('click', function () {
//        pop.style.display = 'none';
//    });
//});




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
