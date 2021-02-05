var x, i, j, l, ll, selElmnt, a, b, c;
x = document.getElementsByClassName("shipping-options");
l = x.length;

var elem = document.getElementById("shipping-options");
var header = document.getElementById("shipping-header");
var inputname = document.getElementById("input-shipping-name");
var inputprice = document.getElementById("input-shipping-price");

for (i = 0; i < l; i++) {
    selElmnt = x[i].getElementsByTagName("select")[0];
    ll = selElmnt.length;
    for (j = 1; j < ll; j++) {
        c = document.createElement("div");
        c.setAttribute("class", "shipping-option notselected");
        c.innerHTML = selElmnt.options[j].innerHTML;

        c.addEventListener("click", function (e) {
            var y, i, k, s, h, sl, yl;
            s = this.parentNode.parentNode.getElementsByTagName("select")[0];
            sl = s.length;
            h = this.parentNode.previousSibling;
            for (i = 0; i < sl; i++) {
                if (s.options[i].innerHTML == this.innerHTML) {
                    s.selectedIndex = i;
                    //inputprice.innerHTML = this.innerHTML;
                    header.innerHTML = this.innerHTML;
                    y = this.parentNode.getElementsByClassName("shipping-option selected");
                    yl = y.length;
                    for (k = 0; k < yl; k++) {
                        y[k].setAttribute("class", "shipping-option notselected");
                    }
                    this.setAttribute("class", "shipping-option selected");
                    inputname.value = this.innerHTML;
                    break;
                }
            }
            h.click();
        });
        elem.appendChild(c);
    }
}

