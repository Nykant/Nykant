
var close_button = document.getElementById("close-button");
var switchInputs = document.getElementsByClassName("settings-input");
var privacy_settings = document.getElementById("privacy-settings");
var cookie_consent = document.getElementById("cookie-consent");
var allow_all_button = document.getElementById("allow-all-button");

for (var i = 0; i < switchInputs.length; i++) {
    switchInputs[i].addEventListener("change", function () {
        for (var h = 0; h < switchInputs.length; h++) {
            switchInputs[h].value = 0;
        };
        var checkedElements = document.querySelectorAll('input:checked');
        for (var j = 0; j < checkedElements.length; j++) {
            checkedElements[j].value = 1;
        };

        //if (switchInputs[i].value == '0') {
        //    switchInputs[i].value = 1;
        //}
        //else {
        //    switchInputs[i].value = 0;
        //}
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

consent_settings_updated = function (response) {
    $('#cookie-consent-updated').css('display', 'block');
    setTimeout(function () {
        $('#cookie-consent-updated').css('transition', 'all .3s');
        $('#cookie-consent-updated').css('right', '-200px');
        setTimeout(function () {
            $('#cookie-consent-updated').css('display', 'none');
            $('#cookie-consent-updated').css('transition', 'initial');
            $('#cookie-consent-updated').css('right', '0px');
        }, 300)
    }, 5000);
    if (cookie_consent !== null) {
        cookie_consent.style.transition = "all 1s";
        cookie_consent.style.transform = "translateY(+125px)";
        setTimeout(function () {
            cookie_consent.style.transition = "initial";
            cookie_consent.style.display = "none";
            cookie_consent.style.transform = "translateX(0px)";
        }, 1000);
    };
};
