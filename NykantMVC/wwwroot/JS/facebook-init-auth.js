
var chatbox = document.getElementById('fb-customer-chat');
chatbox.setAttribute("page_id", "104882272120980");
chatbox.setAttribute("attribution", "biz_inbox");

function statusChangeCallback(response) {  // Called with the results from FB.getLoginStatus().
    console.log('statusChangeCallback');
    console.log(response);                   // The current login status of the person.
    if (response.status === 'connected') {   // Logged into your webpage and Facebook.
        loginResponse();
    } else {                                 // Not logged into your webpage or we are unable to tell.
        document.getElementById('status').innerHTML = 'Facebook: Not logged in';
    }
}

function checkLoginState() {               // Called when a person is finished with the Login Button.
    FB.getLoginStatus(function (response) {   // See the onlogin handler
        statusChangeCallback(response);
    });
    location.reload();
}

function loginResponse() {                      // Testing Graph API after login.  See statusChangeCallback() for when this call is made.
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', function (response) {
        console.log('Successful login for: ' + response.name);
        document.getElementById('status').innerHTML =
            'Facebook: Logged in as: ' + response.name;
        document.getElementById('fb-user').dataset.fbuser = response.name;
    });
}

function facebookLogout() {
    try {
        FB.logout(function (response) {
            console.log('logged out facebook');

        });
    }
    catch (e) {

    }
    finally {
        location.reload();
    }
}

function facebookRequest() {
    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') {
            var userAccessToken = response.authResponse.accessToken;
            FB.api('/me', function (response) {
                if (response.name !== "Spiderman Test User") {
                    document.getElementById('fb-logincase').style.display = 'block';
                }
                else {
                    var request = '/109096938387808?fields=access_token&access_token=' + userAccessToken;
                    FB.api(request, function (response) {
                        var pageAccessToken = response.access_token;
                        request = '/109096938387808/feed?fields=from,id,created_time,comments&access_token=' + pageAccessToken;
                        FB.api(request, function (response) {
                            Log("Fb call worked");
                            $.ajax({
                                url: '/Facebook/PostFeed',
                                type: 'POST',
                                data: AddAntiforgeryToken({
                                    jsonFeed: JSON.stringify(response),
                                    accessToken: pageAccessToken
                                }),
                                success: function (data) {
                                    Log("/Facebook/PostFeed call success");
                                    $("#posts_list").html(data);
                                },
                                error: function () {
                                    Log("/Facebook/PostFeed call error");
                                }
                            });
                        });
                    });
                }
            });
        }
        else {
            document.getElementById('fb-logincase').style.display = 'block';
            document.getElementById('status').innerHTML = 'Facebook: Not logged in';
        }
    });
}

window.fbAsyncInit = function () {
    FB.init({
        appId: '391655249463703',
        autoLogAppEvents: true,
        xfbml: true,
        version: 'v13.0'
    });

    FB.getLoginStatus(function (response) {   // Called after the JS SDK has been initialized.
        statusChangeCallback(response);        // Returns the login status.
    });
};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = 'https://connect.facebook.net/en_US/sdk/xfbml.customerchat.js';
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));
