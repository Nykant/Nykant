AddAntiforgeryToken = function (data) {
    var token = $('#AntiforgeryToken input[name=AntiforgeryToken]').val();
    data.AntiforgeryToken = token;
    return data;
};