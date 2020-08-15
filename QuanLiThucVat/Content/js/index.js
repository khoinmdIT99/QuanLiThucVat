$(document).on("click", "#btn-apply", function () {
    var tenVietNam = $(".table-fitter input[name=tentiengviet]").val();
    var tenLaTinh = $(".table-fitter input[name=tenlatinh]").val();
    var IDBo = $(".table-fitter select[name=bo]").val();
    var IDHo = $(".table-fitter select[name=ho]").val();

    showLoadingScreen();
    $.ajax({
        url: '/Home/_PartialIndex',
        type: 'get',
        data: {
            tenVietNam: tenVietNam,
            tenLaTinh: tenLaTinh,
            IDBo: IDBo,
            IDHo: IDHo
        },
        success: function (data) {
            hideLoadingScreen();
            $('.partial-view').html(data);

        },
        error: function () {
            alertModalMini("Đã có lỗi xảy ra ", "error");
        },
    });

});

$(document).on("change", "select[name=bo]", function () {
    var id = $(this).val();
    showLoadingScreen();
    $.ajax({
        url: '/Home/getListHoByBoID',
        type: 'get',
        dataType: 'json',
        data: {
         id:id
        },
        success: function (data) {
            console.log(data);
            $("select[name=ho] option").each(function () {
                if ($(this).attr("value") != 0) {
                    $(this).remove();
                }
            })
            var option; 
            for (i = 0; i < data.length;i++)
            {
                option += '<option value="' + data[i].ID + '">' + data[i].TenHo+'</option>'
            }
            $("select[name=ho]").append(option);
        },
        error: function () {
            alertModalMini("Đã có lỗi xảy ra ", "error");
        },
    });
});
function showLoadingScreen() {
    $('body').addClass('loading');
}

function hideLoadingScreen() {
    $('body').removeClass('loading');
}
function alertModalMini(message, type) {
    $('#alertModalMini .modal-body').html(message);
    if (!type) {
        //do nothing
    } else if (type == 'error') {
        $('#alertModalMini .modal-body').css('color', 'red');
    } else if (type == 'success') {
        $('#alertModalMini .modal-body').css('color', 'green');
    } else {
        $('#alertModalMini .modal-body').css('color', type);
    }
    $('#alertModalMini').modal('show');
}