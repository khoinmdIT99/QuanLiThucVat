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
    $nameTV = $("#myModal-create input[name=nameTV]");
    $nameLT = $("#myModal-create input[name=nameLT]");
    $description = $("#myModal-create textarea[name=description]");
    $DoDayLa = $("#myModal-create input[name=DoDayLa]");
    $DoDayVo = $("#myModal-create input[name=DoDayVo]");
    $LuongNuocTrongLa = $("#myModal-create input[name=LuongNuocTrongLa]");
    $LuongNuocTrongVo = $("#myModal-create input[name=LuongNuocTrongVo]");
    $LuongTroThoTrongLa = $("#myModal-create input[name=LuongTroThoTrongLa]");
    $LuongTroThoTrongVo = $("#myModal-create input[name=LuongTroThoTrongVo]");
    $ThoiGianChayTrenLa = $("#myModal-create input[name=ThoiGianChayTrenLa]");
    $ThoiGianChayTrenVo = $("#myModal-create input[name=ThoiGianChayTrenVo]");
    $growth = $("#myModal-create select[name=growth] option:selected");
    $reborn = $("#myModal-create select[name=reborn] option:selected");
    $economy = $("#myModal-create select[name=economy] option:selected");
    $IDBo = $("#myModal-create select[name=IDBo] option:selected");
    var fileUpload = $("#file").get(0).files;
    var formData = new FormData();
    formData.append('nameTV', $nameTV.val());
    formData.append('nameLT', $nameLT.val());
    formData.append('description', $description.val());
    formData.append('DoDayLa', $DoDayLa.val());
    formData.append('DoDayVo', $DoDayVo.val());
    formData.append('LuongNuocTrongLa', $LuongNuocTrongLa.val());
    formData.append('LuongNuocTrongVo', $LuongNuocTrongVo.val());
    formData.append('LuongTroThoTrongLa', $LuongTroThoTrongLa.val());
    formData.append('LuongTroThoTrongVo', $LuongTroThoTrongVo.val());
    formData.append('ThoiGianChayTrenLa', $ThoiGianChayTrenLa.val());
    formData.append('ThoiGianChayTrenVo', $ThoiGianChayTrenVo.val());
    formData.append('growth', $growth.val());
    formData.append('reborn', $reborn.val());
    formData.append('economy', $economy.val());
    formData.append('IDBo', $IDBo.val());
    formData.append('cv', fileUpload[0]);
   
    if (CheckName($nameTV, "tiếng việt") & CheckName($nameLT, "la tinh") & CheckDescription($description) 
        & CheckNumber($DoDayLa, "Độ dày lá") & CheckNumber($DoDayVo, "Độ dày vỏ") & CheckNumber($LuongNuocTrongLa, "Lượng nước trong lá") 
        & CheckNumber($LuongNuocTrongVo, "Lượng nước trong vỏ") & CheckNumber($LuongTroThoTrongLa, "Lượng tro thô trong lá") 
         & CheckNumber($LuongTroThoTrongVo, "Lượng tro thô trong vỏ") & CheckNumber($ThoiGianChayTrenLa, "Thời gian cháy trên lá")
        & CheckNumber($ThoiGianChayTrenVo, "Thời gian cháy trên vỏ")) {
        showLoadingScreen();

    $.ajax({
        url: '/admin/ThucVat/AddThucVat',
        type: 'post',
        contentType: false,
        processData: false,
        data: formData,
        success: function (data) {
            $.ajax({
                url: '/admin/ThucVat/_PartialThucVat',
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
        url: '/admin/ThucVat/_PartialThucVat',
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
    var nameTV = $(this).parents("tr").find("td[name=nameTV]").text();
    $("#myModal-edit input[name=nameTV]").val(nameTV);
    var nameLT = $(this).parents("tr").find("td[name=nameLT]").text();
    $("#myModal-edit input[name=nameLT]").val(nameLT);
    var description = $(this).parents("tr").find("td[name=description]").text();
    $("#myModal-edit textarea[name=description]").val(description);
    var DoDayLa = $(this).parents("tr").find("td[name=DoDayLa]").text();
    $("#myModal-edit input[name=DoDayLa]").val(DoDayLa);
    var DoDayVo = $(this).parents("tr").find("td[name=DoDayVo]").text();
    $("#myModal-edit input[name=DoDayVo]").val(DoDayVo);
    var LuongNuocTrongLa = $(this).parents("tr").find("td[name=LuongNuocTrongLa]").text();
    $("#myModal-edit input[name=LuongNuocTrongLa]").val(LuongNuocTrongLa);
    var LuongNuocTrongVo = $(this).parents("tr").find("td[name=LuongNuocTrongVo]").text();
    $("#myModal-edit input[name=LuongNuocTrongVo]").val(LuongNuocTrongVo);
    var LuongTroThoTrongLa = $(this).parents("tr").find("td[name=LuongTroThoTrongLa]").text();
    $("#myModal-edit input[name=LuongTroThoTrongLa]").val(LuongTroThoTrongLa);
    var LuongTroThoTrongVo = $(this).parents("tr").find("td[name=LuongTroThoTrongVo]").text();
    $("#myModal-edit input[name=LuongTroThoTrongVo]").val(LuongTroThoTrongVo);
    var ThoiGianChayTrenLa = $(this).parents("tr").find("td[name=ThoiGianChayTrenLa]").text();
    $("#myModal-edit input[name=ThoiGianChayTrenLa]").val(ThoiGianChayTrenLa);
    var ThoiGianChayTrenVo = $(this).parents("tr").find("td[name=ThoiGianChayTrenVo]").text();
    $("#myModal-edit input[name=ThoiGianChayTrenVo]").val(ThoiGianChayTrenVo);
    var growth = $(this).parents("tr").find("td[name=growth]").attr("value");
    $("#myModal-edit select[name=growth] option[value=" + growth + "]").prop("selected", "selected");
    var reborn = $(this).parents("tr").find("td[name=reborn]").attr("value");
    $("#myModal-edit select[name=reborn] option[value=" + reborn + "]").prop("selected", "selected");
    var economy = $(this).parents("tr").find("td[name=economy]").attr("value");
    $("#myModal-edit select[name=economy] option[value=" + economy + "]").prop("selected", "selected");
    var IDBo = $(this).parents("tr").find("td[name=IDBo]").attr("value");
    $("#myModal-edit select[name=IDBo] option[value=" + IDBo + "]").prop("selected", "selected");
    var path = $(this).parents("tr").find("td[name=path] img").attr("src");
    $("#myModal-edit img[name=view-file-edit]").attr("src", path);
});
$(document).on("click", "#save-edit", function () {

    $nameTV = $("#myModal-edit input[name=nameTV]");
    $nameLT = $("#myModal-edit input[name=nameLT]");
    $description = $("#myModal-edit textarea[name=description]");
    $DoDayLa = $("#myModal-edit input[name=DoDayLa]");
    $DoDayVo = $("#myModal-edit input[name=DoDayVo]");
    $LuongNuocTrongLa = $("#myModal-edit input[name=LuongNuocTrongLa]");
    $LuongNuocTrongVo = $("#myModal-edit input[name=LuongNuocTrongVo]");
    $LuongTroThoTrongLa = $("#myModal-edit input[name=LuongTroThoTrongLa]");
    $LuongTroThoTrongVo = $("#myModal-edit input[name=LuongTroThoTrongVo]");
    $ThoiGianChayTrenLa = $("#myModal-edit input[name=ThoiGianChayTrenLa]");
    $ThoiGianChayTrenVo = $("#myModal-edit input[name=ThoiGianChayTrenVo]");
    $growth = $("#myModal-edit select[name=growth] option:selected");
    $reborn = $("#myModal-edit select[name=reborn] option:selected");
    $economy = $("#myModal-edit select[name=economy] option:selected");
    $IDBo = $("#myModal-edit select[name=IDBo] option:selected");
    var fileUpload = $("#file-edit").get(0).files;
    var formData = new FormData();
    formData.append('id', ID);
    formData.append('nameTV', $nameTV.val());
    formData.append('nameLT', $nameLT.val());
    formData.append('description', $description.val());
    formData.append('DoDayLa', $DoDayLa.val());
    formData.append('DoDayVo', $DoDayVo.val());
    formData.append('LuongNuocTrongLa', $LuongNuocTrongLa.val());
    formData.append('LuongNuocTrongVo', $LuongNuocTrongVo.val());
    formData.append('LuongTroThoTrongLa', $LuongTroThoTrongLa.val());
    formData.append('LuongTroThoTrongVo', $LuongTroThoTrongVo.val());
    formData.append('ThoiGianChayTrenLa', $ThoiGianChayTrenLa.val());
    formData.append('ThoiGianChayTrenVo', $ThoiGianChayTrenVo.val());
    formData.append('growth', $growth.val());
    formData.append('reborn', $reborn.val());
    formData.append('economy', $economy.val());
    formData.append('IDBo', $IDBo.val());
    formData.append('cv', fileUpload[0]);
   
    if (CheckName($nameTV, "tiếng việt") & CheckName($nameLT, "la tinh") & CheckDescription($description)
        & CheckNumber($DoDayLa, "Độ dày lá") & CheckNumber($DoDayVo, "Độ dày vỏ") & CheckNumber($LuongNuocTrongLa, "Lượng nước trong lá")
        & CheckNumber($LuongNuocTrongVo, "Lượng nước trong vỏ") & CheckNumber($LuongTroThoTrongLa, "Lượng tro thô trong lá")
        & CheckNumber($LuongTroThoTrongVo, "Lượng tro thô trong vỏ") & CheckNumber($ThoiGianChayTrenLa, "Thời gian cháy trên lá")
        & CheckNumber($ThoiGianChayTrenVo, "Thời gian cháy trên vỏ")) {
        showLoadingScreen();
        $.ajax({
            url: '/admin/ThucVat/EditThucVat',
            type: 'post',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                $.ajax({
                    url: '/admin/ThucVat/_PartialThucVat',
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
        url: '/admin/ThucVat/DeleteThucVat',
        type: 'post',
        contentType: false,
        processData: false,
        data: formData,
        success: function (data) {

            $.ajax({
                url: '/admin/ThucVat/_PartialThucVat',
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
        $("#myModal-create img[name =view-file]").hide();
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
function CheckName(title,language) {
    var check = true;
    var error = 0;
    var name = title.val().trim();
    var regex = /^[\w'’,-\/.\s]+$/;
    var $messageError = title.parents(".form-group").find(".help-block");
    var $formGroup = title.parents(".form-group");
    if (name.length == 0) {
        check = false;
        error = 1;

    } else if (name.length > 100) {
        check = false;
        error = 2;
    }
    else if (!regex.test(ConvertToUnsigned(name))) {
        check = false;
        error = 3;
    }
    else if (name.split(" ").length == 1 && name.length > 20) {
        check = false;
        error = 4;
    }
    switch (error) {
        case 0: {
            $messageError.text("");
            break;
        }
        case 1: {
            $messageError.text("Tên " + language + " không được để trống");
            break;
        }
        case 2: {
            $messageError.text("Tên " + language+" không được quá 100 kí tự");
            break;
        }
        case 3: {
            $messageError.text("Tên " + language+" không được chứa kí tự đặc biệt!");
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
function CheckDescription(title) {
    var check = true;
    var error = 0;
    var name = title.val().trim();
    var regex = /^[\w'’,-\/.\s]+$/;
    var $messageError = title.parents(".form-group").find(".help-block");
    var $formGroup = title.parents(".form-group");
    if (name.length == 0) {
        check = false;
        error = 1;

    } else if (name.length > 4000) {
        check = false;
        error = 2;
    }
    switch (error) {
        case 0: {
            $messageError.text("");
            break;
        }
        case 1: {
            $messageError.text("Mô tả không được để trống");
            break;
        }
        case 2: {
            $messageError.text("Mô tả không được quá 4000 kí tự");
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
function CheckNumber(number,field) {

    var check = true;
    var error = 0;
    var name = number.val();
    var regex = /^\d*\.?\d*$/;
    var $messageError = number.parents(".form-group").find(".help-block");
    var $formGroup = number.parents(".form-group");
    if (name.length == 0) {
        check = false;
        error = 1;

    } else if (name.length > 10) {
        check = false;
        error = 2;
    } else if (!regex.test(ConvertToUnsigned(name))) {
        check = false;
        error = 3;
    }
    switch (error) {
        case 0: {
            $messageError.text("");
            break;
        }
        case 1: {
            $messageError.text(field+" không được để trống");
            break;
        }
        case 2: {
            $messageError.text(field+" không được quá 10 kí tự");
            break;
        }
        case 3: {
            $messageError.text("Chỉ được nhập số thập phân");
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