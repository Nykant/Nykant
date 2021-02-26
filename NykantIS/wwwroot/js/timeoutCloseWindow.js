var button = document.getElementById("closeButton");
var count = 5;
button.innerHTML = count;

setInterval(function () {
    count = count - 1;
    button.innerHTML = count;
}, 1000)

setTimeout(function () {
    window.close();
}, 5000);


