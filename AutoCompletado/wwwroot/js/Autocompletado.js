$(document).ready(function () {
    $("#nombre").autocomplete({
        source: '@Url.Action("ListaNombre", "Home")',
        minlength: 2
    });
});