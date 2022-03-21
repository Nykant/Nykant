//var statusChangeCallback = function(response) {  // Called with the results from FB.getLoginStatus().
//    console.log('statusChangeCallback');
//    console.log(response);                   // The current login status of the person.
//    if (response.status === 'connected') {   // Logged into your webpage and Facebook.
//        testAPI();
//    } else {                                 // Not logged into your webpage or we are unable to tell.
//        //document.getElementById('status').innerHTML = 'Please log ' +
//        //    'into this webpage.';
//    }
//}

//var checkLoginState = function() {               // Called when a person is finished with the Login Button.
//    FB.getLoginStatus(function (response) {   // See the onlogin handler
//        statusChangeCallback(response);
//    });
//}
var testApi = function () {
    FB.getLoginStatus(function (response) {   // Called after the JS SDK has been initialized.
        if (response.status !== "connected") {
            FB.login(function (response) {
                if (response.status === 'connected') {
                    var request = '/v13.0/104882272120980?fields=access_token&access_token=' + response.authResponse.accessToken;
                    FB.api(request, function (response) {
                        request = '/v13.0/104882272120980/feed?access_token=' + response.access_token;
                        FB.api(request, function (response) {
                            console.log('Successful login for: ' + response.name);
                        });
                    });
                }
            }, { scope: 'public_profile,email,pages_read_user_content,pages_read_engagement,pages_show_list' });
        }
    });
}

window.fbAsyncInit = function () {
    FB.init({
        appId: '391655249463703',
        autoLogAppEvents: true,
        cookie: true,                     // Enable cookies to allow the server to access the session.
        xfbml: true,                     // Parse social plugins on this webpage.
        version: 'v13.0'           // Use this Graph API version for this call.
    });



    //FB.getLoginStatus(function (response) {   // Called after the JS SDK has been initialized.
    //    statusChangeCallback(response);        // Returns the login status.
    //});
};



    //function testAPI() {                      // Testing Graph API after login.  See statusChangeCallback() for when this call is made.
    //    console.log('Welcome!  Fetching your information.... ');
    //    FB.api('/me', function (response) {
    //        console.log('Successful login for: ' + response.name);
    //        document.getElementById('status').innerHTML =
    //            'Thanks for logging in, ' + response.name + '!';
    //    });
    //}