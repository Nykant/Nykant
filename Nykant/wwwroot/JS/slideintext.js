var x = document.getElementById("slideMeIn");
$(window).scroll(function () {
    if ($(window).scrollTop() > 100) {
        x.style.display = "block";
    }
});

var u = document.getElementById("slideme");
var y = document.getElementById("slide-container");
$(window).scroll(function () {
    if ($(window).scrollTop() > 700) {
        y.style.display = "block";
        u.style.display = "block";
    }
});


