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
    $TieuDe = $("#myModal-create input[name=title]");
    $DanNhap = $("#myModal-create textarea[name=input]");
    $NoiDung = CKEDITOR.instances['content'];
    var fileUpload = $("#file").get(0).files;
    var formData = new FormData();
    formData.append('TieuDe', $TieuDe.val());
    formData.append('DanNhap', $DanNhap.val());
    formData.append('NoiDung', $NoiDung.getData());
    formData.append('cv', fileUpload[0]);
    if (CheckFullName($TieuDe) & CheckFullName2($DanNhap)&CheckIsValidForCKEDITOR($("#content"))) {
        showLoadingScreen();
        $.ajax({
            url: '/admin/New/AddNew',
            type: 'post',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                $.ajax({
                    url: '/admin/New/_PartialNew',
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
        url: '/admin/New/_PartialNew',
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
var path;
$(document).on("click", "#btn-edit", function () {
    resetAllField();
    ID = $(this).parents("tr").prop("id");
    var title = $(this).parents("tr").find("td[name=title]").text();
    $("#myModal-edit input[name=title]").val(title);
    var input = $(this).parents("tr").find("td[name=input]").text();
    $("#myModal-edit textarea[name=input]").val(input);
    var content = $(this).parents("tr").find("td[name=content]").html();
    CKEDITOR.instances['content-edit'].setData(content);
    path = $(this).parents("tr").find("td[name=path] img").attr("src");
    $("#myModal-edit img[name=view-file-edit]").attr("src", path);
});
$(document).on("click", "#save-edit", function () {

    $TieuDe = $("#myModal-edit input[name=title]");
    $DanNhap = $("#myModal-edit textarea[name=input]");
    $NoiDung = CKEDITOR.instances['content-edit'];
    var fileUpload = $("#file-edit").get(0).files;
    var formData = new FormData();
    formData.append('id', ID);
    formData.append('TieuDe', $TieuDe.val());
    formData.append('DanNhap', $DanNhap.val());
    formData.append('NoiDung', $NoiDung.getData());
    formData.append('path', path);
    formData.append('cv', fileUpload[0]);
    if (CheckFullName($TieuDe) & CheckFullName2($DanNhap) & CheckIsValidForCKEDITOR($("#content-edit"))){
        showLoadingScreen();

        $.ajax({
            url: '/admin/New/EditNew',
            type: 'post',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                $.ajax({
                    url: '/admin/New/_PartialNew',
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
        url: '/admin/New/DeleteNew',
        type: 'post',
        contentType: false,
        processData: false,
        data: formData,
        success: function (data) {

            $.ajax({
                url: '/admin/New/_PartialNew',
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
        },
        error: function () {
            alertModalMini("Đã có lỗi xảy ra ", "error");
        },
    });

    $("#myModal-delete").modal("hide");

});
$(document).on("change", "#file", function () {
    var allowedExtensions = /(\.jpg|\.bmg|\.png|\.gif)$/i;
    var fileUpload = $(this).get(0);
    var files = fileUpload.files;
    if (fileUpload.files.length > 0 && !allowedExtensions.exec(fileUpload.value)) {
        alertModalMini('Không đúng định dạng ảnh', 'error');
        $("#file").val("");
    }
    else {
        var reader = new FileReader();
        reader.onload = function (e) {
            $("#myModal-create img[name =view-file]").attr("src", e.target.result);
            $("#myModal-create img[name =view-file]").show();

        }
        reader.readAsDataURL(this.files[0]);
    }
});

$(document).on("click", "img[name=view-file-edit]", function () {
    $("#file-edit").trigger("click");
    $(document).on("change", "#file-edit", function () {
        var allowedExtensions = /(\.jpg|\.bmg|\.png|\.gif)$/i;
        var fileUpload = $(this).get(0);
        var files = fileUpload.files;
        if (fileUpload.files.length > 0 && !allowedExtensions.exec(fileUpload.value)) {
            alertModalMini('Không đúng định dạng ảnh', 'error');
            $("#file-edit").val("");
        }
        else {
            var reader = new FileReader();
            reader.onload = function (e) {
                $("#myModal-edit img[name=view-file-edit]").attr("src", e.target.result);

            }
            reader.readAsDataURL(this.files[0]);
        }
    });
})
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
            $messageError.text("Tên tiêu đề không được để trống!");
            break;
        }
        case 2: {
            $messageError.text("Tên tiêu đề quá 100 kí tự!");
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
function CheckFullName2(fullname) {
    var check = true;
    var error = 0;
    var name = fullname.val().trim();
    var $messageError = fullname.parents(".form-group").find(".help-block");
    var $formGroup = fullname.parents(".form-group");
    if (name.length == 0) {
        check = false;
        error = 1;

    } else if (name.length > 1000) {
        check = false;
        error = 2;
    }

    switch (error) {
        case 0: {
            $messageError.text("");
            break;
        }
        case 1: {
            $messageError.text("Dẫn nhập không được để trống!");
            break;
        }
        case 2: {
            $messageError.text("Dẫn nhập quá 1000 kí tự!");
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
function CheckIsValidForCKEDITOR(obj) {

    var check = true;
    var error = 0;
    var name = obj.parents(".form-group").find("iframe").contents().find("body").text().trim();
    var length = obj.parents(".form-group").find("iframe").contents().find("body").length;
    var $messageError = obj.parents(".form-group").find(".help-block");
    var $formGroup = obj.parents(".form-group");
    if (length == 1 && name.length == 0) {
        check = false;
        error = 1;
    }

    switch (error) {
        case 0: {
            $messageError.text("");

            break;
        }
        case 1: {
            $messageError.text("Nội dung không được để trống");
        }

    }
    if (check == false) {

        $formGroup.addClass("has-error-occurr");

    } else {
        $formGroup.removeClass("has-error-occurr");
    }
    return check;
}


