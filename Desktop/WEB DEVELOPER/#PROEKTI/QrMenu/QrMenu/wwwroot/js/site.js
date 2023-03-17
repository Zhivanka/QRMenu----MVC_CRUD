// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function autoFillPass() {

    var cookie = document.cookie;
    var allcookies = cookie.split(";");
    for (var item = 0; item < allcookies.length; item++) {

        var cookieItem = allcookies[item];
        var str = cookieItem.split("=");
        if (str[0].trim() == document.getElementByClass("form-check").value.trim()) {
            break;

        }

    }

}
