var x = document.getElementById("detailsdescription");
$(window).scroll(function () {
    if ($(window).scrollTop() > 100) {
        x.style.display = "block";
    }
});