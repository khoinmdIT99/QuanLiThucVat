//var keyword;
//$(document).on("click", "#btn-search", function () {
//    var keyword = $("#search-input").val().trim();
//    var item = item = getUrlParameter('item');
//    showLoadingScreen();
//    $.ajax({
//        url: '/admin/BangXepHang/_PartialCacPhuongPhap',
//        type: 'get',
//        data: {
//            keyword: keyword,
//            item:item
//        },
//        success: function (data) {
//            hideLoadingScreen();
//            $('.partial-view').html(data);

//        },
//        error: function () {
//            alertModalMini("Đã có lỗi xảy ra ", "error");
//        },
//    });

//});

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};