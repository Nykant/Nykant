var notification = document.getElementById("capture-notification");
var notification_text = document.getElementById("capture-notification-text");
complete = function (response) {
    notification_text.innerHTML = response;
    notification.style.display = "block";
    setTimeout(function () {
        notification.style.transition = "all 1s";
        notification.style.top = "-130px";
        setTimeout(function () {
            notification.setAttribute("class", "notification3")
        }, 1000);
    }, 5000);
}