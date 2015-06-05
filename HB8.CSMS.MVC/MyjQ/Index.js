//**************************************************************************************//
//PHAN DANH CHO STAFF
//**************************************************************************************//
var selectedId = 0;
//Cau hinh dialog
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
    }
};
var optforDel = {
    autoOpen: false,
    modal: true,
    height: 500,
    width: 600,
    resizable: false,
    modal: true,
    open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
}
//An di nhung thu khong can thiet khi load vao page
$(document).ready(function () {
    $("#buttonEditForStaff").hide();
    $(".itemIdClass").hide();
    $("#deleteForm").hide();
    $("#buttonprevious").hide();//An di 2 nut Next va Previous
    $("#buttonnext").hide();
    $("#buttonDeleteForStaff").hide();

});
//jQueryUI method to create dialog box
$("#deleteFormStaff").dialog({
    autoOpen: false,
    modal: true,
    height: 200,
    width: 600,
    resizable: false,
    modal: true,
    open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
});
$("#showspinnerForm").dialog({
    autoOpen: false,
    modal: true,
    height: 200,
    width: 600,
    resizable: false,
    modal: true,
    open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
});
//Show bieu tuong loading
$("#showLoading").dialog({
    autoOpen: false,
    modal: true,
    height: 200,
    width: 600,
    resizable: false,
    modal: true,
    open: function (event, ui) {
        $(".ui-dialog-titlebar-close").hide();
        setTimeout("$('#showLoading').dialog('close')", 150);
    },
});
//Goi hien ra form them nhan vien
$(".buttonCreate").button().click(function () {
    $.ajax({
        // Goi CreateStaffPV action
        url: "/StaffManager/CreateStaffPV",
        type: 'Get',
        success: function (data) {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("close");
            $("#btnloadstaff").hide();
            $("#staff-list").empty().append(data);
        },
        beforeSend: function () {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("open");
        },
        error: function () {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
});
var selectedTrainer;
//Goi form ra form sua nhan vien
$(".buttonEdit").button().click(function () {
    // Lấy về Id và gán cho biến selectedId 
    var selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
    $.ajax({
        // Gọi 
        url: "/StaffManager/EditStaffPV",
        data: { id: selectedId },
        type: 'Get',
        success: function (data) {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("close");
            $("#btnloadstaff").hide();
            $("#staff-list").empty().append(data);
        },
        beforeSend: function () {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("open");
        },
        error: function () {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
});
//Sua thong tin khi dang o trang xem chi tiet
$("#buttonEditForStaff").click(function () {
    var selectedId = $("#getId").attr('value');
    $.ajax({
        // Gọi 
        url: "/StaffManager/EditStaffPV",
        data: { id: selectedId },
        type: 'Get',
        success: function (data) {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("close");
            $("#btnloadstaff").hide();
            $("#staff-list").empty().append(data);
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
//Hien thong bao cho nguoi dung co dong y xoa hay khong
$(".buttonDelete").button().click(function () {
    $(".buttonEdit").attr('disabled', 'disabled');
    $(".buttonCreate").attr('disabled', 'disabled');
    $(".buttonDelete").attr('disabled', 'disabled');
    //Open the dialog box

    var theDialog = $("#deleteFormStaff").dialog(optforDel);
    theDialog.dialog("open");
    //Get the TrainingId
    selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
});
//Hien thong bao xoa o trang chi tiet nhan vien
$("#buttonDeleteForStaff").button().click(function () {
    $(".buttonEdit").attr('disabled', 'disabled');
    $(".buttonCreate").attr('disabled', 'disabled');
    $(".buttonDelete").attr('disabled', 'disabled');
    //Open the dialog box

    var theDialog = $("#deleteFormStaff").dialog(optforDel);
    theDialog.dialog("open");
    //Get the TrainingId
    selectedId = $("#getId").attr('value');
});
$(".buttonCloseDelete").button().click(function () {
    $('.buttonEdit').prop("disabled", false);
    $('.buttonCreate').prop("disabled", false);
    $('.buttonDelete').prop("disabled", false);
    //Open the dialog box
    var theDialog = $("#deleteFormStaff").dialog(optforDel);
    theDialog.dialog("close");


});
$(".okDelete").button().click(function () {
    $('.buttonEdit').prop("disabled", false);
    $('.buttonCreate').prop("disabled", false);
    $('.buttonDelete').prop("disabled", false);
    // Close the dialog box on Yes button is clicked
    $("#deleteForm").dialog("close");
    $.ajax({
        // Call Delete action method
        url: "/StaffManager/DeleteStaff",
        data: { id: selectedId },
        type: 'Get',
        success: function (msg) {

            window.location.reload(true);
        },
        beforeSend: function () {
            //$("#showspinner").html("<center><i class='fa fa-spinner fa-spin fa-5x ' id='spinner'></i></center>").delay(10000000).fadeOut();
            $("#showspinnerForm").dialog("open");
        },
        error: function (xhr) {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
});
//Dung trong phan trang
$(document).ready(function () {
    var _inCallback = false;
    var page = 0;
    var numberPage = $(".getnumberpages").val();
    var pageSize = $(".pagesize").val();
    $("#btnloadstaff").click(function () {
        if (page > -1 && !_inCallback) {
            _inCallback = true;
            page++;
            $.get("/StaffManager/ListStaff/" + page, function (data) {
                if (data != "") {
                    var value = (pageSize * (page));//Tinh so nhan vien con lai 
                    $("#btnloadstaff").text('Còn ' + value + ' nhân viên')
                    $("#staff-list").append(data);
                    if (page == numberPage - 1) {
                        $("#btnloadstaff").hide();
                    }
                }
                else {
                    page = -1;
                }
                _inCallback = false;
                $("#showLoading").dialog("open");
            });
        }
    });
});
//Dung de hien thi thong tin dang LIST
$(document).ready(function () {
    $("#btnListView").click(function () {
        $.ajax({
            url: '/StaffManager/ListStaffView',
            data: {},
            type: 'GET',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#staff-list").empty();
                $("#btnloadstaff").hide();
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
    });
});
//Hien thi danh sach khach hang dang list tung trang
$(document).ready(function () {
    $(".page-number").on('click', function () {
        var page = parseInt($(this).html());
        $.ajax({
            url: '/StaffManager/ListStaffView',
            data: { "page": page },
            type: 'GET',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
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

    });
});
//Hien thi dang LARGE VIEW
$(document).ready(function () {
    $("#btnLargeView").click(function () {
        $("#showLoading").dialog({
            autoOpen: false,
        });
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
    });
});
//Hien thi chi tiet thong tin nhan vien
$(document).ready(function () {
    $(".detailstaff").on("click", function () {
        var id = $(this).attr('value');
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

    });
});
//********************************************************************************************//
//PHAN JS DANH CHO CUSTOMER
//*******************************************************************************************//

//Goi hien ra form them khách hàng mới
$(".buttonCreateForCustomer").button().click(function () {
    $.ajax({
        // Goi CreateStaffPV action
        url: "/CustomerManager/CreateCustomerPV",
        type: 'Get',
        success: function (data) {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("close");
            $("#btnloadcustomer").hide();
            $("#person-list").empty().append(data);
        },
        beforeSend: function () {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("open");
        },
        error: function () {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
});
//Hien thong tin chi tiet khach hang
$(".detailcustomer").on("click", function () {
    var id = $(this).attr('value');
    $.ajax({
        url: '/CustomerManager/DetailCustomer',
        data: { custId: id },
        type: 'GET',
        success: function (data) {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("close");
            $("#btnloadcustomer").hide();
            $("#person-list").empty();
            $("#person-list").append(data);
        },
        beforeSend: function () {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("open");
        },
        error: function () {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }

    })
});


//Cai dat
$(document).ready(function () {
    $("#buttonEditForCustomer").hide();
    $("#buttonpreviousForCustomer").hide();
    $("#buttonnextForCustomer").hide();
    $("#countInvnetory").hide();
})
//Chuc nang load nhung khach hang con lai
$(document).ready(function () {
    var page = 0;
    var _inCallback = false;
    var numberPage = parseInt($(".getnumberpages").val()) - 1;
    var pageSize = $(".pagesize").val();
    var count = $(".count").val() - pageSize;
    $("#btnloadcustomer").click(function () {
        var flag = $("#btnLargeViewForCustomer").val();
        if (flag == "") {
            if (page > -1 && !_inCallback) {
                _inCallback = true;
                page++;
                var number = count - page * pageSize;
                if (page < numberPage) {
                    $("#btnloadcustomer").text("Còn " + number + " sản phẩm");
                } else {
                    $("#btnloadcustomer").hide();
                }
                $.get("/CustomerManager/ListCustomer/" + page, function (data) {
                    if (data != null) {
                        $("#customer-list").append(data);
                    }
                    else {
                        page = -1;
                    }
                    _inCallback = false;
                    $("#showLoading").dialog("open");
                });
            }
        } else {
            page = 0;// Khi ma da nhan nut LARGE VIEW thi tu dong page se dc tra ve la 0 va value cua btn se la rong
            $("#btnLargeViewForCustomer").prop('value', '');
        }
    });
});
//Hien thi thong tin chi tiet khach hang
$(document).ready(function () {
    $(".detailcustomer").on("click", function () {
        var id = $(this).attr('value');
        $.ajax({
            url: '/CustomerManager/DetailCustomer',
            data: { "custId": id },
            type: "Get",
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#btnloadcustomer").hide();
                $("#buttonEditForCustomer").show();
                $("#buttonpreviousForCustomer").show();
                $("#buttonnextForCustomer").show();
                $("#customer-list").empty();
                $("#customer-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
                $.ajax({
                    url: '/InventoryManager/IndexOfInventory',
                    data: { id: id },
                    success: function (data) {
                        $(".countCustomer").empty();
                        $(".countCustomer").append('<a href="#">' + data.Index + '/' + data.Count + '</a>');
                    }
                });
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });

    });
});
//Hien thi dang LARGE VIEW
$(document).ready(function () {
    $("#btnLargeViewForCustomer").click(function () {
        $.ajax({
            url: '/CustomerManager/ListCustomer',
            data: {},
            type: 'GET',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");             
                $("#btnloadcustomer").show();
                $("#buttonEditForCustomer").hide();
                $("#buttonpreviousForCustomer").hide();
                $("#buttonnextForCustomer").hide();
                $("#btnloadcustomer").text('Hiển thêm');
                $("#btnLargeViewForCustomer").prop('value', '1');
                $("#customer-list").empty();
                $("#customer-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        })
    });
});
//Hien thi dang LIST VIEW
$(document).ready(function () {
    $("#btnListViewForCustomer").click(function () {
        $.ajax({
            url: '/CustomerManager/ListCustomerView',
            data: {},
            type: 'GET',
            success: function (data) {
                
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#btnloadcustomer").hide();
                $("#buttonEditForCustomer").hide();
                $("#customer-list").empty();
                $("#customer-list").append(data);

            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        })
    });
});
//Hien thi danh sach khach hang list tung trang
$(document).ready(function () {
    $(".page-numberForCustomer").on('click', function () {
        var page = parseInt($(this).html());
        $.ajax({
            url: '/CustomerManager/ListCustomerView',
            data: { "page": page },
            type: 'GET',
            success: function (data) {
                $("#btnloadinventory").hide();
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#customer-list").empty();
                $("#customer-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });

    });
});
//Chon 1 dong se hien ra thong tin chi tiet cua san pham
$(document).ready(function () {
    $('#tableCustomer').find('tr').click(function () {
        var id = $(this).find('input').attr('value');
        $.ajax({
            url: '/CustomerManager/DetailCustomer',
            data: { "custId": id },
            type: "Get",
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#btnloadcustomer").hide();
                $("#buttonEditForCustomer").show();
                $("#buttonpreviousForCustomer").show();
                $("#buttonnextForCustomer").show();
                $("#customer-list").empty();
                $("#customer-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
                $.ajax({
                    url: '/CustomerManager/IndexOfCustomer',
                    data: { id: id },
                    success: function (data) {
                        $(".countCustomer").empty();
                        $(".countCustomer").append('<a href="#">' + data.Index + '/' + data.Count + '</a>');
                    }
                });
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    });
})
//Hien thi thong tin san pham tiep theo
$(document).ready(function () {
    $("#buttonnextForCustomer").click(function () {
        var id = $("#id").val();
        $.ajax({
            url: '/CustomerManager/NextCustomer',
            data: { id: id },
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#customer-list").empty();
                $("#customer-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
                $.ajax({
                    url: '/CustomerManager/IndexOfCustomer',
                    data: { id: id },
                    success: function (data) {      
                        if (data.Index == data.Count) {
                            $(".countCustomer").empty();
                            $(".countCustomer").append('<a href="#">' + data.Index + '/' + data.Count + '</a>');
                        } else {
                            $(".countCustomer").empty();
                            $(".countCustomer").append('<a href="#">' + (data.Index + 1) + '/' + data.Count + '</a>');
                        }
                    }
                });
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    });
});
//Hien thi thong tin san pham truoc
$(document).ready(function () {
    $("#buttonpreviousForCustomer").click(function () {
        var id = $("#id").val();
        $.ajax({
            url: '/CustomerManager/PreviousCustomer',
            data: { id: id },
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#customer-list").empty();
                $("#customer-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
                $.ajax({
                    url: '/CustomerManager/IndexOfCustomer',
                    success: function (data) {
                        if (data.Index == 1) {
                            $(".countCustomer").empty();
                            $(".countCustomer").append('<a href="#">' + data.Index + '/' + data.Count + '</a>');
                        } else {
                            $(".countCustomer").empty();
                            $(".countCustomer").append('<a href="#">' + (data.Index - 1) + '/' + data.Count + '</a>');
                        }

                    }
                });
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    });
});




//**************************************************************************************//
//PHAN DANH CHO INVENTORY
//*************************************************************************************//
//Cai dat
$(document).ready(function () {
    $("#buttonEditForInventory").hide();
    $("#buttonpreviousForInventory").hide();
    $("#buttonnextForInventory").hide();
    $("#countInvnetory").hide();
})
//Goi trang them san pham moi
$(".buttonCreateForInventory").button().click(function () {
    $.ajax({
        // Goi CreateStaffPV action
        url: "/InventoryManager/CreateNewInventory",
        type: 'Get',
        success: function (data) {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("close");
            $("#buttonEditForInventory").hide();
            $("#btnloadstaff").hide();
            $("#inventory-list").empty().append(data);
        },
        beforeSend: function () {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("open");
        },
        error: function () {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
});
//Hien thi thong tin chi tiet san pham
$(document).ready(function () {
    $(".detailinventory").on("click", function () {
        var id = $(this).attr('value');
        $.ajax({
            url: '/InventoryManager/DetailInventory',
            data: { "id": id },
            type: "Get",
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#btnloadinventory").hide();
                $("#buttonEditForInventory").show();
                $("#buttonpreviousForInventory").show();
                $("#buttonnextForInventory").show();
                $("#inventory-list").empty();
                $("#inventory-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
                $.ajax({
                    url: '/InventoryManager/IndexOfInventory',
                    data: { id: id },
                    success: function (data) {
                        $(".countInvnetory").empty();
                        $(".countInvnetory").append('<a href="#">' + data.Index + '/' + data.Count + '</a>');
                    }
                });
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });

    });
});
//Sua thong tin khi dang o trang xem chi tiet
$("#buttonEditForInventory").click(function () {
    var selectedId = $("#id").val();
    $.ajax({
        // Gọi 
        url: "/InventoryManager/EditInventory",
        data: { id: selectedId },
        type: 'Get',
        success: function (data) {
            //var theDialog = $("#showLoading").dialog(opt);
            //theDialog.dialog("close");
            //$("#btnloadstaff").hide();
            $("#inventory-list").empty().append(data);
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
//Hien thi dang LARGE VIEW
$(document).ready(function () {
    $("#btnLargeViewForInventory").click(function () {
        $.ajax({
            url: '/InventoryManager/ListInventory',
            data: {},
            type: 'GET',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#inventory-list").empty();
                $("#btnloadinventory").show();
                $("#buttonEditForInventory").hide();
                $("#buttonpreviousForInventory").hide();
                $("#buttonnextForInventory").hide();
                $("#btnloadinventory").text('Hiển thêm');
                $("#btnLargeViewForInventory").prop('value', '1');
                $("#inventory-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        })
    });
});
//Hien thi dang LIST VIEW
$(document).ready(function () {
    $("#btnListViewForInventory").click(function () {
        $.ajax({
            url: '/InventoryManager/ListInventoryView',
            data: {},
            type: 'GET',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#btnloadinventory").hide();
                $("#buttonEditForInventory").hide();
                $("#inventory-list").empty();
                $("#inventory-list").append(data);

            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        })
    });
});
//Chuc nang load nhung san pham con lai
$(document).ready(function () {
    var page = 0;
    var _inCallback = false;
    var numberPage = parseInt($(".getnumberpages").val()) - 1;
    var pageSize = $(".pagesize").val();
    var count = $(".count").val() - pageSize;
    $("#btnloadinventory").click(function () {
        var flag = $("#btnLargeViewForInventory").val();
        if (flag == "") {
            if (page > -1 && !_inCallback) {
                _inCallback = true;
                page++;
                var number = count - page * pageSize;
                if (page < numberPage) {
                    $("#btnloadinventory").text("Còn " + number + " sản phẩm");
                } else {
                    $("#btnloadinventory").hide();
                }
                $.get("/InventoryManager/ListInventory/" + page, function (data) {
                    if (data != null) {
                        $("#inventory-list").append(data);
                    }
                    else {
                        page = -1;
                    }
                    _inCallback = false;
                    $("#showLoading").dialog("open");
                });
            }
        } else {
            page = 0;// Khi ma da nhan nut LARGE VIEW thi tu dong page se dc tra ve la 0 va value cua btn se la rong
            $("#btnLargeViewForInventory").prop('value', '');
        }
    });
});
//Hien thi danh sach san pham hdang list tung trang
$(document).ready(function () {
    $(".page-numberForInventory").on('click', function () {
        var page = parseInt($(this).html());
        $.ajax({
            url: '/InventoryManager/ListInventoryView',
            data: { "page": page },
            type: 'GET',
            success: function (data) {
                $("#btnloadinventory").hide();
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#inventory-list").empty();
                $("#inventory-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });

    });
});
//Chon 1 dong se hien ra thong tin chi tiet cua san pham
$(document).ready(function () {
    $('#tableInventory').find('tr').click(function () {
        var id = $(this).find('input').attr('value');
        $.ajax({
            url: '/InventoryManager/DetailInventory',
            data: { "id": id },
            type: "Get",
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#btnloadinventory").hide();
                $("#buttonEditForInventory").show();
                $("#buttonpreviousForInventory").show();
                $("#buttonnextForInventory").show();
                $("#inventory-list").empty();
                $("#inventory-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
                $.ajax({
                    url: '/InventoryManager/IndexOfInventory',
                    data: { id: id },
                    success: function (data) {
                        $(".countInvnetory").empty();
                        $(".countInvnetory").append('<a href="#">' + data.Index + '/' + data.Count + '</a>');
                    }
                });
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    });
})
//Hien thi thong tin san pham tiep theo
$(document).ready(function () {
    $("#buttonnextForInventory").click(function () {
        var id = $("#id").val();
        $.ajax({
            url: '/InventoryManager/NextInventory',
            data: { id: id },
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#inventory-list").empty();
                $("#inventory-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
                $.ajax({
                    url: '/InventoryManager/IndexOfInventory',
                    data: { id: id },
                    success: function (data) {
                        if (data.Index == data.Count) {
                            $(".countInvnetory").empty();
                            $(".countInvnetory").append('<a href="#">' + data.Index + '/' + data.Count + '</a>');
                        } else {
                            $(".countInvnetory").empty();
                            $(".countInvnetory").append('<a href="#">' + (data.Index + 1) + '/' + data.Count + '</a>');
                        }
                    }
                });
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    });
});
//Hien thi thong tin san pham truoc
$(document).ready(function () {
    $("#buttonpreviousForInventory").click(function () {
        var id = $("#id").val();
        $.ajax({
            url: '/InventoryManager/PreviousInventory',
            data: { id: id },
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#inventory-list").empty();
                $("#inventory-list").append(data);
            },
            beforeSend: function () {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("open");
                $.ajax({
                    url: '/InventoryManager/IndexOfInventory',
                    data: { id: id },
                    success: function (data) {
                        if (data.Index ==1) {
                            $(".countInvnetory").empty();
                            $(".countInvnetory").append('<a href="#">' + data.Index + '/' + data.Count + '</a>');
                        } else {
                            $(".countInvnetory").empty();
                            $(".countInvnetory").append('<a href="#">' + (data.Index - 1) + '/' + data.Count + '</a>');
                        }
                     
                    }
                });
            },
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    });
});
