$(document).ready(function () {
    //modal product create
    //$("#product-create").click(function (e) {
    //    e.preventDefault();
     
    //})
    //edit click show popup
    $(".product-edit").click(function () {
        var productId = $(this).parent().data("productId");
        console.log(productId);
        $.ajax({
            type: 'POST',
            url: '/Admin/Product/EditProduct?productId=' + productId,
            success: function (response) {
                $(".modal-title").text("Cập Nhật Sản Phẩm");
                $("#productname").val(response.TenSanPham);
                $("#productimage").attr("src", "/Content/images/" + response.AnhDaiDien);
            }
        })
    })
    //thay đổi ảnh sản phẩm
    //$("#selectimage").click(function () {
    //    $("#fileimage").trigger("click");
        
    //})
    $('#selectimage').on('click', function () {
        console.log('nút chọn file đã được click hoạt');
        $('#fileimage').trigger('click');
    });

    $('#fileimage').change(function () {
        console.log('sự kiện open file được kích hoạt');
        var fileInput = $(this);
        var urlImage = URL.createObjectURL(fileInput[0].files[0]);
        console.log(urlImage);
        var img = new Image();
        img.src = urlImage;
        //khi load thành công
        img.onload = function () {
            console.log('sự kiện onload image thành công.');
            $('#productimage').attr('src', urlImage);
        };

        //khi load không thành công
        img.onerror = function () {
            console.log('sự kiện lỗi khi load anh xảy ra');
        };
    });

  

    //$('.saveimg').on('click', function () {
    //    console.log('sự kiện lưu image đã được kích hoạt');
    //    var form = new FormData();
    //    form.append('avarta', document.getElementById('idAvartar').files[0]);
    //    form.append('DuLieuThem', 12);

    //    console.log('Gửi ảnh lên server...');
    //    $.ajax({
    //        url: '/home/saveimg',
    //        dataType: 'json',
    //        type: 'post',
    //        data: form,
    //        contentType: false,
    //        processData: false,
    //        success: function (rs) {
    //            var result = JSON.parse(rs);
    //            if (result == true) {
    //                alert('upload thành công');
    //            }
    //            else {
    //                alert('upload không thành công');
    //            }
    //        },
    //        error: function () {

    //        }
    //    });
    });
