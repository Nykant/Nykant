var frontpage_mousePosition, frontpage_offset = 0, frontpage_isDown = false, frontpage_currentItem, frontpage_itemWidth, frontpage_karuselboxWidth, frontpage_karusel, frontpage_karuselbox, frontpage_items, frontpage_karuselWidth, frontpage_timeout;

function frontpage_SetupKarusel() {
    frontpage_karuselbox = document.getElementById('frontpage-karusel-box');
    frontpage_karusel = document.getElementById('frontpage-karusel');
    frontpage_items = frontpage_karuselbox.children;
    if (frontpage_items.length > 0) {
        frontpage_itemWidth = frontpage_items[0].clientWidth;
        frontpage_karuselboxWidth = frontpage_items.length * frontpage_itemWidth;
        frontpage_karuselWidth = frontpage_karusel.clientWidth;
        $('#frontpage-karusel-box').css('width', frontpage_karuselboxWidth.toString() + 'px');
        for (var i = 0; i < frontpage_items.length; i++) {
            frontpage_items[i].style.width = frontpage_itemWidth + 'px';
        }
    }

    frontpage_karuselbox.addEventListener('touchstart', function (e) {
        frontpage_isDown = true;
        frontpage_karuselbox.style.transition = "none";
        frontpage_offset = frontpage_karuselbox.offsetLeft - e.changedTouches[0].clientX;
    }, true);

    frontpage_karuselbox.addEventListener('touchend', function () {
        frontpage_isDown = false;
        frontpage_karuselbox.style.transition = "all 1s";
    }, true);

    frontpage_karuselbox.addEventListener('touchmove', function (event) {
        event.preventDefault();
        if (frontpage_isDown) {
            frontpage_mousePosition = event.changedTouches[0].clientX;
            var left = (frontpage_mousePosition + frontpage_offset);
            var negativeKaruselwidth = -frontpage_karuselboxWidth;
            if (left < 0 && left > negativeKaruselwidth + frontpage_karuselWidth) {
                frontpage_karuselbox.style.left = left + 'px';
            }
        }
    }, true);

    frontpage_karuselbox.addEventListener('mousedown', function (e) {
        frontpage_karuselbox.style.transition = "none";
        frontpage_currentItem = e.target;
        frontpage_isDown = true;
        frontpage_offset = frontpage_karuselbox.offsetLeft - e.clientX;
        setTimeout(function () {
            frontpage_currentItem.classList.add('cancelclickevent');
        }, 150)
    }, true);

    frontpage_karuselbox.addEventListener('mouseup', () => {
        if (frontpage_currentItem.classList.contains('cancelclickevent')) {
            frontpage_currentItem.classList.remove('cancelclickevent');
        }
        frontpage_karuselbox.style.transition = "all 1s";
        frontpage_isDown = false;
    }, true);

    frontpage_karuselbox.addEventListener('mousemove', function (e) {
        e.preventDefault();
        if (frontpage_isDown) {
            frontpage_mousePosition = e.clientX;
            var left = (frontpage_mousePosition + frontpage_offset);
            var negativeKaruselwidth = -frontpage_karuselboxWidth;
            if (left < 0 && left > negativeKaruselwidth + frontpage_karuselWidth) {
                frontpage_karuselbox.style.left = left + 'px';
            }
        }
    }, true);

    frontpage_karuselbox.addEventListener('mouseleave', function () {
        if (frontpage_currentItem != undefined) {
            if (frontpage_currentItem.classList.contains('cancelclickevent')) {
                frontpage_currentItem.classList.remove('cancelclickevent');
            }
            frontpage_karuselbox.style.transition = "all 1s";
            frontpage_isDown = false;
        }
    });
}

function frontpage_backevent() {
    var left = frontpage_karuselbox.style.left;
    if (left != '') {
        var isNegative = left.includes('-');
        left = left.replace(/[^\d.]/g, '');
        var leftN = +left;
        if (isNegative) {
            leftN = -left;
        }
        if (leftN < 0) {
            if (leftN > -frontpage_itemWidth) {
                frontpage_karuselbox.style.left = 0 + 'px';
            }
            else {
                frontpage_karuselbox.style.left = leftN + frontpage_itemWidth + 'px';
            }
        }
    }
}

function frontpage_forwardevent() {
    var left = frontpage_karuselbox.style.left;
    if (left != '') {
        var isNegative = left.includes('-');
        left = left.replace(/[^\d.]/g, '');
        var leftN = +left;
        if (isNegative) {
            leftN = -left;
        }
        var negativeKaruselwidth = -frontpage_karuselboxWidth;
        if (leftN > negativeKaruselwidth + frontpage_karuselWidth) {
            if (leftN < (negativeKaruselwidth + frontpage_karuselWidth) + frontpage_itemWidth) {
                frontpage_karuselbox.style.left = negativeKaruselwidth + frontpage_karuselWidth + 'px';
            }
            else {
                frontpage_karuselbox.style.left = leftN - frontpage_itemWidth + 'px';
            }
        }
    }
    else {
        if (frontpage_karuselboxWidth > frontpage_karuselWidth) {
            var itemWidthN = -frontpage_itemWidth;
            frontpage_karuselbox.style.left = itemWidthN + 'px';
        }
    }
}

frontpage_SetupKarusel();

$(window).resize(function () {
    clearTimeout(frontpage_timeout);
    frontpage_timeout = setTimeout(frontpage_LoadKarusel, 500);
});

function frontpage_LoadKarusel() {
    $("#frontpage-karusel").load(" #frontpage-karusel > *");
    setTimeout(frontpage_SetupKarusel, 1000);
}