//************************************************************//
//PHAN DANH CHO NHAN VIEN
//************************************************************//
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
//Do du lieu vao dropdowlist
$(document).ready(function () {
    $("#manv").keyup(function () {
        var checkId = $(this).val();
        if (checkId != '') {
            $.ajax({
                url: "/StaffManager/HaveStaffId",
                type: 'Get',
                data: { staffId: checkId },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data) {
                        sweetAlert("Cảnh báo", "Mã nhân viên đã tồn tại!", "error");
                    }
                },
                error: function (result) {
                    swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
                }
            });
        }
    });
})
$(document).ready(function () {
    $("#create-button").click(function () {
        $(this).attr('type', 'button');
        var id = $("#manv").val();
        var name = $("#staffName").val();
        var position = $("#ddlPosition").val();
        var address = $("#address").val();
        var phone = $("#numberphone").val();
        var mail = $("#email").val();
        var image = $("#uploadFile").val();
        if (id != '') {
            //Kiem tra 1 lan nua xem ma nv co ton tai hay khong
            $.ajax({
                url: "/StaffManager/HaveStaffId",
                type: 'Get',
                data: { staffId: id },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data) {
                        sweetAlert("Cảnh báo", "Mã nhân viên đã tồn tại!", "error");
                    } else {
                        //Dung kiem tra xem cac thong tin nhap vao dung hay sai
                        if (name.length <= 10 || name.length >= 50 || address.length < 2 || phone.length < 1 || position.length < 2) {
                            $(this).attr('type', 'submit');
                            $("#staffform").submit();
                        } else {
                            $("#editForm").dialog("close");
                            $.post('/StaffManager/CreateStaff', { "Id": id, "staffName": name, "userId": position, "address": address, "numberphone": phone, "email": mail, "Image": image }, function () {
                                swal({ title: "Lưu dữ liệu", text: "Lưu thành công", timer: 2000, showConfirmButton: false });
                                window.location.reload(true);
                            })
                        }
                    }
                },
                error: function (result) {
                    swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
                }
            });

        }
    });
});
//Kiem tra thong tin nhap vao dung hay sai
$(document).ready(function () {
    $('#staffform').validate({
    });
});
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
            $("#changeimage").show();
        }
    });
});
//Dung de dong diaglog chua form
$("#buttonExitCreate").button().click(function () {
    $.ajax({
        url: '/StaffManager/ListStaff',
        data: {},
        type: 'GET',
        success: function (data) {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("close");
            $("#staff-list").empty();
            $("#btnloadstaff").show();
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

//***********************************************************************//
//PHAN CHO INVENTORY
//**********************************************************************//
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
//Kiem tra thong tin nhap vao dung hay sai
$(document).ready(function () {
    $('#inventoryform').validate({
    });
});
//Luu hinh vao thu muc InventoryImages
$(document).ready(function () {
    $("#uploadFileForInventory").change(function () {
        var myfile = $("#uploadFileForInventory").val();
        var extensionfile = myfile.split('.').pop().toString();
        if (extensionfile == "jpg" || extensionfile == "png" || extensionfile == "gif") {
            var data = new FormData();
            var files = $("#uploadFileForInventory").get(0).files;
            if (files.length > 0) {
                data.append("SectionImages", files[0]);
                data.append("Path", "/Images/InventoryImages");
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
                    var srcname = '/Images/InventoryImages/' + imagename;
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
            $("#changeimage").show();
        }
    });
});
//******************************************************************************//
//PHAN CHO BILL SALE ORDER
//*****************************************************************************//
//Kiem tra thong tin nhap vao dung hay sai
$(document).ready(function () {
    $('#billsaleorderform').validate({
    });
});
//Do du lieu vao dropdowlist khach hang
$(document).ready(function () {
    $.ajax({
        url: "/BillSaleOrderManager/ListCustomer",
        type: 'Get',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ddlCustomer").append($("<option></option>").val(value.CustID).html(value.CustName));
            });
        },
        error: function (result) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
})
//Do du lieu vao dropdowlist nhan vien quan li
$(document).ready(function () {
    $.ajax({
        url: "/BillSaleOrderManager/ListStaff",
        type: 'Get',
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, value) {
                $("#ddlStaffForBillSaleOrder").append($("<option></option>").val(value.StaffId).html(value.StaffName));
            });
        },
        error: function (result) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
})
//Hien thi lich 
$(document).ready(function () {
    $("#createdatepicker").datepicker();//Hien lich cho nguoi dung chon ngay thang nam
    $("#overdatepicker").datepicker();

})
//Hien thi dong du lieu
$(document).ready(function () {
    $("#showrow").click(function () {
        var index = 0;
        $.ajax({
            url: "/BillSaleOrderManager/ShowRow",
            type: 'Get',
            data: "{}",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#tableInventory").append(data);
                index = $("#tableInventory tr").length;
                $("#tableInventory > tr:last >td:nth-child(1) >p").text(index);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");

            },
            error: function (result) {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });

    });
})
//Luu thong tin hoa don ban hang
$(document).ready(function () {
    $("#createBillSaleOrder-button").click(function () {
        alert('vao day 2')
        var custId = $("#ddlCustomer").val();
        var description = $("#description").val();
        var dataCreate = $("#createdatepicker").val();
        var staffId = $("#ddlStaffForBillSaleOrder").val();
        var overDueDate = $("#overdatepicker").val();
        $.post('/BillSaleOrderManager/CreateNewBillOrder', { CustID: custId, Description: description, OrderDate: dataCreate, StaffId: staffId, OverdueDate: overDueDate }, function () {
            swal({ title: "Lưu dữ liệu", text: "Lưu thành công", timer: 2000, showConfirmButton: false });
        })
    })
})
