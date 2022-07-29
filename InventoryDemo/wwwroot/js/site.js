// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var globalIsCoveredList;

function closeProductModal() {
    $("#product-modal").modal("hide");
    
}
function closeCustomerModal() {
    $("#customer-modal").modal("hide");
}

function showCustomerModal() {
    $('#customer-modal').modal("show");
}

function showProductModal() {
    $('#product-modal').modal("show");
}

function EnableProductBoxes(i) {
    var productIsPurchased = document.getElementById("Products_" + i + "__IsPurchased");
    var productInstock = document.getElementById("Products_" + i + "__Instock");
    var productInstockWeight = document.getElementById("Products_" + i + "__InstockWeight");

    if (productIsPurchased.checked) {
        productInstock.removeAttribute("disabled");
        productInstockWeight.removeAttribute("disabled");
    }
    else {
        productInstock.disabled = "true";
        productInstockWeight.disabled = "true";
    }
}

/*function showProductModal(c) {
    var len = c.length;
    globalIsCoveredList = c;
    for (var i = 0; i < len; i++) {
        EnableBox(i);
    }
    $('#myModal').modal("show");

}

function EnableBox(i) {
    var _check = document.getElementById("CoveredModules_" + i + "__IsCovered");
    var _textbox = document.getElementById("CoveredModules_" + i + "__Percentage");

    if (globalIsCoveredList[i] == "True" || _check.checked) {
        _textbox.removeAttribute("disabled");
    }
    else {
        _textbox.disabled = "true";
    }
}*/
