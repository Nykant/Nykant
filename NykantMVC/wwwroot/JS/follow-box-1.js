$(document).ready(function () {
    var x, y;

    var followbox = document.getElementById('follow-box-table');
    var followname = document.getElementById('follow-name-table');
    var followprice = document.getElementById('follow-price-table');

    $("#follow-container-table").mousemove(function (e) {
        if (e.target != followbox && e.target != followname && e.target != followprice) {
            var rect = e.target.getBoundingClientRect();

            x = e.clientX - rect.left;
            y = e.clientY - rect.top;

            $("#follow-box-table").stop().animate({ left: x - 170, top: y - 80 }, {
                duration: 500,
                specialEasing: {
                    width: "linear",
                    height: "easeOutBounce"
                }
            });
        }
    });

    $("#follow-container-table").mouseleave(function (e) {
        $("#follow-box-table").stop().animate({ left: "35%", top: "85%" }, {
            duration: 500,
            specialEasing: {
                width: "linear",
                height: "easeOutBounce"
            }
        });
    });

    $("#follow-box-table").css('left', "35%");
    $("#follow-box-table").css('top', "85%");

});


