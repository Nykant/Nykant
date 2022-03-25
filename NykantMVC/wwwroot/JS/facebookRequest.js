FB.getLoginStatus(function (response) {
    if (response.status === "connected") {
        var accessToken = "";
        var request = '/109096938387808?fields=access_token&access_token=' + response.authResponse.accessToken;
        FB.api(request, function (response) {
            accessToken = response.access_token;
            request = '/109096938387808/feed?fields=from,id,created_time,comments&access_token=' + accessToken;
            FB.api(request, function (response) {
                $.ajax({
                    url: '/facebook/postfeed',
                    type: 'POST',
                    data: AddAntiforgeryToken({
                        jsonFeed: JSON.stringify(response),
                        accessToken: accessToken
                    }),
                    success: function (data) {
                        $("#posts_list").html(data);
                    }
                });
            });
        });
    }
    else {
        document.getElementById('status').innerHTML =
            'Facebook: Please log in if you want to make any api requests';
    }
});

//FB.getLoginStatus(function (response) {
//    if (response.status === "connected") {
//        var accessToken = "";
//        var request = '/109096938387808?fields=access_token&access_token=' + response.authResponse.accessToken;
//        FB.api(request, function (response) {
//            accessToken = response.access_token;
//            request = '/109096938387808/feed?&access_token=' + accessToken;
//            FB.api(request, function (response1) {
//                request = response1.data[2].id + '/likes?&access_token=' + accessToken;
//                FB.api(request, function (response2) {
//                    request = response1.data[2].id + '/comments?&access_token=' + accessToken;
//                    FB.api(request, function (response3) {
//                        console.log('hey');
//                    });
//                });
//            });
//        });
//    }
//});

//request = response1.data[2].id + '/likes?&access_token=' + accessToken;
//FB.api(request, function (response2) {
//    request = response1.data[2].id + '/comments?&access_token=' + accessToken;
//    FB.api(request, function (response3) {
//        console.log('hey');
//    });
//});