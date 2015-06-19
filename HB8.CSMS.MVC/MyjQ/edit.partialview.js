//*****************************************************************//
//PHAN EDIT CUA NHAN VIEN
//****************************************************************//
//Do du lieu vao dropdowlist
var opt = {
    autoOpen: false,
    modal: true,
    height: 200,
    width: 600,
    resizable: false,
    modal: true,
    open: function (event, ui) {
        $(".ui-dialog-titlebar-close").hide();
        setTimeout("$('#showLoading').dialog('close')", 100);
    },
};
//Do du lieu vao dropdownlist cho position
$(document).ready(function () {
    $('#ddlPosition').click(function () {
        $.ajax({
            url: "/StaffManager/ListPositonForStaff",
            type: 'Get',
            data: "{}",
            success: function (data) {
                $("#dropdownlistForPosition").empty();
                $("#dropdownlistForPosition").append(data);

            },
            error: function (result) {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    })

})

//Kiem tra thong tin nhap vao dung hay sai
$(document).ready(function () {
    $('#staffform').validate({
    });
});
//Luu nhung thay doi
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
        var confirmPass = $("#confirmPass").val().toUpperCase();
        var pass = $("#pass").val().toUpperCase();
        //Dung kiem tra xem cac thong tin nhap vao dung hay sai
        if (name.length <= 10 || name.length >= 50 || address.length < 2 || phone.length < 1 || position.length < 2) {
            $(this).attr('type', 'submit');
        } else {
            //So sanh pass
            if (pass != confirmPass) {
                $(this).attr('type', 'submit');
            } else {
                $("#editForm").dialog("close");
                $.post('/StaffManager/EditStaff', { "Id": id, "staffName": name, "userId": position, "address": address, "numberphone": phone, "email": mail, "Image": image, "ConfirmPassword": confirmPass }, function () {
                    swal({ title: "Lưu dữ liệu", text: "Lưu thành công", timer: 2000, showConfirmButton: false });
                    $.ajax({
                        url: '/StaffManager/DetailStaff',
                        data: { "staffId": id },
                        type: "Get",
                        success: function (data) {
                            var theDialog = $("#showLoading").dialog(opt);
                            theDialog.dialog("close");
                            $("#btnloadstaff").hide();
                            $("#buttonEditForStaff").show();
                            $("#buttonDeleteForStaff").show();
                            $("#staff-list").empty();
                            $("#staff-list").append(data);
                        },
                        beforeSend: function () {
                            var theDialog = $("#showLoading").dialog(opt);
                            theDialog.dialog("open");
                        },
                        error: function () {
                            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
                        }
                    });
                })
            }

        }
    });
});

