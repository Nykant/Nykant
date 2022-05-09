$(document).ready(function () {
    var x, y;

    var followbox = document.getElementById('follow-box-rack');
    var followname = document.getElementById('follow-name-rack');
    var followprice = document.getElementById('follow-price-rack');

    $("#follow-container-rack").mousemove(function (e) {
        if (e.target != followbox && e.target != followname && e.target != followprice) {
            var rect = e.target.getBoundingClientRect();

            x = e.clientX - rect.left;
            y = e.clientY - rect.top;

            $("#follow-box-rack").stop().animate({ left: x - 170, top: y - 80 }, {
                duration: 500,
                specialEasing: {
                    width: "linear",
                    height: "easeOutBounce"
                }
            });
        }
    });

    $("#follow-container-rack").mouseleave(function (e) {
        $("#follow-box-rack").stop().animate({ left: "35%", top: "85%" }, {
            duration: 500,
            specialEasing: {
                width: "linear",
                height: "easeOutBounce"
            }
        });
    });

    $("#follow-box-rack").css('left', "35%");
    $("#follow-box-rack").css('top', "85%");


});

