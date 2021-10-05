var capture_notification = document.getElementById("capture-notification");
var capture_notification_text = document.getElementById("capture-notification-text");
complete = function (response) {
    capture_notification_text.textContent = response;
    capture_notification.style.display = "block";
    setTimeout(function () {
        capture_notification.style.transition = "all 1s";
        capture_notification.style.top = "-130px";
        setTimeout(function () {
            capture_notification.setAttribute("class", "notification3");
        }, 1000);
    }, 5000);
}