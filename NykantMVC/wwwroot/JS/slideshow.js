var slideshow = document.getElementById('slideshow');
var img, img2, infobox, header, info, productlink1, productlink2, productlink3, i, shelf, hanger, productlink1text, productlink1header, productlink1p, productlink2text, productlink2header, productlink2p, productlink3text, productlink3header, productlink3p;
i = 1;

document.getElementById('navbar').setAttribute("class", "navbar-transparent");

var updateSrc = function (number) {
    if (number == 1) {
        productlink1 = document.createElement('a');
        productlink1.setAttribute('class', 'miljo-link table-1');
        productlink1.setAttribute('asp-controller', 'Product');
        productlink1.setAttribute('asp-action', 'Index');
        productlink1header = document.createElement('h1');
        productlink1header.textContent = 'Ingrid Bordet';
        productlink1text = document.createElement('div');
        productlink1text.setAttribute('class', 'miljo-link-text table-1-text');
        productlink1p = document.createElement('p');
        productlink1p.textContent = 'Simpelt skal der lægges tryk på ved dette enestående håndværk. passer godt til et lille skrivebord.';

        productlink1.addEventListener('mouseover', function () {
            productlink1text.style.display = 'block';
        });
        productlink1.addEventListener('mouseout', function () {
            productlink1text.style.display = 'none';
        });
        productlink1text.appendChild(productlink1header);
        productlink1text.appendChild(productlink1p);
        productlink1.appendChild(productlink1text);
        slideshow.appendChild(productlink1);

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

infobox = document.createElement('div');
infobox.setAttribute('class', 'infobox');
header = document.createElement('h1');
header.textContent = 'Jomfru Kollektionen';
info = document.createElement('p');
info.textContent = 'Hermed udgiver vi vores første kollektion af møbler, lavet af egetræ, nordisk design og godt håndværk.';

img = document.createElement('img');
img.setAttribute('src', updateSrc(i));
img.setAttribute("class", "first-slide");

slideshow.appendChild(img);
slideshow.appendChild(infobox);
infobox.appendChild(header);
infobox.appendChild(info);

setTimeout(function () {
    img.classList.add('img-grow');
}, 500);

i++;

img2 = document.createElement('img');
img2.setAttribute('src', updateSrc(i));
img2.setAttribute("class", "second-slide");

slideshow.appendChild(img2);

i++;

setTimeout(function () {
    img.classList.remove('img-grow');
    img.setAttribute("class", "waiting-slide");
    img2.setAttribute('src', updateSrc(i));
    img2.setAttribute("class", "current-slide");

    setTimeout(function () {
        img2.classList.add('img-grow');
    }, 500);

    i++;

}, 10000);

var theInterval = setInterval(function () {
    img2.classList.remove('img-grow');
    img2.setAttribute("class", "waiting-slide");
    img.setAttribute('src', updateSrc(i));
    img.setAttribute("class", "current-slide");

    setTimeout(function () {
        img.classList.add('img-grow');
    }, 500);

    i++;

    if (i == 5) { i = 1 }
    setTimeout(function () {
        img.classList.remove('img-grow');
        img.setAttribute("class", "waiting-slide");
        img2.setAttribute('src', updateSrc(i));
        img2.setAttribute("class", "current-slide");

        setTimeout(function () {
            img2.classList.add('img-grow');
        }, 500);

        i++;

        if (i == 5) { i = 1 }
    }, 10000)
}, 20000);

window.onbeforeunload = function (e) {
    clearInterval(theInterval);
    document.getElementById('navbar').setAttribute("class", "navbar");
}

