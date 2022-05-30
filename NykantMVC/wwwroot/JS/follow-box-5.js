$(document).ready(function () {
    var x, y;

    var followbox = document.getElementById('follow-box-about');
    var followabout = document.getElementById('follow-about');

    $("#follow-container-about").mousemove(function (e) {
        if (e.target != followbox && e.target != followabout) {
            var rect = e.target.getBoundingClientRect();

            x = e.clientX - rect.left;
            y = e.clientY - rect.top;

            $("#follow-box-about").css({ 'left': x - 150, 'top': y - 60 });

            //$("#follow-box-rack").stop().animate({ left: x - 170, top: y - 80 }, {
            //    duration: 500,
            //    specialEasing: {
            //        width: "linear",
            //        height: "easeOutBounce"
            //    }
            //});
        }
    });

    $("#follow-container-about").mouseleave(function (e) {

        $("#follow-box-about").stop().css({ 'left': "35%", 'top': "85%" });

        //$("#follow-box-rack").stop().animate({ left: "35%", top: "85%" }, {
        //    duration: 500,
        //    specialEasing: {
        //        width: "linear",
        //        height: "easeOutBounce"
        //    }
        //});
    });

    $("#follow-box-about").stop().css({ 'left': "35%", 'top': "85%" });


});