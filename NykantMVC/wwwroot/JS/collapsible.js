var coll = document.getElementsByClassName("collapsible-button");
var contents = document.getElementsByClassName("collapsible-content");
var i, j;

for (j = 0; j < contents.length; j++) {
    var content = contents[j];
    content.style.maxHeight = content.scrollHeight + "px";
}

for (i = 0; i < coll.length; i++) {

    coll[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var content = this.nextElementSibling;
        if (content.style.maxHeight) {
            content.style.maxHeight = null;
        } else {
            content.style.maxHeight = content.scrollHeight + "px";
        }
    });
}