var button = document.querySelector("#cookie-consent button[data-cookie-string]");
var close_button = document.getElementById("close-button");
var switchInputs = document.getElementsByClassName("settings-input");
var privacy_settings = document.getElementById("privacy-settings");
var open_privacy1 = document.getElementById("open-privacy1");
var open_privacy2 = document.getElementById("open-privacy2");
var cookie_consent = document.getElementById("cookie-consent");
var cookie_modal = document.getElementById("cookie-modal");
var allow_all_button = document.getElementById("allow-all-button");
if (cookie_modal !== null) {
    cookie_modal.style.display = "block";
}

//if (allow_all_button !== null) {
//    allow_all_button.addEventListener("click", function () {
//        document.cookie = button.dataset.cookieString;
//    });
//};

if (button !== null) {
    button.addEventListener("click", function (event) {
        cookie_modal.style.display = "none";
        document.cookie = button.dataset.cookieString;
        cookie_consent.style.transition = "all 1s";
        cookie_consent.style.transform = "translateY(+125px)";
        setTimeout(function () {
            cookie_consent.style.display = "none";
            cookie_consent.style.transform = "translateX(0px)";
        }, 1000);
    });
};



close_button.addEventListener("click", function () {
    privacy_settings.style.transition = "all 1s";
    privacy_settings.style.transform = "translateX(-400px)";
    setTimeout(function () {
        privacy_settings.style.display = "none";
        privacy_settings.style.transform = "translateX(0px)";
    }, 1000);
});

for (var i = 0; i < switchInputs.length; i++) {
    switchInputs[i].addEventListener("change", function () {
        for (var h = 0; h < switchInputs.length; h++) {
            switchInputs[h].value = 0;
        };
        var checkedElements = document.querySelectorAll('input:checked');
        for (var j = 0; j < checkedElements.length; j++) {
            checkedElements[j].value = 1;
        };
    });
};

if (open_privacy1 !== null) {
    open_privacy1.addEventListener("click", function (event) {
        privacy_settings.style.display = "block";
    });
};

if (open_privacy2 !== null) {
    open_privacy2.addEventListener("click", function (event) {
        privacy_settings.style.display = "block";
    });
};

completed = function (response) {
    if (cookie_modal !== null) {
        cookie_modal.style.display = "none";
    }
    if (cookie_consent !== null) {
        cookie_consent.style.transition = "all 1s";
        cookie_consent.style.transform = "translateY(+125px)";
        setTimeout(function () {
            cookie_consent.style.display = "none";
            cookie_consent.style.transform = "translateX(0px)";
        }, 1000);
    }
    privacy_settings.style.transition = "all 1s";
    privacy_settings.style.transform = "translateX(-400px)";
    setTimeout(function () {
        privacy_settings.style.display = "none";
        privacy_settings.style.transform = "translateX(0px)";
    }, 1000);
};

var notification = document.getElementById("cookie-notification");
var notification_text = document.getElementById("cookie-notification-text");
done = function (response) {
    notification_text.innerHTML = response;
    notification.style.display = "block";
    setTimeout(function () {
        notification.style.transition = "all 1s";
        notification.style.top = "-130px";
        setTimeout(function () {
            notification.setAttribute("class", "notification2")
        }, 1000);
    }, 5000);
}

var notification2 = document.getElementById("cookie-notification2");
var notification_text2 = document.getElementById("cookie-notification-text2");
done2 = function (response) {
    notification_text2.innerHTML = response;
    notification2.style.display = "block";
    
    setTimeout(function () {
        notification2.style.transition = "all 1s";
        notification2.style.top = "-130px";
        setTimeout(function () {
            notification2.setAttribute("class", "notification3")
        }, 1000);
    }, 5000);
}