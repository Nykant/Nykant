/*/*var privacy_settings = document.getElementById("privacy-settings");*/*/
var cookie_consent = document.getElementById("cookie-consent");
var cookie_consent_modal = document.getElementById("cookie-consent-modal");
if (cookie_consent_modal !== null) {
    cookie_consent_modal.style.display = "block";
}

var consent_updated = function (xhr) {
    if (cookie_consent !== null) {
        cookie_consent.style.display = "none";
        cookie_consent_modal.style.display = "none";
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
