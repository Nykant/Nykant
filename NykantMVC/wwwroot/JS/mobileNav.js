
$('#nav-burger').on('click', function () {
    var x = document.getElementById("nav-links");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
    }
}) 

//var userBurger2 = document.getElementById("userBurger2");
//var userLogo = document.getElementById("userLogo");

//userLogo.addEventListener('click', function () {
//    if (userBurger2.style.display === "block") {
//        userBurger2.style.display = "none";
//    } else {
//        userBurger2.style.display = "block";
//    }
//})

//$(document).mouseup(function (e) {
//    if ($(e.target).closest(userBurger2).length === 0 && $(e.target).closest(userLogo).length === 0) {
//        userBurger2.style.display = "none";
//    }
//}); 

