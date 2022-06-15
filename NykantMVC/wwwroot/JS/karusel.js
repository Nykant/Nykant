var currentPosition;
var mousePosition;
var offset = 0;
var isDown = false;

function SetupKarusel() {
    var karuselbox = document.getElementById('karusel-box');
    var items = karuselbox.children;
    if (items.length > 0) {
        currentPosition = 0;
        itemWidth = items[0].clientWidth;
        karuselwidth = items.length * itemWidth;
/*        karuselbox.style.width = karuselwidth.toString() + 'px';*/
        $('#karusel-box').css('width', karuselwidth.toString() + 'px');
        for (var i = 0; i < items.length; i++) {
            items[i].style.width = itemWidth + 'px';
        }
    }

    karuselbox.addEventListener('touchstart', function (e) {
        isDown = true;
        offset = karuselbox.offsetLeft - e.changedTouches[0].clientX;
    }, true);

    karuselbox.addEventListener('touchend', function () {
        isDown = false;
    }, true);

    karuselbox.addEventListener('touchmove', function (event) {
        event.preventDefault();
        if (isDown) {
            mousePosition = event.changedTouches[0].clientX;
            var left = (mousePosition + offset);
            var divi = itemWidth * 3;
            var negativeKaruselwidth = -karuselwidth;
            if (left < 0 && left > negativeKaruselwidth + divi) {
                karuselbox.style.left = left + 'px';
            }
        }
    }, true);


    karuselbox.addEventListener('mousedown', function (e) {
        e.target.classList.add('cancelclickevent');
        isDown = true;
        offset = karuselbox.offsetLeft - e.clientX;
    });

    karuselbox.addEventListener('mouseup', function (e) {
        e.target.classList.remove('cancelclickevent');
        isDown = false;
    });

    karuselbox.addEventListener('mousemove', function (event) {
        event.preventDefault();
        if (isDown) {
            mousePosition = event.clientX;
            var left = (mousePosition + offset);
            var width3 = itemWidth * 3;
            var negativeKaruselwidth = -karuselwidth;
            if (left < 500 && left > (negativeKaruselwidth + width3) - 500) {
                karuselbox.style.left = left + 'px';
            }
        }
    });

    karuselbox.addEventListener('mouseleave', function () {
        isDown = false;
    });
}

function backevent() {
    var karuselbox = document.getElementById('karusel-box');
    karuselbox.style.transition = 'left ease 1s !important';
    var items = karuselbox.children;
    var left = karuselbox.style.left;
    if (left != '') {
        var isNegative = left.includes('-');
        left = left.replace(/[^\d.]/g, '');
        var leftN = +left;
        if (isNegative) {
            leftN = -left;
        }
        var itemWidth = items[0].clientWidth;
        if (leftN < 0) {
            karuselbox.style.left = leftN + itemWidth + 'px';
        }
    }
    else {

    }
    karuselbox.style.transition = 'none !important';
}

function forwardevent() {
    var karuselbox = document.getElementById('karusel-box');
    karuselbox.style.transition = 'left ease 1s !important';
    var items = karuselbox.children;
    var left = karuselbox.style.left;
    
    if (left != '') {
        var isNegative = left.includes('-');
        left = left.replace(/[^\d.]/g, '');
        var leftN = +left;
        if (isNegative) {
            leftN = -left;
        }
        var itemWidth = items[0].clientWidth;
        var width3 = itemWidth * 3;
        var negativeKaruselwidth = -karuselwidth;
        if (leftN > negativeKaruselwidth + width3) {
            
            karuselbox.style.left = leftN - itemWidth + 'px';
        }
    }
    else {
        var itemWidth = items[0].clientWidth;
        var itemWidthN = -itemWidth;
        karuselbox.style.left = itemWidthN + 'px';
    }
    karuselbox.style.transition = 'none !important';
}

SetupKarusel();

var timeout;
$(window).resize(function () {
    clearTimeout(timeout);
    timeout = setTimeout(LoadKarusel, 500);
});

function LoadKarusel() {
    $("#karusel").load(" #karusel > *");
    setTimeout(SetupKarusel, 1000);
}