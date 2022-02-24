var Log = function (message) {
    $.ajax({
        type: "POST",
        url: '/Home/Log',
        data: AddAntiforgeryToken({
            message: message
        })
    });
};