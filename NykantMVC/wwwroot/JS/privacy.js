var button = document.querySelector("#cookieConsent button[data-cookie-string]");
var close_button = document.getElementById("close-button");
var switchInputs = document.getElementsByClassName("settings-input");
var privacy_settings = document.getElementById("privacy-settings");
var open_privacy1 = document.getElementById("open-privacy1");
var open_privacy2 = document.getElementById("open-privacy2");

button.addEventListener("click", function (event) {
    document.cookie = button.dataset.cookieString;
});

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

open_privacy1.addEventListener("click", function (event) {
    privacy_settings.style.display = "block";
});

open_privacy2.addEventListener("click", function (event) {
    privacy_settings.style.display = "block";
});