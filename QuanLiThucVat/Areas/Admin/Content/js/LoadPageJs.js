$(document).ready(function () {
    $("#loadpage a").click(function (e) {
        var url = $(this).attr('href');
        e.preventDefault();
        $.ajax({
            type:'GET',
            url: url,
            success: function (response) {
                
            }
        });
    })
})