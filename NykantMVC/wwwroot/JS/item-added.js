
var item_added = document.getElementById("item-added");

item_added.style.display = "block";
setTimeout(function () {
    item_added.style.transition = "all 1s";
    item_added.style.top = "-15%";
    setTimeout(function () {
        item_added.style.display = "none";
    }, 1000)
}, 10000)

