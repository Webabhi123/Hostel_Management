// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.chat_icon').click(function (event) {
        $('.chat-box').toggleClass('active');
    });
    $('.conv-form-wrapper').convform({ selectInputStyle: 'disable' });
})