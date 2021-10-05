var x, i, j, l, ll, selElmnt, a, b, c;
x = document.getElementsByClassName("custom-list");
l = x.length;

var elem = document.getElementById("custom-list-options");
var button = document.getElementById("custom-list-button");
var shippingdelivery_type = document.getElementById("shipping-delivery-type");
var shippingdelivery_price = document.getElementById("shipping-delivery-price");
var parcelshop_Number = document.getElementById("parcelshop-Number");
var parcelshop_CompanyName = document.getElementById("parcelshop-CompanyName");
var parcelshop_StreetName = document.getElementById("parcelshop-StreetName");
var parcelshop_StreetName2 = document.getElementById("parcelshop-StreetName2");
var parcelshop_ZipCode = document.getElementById("parcelshop-ZipCode");
var parcelshop_CityName = document.getElementById("parcelshop-CityName");
var parcelshop_CountryCode = document.getElementById("parcelshop-CountryCode");
var parcelshop_CountryCodeISO3166A2 = document.getElementById("parcelshop-CountryCodeISO3166A2");
var nearby_shops = document.getElementById("nearby-shops");
var nearby_shops_modal = document.getElementById('nearby-shops-modal');

button.disabled = true;

for (i = 0; i < l; i++) {
    selElmnt = x[i].getElementsByTagName("select")[0];
    ll = selElmnt.length;
    for (j = 1; j < ll; j++) {
        c = document.createElement("div");
        c.setAttribute("class", "custom-list-option notselected");
        c.textContent = selElmnt.options[j].textContent;

        c.addEventListener("click", function (e) {
            var y, i, k, select, h, selectlength, yl;
            select = this.parentNode.parentNode.getElementsByTagName("select")[0];
            selectlength = select.length;
            h = this.parentNode.previousSibling;
            for (i = 1; i < selectlength; i++) {
                if (select.options[i].textContent == this.textContent) {
                    select.selectedIndex = i;
                    if (this.textContent.includes("Home")) {
                        shippingdelivery_type.value = 'Home';
                        shippingdelivery_price.value = 65;
                    }
                    else {
                        shippingdelivery_type.value = 'Shop';
                        shippingdelivery_price.value = 0;
                    }
                    
                    button.disabled = false;
                    y = this.parentNode.getElementsByClassName("custom-list-option selected");
                    yl = y.length;
                    for (k = 0; k < yl; k++) {
                        y[k].setAttribute("class", "custom-list-option notselected");
                    }
                    this.setAttribute("class", "custom-list-option selected");

                    if (this.textContent.includes('Shop')) {
                        fetch('/checkout/GetNearbyShopsJson?Street=' + shippingaddress_address.value + '&ZipCode=' + shippingaddress_postal.value + '&CountryIso=DK&Amount=5'
                        ).then(function (result) {
                            result.json().then(function (json) {
                                for (var t = 0; t < json.parcelshops.length; t++) {
                                    a = document.createElement("div");
                                    a.setAttribute("class", "shop");

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.textContent = json.parcelshops[t].companyName;
                                    a.appendChild(b);

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.textContent = json.parcelshops[t].streetname;
                                    a.appendChild(b);

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.textContent = json.parcelshops[t].streetname2;
                                    a.appendChild(b);

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.textContent = json.parcelshops[t].zipCode;
                                    a.appendChild(b);

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.textContent = json.parcelshops[t].cityName;
                                    a.appendChild(b);

                                    b = document.createElement("label");
                                    b.setAttribute("class", "shop-label");
                                    b.textContent = json.parcelshops[t].countryCodeISO3166A2;
                                    a.appendChild(b);

                                    a.addEventListener("click", function (e) {
                                        //parcelshop_Number.value = 
                                        //parcelshop_CompanyName
                                        //parcelshop_StreetName
                                        //parcelshop_StreetName2
                                        //parcelshop_ZipCode
                                        //parcelshop_CityName
                                        //parcelshop_CountryCode
                                        //parcelshop_CountryCodeISO3166A2
                                        nearby_shops_modal.style.display = "none";
                                    });

                                    nearby_shops.appendChild(a);
                                }

                                nearby_shops_modal.style.display = "block";
                            })
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



