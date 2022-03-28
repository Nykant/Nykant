/*/*var privacy_settings = document.getElementById("privacy-settings");*/
var cookie_consent = document.getElementById("cookie-consent");

var consent_updated = function (xhr) {
    if (cookie_consent !== null) {
        cookie_consent.style.display = "none";
        location.reload();
    };
}

//var open_privacy1 = document.getElementById("open-privacy1");
//var open_privacy2 = document.getElementById("open-privacy2");

//if (open_privacy1 !== null) {
//    open_privacy1.addEventListener("click", function (event) {
//        privacy_settings.style.display = "block";
//    });
//};

//if (open_privacy2 !== null) {
//    open_privacy2.addEventListener("click", function (event) {
//        privacy_settings.style.display = "block";
//    });
//};
