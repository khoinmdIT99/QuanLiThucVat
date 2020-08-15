$(document).ready(function () {
    $("#submit").click(function (e) {
        e.preventDefault();
        $("#form").children("input").not("input[type='submit']").each(function () {
            var objThis = $(this);
            if (objThis.val().length < 6) {
                $(".err-show ul").append("<li>" + objThis.attr("placeholder") + " phải lớn hơn 6 kí tự </li>").css("display:block");
            } else {
                $(".err-show ul").remove().css("display:none");
                var user = $("#form").serialize();
                $.ajax({
                    type: 'POST',
                    url: '/Admin/Account/LoginPost',
                    data: user,
                    success: function (response) {
                        if (response == "SUCCESS") {
                            window.location.reload();
                        }
                    }
                })
            }
        })
        
    })
})