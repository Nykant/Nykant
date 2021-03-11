var button = document.getElementById("review-button");
button.disabled = true;
var star1 = document.getElementById("star1");
var star2 = document.getElementById("star2");
var star3 = document.getElementById("star3");
var star4 = document.getElementById("star4");
var star5 = document.getElementById("star5");
var input = document.getElementById("stars-input");
var body = document.getElementById("review-body");
var title = document.getElementById("review-title");

star1.addEventListener("click", function () {

    star1.classList.remove("unchecked");
    star1.classList.add("checked");

    star2.classList.remove("checked");
    star2.classList.add("unchecked");

    star3.classList.remove("checked");
    star3.classList.add("unchecked");

    star4.classList.remove("checked");
    star4.classList.add("unchecked");

    star5.classList.remove("checked");
    star5.classList.add("unchecked");

    button.innerHTML = "Send";
    button.disabled = false;


    input.value = 1;
})
star2.addEventListener("click", function () {
    star1.classList.remove("unchecked");
    star1.classList.add("checked");

    star2.classList.remove("unchecked");
    star2.classList.add("checked");

    star3.classList.remove("checked");
    star3.classList.add("unchecked");

    star4.classList.remove("checked");
    star4.classList.add("unchecked");

    star5.classList.remove("checked");
    star5.classList.add("unchecked");

    button.innerHTML = "Send";
    button.disabled = false;

    input.value = 2;
})
star3.addEventListener("click", function () {
    star1.classList.remove("unchecked");
    star1.classList.add("checked");

    star2.classList.remove("unchecked");
    star2.classList.add("checked");

    star3.classList.remove("unchecked");
    star3.classList.add("checked");

    star4.classList.remove("checked");
    star4.classList.add("unchecked");

    star5.classList.remove("checked");
    star5.classList.add("unchecked");

    button.innerHTML = "Send";
    button.disabled = false;

    input.value = 3;
})
star4.addEventListener("click", function () {
    star1.classList.remove("unchecked");
    star1.classList.add("checked");

    star2.classList.remove("unchecked");
    star2.classList.add("checked");

    star3.classList.remove("unchecked");
    star3.classList.add("checked");

    star4.classList.remove("unchecked");
    star4.classList.add("checked");

    star5.classList.remove("checked");
    star5.classList.add("unchecked");

    button.innerHTML = "Send";
    button.disabled = false;

    input.value = 4;
})
star5.addEventListener("click", function () {
    star1.classList.remove("unchecked");
    star1.classList.add("checked");

    star2.classList.remove("unchecked");
    star2.classList.add("checked");

    star3.classList.remove("unchecked");
    star3.classList.add("checked");

    star4.classList.remove("unchecked");
    star4.classList.add("checked");

    star5.classList.remove("unchecked");
    star5.classList.add("checked");

    button.innerHTML = "Send";
    button.disabled = false;

    input.value = 5;
})