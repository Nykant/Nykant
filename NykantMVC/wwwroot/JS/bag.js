bag_item_updated = function () {
    fetch("/bag/getprice", {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    }).then(response => response.json())
        .then(function (data) {
            document.getElementById("total-price-text").textContent = 'total: ' + data.price;
        })
};