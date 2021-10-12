var x, i, j, l, ll, selElmnt, a, b, c, shopOption;
x = document.getElementsByClassName("custom-list");
l = x.length;

var elem = document.getElementById("custom-list-options");
var shippingdelivery_type = document.getElementById("shipping-delivery-type");
var shippingdelivery_price = document.getElementById("shipping-delivery-price");
var parcelshop_CompanyName = document.getElementById("parcelshop-CompanyName");
var parcelshop_StreetName = document.getElementById("parcelshop-StreetName");
var parcelshop_StreetName2 = document.getElementById("parcelshop-StreetName2");
var parcelshop_ZipCode = document.getElementById("parcelshop-ZipCode");
var parcelshop_CityName = document.getElementById("parcelshop-CityName");
var parcelshop_CountryCodeISO3166A2 = document.getElementById("parcelshop-CountryCodeISO3166A2");
var nearby_shops = document.getElementById("nearby-shops");
var nearby_shops_modal = document.getElementById('nearby-shops-modal');
var shipping_form = document.getElementById('shipping-form');
var submit_button = document.getElementById('custom-list-button')
submit_button.disabled = true;

for (i = 0; i < l; i++) {
    selElmnt = x[i].getElementsByTagName("select")[0];
    ll = selElmnt.length;
    for (j = 1; j < ll; j++) {
        c = document.createElement("div");
        c.setAttribute("class", "custom-list-option notselected");
        c.textContent = selElmnt.options[j].textContent;
        if (selElmnt.options[j].textContent.includes('Shop')) {
            shopOption = c;
        }

        c.addEventListener("click", function (e) {
            var y, i, k, select, h, selectlength, yl;
            select = this.parentNode.parentNode.getElementsByTagName("select")[0];
            selectlength = select.length;
            h = this.parentNode.previousSibling;
            for (i = 1; i < selectlength; i++) {
                if (select.options[i].textContent == this.textContent) {
                    select.selectedIndex = i;
                    
                    y = this.parentNode.getElementsByClassName("custom-list-option selected");
                    yl = y.length;
                    for (k = 0; k < yl; k++) {
                        y[k].setAttribute("class", "custom-list-option notselected");
                    }
                    this.setAttribute("class", "custom-list-option selected");

                    if (this.textContent.includes("Home")) {
                        shippingdelivery_type.value = 'Home';
                        shippingdelivery_price.value = 65;
                        submit_button.disabled = false;
                        break;
                    }
                    else {
                        shippingloading(true);
                        shippingdelivery_type.value = 'Shop';
                        shippingdelivery_price.value = 0;
                        submit_button.disabled = true;
                    }

                    if (this.textContent.includes('Shop')) {
                        var address, postal;
                        if (shippingaddress_address.value != '') {
                            address = shippingaddress_address.value;
                        }
                        else if (shippingaddress_address.textContent != '') {
                            address = shippingaddress_address.textContent;
                        }
                        if (shippingaddress_postal.value != '') {
                            postal = shippingaddress_postal.value;
                        }
                        else if (shippingaddress_postal.textContent != '') {
                            postal = shippingaddress_postal.textContent;
                        }
                        /* fetch('/checkout/GetNearbyShopsJson?Street=' + address + '&ZipCode=' + postal + '&CountryIso=DK&Amount=5'*/
                        $.ajax({
                            type: "GET",
                            url: '/checkout/GetNearbyShopsJson?Street=' + address + '&ZipCode=' + postal + '&CountryIso=DK&Amount=5'
                        }).then(function (result) {
                            for (var t = 0; t < result.parcelshops.length; t++) {
                                if (nearby_shops.children.length < 6) {
                                    a = document.createElement("div");
                                    a.setAttribute("class", "shop");
                                    a.style.zIndex = "100";

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.style.pointerEvents = "none";
                                    b.textContent = result.parcelshops[t].companyName;
                                    b.setAttribute("data-type", "companyName");
                                    a.appendChild(b);

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.style.pointerEvents = "none";
                                    b.textContent = result.parcelshops[t].streetname;
                                    b.setAttribute("data-type", "streetname");
                                    a.appendChild(b);

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.style.pointerEvents = "none";
                                    b.textContent = result.parcelshops[t].streetname2;
                                    b.setAttribute("data-type", "streetname2");
                                    a.appendChild(b);

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.style.pointerEvents = "none";
                                    b.textContent = result.parcelshops[t].zipCode;
                                    b.setAttribute("data-type", "zipCode");
                                    a.appendChild(b);

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.style.pointerEvents = "none";
                                    b.textContent = result.parcelshops[t].cityName;
                                    b.setAttribute("data-type", "cityName");
                                    a.appendChild(b);

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.style.pointerEvents = "none";
                                    b.textContent = result.parcelshops[t].countryCodeISO3166A2;
                                    b.setAttribute("data-type", "countryCodeISO3166A2");
                                    a.appendChild(b);

                                    a.addEventListener("click", function (e) {
                                        var props = e.target.children;
                                        for (var i = 0; i < props.length; i++) {
                                            var prop_type = props[i].getAttribute("data-type");
                                            if (prop_type == "companyName") {
                                                parcelshop_CompanyName.value = props[i].textContent;
                                                select.options[select.selectedIndex].textContent = "Shop | " + props[i].textContent + "   |   0 dkk,-";
                                                shopOption.textContent = "Shop | " + props[i].textContent + "   |   0 dkk,-";
                                            }
                                            else if (prop_type == "streetname") {
                                                parcelshop_StreetName.value = props[i].textContent;
                                            }
                                            else if (prop_type == "streetname2") {
                                                parcelshop_StreetName2.value = props[i].textContent;
                                            }
                                            else if (prop_type == "zipCode") {
                                                parcelshop_ZipCode.value = props[i].textContent;
                                            }
                                            else if (prop_type == "cityName") {
                                                parcelshop_CityName.value = props[i].textContent;
                                            }
                                            else if (prop_type == "countryCodeISO3166A2") {
                                                parcelshop_CountryCodeISO3166A2.value = props[i].textContent;
                                            }
                                        }

                                        nearby_shops_modal.style.display = "none";
                                        submit_button.disabled = false;
                                        shippingloading(false);
                                    });

                                    nearby_shops.appendChild(a);
                                }
                            }

                            nearby_shops_modal.style.display = "block";
                        });
                    }
                    break;
                }
            }
            h.click();
        });
        elem.appendChild(c);
    }
}

var shippingloading = function (isLoading) {
    if (isLoading) {
        document.querySelector("#shippingspinner").classList.remove("hidden");
        document.getElementById("shipping-button-text").classList.add("hidden");
    }
    else {
        document.querySelector("#shippingspinner").classList.add("hidden");
        document.getElementById("shipping-button-text").classList.remove("hidden");
    }
};

