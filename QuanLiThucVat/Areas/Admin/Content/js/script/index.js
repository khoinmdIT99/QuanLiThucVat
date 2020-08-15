$(document).ready(function () {
    //create filed
    $(document).on("click", "#btn-create", function () {
        if (CheckName()) {
            var name = $("#myModal-create input[name=name]").val();
            var content = '<tr>'
                + '<th scope= "row" > 1</th>'
                + '<td>' + name + '</td>'
                + '<td> <a data-toggle="modal" data-target="#myModal-edit"> <span class="glyphicon glyphicon-edit"></span></a>'
                + '<a data-toggle="modal" data-target="#myModal-delete"> <span class="glyphicon glyphicon-trash"></span> </a>'
                + ' </td ></tr >';
            $(content).insertBefore("#table-field > tbody > tr:first");
            $("#myModal-create").modal("hide");
            $.ajax({
                url: '/admin/home/create',
                type: 'post',
                data: {
                    name: name
                }, success: function () {
                    //alert("s");
                }, error: function () {
                    alert("error");

                }
            });
        } else {

        }
    });
    //edit filed
    $(document).on("click", "#btn-create", function () {
        if (CheckName()) {
            var name = $("#myModal-create input[name=name]").val();
            var content = '<tr>'
                + '<th scope= "row" > 1</th>'
                + '<td>' + name + '</td>'
                + '<td> <a data-toggle="modal" data-target="#myModal-edit"> <span class="glyphicon glyphicon-edit"></span></a>'
                + '<a data-toggle="modal" data-target="#myModal-delete"> <span class="glyphicon glyphicon-trash"></span> </a>'
                + ' </td ></tr >';
            $(content).insertBefore("#table-field > tbody > tr:first");
            $("#myModal-create").modal("hide");
            $.ajax({
                url: '/admin/home/create',
                type: 'post',
                data: {
                    name: name
                }, success: function () {
                    //alert("s");
                }, error: function () {
                    alert("e");

                }
            });
        } else {

        }
    });

    function CheckName() {
        var check = true;
        var error = 0;
        var name = $("#myModal-create input[name=name]").val();
        var regex = /^[\w',-\/.\s]+$/;
        var $messageError = $("#myModal-create input[name=name]").parents(".form-group").find(".help-block");
        var $formGroup = $("#myModal-create input[name=name]").parents(".form-group");
        if (name.length == 0) {
            check = false;
            error = 1;

        } else if (name.length > 50) {
            check = false;
            error = 2;
        } else if (!regex.test(ConvertToUnsigned(name))) {
            check = false;
            error = 3;
        }
        switch (error) {
            case 0: {
                $("#myModal-create input[name=name]").parents(".form-group").find(".help-block").text("");
                break;
            }
            case 1: {
                $messageError.text("Tên lĩnh vực không được để trống!");
                break;
            }
            case 2: {
                $messageError.text("Tên lĩnh vực không được quá 50 kí tự!");
                break;
            }
            case 3: {
                $messageError.text("Tên lĩnh vực không được chứa kí tự đặc biệt!");
                break;
            }
            default: {
                $messageError.text("");
            }
        }
        if (check == false) {
            $formGroup.addClass("has-error");


        } else {
            $formGroup.removeClass("has-error");
        }
        return check;

    }
});