$(document).ready(function () {
    var x, y;

    var followbox = document.getElementById('follow-box');
    var followname = document.getElementById('follow-name');
    var followprice = document.getElementById('follow-price');
    var followoil = document.getElementById('follow-oil');

    $("#follow-container").mousemove(function (e) {
        if (e.target != followbox && e.target != followname && e.target != followprice && e.target != followoil) {
            var rect = e.target.getBoundingClientRect();

            x = e.clientX - rect.left;
            y = e.clientY - rect.top;

            $("#follow-box").css({ 'left': x - 150, 'top': y - 170 });

            //$("#follow-box").stop().animate({ left: x - 170, top: y - 80 }, {
            //    duration: 500,
            //    specialEasing: {
            //        width: "linear",
            //        height: "easeOutBounce"
            //    }
            //});
        }
    });

    $("#follow-container").mouseleave(function (e) {

        $("#follow-box").stop().css({ 'left': "35%", 'top': "85%" });

        //$("#follow-box").stop().animate({ left: "35%", top: "85%" }, {
        //    duration: 500,
        //    specialEasing: {
        //        width: "linear",
        //        height: "easeOutBounce"
        //    }
        //});
    });

    $("#follow-box").stop().css({ 'left': "35%", 'top': "85%" });
});


