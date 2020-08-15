//$(document).on("click", "#search", function () {
//    keyword = $("#search-input").val().trim();

//    showLoadingScreen();
//    $.ajax({
//        url: '/XepHang/_PartialIndex',
//        type: 'get',
//        data: {
//            keyword: keyword
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
function showLoadingScreen() {
    $('body').addClass('loading');
}

function hideLoadingScreen() {
    $('body').removeClass('loading');
}
//function alertModalMini(message, type) {
//    $('#alertModalMini .modal-body').html(message);
//    if (!type) {
//        //do nothing
//    } else if (type == 'error') {
//        $('#alertModalMini .modal-body').css('color', 'red');
//    } else if (type == 'success') {
//        $('#alertModalMini .modal-body').css('color', 'green');
//    } else {
//        $('#alertModalMini .modal-body').css('color', type);
//    }
//    $('#alertModalMini').modal('show');
//}

var keyword;
$(document).on("click", "#search", function () {
    var keyword = $("#search-input").val().trim();
    var tc1 = $("form input[name=tc1]").prop("checked");
    var tc2 = $("form input[name=tc2]").prop("checked");
    var tc3 = $("form input[name=tc3]").prop("checked");
    var tc4 = $("form input[name=tc4]").prop("checked");
    var tc5 = $("form input[name=tc5]").prop("checked");
    var tc6 = $("form input[name=tc6]").prop("checked");
    var tc7 = $("form input[name=tc7]").prop("checked");
    var tc8 = $("form input[name=tc8]").prop("checked");
    var tc9 = $("form input[name=tc9]").prop("checked");
    var tc10 = $("form input[name=tc10]").prop("checked");
    var tc11 = $("form input[name=tc11]").prop("checked");
    showLoadingScreen();
    $.ajax({
        url: '/XepHang/_PartialIndex',
        type: 'get',
        data: {
            keyword: keyword,
            tc1: tc1,
            tc2: tc2,
            tc3: tc3,
            tc4: tc4,
            tc5: tc5,
            tc6: tc6,
            tc7: tc7,
            tc8: tc8,
            tc9: tc9,
            tc10: tc10,
            tc11: tc11,
        },
        success: function (data) {
            hideLoadingScreen();
            $('.partial-view').html(data);

        },
        error: function () {
            alert("loi");
        },
    });

});
$(document).on("click", "#btn-apply", function () {
    keyword = $("#search-input").val().trim();

    var tc1 = $("form input[name=tc1]").prop("checked");
    var tc2 = $("form input[name=tc2]").prop("checked");
    var tc3 = $("form input[name=tc3]").prop("checked");
    var tc4 = $("form input[name=tc4]").prop("checked");
    var tc5 = $("form input[name=tc5]").prop("checked");
    var tc6 = $("form input[name=tc6]").prop("checked");
    var tc7 = $("form input[name=tc7]").prop("checked");
    var tc8 = $("form input[name=tc8]").prop("checked");
    var tc9 = $("form input[name=tc9]").prop("checked");
    var tc10 = $("form input[name=tc10]").prop("checked");
    var tc11 = $("form input[name=tc11]").prop("checked");

    showLoadingScreen();
    $.ajax({
        url: '/XepHang/_PartialIndex',
        type: 'get',
        data: {
            keyword: keyword,
            tc1: tc1,
            tc2: tc2,
            tc3: tc3,
            tc4: tc4,
            tc5: tc5,
            tc6: tc6,
            tc7: tc7,
            tc8: tc8,
            tc9: tc9,
            tc10: tc10,
            tc11: tc11,
        },
        success: function (data) {
            hideLoadingScreen();
            $('.partial-view').html(data);

        },
        error: function () {
            alert("loi");
        },
    });

});