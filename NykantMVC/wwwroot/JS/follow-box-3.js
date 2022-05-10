$(document).ready(function () {
    var x, y;

    var followbox = document.getElementById('follow-box-baenk');
    var followname = document.getElementById('follow-name-baenk');
    var followprice = document.getElementById('follow-price-baenk');
    var followoil = document.getElementById('follow-oil-baenk');

    $("#follow-container-baenk").mousemove(function (e) {
        if (e.target != followbox && e.target != followname && e.target != followprice && e.target != followoil) {
            var rect = e.target.getBoundingClientRect();

            x = e.clientX - rect.left;
            y = e.clientY - rect.top;

            $("#follow-box-baenk").css({ 'left': x - 170, 'top': y - 80 });

            //$("#follow-box-baenk").stop().animate({ left: x - 170, top: y - 80 }, {
            //    duration: 500,
            //    specialEasing: {
            //        width: "linear",
            //        height: "easeOutBounce"
            //    }
            //});
        }
    });

    $("#follow-container-baenk").mouseleave(function (e) {

        $("#follow-box-baenk").stop().css({ 'left': "35%", 'top': "85%" });

        //$("#follow-box-baenk").stop().animate({ left: "35%", top: "85%" }, {
        //    duration: 500,
        //    specialEasing: {
        //        width: "linear",
        //        height: "easeOutBounce"
        //    }
        //});
    });

    $("#follow-box-baenk").stop().css({ 'left': "35%", 'top': "85%" });

});


