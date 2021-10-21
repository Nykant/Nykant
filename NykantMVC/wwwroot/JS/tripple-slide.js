var slides = document.getElementById('tripple-slider').children;
var forwardbutton = document.getElementById('forward-button');
var backbutton = document.getElementById('back-button');

var position = 0;
backbutton.disabled = true;

forwardbutton.addEventListener('click', function (e) {
    hideall(slides);
    if (backbutton.disabled) {
        backbutton.disabled = false;
    }
    if (position < 10) {
        slides[position].style.display = 'block';
        slides[position + 1].style.display = 'block';
        slides[position + 2].style.display = 'block';
        position = position + 3;
        if (position == 4) {
            backbutton.disabled = true;
        }
    }
    else {
        forwardbutton.disabled = true;
    }
});

backbutton.addEventListener('click', function (e) {
    hideall(slides);
    if (forwardbutton.disabled) {
        forwardbutton.disabled = false;
    }
    if (position > 2) {
        slides[position].style.display = 'block';
        slides[position - 1].style.display = 'block';
        slides[position - 2].style.display = 'block';
        position = position - 3;
        if (position == 0) {
            backbutton.disabled = true;
        }
    }
    else {
        backbutton.disabled = true;
    }
});

var hideall = function (slides) {
    for (var i = 0; i < slides.length; i++) {
        slides[i].style.display = 'none';
    }
};

setTimeout(function () {
    var save = slides[0];
    var save1 = slides[1];
    var save2 = slides[2];

    slides[0] = slides[3];
    slides[1] = slides[4];
    slides[2] = slides[5];

    slides[3] = slides[save];
    slides[4] = slides[save1];
    slides[5] = slides[save2];

}, 5000);
