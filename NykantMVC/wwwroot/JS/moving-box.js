

$("#follow-container").mousemove(function (e) {
    // e = Mouse click event.

    var rect = e.target.getBoundingClientRect();

    var x = e.clientX - rect.left; //x position within the element.
    var y = e.clientY - rect.top;  //y position within the element.

    $("#follow-box").css('left', x);
    $("#follow-box").css('top', y);

/*    $("#follow-box").animate({ left: x - 40, top: y - 40 }, 1, 'linear');*/
});