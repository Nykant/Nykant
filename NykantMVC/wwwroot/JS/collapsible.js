
var coll3 = document.getElementsByClassName("cookie-collapsible-button2");

for (var i = 0; i < coll3.length; i++) {
    coll3[i].addEventListener("click", function () {
        this.classList.toggle("active2");
        var content = this.nextElementSibling;
        if (content.style.maxHeight && content.style.maxHeight != '0px') {
            content.style.maxHeight = null;
        } else {
            content.style.maxHeight = content.scrollHeight + "px";
        }
    });
}

