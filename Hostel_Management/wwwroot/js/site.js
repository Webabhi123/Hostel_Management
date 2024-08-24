// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#pricing_size_item_by_id").addClass('active');
    var planName = $("#pricing_size_item_by_id").data('plan');
    var plansize = $("#pricing_size_item_by_id").data('unit');
    var planprice = $("#pricing_size_item_by_id").data('price');

    // Update the pricing header and body with the selected plan
    $('.pricing_plan_name').text(planName);
    $('.pricing_plan_size').text(plansize);
    $('.pricing_body_price').text(planprice);
    $('.chat_icon').click(function (event) {
        $('.chat-box').toggleClass('active');
    });
    $('.conv-form-wrapper').convform({ selectInputStyle: 'disable' });

    $('.pricing_size_item').on('click', function () {
        $('.pricing_size_item').removeClass('active');
        $(this).addClass('active');

        // Get the plan name and price from the clicked item
        var planName = $(this).data('plan');
        var plansize = $(this).data('unit');
        var planprice = $(this).data('price');

        // Update the pricing header and body with the selected plan
        $('.pricing_plan_name').text(planName);
        $('.pricing_plan_size').text(plansize);
        $('.pricing_body_price').text(planprice);
    });

    //document.querySelectorAll('.pricing_size_item').forEach(item => {
    //    item.addEventListener('click', function () {
    //        document.getElementById('planNameInput').value = this.getAttribute('data-plan');
    //        document.getElementById('priceInput').value = this.getAttribute('data-price');
    //    });
    //});
});


//$(document).ready(function () {
//    $('.pricing_size_item').on('click', function () {
//        $('.pricing_size_item').removeClass('active'); // Remove 'active' class from all items
//        $(this).addClass('active'); // Add 'active' class to the clicked item
//    });
//});
//$(document).ready(function () {
//    $('.pricing_size_item').on('click', function () {
//        $('.pricing_size_item').removeClass('active');
//        $(this).addClass('active');

//        // Get the plan name and price from the clicked item
//        var planName = $(this).data('plan');
//        var planPrice = $(this).data('price');

//        // Update the pricing header and body with the selected plan
//        $('.pricing_plan_name').text(planName);
//        $('.pricing_plan_body').text('Price: ' + planPrice);
//    });
//});
