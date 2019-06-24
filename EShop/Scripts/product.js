$(document).ready(function() {

    // buy button click
    $('#add-to-cart').click(function () {
        // get product data
        var sizesSelect = document.getElementById("sizesSelect");
        var product = {
            id: document.getElementById("data-id").getAttribute("data-id"),
            sizeId: sizesSelect.options[sizesSelect.selectedIndex].value
        }

        // save to cart
        var cartProductsJson = localStorage.getItem('cartProducts');

        if (cartProductsJson == null || cartProductsJson == '') {
            localStorage.setItem('cartProducts', JSON.stringify(product));
            document.getElementById('pruduct-in-cart').style.display = 'block';
            console.log(1);
        } else {
            console.log(2);
            var cartProducts = JSON.parse(cartProductsJson);
            var inStorage = false;

            for (var i = 0; i < cartProducts.length; i++) {
                if (cartProducts[i].id == product.id) {
                    inStorage = true;
                    break;
                }
            }

            if (!Array.isArray(cartProducts)) {
                inStorage = cartProducts.id == product.id
                if (!inStorage) {
                    cartProducts = [cartProducts]
                }
            }

            if (!inStorage) {
                console.log(3);
                cartProducts.push(product);
                // show buy message
                document.getElementById('pruduct-in-cart').style.display = 'block';
            }

            localStorage.setItem('cartProducts', JSON.stringify(cartProducts));
        }

        // hide buy message
        setTimeout(function () {
            document.getElementById('pruduct-in-cart').style.display = 'none';
        }, 5000);
    })
})