//reset all field of data before add,edit
function resetAllField() {
    $("#myModal-create input[name=active]:first").prop("checked", true);
    $("#myModal-edit select").each(function () {
        $(this).val($(this).find("option").removeAttr("selected"));
    });
    $("#myModal-create select").each(function () {
        $(this).val($(this).find("option:first").val());
    });
    $("#myModal-edit input, #myModal-create input").each(function () {
        $(this).val("");
    });
    $("#myModal-edit textarea, #myModal-create textarea").each(function () {
        $(this).val("");
    });
    $("img[name=view-file]").hide();

    $(".form-group").each(function () {

        $(this).removeClass("has-error");
    });
    $(".form-group .help-block").each(function () {
        $(this).text("");
    });
}

$(document).on("click", "#btn-add", function () {
    resetAllField();
});
$(document).on("click", "#btn-create", function () {
    var keyword;
    $TenBo = $("#myModal-create input[name=TenBo]");
    $IDLop = $("#myModal-create select[name=TenLop] option:selected");
    var formData = new FormData();
    formData.append('TenBo', $TenBo.val());
    formData.append('IDLop', $IDLop.val());
    if (CheckFullName($TenBo)) {
        showLoadingScreen();
        $.ajax({
            url: '/admin/Ho/AddHo',
            type: 'post',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                $.ajax({
                    url: '/admin/Ho/_PartialHo',
                    data: {
                    },
                    beforeSend: function () {

                    },
                    success: function (res) {
                        hideLoadingScreen();
                        $('.partial-view').html(res);
                        alertModalMini("Thêm thành công", "success");
                    },
                    error: function () {
                        alertModalMini("Đã có lỗi xảy ra ", "error");
                    }
                })

            },
            error: function () {
                alertModalMini("Đã có lỗi xảy ra ", "error");
            },
        });

        $("#myModal-create").modal("hide");
    }
});
$(document).on("click", "#btn-search", function () {
    keyword = $("#search-input").val().trim();
    showLoadingScreen();
    $.ajax({
        url: '/admin/Ho/_PartialHo',
        type: 'get',
        data: {
            keyword: keyword
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
var ID;
$(document).on("click", "#btn-edit", function () {
    resetAllField();

    ID = $(this).parents("tr").prop("id");
    var TenBo = $(this).parents("tr").find("td[name=TenBo]").text();
    $("#myModal-edit input[name=TenBo]").val(TenBo);
    var IDLop = $(this).parents("tr").find("td[name=TenLop]").attr("value");
    $("#myModal-edit select[name=TenLop] option[value=" + IDLop + "]").prop("selected", "selected");
});
$(document).on("click", "#save-edit", function () {

    $TenBo = $("#myModal-edit input[name=TenBo]");
    $IDLop = $("#myModal-edit select[name=TenLop] option:selected");
    var formData = new FormData();
    formData.append('id', ID);
    formData.append('TenBo', $TenBo.val());
    formData.append('IDLop', $IDLop.val());
    if (CheckFullName($TenBo)) {
        showLoadingScreen();

        $.ajax({
            url: '/admin/Ho/EditHo',
            type: 'post',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                $.ajax({
                    url: '/admin/Ho/_PartialHo',
                    data: {
                    },
                    beforeSend: function () {

                    },
                    success: function (res) {
                        hideLoadingScreen();
                        $('.partial-view').html(res);
                        alertModalMini("Chỉnh sửa thành công", "success");
                    },
                    error: function () {
                        alertModalMini("Đã có lỗi xảy ra ", "error");
                    }
                })

            },
            error: function () {
                alertModalMini("Đã có lỗi xảy ra ", "error");
            },
        });

        $("#myModal-edit").modal("hide");
    }

});

$(document).on("click", "#btn-delete", function () {
    ID = $(this).parents("tr").prop("id");
});
$(document).on("click", "#btnYes", function () {
    var page = $(".pagination .active a").text();
    var formData = new FormData();
    formData.append('id', ID);
    showLoadingScreen();
    $.ajax({
        url: '/admin/Ho/DeleteHo',
        type: 'post',
        contentType: false,
        processData: false,
        data: formData,
        success: function (data) {
            if (data.status == "SUCCESS") {
                $.ajax({
                    url: '/admin/Ho/_PartialHo',
                    data: {
                        page: page
                    },
                    beforeSend: function () {

                    },
                    success: function (res) {
                        hideLoadingScreen();
                        $('.partial-view').html(res);
                        alertModalMini("Xóa thành công", "success");
                    },
                    error: function () {
                        alertModalMini("Đã có lỗi xảy ra ", "error");
                    }
                })
            } else {
                hideLoadingScreen();
                alertModalMini("Không thể xóa vì họ này có chứa các thực vật.", "error");
            }
        
        },
        error: function () {
            alertModalMini("Đã có lỗi xảy ra ", "error");
        },
    });

    $("#myModal-delete").modal("hide");

});

function CheckFullName(fullname) {
    var check = true;
    var error = 0;
    var name = fullname.val().trim();
    var $messageError = fullname.parents(".form-group").find(".help-block");
    var $formGroup = fullname.parents(".form-group");
    if (name.length == 0) {
        check = false;
        error = 1;

    } else if (name.length > 100) {
        check = false;
        error = 2;
    }

    switch (error) {
        case 0: {
            $messageError.text("");
            break;
        }
        case 1: {
            $messageError.text("Tên bộ không được để trống!");
            break;
        }
        case 2: {
            $messageError.text("Tên bộ quá 100 kí tự!");
            break;
        }
        default: {
            $messageError.text("");
        }
    }
    if (check == false) {
        $formGroup.addClass("has-error-occurr");


    } else {
        $formGroup.removeClass("has-error-occurr");
    }
    return check;
}

