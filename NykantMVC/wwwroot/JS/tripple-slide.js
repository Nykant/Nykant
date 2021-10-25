var slides = document.getElementById('tripple-slider').children;
var trippleslider = document.getElementById('tripple-slider');
var forwardbutton = document.getElementById('forward-button');
var backbutton = document.getElementById('back-button');
var radioform = document.getElementById('product-slides-radio');
var groups = [];
backbutton.disabled = true;
var position = 0;
var amount = 0;
var timeout = false;
var direction = 1;

// Homegrown Functions //

var hideall = function () {
    var outgroup = [];
    for (var i = 0; i < groups.length; i++) {
        for (var j = 0; j < groups[i].length; j++) {
            if (groups[i][j].className.includes('productslide-in')) {

                if (direction == 1) {
                    groups[i][j].setAttribute('class', 'col-4 productslide-out-left');
                }
                else if (direction == 2) {
                    groups[i][j].setAttribute('class', 'col-4 productslide-out-right');
                }

                outgroup.push(groups[i][j]);

                setTimeout(function () {
                    for (var i = 0; i < outgroup.length; i++) {
                        if (outgroup[i].className.includes('productslide-out')) {
                            outgroup[i].style.display = 'none';
                        }
                    }
                }, 300);
            }
        }
    }
};

var makegroups = function () {
    var j = 0;
    groups = [];
    for (var i = 0; i < slides.length / amount; i++) {
        var group = [];
        if (amount >= 1 && slides[j] !== undefined) {
            group.push(slides[j]);
        }
        if (amount >= 2 && slides[j + 1] !== undefined) {
            group.push(slides[j + 1]);
        }
        if (amount >= 3 && slides[j + 2] !== undefined) {
            group.push(slides[j + 2]);
        }
        groups.push(group);
        j = j + amount;
    }
};

var checkresize = function () {
    if (timeout == false) {
        /*        settimeout();*/
        if (trippleslider.offsetLeft < 5) {
            amount = 1;
            position = 0;
        }
        else {
            amount = 3;
            position = 0;
        }
        makegroups();
        slideInterval(1);
        makeRadioButtons();
    }
};

var settimeout = function () {
    timeout = true;
    setTimeout(function () {
        timeout = false;
    }, 1000)
};

var slideInterval = function (direction) {
    hideall();
    var i = 0;
    var interval = setInterval(function () {
        if (groups[position][i] !== undefined) {
            if (direction == 1) {
                groups[position][i].setAttribute('class', 'col-4 productslide-in-left');
            }
            else if (direction == 2) {
                groups[position][i].setAttribute('class', 'col-4 productslide-in-right');
            }

            //groups[position][i].classList.remove('hidden');
            //groups[position][i].classList.remove('productslide-out-left');
            //groups[position][i].classList.add('productslide-in');
            groups[position][i].style.display = 'block';
            i++;
            if (i >= amount) {
                if (position >= groups.length - 1) {
                    forwardbutton.disabled = true;
                }
                else {
                    forwardbutton.disabled = false;
                }
                if (position <= 0) {
                    backbutton.disabled = true;
                }
                else {
                    backbutton.disabled = false;
                }
                clearInterval(interval);
            }
        }
        else {
            if (position >= groups.length - 1) {
                forwardbutton.disabled = true;
            }
            else {
                forwardbutton.disabled = false;
            }
            if (position <= 0) {
                backbutton.disabled = true;
            }
            else {
                backbutton.disabled = false;
            }
            clearInterval(interval);
        }
    }, 100);
};

var clearRadiobuttons = function () {
    var length = radioform.children.length;
    for (var i = 0; i < length; i++) {
        radioform.removeChild(radioform.children[0]);
    }
};

var makeRadioButtons = function () {
    clearRadiobuttons();
    for (var l = 0; l < groups.length; l++) {
        var radioinput = document.createElement('input');
        radioinput.setAttribute('type', 'radio');
        radioinput.setAttribute('name', 'product-slide-radio');
        radioinput.setAttribute('class', 'slide-radio');
        radioinput.dataset.radionumber = l;
        if (l == position) {
            radioinput.checked = true;
        }
        radioinput.addEventListener('click', function (event) {
            backbutton.disabled = true;
            forwardbutton.disabled = true;
            var radionumber = parseInt(event.currentTarget.dataset.radionumber);
            if (radionumber > position) {
                direction = 1;
            }
            else {
                direction = 2;
            }
            position = radionumber;
            slideInterval(direction);
        });
        radioform.appendChild(radioinput);
    }
};

// Formula //

checkresize();

forwardbutton.addEventListener('click', function (e) {
    backbutton.disabled = true;
    forwardbutton.disabled = true;
    if (position < groups.length - 1) {
        position++;
        direction = 1;
        slideInterval(direction);
        for (var i = 0; i < radioform.children.length; i++) {
            if (radioform.children[i].dataset.radionumber == position) {
                radioform.children[i].checked = true;
            }
        }
    }
});

backbutton.addEventListener('click', function (e) {
    backbutton.disabled = true;
    forwardbutton.disabled = true;
    if (position > 0) {
        position--;
        direction = 2;
        slideInterval(direction);
        for (var i = 0; i < radioform.children.length; i++) {
            if (radioform.children[i].dataset.radionumber == position) {
                radioform.children[i].checked = true;
            }
        }
    }
});

window.addEventListener('resize', function () {
    checkresize();
});



