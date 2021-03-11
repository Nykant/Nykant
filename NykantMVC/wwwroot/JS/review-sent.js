
var elem = document.getElementById("review-sent");
elem.style.display = "block";
setTimeout(function () {
    elem.style.transition = "all 1s";
    elem.style.top = "-115px";
    setTimeout(function () {
        elem.style.display = "none";
    }, 1000);
}, 10000);

