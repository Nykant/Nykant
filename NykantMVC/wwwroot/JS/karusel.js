var karusel = document.getElementById('karusel');
var karuselbox = document.getElementById('karusel-box');
var karuselback = document.getElementById('karusel-back');
var karuselforward = document.getElementById('karusel-forward');
var items = karuselbox.children;
if (items.length > 0) {
    var currentPosition = 0;
    var itemWidth = items[0].clientWidth;
    karuselwidth = items.length * itemWidth;
    karuselbox.style.width = karuselwidth.toString() + 'px';
    for (var i = 0; i < items.length; i++) {
        items[i].style.width = itemWidth + 'px';
    }

    karuselback.addEventListener('click', function () {
        if (currentPosition > 0) {
            itemWidth = items[0].clientWidth;
            var transform = karuselbox.style.transform;
            if (transform != '') {
                var translateX = transform.replace(/[^\d.]/g, '');
                var translateXNumber = +translateX;
                var translateXNumber = -translateXNumber;

                var translate = 'translateX(' + (translateXNumber + itemWidth) + 'px)';
                karuselbox.style.transform = translate;
                currentPosition--;
            }
            else {
                var translate = 'translateX(+' + itemWidth + 'px)';
                karuselbox.style.transform = translate;
                currentPosition--;
            }
        }
    });

    karuselforward.addEventListener('click', function () {
        if (currentPosition < items.length - 3) {
            itemWidth = items[0].clientWidth;
            var transform = karuselbox.style.transform;
            if (transform != '') {
                var translateX = transform.replace(/[^\d.]/g, '');
                var translateXNumber = +translateX;
                var translateXNumber = -translateXNumber;

                var translate = 'translateX(' + (translateXNumber - itemWidth) + 'px)';
                karuselbox.style.transform = translate;
                currentPosition++;
            }
            else {
                var translate = 'translateX(-' + itemWidth + 'px)';
                karuselbox.style.transform = translate;
                currentPosition++;
            }

        }
    });
}

