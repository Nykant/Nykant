var slideshow = document.getElementById('slideshow');
var img, img2, infobox, header, info, productlink1, productlink2, productlink3, i, shelf, hanger, productlink1text, productlink1header, productlink1p, productlink2text, productlink2header, productlink2p, productlink3text, productlink3header, productlink3p;
i = 1;

/*document.getElementById('navbar').setAttribute("class", "navbar-transparent");*/

var updateSrc = function (number) {
    if (number == 1) {
        return '../images/Products/NYKANT_miljoe 1.png';
    }
    else if (number == 2) {
        return '../images/Products/NYKANT_miljoe 4.png';
    }
    else if (number == 3) {
        return '../images/Products/NYKANT_miljoe 5.png';
    }
}

infobox = document.createElement('div');
infobox.setAttribute('class', 'infobox');
header = document.createElement('h1');
header.textContent = 'Debut Kollektionen';
info = document.createElement('p');
info.textContent = 'Hermed udgiver vi vores første kollektion af møbler, lavet af egetræ, nordisk design og godt håndværk.';

var infobutton = document.createElement('a');
infobutton.setAttribute('href', '/Product/Index?searchString=Debut Kollektion')
var infobuttondiv = document.createElement('div');
infobuttondiv.setAttribute('class', 'button infobutton');
infobuttondiv.textContent = 'Se Alle';
infobutton.appendChild(infobuttondiv);
    
img = document.createElement('img');
img.setAttribute('src', updateSrc(i));
i++;
if (i > 3) { i = 1 }
img.setAttribute("class", "first-slide");

slideshow.appendChild(img);
slideshow.appendChild(infobox);
infobox.appendChild(header);
infobox.appendChild(info);
infobox.appendChild(infobutton);

setTimeout(function () {
    img.classList.add('img-grow');
}, 500);

img2 = document.createElement('img');
img2.setAttribute('src', updateSrc(i));
i++;
if (i > 3) { i = 1 }
img2.setAttribute("class", "second-slide");

slideshow.appendChild(img2);


setTimeout(function () {
    img.classList.remove('img-grow');
    img.setAttribute("class", "waiting-slide");
    img2.setAttribute('src', updateSrc(i));
    i++;
    if (i > 3) { i = 1 }
    img2.setAttribute("class", "current-slide");

    setTimeout(function () {
        img2.classList.add('img-grow');
    }, 500);

}, 10000);

var theInterval = setInterval(function () {
    img2.classList.remove('img-grow');
    img2.setAttribute("class", "waiting-slide");
    img.setAttribute('src', updateSrc(i));
    i++;
    if (i > 3) { i = 1 }
    img.setAttribute("class", "current-slide");

    setTimeout(function () {
        img.classList.add('img-grow');
    }, 500);

    setTimeout(function () {
        img.classList.remove('img-grow');
        img.setAttribute("class", "waiting-slide");
        img2.setAttribute('src', updateSrc(i));
        i++;
        if (i > 3) { i = 1 }
        img2.setAttribute("class", "current-slide");

        setTimeout(function () {
            img2.classList.add('img-grow');
        }, 500);

    }, 10000)
}, 20000);

window.onbeforeunload = function (e) {
    clearInterval(theInterval);
/*    document.getElementById('navbar').setAttribute("class", "navbar");*/
}

