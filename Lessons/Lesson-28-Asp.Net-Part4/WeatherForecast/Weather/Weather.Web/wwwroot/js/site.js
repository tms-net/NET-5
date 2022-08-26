// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    var input = document.querySelector("#search-box");
    var button = document.querySelector("#search-button");

    button.onclick = function () {

        //debugger;

        if (input.value) { // "" ~ false
            location.href = "/?search=" + input.value;
        }
    }

});
