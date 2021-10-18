var slideshow = document.getElementById('slideshow');
var img, img2, c, d, e, f, g, l, i, j;
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
img.setAttribute("class", "current-slide");

slideshow.appendChild(img);

i++;

img2 = document.createElement('img');
img2.setAttribute('src', updateSrc(i));
img2.setAttribute("class", "waiting-slide");

slideshow.appendChild(img2);

i++;

setTimeout(function () {
    img.setAttribute("class", "waiting-slide");
    img2.setAttribute('src', updateSrc(i));
    img2.setAttribute("class", "current-slide");
    i++;

}, 5000)

var theInterval = setInterval(function () {
    img2.setAttribute("class", "waiting-slide");
    img.setAttribute('src', updateSrc(i));
    img.setAttribute("class", "current-slide");
    i++;

    if (i == 5) { i = 1 }
    setTimeout(function () {
        img.setAttribute("class", "waiting-slide");
        img2.setAttribute('src', updateSrc(i));
        img2.setAttribute("class", "current-slide");
        i++;

        if (i == 5) { i = 1 }
    }, 5000)
}, 10000);

window.onbeforeunload = function (e) {
    clearInterval(theInterval);
    document.getElementById('navbar').setAttribute("class", "navbar");
}

