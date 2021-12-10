$(document).ready(function () {
    if (window.innerWidth > 768) {
        $('.owl-carousel').slick({
            infinite: true,
            centerMode: false,
            slidesToShow: 3,
            slidesToScroll: 3,
            arrows: true,
            autoplay: true,
            autoplaySpeed: 3000,
        });
    }
    else {
        $('.owl-carousel').slick({
            infinite: true,
            centerMode: false,
            slidesToShow: 1,
            slidesToScroll: 1,
            arrows: true,
            autoplay: true,
            autoplaySpeed: 3000,
        });
    }
});

