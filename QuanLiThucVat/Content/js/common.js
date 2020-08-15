$(document).ready(function () {
    $(document).on("click", ".navbar-nav > li", function () {
        $('li').removeClass("active");
        $(this).addClass("active");
    })

})
