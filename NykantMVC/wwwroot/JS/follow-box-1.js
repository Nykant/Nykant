$(document).ready(function () {
    var x, y;

    var followbox = document.getElementById('follow-box-table');
    var followname = document.getElementById('follow-name-table');
    var followprice = document.getElementById('follow-price-table');
    var followoil = document.getElementById('follow-oil-table');

    $("#follow-container-table").mousemove(function (e) {
        if (e.target != followbox && e.target != followname && e.target != followprice && e.target != followoil) {
            var rect = e.target.getBoundingClientRect();

            x = e.clientX - rect.left;
            y = e.clientY - rect.top;

            $("#follow-box-table").css({ 'left': x - 150, 'top': y - 170});

            //$("#follow-box-table").stop().animate({ left: x - 170, top: y - 80 }, {
            //    duration: 500,
            //    specialEasing: {
            //        width: "linear",
            //        height: "easeOutBounce"
            //    }
            //});
        }
    });

    $("#follow-container-table").mouseleave(function (e) {

        $("#follow-box-table").stop().css({ 'left': "35%", 'top': "85%"});

        //$("#follow-box-table").stop().animate({ left: "35%", top: "85%" }, {
        //    duration: 500,
        //    specialEasing: {
        //        width: "linear",
        //        height: "easeOutBounce"
        //    }
        //});
    });


    $("#follow-box-table").stop().css({ 'left': "35%", 'top': "85%" });

});


