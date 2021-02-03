
function onload() {
    var e = document.getElementById("breadcrumb");
    var size = 0;
    var id = setInterval(frame, 1);
    function frame() {
        if (size == 1) {
            clearInterval(id);
        }
        else {
            size = size + 0.01; 
            e.style.transform = `scaleX(${size})`;
        }
    }
}