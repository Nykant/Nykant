function facebookLogout() {
    try {
        FB.logout(function (response) {
            console.log('logged out facebook');

        });
    }
    catch (e) {

    }
    finally{
        location.reload();
    }
}
