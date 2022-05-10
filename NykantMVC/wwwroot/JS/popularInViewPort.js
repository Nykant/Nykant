
$.fn.isInViewport = function () {
    var elementTop = $(this).offset().top;
    var elementBottom = elementTop + $(this).outerHeight();

    var viewportTop = $(window).scrollTop();
    var viewportBottom = viewportTop + $(window).height();

    return elementBottom > viewportTop && elementTop < viewportBottom;
};

let wasInViewPort;
$(window).on('resize scroll', function() {
    const isInViewPort = $('#favorites-header').isInViewport();
    if (isInViewPort !== wasInViewPort) {
        $('#favorites-header').css({ transform: 'translateX(+100%)' });
    }
    wasInViewPort = isInViewPort;
});