//Dung de dong diaglog chua form
$("#buttonExitEdit").button().click(function () {
    $.ajax({
        url: '/StaffManager/ListStaff',
        data: {},
        type: 'GET',
        success: function (data) {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("close");
            $("#staff-list").empty();
            $("#btnloadstaff").show();
            $("#buttonCreateForStaff").show();
            $("#staff-list").append(data);
        },
        beforeSend: function () {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("open");
        },
        error: function () {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    })
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



//***********************************************************************************************************************//
//PHAN CHO EDIT CUSTOMER
//***********************************************************************************************************************//

////Dung de dong diaglog chua form
//$("#buttonExitEdit").button().click(function () {
//    //$('.buttonEdit').prop("disabled", false);
//    //$('.buttonDelete').prop("disabled", false);
//    $("#editFormCustomer").dialog("close");  
//})


////Do du lieu vao dropdowlist
//$(document).ready(function () {
//    $.ajax({
//        url: "/CustomerManager/ListStatus",
//        type: 'Get',
//        data: "{}",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (data) {
//            $.each(data, function (key, value) {
//                $("#ddlStatus").append($("<option></option>").val(value.StatusID).html(value.StatusName));
//            });
//        },
//        error: function (result) {
//            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
//        }
//    });
//})

////Dung cho update thong tin cua form EDIT
//$(document).ready(function () {
//    $("#updateCustomer-button").click(function () {
//        $(this).attr('type', 'button');
//        var page = $(".currentpage").text();
//        var id = $("#Id").val();
//        var name = $("#customerName").val();
//        var date = $("#birthdatepicker").val();
//        var address = $("#address").val();
//        var phone = $("#numberphone").val();
//        var fax = $("#fax").val();
//        var mail = $("#email").val();
//        var status = $("#ddlStatus").val();
//        var image = $("#uploadFile").val();
//        var description = $("#description").val();
//        //Dung kiem tra xem cac thong tin nhap vao dung hay sai
//        if (name.length <= 10 || name.length >= 50 || date.length == 0 || address.length < 2 || phone.length < 1|| mail.length == 0 || status.length == 0) {
//            $(this).attr('type', 'submit');
//            //$("#customerform").submit();
//        } else {
//            $("#editFormCustomer").dialog("close");
//            $.post('/CustomerManager/EditCustomer', { "CustID": id, "CustName": name, "BirthDate": date, "StatusId": status, "address": address, "Phone": phone, "fax": fax, "email": mail, "Image": image, "description": description }, function () {
//                swal({ title: "Lưu dữ liệu", text: "Lưu thành công", timer: 2000, showConfirmButton: false });
//                $("#person-list").empty();
//                //window.location.reload(true);
//                $.ajax({
//                    url: "/CustomerManager/CallBackCustomerPartialView",
//                    type: 'Get',
//                    data: { page: page},
//                    success: function (data) {
//                        $("#person-list").empty();
//                        $("#person-list").append(data);
//                        $(".gridView").hide();
//                        $("#listView").show();
//                    }
//                });
//            })

//        }
//    });
//});
//Dung de dong diaglog chua form
//$("#buttonExitEdit").button().click(function () {
//    //$('.buttonEdit').prop("disabled", false);
//    //$('.buttonDelete').prop("disabled", false);
//    $("#editFormCustomer").dialog("close");
//})


////Do du lieu vao dropdowlist
//$(document).ready(function () {
//    $.ajax({
//        url: "/CustomerManager/ListStatus",
//        type: 'Get',
//        data: "{}",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (data) {
//            $.each(data, function (key, value) {
//                $("#ddlStatus").append($("<option></option>").val(value.StatusID).html(value.StatusName));
//            });
//        },
//        error: function (result) {
//            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
//        }
//    });
//})

////Dung cho update thong tin cua form EDIT
//$(document).ready(function () {
//    $("#updateCustomer-button").click(function () {
//        $(this).attr('type', 'button');
//        var page = $(".currentpage").text();
//        var id = $("#Id").val();
//        var name = $("#customerName").val();
//        var date = $("#birthdatepicker").val();
//        var address = $("#address").val();
//        var phone = $("#numberphone").val();
//        var fax = $("#fax").val();
//        var mail = $("#email").val();
//        var status = $("#ddlStatus").val();
//        var image = $("#uploadFile").val();
//        var description = $("#description").val();
//        //Dung kiem tra xem cac thong tin nhap vao dung hay sai
//        if (name.length <= 10 || name.length >= 50 || date.length == 0 || address.length < 2 || phone.length < 1 || mail.length == 0 || status.length == 0) {
//            $(this).attr('type', 'submit');
//            //$("#customerform").submit();
//        } else {
//            $("#editFormCustomer").dialog("close");
//            $.post('/CustomerManager/EditCustomer', { "CustID": id, "CustName": name, "BirthDate": date, "StatusId": status, "address": address, "Phone": phone, "fax": fax, "email": mail, "Image": image, "description": description }, function () {
//                swal({ title: "Lưu dữ liệu", text: "Lưu thành công", timer: 2000, showConfirmButton: false });
//                $("#person-list").empty();
//                //window.location.reload(true);
//                $.ajax({
//                    url: "/CustomerManager/CallBackCustomerPartialView",
//                    type: 'Get',
//                    data: { page: page },
//                    success: function (data) {
//                        $("#person-list").empty();

//                        $("#person-list").append(data);
//                        $(".gridView").hide();
//                        $("#listView").show();
//                    }
//                });
//            })

//        }
//    });
//});

//PHAN CHO EDIT CUSTOMER
//Dung de dong diaglog chua form
$("#buttonExitEdit").button().click(function () {
    //$('.buttonEdit').prop("disabled", false);
    //$('.buttonDelete').prop("disabled", false);
    $("#editFormCustomer").dialog("close");
})


//Do du lieu vao dropdowlist
$(document).ready(function () {
    $.ajax({
        url: "/CustomerManager/ListStatus",
        type: 'Get',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ddlStatus").append($("<option></option>").val(value.StatusID).html(value.StatusName));
            });
        },
        error: function (result) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
})

//Dung cho update thong tin cua form EDIT
$(document).ready(function () {
    $("#updateCustomer-button").click(function () {
        $(this).attr('type', 'button');
        var page = $(".currentpage").text();
        var id = $("#Id").val();
        var name = $("#customerName").val();
        var date = $("#birthdatepicker").val();
        var address = $("#address").val();
        var phone = $("#numberphone").val();
        var fax = $("#fax").val();
        var mail = $("#email").val();
        var status = $("#ddlStatus").val();
        var image = $("#uploadFile").val();
        var description = $("#description").val();
        //Dung kiem tra xem cac thong tin nhap vao dung hay sai
        if (name.length <= 10 || name.length >= 50 || date.length == 0 || address.length < 2 || phone.length < 1 || mail.length == 0 || status.length == 0) {
            $(this).attr('type', 'submit');
            //$("#customerform").submit();
        } else {
            $("#editFormCustomer").dialog("close");
            $.post('/CustomerManager/EditCustomer', { "CustID": id, "CustName": name, "BirthDate": date, "StatusId": status, "address": address, "Phone": phone, "fax": fax, "email": mail, "Image": image, "description": description }, function () {
                swal({ title: "Lưu dữ liệu", text: "Lưu thành công", timer: 2000, showConfirmButton: false });
                $("#person-list").empty();
                //window.location.reload(true);
                $.ajax({
                    url: "/CustomerManager/CallBackCustomerPartialView",
                    type: 'Get',
                    data: { page: page },
                    success: function (data) {
                        $("#person-list").empty();

                        $("#person-list").append(data);
                        $(".gridView").hide();
                        $("#listView").show();
                    }
                });
            })

        }
    });
});
//****************************************************************************************************//
//PHAN CHO SAN PHAM
//***************************************************************************************************//
//Do du lieu vao dropdowlist nhom san pham
$(document).ready(function () {
    $.ajax({
        url: "/InventoryManager/ListClass",
        type: 'Get',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ddlClass").append($("<option></option>").val(value.ClassId).html(value.ClassName));
            });
        },
        error: function (result) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
})
//Do du lieu vao dropdowlist don vi tinh THUNG
$(document).ready(function () {
    $.ajax({
        url: "/InventoryManager/ListUnitT",
        type: 'Get',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ddlUnitT").append($("<option></option>").val(value.UnitID_T).html(value.UnitName));
            });
        },
        error: function (result) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
})
//Do du lieu vao dropdowlist don vi tinh LE
$(document).ready(function () {
    $.ajax({
        url: "/InventoryManager/ListUnitL",
        type: 'Get',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ddlUnitL").append($("<option></option>").val(value.UnitID_L).html(value.UnitName));
            });
        },
        error: function (result) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
})
//Do du lieu vao dropdowlist nhom san pham
$(document).ready(function () {
    $.ajax({
        url: "/InventoryManager/ListStatus",
        type: 'Get',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ddlStatus").append($("<option></option>").val(value.StInventoryId).html(value.StInvetoryName));
            });
        },
        error: function (result) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
})
//Do du lieu vao dropdowlist danh sach nhan vien
$(document).ready(function () {
    $.ajax({
        url: "/InventoryManager/ListStaff",
        type: 'Get',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ddlStaff").append($("<option></option>").val(value.StaffId).html(value.StaffName));
            });
        },
        error: function (result) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
})
//Do du lieu vao dropdowlist danh sach kho hang
$(document).ready(function () {
    $.ajax({
        url: "/InventoryManager/ListStock",
        type: 'Get',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ddlStock").append($("<option></option>").val(value.StockID).html(value.StockName));
            });
        },
        error: function (result) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
})