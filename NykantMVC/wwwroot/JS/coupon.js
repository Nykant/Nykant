var coupon_product_select = document.getElementById('coupon-product-select');
var coupon_for_product = document.getElementById('coupon-for-products');

coupon_product_select.addEventListener('change', function (event) {
    if (coupon_for_product.value == '') {
        coupon_for_product.value = event.target[event.target.selectedIndex].dataset.id;
    }
    else {
        coupon_for_product.value = coupon_for_product.value + "," + event.target[event.target.selectedIndex].dataset.id;
    }
});