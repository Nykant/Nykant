AddAntiCSRFToken = function (data) {
    var token = $('#AntiCSRFTokenForm input[name=NykantAntiCSRFToken]').val();
    data.NykantAntiCSRFToken = token;
    return data;
};