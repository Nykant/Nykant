var button = document.querySelector("#cookieConsent button[data-cookie-string]");
var settings_button = document.getElementById("settings-button");
var close_button = document.getElementById("close-button");
var switchInputs = document.getElementsByClassName("settings-input");

button.addEventListener("click", function (event) {
    document.cookie = button.dataset.cookieString;
});

settings_button.addEventListener("click", function (event) {
    document.getElementById("privacy-settings").style.display = "block";
});

close_button.addEventListener("click", function () {
    document.getElementById("privacy-settings").style.transition = "all 1s";
    document.getElementById("privacy-settings").style.transform = "translateX(-400px)";
    setTimeout(function () {
        document.getElementById("privacy-settings").style.display = "none";
        document.getElementById("privacy-settings").style.transform = "translateX(0px)";
    }, 1000);
});

for (var i = 0; i < switchInputs.length; i++) {
    switchInputs[i].addEventListener("change", function () {
        var checkedElements = document.querySelectorAll('input:checked');
        for (var j = 0; j < checkedElements.length; j++) {
            var hello = "test";
        };
    });
};