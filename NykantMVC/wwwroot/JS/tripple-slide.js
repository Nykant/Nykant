var slides = document.getElementById('tripple-slider').children;
var forwardbutton = document.getElementById('forward-button');
var backbutton = document.getElementById('back-button');
var radioform = document.getElementById('product-slides-radio');
var groups = [];
backbutton.disabled = true;
var position = 0;
var j = 0;
for (var i = 0; i < slides.length / 3; i++) {
    var group = [];
    group.push(slides[j]);
    if (slides[j + 1] !== undefined) {
        group.push(slides[j + 1]);
    }
    if (slides[j + 2] !== undefined) {
        group.push(slides[j + 2]);
    }
    groups.push(group);
    j = j + 3;
}

for (var l = 0; l < groups.length; l++) {
    var radioinput = document.createElement('input');
    radioinput.setAttribute('type', 'radio');
    radioinput.setAttribute('name', 'product-slide-radio');
    radioinput.setAttribute('class', 'slide-radio');
    radioinput.dataset.radionumber = l;
    radioinput.addEventListener('click', function (event) {
        backbutton.disabled = true;
        forwardbutton.disabled = true;
        hideall();
        position = parseInt(event.currentTarget.dataset.radionumber);
        var k = 0;
        var interval = setInterval(function () {
            if (groups[position][k] !== undefined) {
                groups[position][k].style.display = 'block';

                k++;
                if (k >= 3) {
                    if (position == groups.length - 1) {
                        forwardbutton.disabled = true;
                    }
                    else {
                        forwardbutton.disabled = false;
                    }
                    if (position == 0) {
                        backbutton.disabled = true;
                    }
                    else {
                        backbutton.disabled = false;
                    }
                    clearInterval(interval);
                }
            }
            else {
                if (position == groups.length - 1) {
                    forwardbutton.disabled = true;
                }
                else {
                    forwardbutton.disabled = false;
                }
                if (position == 0) {
                    backbutton.disabled = true;
                }
                else {
                    backbutton.disabled = false;
                }
                clearInterval(interval);
            }
        }, 100);
    });

    radioform.appendChild(radioinput);
}

groups[0][0].style.display = 'block';
groups[0][1].style.display = 'block';
groups[0][2].style.display = 'block';

forwardbutton.addEventListener('click', function (e) {
    backbutton.disabled = true;
    forwardbutton.disabled = true;

    hideall();
    if (position < groups.length - 1) {
        position++;
        var i = 0;
        var interval = setInterval(function () {
            if (groups[position][i] !== undefined) {
                groups[position][i].style.display = 'block';

                i++;
                if (i >= 3) {
                    if (position == groups.length - 1) {
                        forwardbutton.disabled = true;
                    }
                    else {
                        forwardbutton.disabled = false;
                    }
                    backbutton.disabled = false;
                    clearInterval(interval);
                }
            }
            else {
                if (position == groups.length - 1) {
                    forwardbutton.disabled = true;
                }
                else {
                    forwardbutton.disabled = false;
                }
                backbutton.disabled = false;
                clearInterval(interval);
            }
        }, 100);

    }
});

backbutton.addEventListener('click', function (e) {
    backbutton.disabled = true;
    forwardbutton.disabled = true;

    hideall();
    if (position > 0) {
        position--;
        var i = 0;
        var interval = setInterval(function () {
            if (groups[position][i] !== undefined) {
                groups[position][i].style.display = 'block';

                i++;
                if (i >= 3) {
                    if (position == 0) {
                        backbutton.disabled = true;
                    }
                    else {
                        backbutton.disabled = false;
                    }
                    forwardbutton.disabled = false;
                    clearInterval(interval);
                }
            }
            else {
                if (position == 0) {
                    backbutton.disabled = true;
                }
                else {
                    backbutton.disabled = false;
                }
                forwardbutton.disabled = false;
                clearInterval(interval);
            }
            
        }, 100);

    }
});

var hideall = function () {
    for (var i = 0; i < groups.length; i++) {
        for (var j = 0; j < groups[i].length; j++) {
            groups[i][j].style.display = 'none';
        }
    }
};
