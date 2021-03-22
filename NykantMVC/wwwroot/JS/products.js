var category_list = document.getElementsByClassName("filter-form");
for (var i = 0; i < category_list.length; i++) {
    category_list[i].addEventListener('submit', function () {
        filterloading(true);
    });
};

filtercomplete = function () {
    filterloading(false);
};

var filterloading = function (isLoading) {
    if (isLoading) {
        document.querySelector("#filterspinner").classList.remove("hidden");
    }
    else {
        document.querySelector("#filterspinner").classList.add("hidden");
    }
};