document.addEventListener('DOMContentLoaded', function () {
    [].forEach.call(document.querySelectorAll('.filter-item'), function (el) {
        el.addEventListener('click', function () {
            this.querySelector('input').checked = true;
        })
    })
})