var privacy_settings = document.getElementById("privacy-settings");
var cookie_consent = document.getElementById("cookie-consent");

var consent_updated = function (xhr) {
    //$('#cookie-consent-updated').css('display', 'block');
    //setTimeout(function () {
    //    $('#cookie-consent-updated').css('transition', 'all .3s');
    //    $('#cookie-consent-updated').css('right', '-200px');
    //    setTimeout(function () {
    //        $('#cookie-consent-updated').css('display', 'none');
    //        $('#cookie-consent-updated').css('transition', 'initial');
    //        $('#cookie-consent-updated').css('right', '0px');
    //    }, 300)
    //}, 5000);
    if (cookie_consent !== null) {
        cookie_consent.style.display = "none";
        //cookie_consent.style.transition = "all 1s";
        //cookie_consent.style.transform = "translateY(+125px)";
        //setTimeout(function () {
        //    cookie_consent.style.transition = "initial";

        //    cookie_consent.style.transform = "translateX(0px)";
        //}, 1000);
    };
}

var open_privacy1 = document.getElementById("open-privacy1");
var open_privacy2 = document.getElementById("open-privacy2");


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
