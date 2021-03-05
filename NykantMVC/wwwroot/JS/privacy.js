var button = document.querySelector("#cookie-consent button[data-cookie-string]");
var close_button = document.getElementById("close-button");
var switchInputs = document.getElementsByClassName("settings-input");
var privacy_settings = document.getElementById("privacy-settings");
var open_privacy1 = document.getElementById("open-privacy1");
var open_privacy2 = document.getElementById("open-privacy2");
var cookie_consent = document.getElementById("cookie-consent");

if (button !== null) {
    button.addEventListener("click", function (event) {
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
