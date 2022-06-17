var details_mousePosition, details_offset = 0, details_isDown = false, details_currentItem, details_itemWidth, details_karuselboxWidth, details_karusel, details_karuselbox, details_items, details_karuselWidth, details_timeout;

function details_SetupKarusel() {
    details_karuselbox = document.getElementById('details-karusel-box');
    details_karusel = document.getElementById('details-karusel');
    details_items = details_karuselbox.children;
    if (details_items.length > 0) {
        details_itemWidth = details_items[0].clientWidth;
        details_karuselboxWidth = details_items.length * details_itemWidth;
        details_karuselWidth = details_karusel.clientWidth;
        $('#details-karusel-box').css('width', details_karuselboxWidth.toString() + 'px');
        for (var i = 0; i < details_items.length; i++) {
            details_items[i].style.width = details_itemWidth + 'px';
        }
    }

    details_karuselbox.addEventListener('touchstart', function (e) {
        details_isDown = true;
        details_karuselbox.style.transition = "none";
        details_offset = details_karuselbox.offsetLeft - e.changedTouches[0].clientX;
    }, true);

    details_karuselbox.addEventListener('touchend', function () {
        details_isDown = false;
        details_karuselbox.style.transition = "all 1s";
    }, true);

    details_karuselbox.addEventListener('touchmove', function (event) {
        event.preventDefault();
        if (details_isDown) {
            details_mousePosition = event.changedTouches[0].clientX;
            var left = (details_mousePosition + details_offset);
            var negativeKaruselwidth = -details_karuselboxWidth;
            if (left < 0 && left > negativeKaruselwidth + details_karuselWidth) {
                details_karuselbox.style.left = left + 'px';
            }
        }
    }, true);

    details_karuselbox.addEventListener('mousedown', function (e) {
        details_karuselbox.style.transition = "none";
        details_currentItem = e.target;
        details_isDown = true;
        details_offset = details_karuselbox.offsetLeft - e.clientX;
        setTimeout(function () {
            details_currentItem.classList.add('cancelclickevent');
        }, 150)
    }, true);

    details_karuselbox.addEventListener('mouseup', () => {
        if (details_currentItem.classList.contains('cancelclickevent')) {
            details_currentItem.classList.remove('cancelclickevent');
        }
        details_karuselbox.style.transition = "all 1s";
        details_isDown = false;
    }, true);

    details_karuselbox.addEventListener('mousemove', function (e) {
        e.preventDefault();
        if (details_isDown) {
            details_mousePosition = e.clientX;
            var left = (details_mousePosition + details_offset);
            var negativeKaruselwidth = -details_karuselboxWidth;
            if (left < 0 && left > negativeKaruselwidth + details_karuselWidth) {
                details_karuselbox.style.left = left + 'px';
            }
        }
    }, true);

    details_karuselbox.addEventListener('mouseleave', function () {
        if (details_currentItem != undefined) {
            if (details_currentItem.classList.contains('cancelclickevent')) {
                details_currentItem.classList.remove('cancelclickevent');
            }
            details_karuselbox.style.transition = "all 1s";
            details_isDown = false;
        }
    });
}

function details_backevent() {
    var left = details_karuselbox.style.left;
    if (left != '') {
        var isNegative = left.includes('-');
        left = left.replace(/[^\d.]/g, '');
        var leftN = +left;
        if (isNegative) {
            leftN = -left;
        }
        if (leftN < 0) {
            if (leftN > -details_itemWidth) {
                details_karuselbox.style.left = 0 + 'px';
            }
            else {
                details_karuselbox.style.left = leftN + details_itemWidth + 'px';
            }
        }
    }
}

function details_forwardevent() {
    var left = details_karuselbox.style.left;
    if (left != '') {
        var isNegative = left.includes('-');
        left = left.replace(/[^\d.]/g, '');
        var leftN = +left;
        if (isNegative) {
            leftN = -left;
        }
        var negativeKaruselwidth = -details_karuselboxWidth;
        if (leftN > negativeKaruselwidth + details_karuselWidth) {
            if (leftN < (negativeKaruselwidth + details_karuselWidth) + details_itemWidth) {
                details_karuselbox.style.left = negativeKaruselwidth + details_karuselWidth + 'px';
            }
            else {
                details_karuselbox.style.left = leftN - details_itemWidth + 'px';
            }
        }
    }
    else {        
        if (details_karuselboxWidth > details_karuselWidth) {
            var itemWidthN = -details_itemWidth;
            details_karuselbox.style.left = itemWidthN + 'px';
        }
    }
}

details_SetupKarusel();

$(window).resize(function () {
    clearTimeout(details_timeout);
    details_timeout = setTimeout(details_LoadKarusel, 500);
});

function details_LoadKarusel() {
    $("#details-karusel").load(" #details-karusel > *");
    setTimeout(details_SetupKarusel, 1000);
}