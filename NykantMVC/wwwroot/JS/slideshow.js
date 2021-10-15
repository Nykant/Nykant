var slideshow = document.getElementById('slideshow');
var img, c, d, e, f, g, l, i, j;
i = 1;

document.getElementById('navbar').setAttribute("class", "navbar-transparent");

var updateSrc = function (number) {
    if (number == 1) {
        return '../images/Products/NYKANT_miljoe 1_varient.png';
    }
    else if (number == 2) {
        return '../images/Products/NYKANT_miljoe 3.png';
    }
    else if (number == 3) {
        return '../images/Products/NYKANT_miljoe 4.png';
    }
    else if (number == 4) {
        return '../images/Products/NYKANT_miljoe 5.png';
    }
}

img = document.createElement('img');
img.setAttribute('src', updateSrc(i));
img.setAttribute("class", "slide-out");
slideshow.appendChild(img);

i++;

setTimeout(function () {
    img.setAttribute('src', updateSrc(i));
    img.setAttribute("class", "slide-in");
    i++;

}, 10000)

var theInterval = setInterval(function () {
    img.setAttribute('src', updateSrc(i));
    img.setAttribute("class", "slide-out");
    i++;

    if (i == 5) { i = 1 }
    setTimeout(function () {
        img.setAttribute('src', updateSrc(i));
        img.setAttribute("class", "slide-in");
        i++;

        if (i == 5) { i = 1 }
    }, 10000)
}, 20000);

window.onbeforeunload = function (e) {
    clearInterval(theInterval);
    document.getElementById('navbar').setAttribute("class", "navbar");
}

