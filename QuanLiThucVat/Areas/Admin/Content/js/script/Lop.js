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
    $TenLop = $("#myModal-create input[name=TenLop]");
    var formData = new FormData();
    formData.append('TenLop', $TenLop.val());    
    if (CheckFullName($TenLop)) {
        showLoadingScreen();
        $.ajax({
            url: '/admin/Bo/AddBo',
            type: 'post',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                $.ajax({
                    url: '/admin/Bo/_PartialBo',
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
        url: '/admin/Bo/_PartialBo',
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
    var TenLop = $(this).parents("tr").find("td[name=TenLop]").text();
    $("#myModal-edit input[name=TenLop]").val(TenLop);
});
$(document).on("click", "#save-edit", function () {

    $TenLop = $("#myModal-edit input[name=TenLop]");    
    var formData = new FormData();
    formData.append('id', ID);
    formData.append('TenLop', $TenLop.val()); 
    if (CheckFullName($TenLop)) {
        showLoadingScreen();

        $.ajax({
            url: '/admin/Bo/EditBo',
            type: 'post',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                $.ajax({
                    url: '/admin/Bo/_PartialBo',
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
        url: '/admin/Bo/DeleteBo',
        type: 'post',
        contentType: false,
        processData: false,
        data: formData,
        success: function (data) {
            if (data.status =="SUCCESS") {

                $.ajax({
                    url: '/admin/Bo/_PartialBo',
                    data: {
                        page: page
                    },
                    beforeSend: function () {

                    },
                    success: function (res) {
                        hideLoadingScreen();
                        $('.partial-view').html(res);
                        if (res.status = "SUCCESS") {
                            alertModalMini("Xóa thành công", "success");
                        }

                    },
                    error: function () {
                        alertModalMini("Đã có lỗi xảy ra ", "error");
                    }
                })
            } else {
                hideLoadingScreen();
                alertModalMini("Không thể xóa vì bộ này có chứa các họ.", "error");
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
            $messageError.text("Tên lớp không được để trống!");
            break;
        }
        case 2: {
            $messageError.text("Tên lớp quá 100 kí tự!");
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

