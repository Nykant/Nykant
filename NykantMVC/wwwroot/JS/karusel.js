var currentPosition, mousePosition, offset = 0, isDown = false, currentItem, clickTime, itemWidth, karuselboxWidth, karusel, karuselbox, items, karuselWidth;

function SetupKarusel() {
    karuselbox = document.getElementById('karusel-box');
    karusel = document.getElementById('karusel');
    items = karuselbox.children;
    if (items.length > 0) {
        currentPosition = 0;
        itemWidth = items[0].clientWidth;
        karuselboxWidth = items.length * itemWidth;
        karuselWidth = karusel.clientWidth;
        $('#karusel-box').css('width', karuselboxWidth.toString() + 'px');
        for (var i = 0; i < items.length; i++) {
            items[i].style.width = itemWidth + 'px';
        }
    }

    karuselbox.addEventListener('touchstart', function (e) {
        isDown = true;
        karuselbox.style.transition = "none";
        offset = karuselbox.offsetLeft - e.changedTouches[0].clientX;
    }, true);

    karuselbox.addEventListener('touchend', function () {
        isDown = false;
        karuselbox.style.transition = "all 1s";
    }, true);

    karuselbox.addEventListener('touchmove', function (event) {
        event.preventDefault();
        if (isDown) {
            mousePosition = event.changedTouches[0].clientX;
            var left = (mousePosition + offset);
            var negativeKaruselwidth = -karuselboxWidth;
            if (left < 0 && left > negativeKaruselwidth + karuselWidth) {
                karuselbox.style.left = left + 'px';
            }
        }
    }, true);

    karuselbox.addEventListener('mousedown', function (e) {
        karuselbox.style.transition = "none";
        currentItem = e.target;
        isDown = true;
        offset = karuselbox.offsetLeft - e.clientX;
        setTimeout(function () {
            currentItem.classList.add('cancelclickevent');
        }, 150)
    }, true);

    karuselbox.addEventListener('mouseup', () => {
        if (currentItem.classList.contains('cancelclickevent')) {
            currentItem.classList.remove('cancelclickevent');
        }
        karuselbox.style.transition = "all 1s";
        isDown = false;
    }, true);

    karuselbox.addEventListener('mousemove', function (e) {
        e.preventDefault();
        if (isDown) {
            mousePosition = e.clientX;
            var left = (mousePosition + offset);
            var negativeKaruselwidth = -karuselboxWidth;
            if (left < 0 && left > negativeKaruselwidth + karuselWidth) {
                karuselbox.style.left = left + 'px';
            }
        }
    }, true);

    karuselbox.addEventListener('mouseleave', function () {
        if (currentItem.classList.contains('cancelclickevent')) {
            currentItem.classList.remove('cancelclickevent');
        }
        karuselbox.style.transition = "all 1s";
        isDown = false;
    });
}

function backevent() {
    var left = karuselbox.style.left;
    if (left != '') {
        var isNegative = left.includes('-');
        left = left.replace(/[^\d.]/g, '');
        var leftN = +left;
        if (isNegative) {
            leftN = -left;
        }
        if (leftN < 0) {
            if (leftN > -itemWidth) {
                karuselbox.style.left = 0 + 'px';
            }
            else {
                karuselbox.style.left = leftN + itemWidth + 'px';
            }
        }
    }
}

function forwardevent() {
    var left = karuselbox.style.left;
    if (left != '') {
        var isNegative = left.includes('-');
        left = left.replace(/[^\d.]/g, '');
        var leftN = +left;
        if (isNegative) {
            leftN = -left;
        }
        var negativeKaruselwidth = -karuselboxWidth;
        if (leftN > negativeKaruselwidth + karuselWidth) {
            if (leftN < (negativeKaruselwidth + karuselWidth) + itemWidth) {
                karuselbox.style.left = negativeKaruselwidth + karuselWidth + 'px';
            }
            else {
                karuselbox.style.left = leftN - itemWidth + 'px';
            }
        }
    }
    else {        
        if (karuselboxWidth > karuselWidth) {
            var itemWidthN = -itemWidth;
            karuselbox.style.left = itemWidthN + 'px';
        }
    }
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