var imageloaded = function (message) {
    var url = 'https://localhost:5002/Home/Log?message=image loaded: ' + message;
    fetch(url);
};