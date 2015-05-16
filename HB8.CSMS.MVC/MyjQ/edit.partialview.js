
//Do du lieu vao dropdowlist
$(document).ready(function () {
    $.ajax({
        url: "/StaffManager/ListPosition",
        type: 'Get',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ddlPosition").append($("<option></option>").val(value.UserId).html(value.UserName));
            });
        },
        error: function (result) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
})

//Kiem tra thong tin nhap vao dung hay sai
$(document).ready(function () {
    $('#staffform').validate({
    });
});


$(document).ready(function () {
    $("#update-button").click(function () {
        $(this).attr('type', 'button');
        var id = $("#Id").val();
        var name = $("#staffName").val();
        var position = $("#ddlPosition").val();
        var address = $("#address").val();
        var phone = $("#numberphone").val();
        var mail = $("#email").val();
        var image = $("#uploadFile").val();
        //Dung kiem tra xem cac thong tin nhap vao dung hay sai
        if (name.length <= 10 || name.length >= 50 || address.length < 2 || phone.length < 1 || position.length < 2) {
            $(this).attr('type', 'submit');
            $("#staffform").submit();
        } else {
            $("#editForm").dialog("close");
            $.post('/StaffManager/EditStaff', { "Id": id, "staffName": name, "userId": position, "address": address, "numberphone": phone, "email": mail, "Image": image }, function () {
                swal({ title: "Lưu dữ liệu", text: "Lưu thành công", timer: 2000, showConfirmButton: false });
                window.location.reload(true);
            })
        }
    });
});

//Dung de dong diaglog chua form
$("#buttonExitEdit").button().click(function () {
    $('.buttonEdit').prop("disabled", false);
    $('.buttonDelete').prop("disabled", false);
    $("#editForm").dialog("close");
})

//Save hinh vao thu muc
$(document).ready(function () {
    $("#uploadFile").change(function () {
        var myfile = $("#uploadFile").val();
        var extensionfile = myfile.split('.').pop().toString();
        if (extensionfile == "jpg" || extensionfile == "png" || extensionfile == "gif") {
            var data = new FormData();
            var files = $("#uploadFile").get(0).files;
            if (files.length > 0) {
                data.append("SectionImages", files[0]);
                data.append("Path", "/Images/StaffImages");
            }
            $.ajax({
                url: 'Upload/UploadImage',
                type: "POST",
                processData: false,
                contentType: false,
                data: data,
                dataType: 'json',
                success: function (response) {
                    $("#spinner").delay(1000).fadeOut();
                    var imagename = response["name"];
                    var srcname = '/Images/StaffImages/' + imagename;
                    setTimeout(function () {
                        $("#imagePreview").append('<img class="img-rounded fa fa-file-image-o centre-block" id="changeimage" height="180" width="180" id="changeimage"  />');
                        $("#changeimage").attr('src', srcname);
                    }, 1500);
                },
                beforeSend: function () {
                    $("#changeimage").hide();
                    $("#imagePreview").html("<center><i class='fa fa-spinner fa-spin fa-5x ' id='spinner'></i></center>");
                },
                error: function (er) {
                    swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
                }
            });
        } else {
            sweetAlert("Cảnh báo", "Chỉ hỗ trợ file ảnh jpg, png, gif. Vui lòng chọn lại", "error");
        }
    });
});

//PHAN CHO EDIT CUSTOMER
//Dung de dong diaglog chua form
$("#buttonExitEdit").button().click(function () {
    //$('.buttonEdit').prop("disabled", false);
    //$('.buttonDelete').prop("disabled", false);
    $("#editFormCustomer").dialog("close");  
})
