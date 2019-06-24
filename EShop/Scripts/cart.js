$(document).ready(function () {
    var cartProducts = JSON.parse(localStorage.getItem('cartProducts'));

    if (cartProducts != null || cartProducts != '') {
        $.ajax({
            type: "POST",
            data: { cartProducts: cartProducts },
            url: '/Home/CartProducts/',
            success: function (data) {
                var total = 0;
                // create product bloks
                data.forEach(function (element) {
                    total += element.Price
                    var productBlock = `
                        <div class="cart-list__item">
                            <div class="cart-list__item-photo" id="product-picture">
                                <img src=/Pictures/` + element.PictureName + ` />
                            </div>
                            <div class="cart-list__item-info">
                                <div class="tag-list">
                                    <span class="icon-tag icon"></span>
                                    <span>Размер: ` + element.Sizes[0].Name + `</span>
                                </div>
                                <div class="name">
                                    <span>` + element.Name + `</span>
                                </div>

                                <div class="action">
                                    <div class="count">
                                        <div class="count__item count__item_minus">-</div>
                                        <div class="count__item count__item_number">1</div>
                                        <div class="count__item count__item_plus">+</div>
                                    </div>
                                    <div class="price">
                                        <span>` + element.Price + ` грн</span>
                                    </div>
                                </div>
                            </div>

                            <div class="delete">+</div>
                        </div>`;

                    $('#cart-list').append(productBlock);
                });

                document.querySelector('.cart-panel__item-total span').innerHTML = total + ' грн';

                $('.count__item_minus').click(function () {
                    var numberDiv = this.parentNode.querySelector('.count__item_number');
                    var number = parseInt(numberDiv.innerText, 10);

                    if (number > 1) {
                        numberDiv.innerText = --number;
                        var actionDiv = numberDiv.parentNode.parentNode;

                        var price = parseFloat(actionDiv.querySelector('.price span').innerText);
                        var difference = price / (number + 1);

                        var totalBlock = document.querySelector('.cart-panel__item-total span');
                        var total = parseFloat(totalBlock.innerText) - difference + ' грн';

                        var productTotal = parseFloat(actionDiv.querySelector('.price span').innerText) - difference;
                        actionDiv.querySelector('.price span').innerText = productTotal + ' грн';

                        totalBlock.innerText = total;
                    }
                })

                $('.count__item_plus').click(function () {
                    var numberDiv = this.parentNode.querySelector('.count__item_number');
                    var number = parseInt(numberDiv.innerText, 10);
                    
                    numberDiv.innerText = ++number;
                    var actionDiv = numberDiv.parentNode.parentNode;

                    var price = parseFloat(actionDiv.querySelector('.price span').innerText);
                    var difference = price / (number - 1);
                    
                    var totalBlock = document.querySelector('.cart-panel__item-total span');
                    var total = parseFloat(totalBlock.innerText) + difference + ' грн';
                    var productTotal = parseFloat(actionDiv.querySelector('.price span').innerText) + difference;
                    actionDiv.querySelector('.price span').innerText = productTotal + ' грн';

                    totalBlock.innerText = total;
                })
            }
        });
    }
})


//function getTotalPrice() {
//    var productBlocks = document.querySelectorAll('.cart-list__item');
//    productBlocks.forEach(function (element) {
//        var price = parseFloat(element.querySelector('.price span').innerText);
//        console.log('price: ' + price);
//    });
//}