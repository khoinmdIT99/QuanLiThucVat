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
var checkEmailExits = true;
$(document).on("click", "#btn-create", function () {
    var keyword;
    $email = $("#myModal-create input[name=email]");
    $password = $("#myModal-create input[name=password]");
    $address = $("#myModal-create input[name=address]");
    $phone = $("#myModal-create input[name=phone]");
    $fullname = $("#myModal-create input[name=fullname]");
    $birthday = $("#myModal-create input[name=birthday]");
    $sex = $("#myModal-create input[name=sex]:first");
    var fileUpload = $("#file").get(0).files;
    var formData = new FormData();
    formData.append('email', $email.val());
    formData.append('password', $password.val());
    formData.append('address', $address.val());
    formData.append('fullname', $fullname.val());
    formData.append('phone', $phone.val());
    formData.append('birthday', $birthday.val());
    formData.append('sex', $sex.val());
    formData.append('cv', fileUpload[0]);
    

    if (CheckEmail($email) & CheckPassword($password) & CheckFullName($fullname)
        & CheckAddress($address) & CheckPhone($phone) & checkEmailExits) {
        showLoadingScreen();
        $.ajax({
            url: '/admin/NguoiDung/AddNguoiDung',
            type: 'post',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                $.ajax({
                    url: '/admin/NguoiDung/_PartialNguoiDung',
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
    if (CheckEmailExist == false) {
    }
});
function CheckEmailExist() {
$email = $("#myModal-create input[name=email]");
var formData = new FormData();
formData.append('email', $email.val());
$.ajax({
    url: '/admin/NguoiDung/CheckEmailExist',
    type: 'post',
    contentType: false,
    processData: false,
    data: formData,
    success: function (response) {
        checkEmailExits = response;
        if (response == false) {
            alertModalMini("Email đã tồn tại ", "error");
        } else {
        }
    },
    error: function () {
        alertModalMini("Đã có lỗi xảy ra ", "error");
    },
});
}
$(document).on("click", "#btn-search", function () {
    keyword = $("#search-input").val().trim();
    showLoadingScreen();
    $.ajax({
        url: '/admin/NguoiDung/_PartialNguoiDung',
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
    var email = $(this).parents("tr").find("td[name=email]").text();
    $("#myModal-edit input[name=email]").val(email);
    var phone = $(this).parents("tr").find("td[name=phone]").text();
    $("#myModal-edit input[name=phone]").val(phone);
    var address = $(this).parents("tr").find("td[name=address]").text();
    $("#myModal-edit input[name=address]").val(address);
    var birthday = $(this).parents("tr").find("td[name=birthday]").text();
    $("#myModal-edit input[name=birthday]").val(birthday);
    var fullname = $(this).parents("tr").find("td[name=fullname]").text();
    $("#myModal-edit input[name=fullname]").val(fullname);
    var sex = $(this).parents("tr").find("td[name=sex]").attr("value");
    if (sex.toLowerCase() == "true") {
        $("#myModal-edit input[name=sex]:first").prop("checked", true);
        $("#myModal-edit input[name=sex]:last").prop("checked", false);
    } else {
        $("#myModal-edit input[name=sex]:first").prop("checked", false);
        $("#myModal-edit input[name=sex]:last").prop("checked", true);
    }
     path = $(this).parents("tr").find("td[name=path] img").attr("src");
    $("#myModal-edit img[name=view-file-edit]").attr("src", path);
});
$(document).on("click", "#save-edit", function () {

    $email = $("#myModal-edit input[name=email]");
    $password = $("#myModal-edit input[name=password]");
    $address = $("#myModal-edit input[name=address]");
    $phone = $("#myModal-edit input[name=phone]");
    $fullname = $("#myModal-edit input[name=fullname]");
    $birthday = $("#myModal-edit input[name=birthday]");
    $sex = $("#myModal-edit input[name=sex]:first");
    var fileUpload = $("#file-edit").get(0).files;
    var formData = new FormData();
    formData.append('id', ID);
    formData.append('email', $email.val());
    formData.append('password', $password.val());
    formData.append('address', $address.val());
    formData.append('fullname', $fullname.val());
    formData.append('phone', $phone.val());
    formData.append('birthday', $birthday.val());
    formData.append('sex', $sex.prop("checked"));
    formData.append('path', path);
    formData.append('cv', fileUpload[0]);
    if (CheckPassword2($password) & CheckFullName($fullname)
        & CheckAddress($address) & CheckPhone($phone)) {
        showLoadingScreen();

        $.ajax({
            url: '/admin/NguoiDung/EditNguoiDung',
            type: 'post',
            contentType: false,
            processData: false,
            data: formData,
            success: function (data) {
                $.ajax({
                    url: '/admin/NguoiDung/_PartialNguoiDung',
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
        url: '/admin/NguoiDung/DeleteNguoiDung',
        type: 'post',
        contentType: false,
        processData: false,
        data: formData,
        success: function (data) {

            $.ajax({
                url: '/admin/NguoiDung/_PartialNguoiDung',
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

function CheckEmail(email) {

    var check = true;
    var error = 0;
    var name = email.val().trim();
    var regex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var $messageError = email.parents(".form-group").find(".help-block");
    var $formGroup = email.parents(".form-group");
    if (name.length == 0) {
        check = false;
        error = 1;
    } else if (name.length > 250) {
        check = false;
        error = 2;
    }
    else if (!regex.test(ConvertToUnsigned(name))) {
        check = false;
        error = 3;
    }
    switch (error) {
        case 0: {
            $messageError.text("");
            break;
        }
        case 1: {
            $messageError.text("Email không được để trống!");
            break;
        }
        case 2: {
            $messageError.text("Email không được quá 250 kí tự");
            break;
        }
        case 3: {
            $messageError.text("Đây không phải email hợp lệ!");
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
function CheckPassword(password) {
    var check = true;
    var error = 0;
    var name = password.val().trim();
    var regex = /^[\w'’+,-\/.\s]+$/;
    var $messageError = password.parents(".form-group").find(".help-block");
    var $formGroup = password.parents(".form-group");
    if (name.length == 0) {
        check = false;
        error = 1;

    } else if (name.length < 6) {
        check = false;
        error = 2;
    } else if (name.length > 100) {
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
            $messageError.text("Mật khẩu không được để trống!");
            break;
        }
        case 2: {
            $messageError.text("Mật khẩu phải trên 6 kí tự!");
            break;
        }
        case 3: {
            $messageError.text("Mật khẩu không được quá 100 kí tự!");
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
function CheckPassword2(password) {
    var check = true;
    var error = 0;
    var name = password.val().trim();
    var regex = /^[\w'’+,-\/.\s]+$/;
    var $messageError = password.parents(".form-group").find(".help-block");
    var $formGroup = password.parents(".form-group");
    if (name.length>0 & name.length < 6) {
        check = false;
        error = 2;
    } else if (name.length > 100) {
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
        case 2: {
            $messageError.text("Mật khẩu phải trên 6 kí tự!");
            break;
        }
        case 3: {
            $messageError.text("Mật khẩu không được quá 100 kí tự!");
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

function CheckAddress(address) {
    var check = true;
    var error = 0;
    var name = address.val().trim();
    var $messageError = address.parents(".form-group").find(".help-block");
    var $formGroup = address.parents(".form-group");
    if (name.length == 0) {
        check = false;
        error = 1;

    } else if (name.length > 300) {
        check = false;
        error = 2;
    }

    switch (error) {
        case 0: {
            $messageError.text("");
            break;
        }
        case 1: {
            $messageError.text("Địa chỉ không được để trống!");
            break;
        }
        case 2: {
            $messageError.text("Địa chỉ quá 300 kí tự!");
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
function CheckPhone(number) {

    var check = true;
    var error = 0;
    var name = number.val();
    var regex = /^[0-9]+$/;
    var $messageError = number.parents(".form-group").find(".help-block");
    var $formGroup = number.parents(".form-group");
    if (name.length == 0) {
        check = false;
        error = 1;

    } else if (name.length > 15) {
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
            $messageError.text("Số điện thoại không được để trống!");
            break;
        }
        case 2: {
            $messageError.text("Không được quá 15 kí tự!");
            break;
        }
        case 3: {
            $messageError.text("Chỉ được nhập số!");
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
            $messageError.text("Họ và tên không được để trống!");
            break;
        }
        case 2: {
            $messageError.text("Họ và tên quá 100 kí tự!");
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
function CheckImage() {
    var check = true;
    var error = 0;
    var allowedExtensions = /(\.jpg|\.bmg|\.png|\.gif)$/i;
    var fileUpload = $("#file").get(0);
    var files = fileUpload.files;
    var $messageError = $("#file").parents(".form-group").find(".help-block");
    var $formGroup = $("#file").parents(".form-group");
    if (fileUpload.files.length == 0) {
        check = false;
        error = 1;

    } else if (!allowedExtensions.exec(fileUpload.value)) {
        check = false;
        error = 2;
    } else if (fileUpload.files[0].size > 3145728) {
        check = false;
        error = 3;
    }
    switch (error) {
        case 0: {
            $messageError.text("");
            break;
        }
        case 1: {
            $messageError.text("File hình ảnh không được để trống!");
            break;
        }
        case 2: {
            $messageError.text("File phải thuộc một trong các định dạng: .jpg/.bmg/.png/.gif!");

            break;
        }
        case 3: {
            $messageError.text("File không được vượt quá dung lượng 3 MB");
            break;
        }
        default: {
            $messageError.text("");
        }
    }
    if (check == false) {
        $messageError.addClass("has-error-occurr");


    } else {
        $messageError.removeClass("has-error-occurr");
    }
    return check;

}
function CheckEditImage(image) {

    var check = true;
    var error = 0;
    var allowedExtensions = /(\.jpg|\.bmg|\.png|\.gif)$/i;
    var fileUpload = image.get(0);
    var files = fileUpload.files;
    var $messageError = image.parents(".form-group").find(".help-block");
    var $formGroup = image.parents(".form-group");
    if (fileUpload.files.length > 0 && !allowedExtensions.exec(fileUpload.value)) {
        check = false;
        error = 2;
    } else if (fileUpload.files.length > 0 && fileUpload.files[0].size > 3145728) {
        check = false;
        error = 3;
    }
    switch (error) {
        case 0: {
            image.parents(".form-group").find(".help-block").text("");
            break;
        }
        case 2: {
            $messageError.text("File phải thuộc một trong các định dạng: .jpg/.bmg/.png/.gif!");
            break;
        }
        case 3: {
            $messageError.text("File không được vượt quá dung lượng 3 MB");
            break;
        }
        default: {
            $messageError.text("");
        }
    }
    if (check == false) {
        $messageError.addClass("has-error-occurr");


    } else {
        $messageError.removeClass("has-error-occurr");
    }
    return check;
}
