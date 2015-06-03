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
////TIP: SƠN HUONG DAN ONCLICK TRUC TIEP
//function btnListViewForCustomer_Click(id) {
//    //ToDo: Something
//    alert('ID');
//}
//$('[id*=]').
//var theDialog = $("#showLoading").dialog(opt);
//theDialog.dialog("close");
/*,
        beforeSend: function () {
            var theDialog = $("#showLoading").dialog(opt);
            theDialog.dialog("open");
        },*/
function btnListViewForCustomer_Click() {
    $.ajax({
        url: '/CustomerManager/ListCustomerView',
        data: {},
        type: 'GET',
        success: function (data) {

            $("#btnloadcustomer").hide();
            $("#person-list").empty();
            $("#person-list").append(data);
        },
        error: function () {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }

    })
}


//$(document).ready(function () {
//    $("#listView").hide();
//    $("#showspinnerForm").hide();
//    $("#showLoading").hide();
//    $(".pagination").hide();
//    $("#paging").hide();
//    $(".buttonEditForDetail").hide();
//});

//Hien thi them danh sach khach hang
//$(document).ready(function () {
//    var page = 0;
//    var _inCallback = false;
//    var count = parseInt($('#count').val());
//    var pagesize = parseInt($('#pagesize').val());
//    $("#btnload").click(function () {
//        var flag = $("#btnGirdView").attr("value");
//        if (flag == 1) {
//            $("#btnGirdView").val("");
//            page = 0;
//        } else {
//            if (page > -1 && !_inCallback) {
//                _inCallback = true;
//                page++;
//                var result = count - (pagesize * page) - pagesize;
//                $("#btnload").text("Còn lại " + result + " kết quả")
//                $.get("/CustomerManager/ListCustomer/" + page, function (data) {
//                    var number = parseInt($(data).find('#getnumberpages').val()) - 1;
//                    if (number == page) {
//                        $("#btnload").hide();
//                        $("#btnload").val(0);
//                    }
//                    var name = $(data).find('#getname').text();
//                    var address = $(data).find('#getaddress').text();
//                    var phone = $(data).find('#getphone').text();
//                    if (name != "" && address != "" && phone != "") {
//                        $("#person-list").append(data);
//                    }
//                    else {

//                        page = -1;
//                    }
//                    _inCallback = false;
//                    $("#showLoading").dialog("open");
//                });
//            }
//        }

//    });

//});

//Hien thi danh sach khach hang dang list tung trang
//$(document).ready(function () {
//    $(".page-number").on('click', function () {
//        var page = parseInt($(this).html());
//        $.ajax({
//            url: '/CustomerManager/CustomerList',
//            data: { "page": page },
//            success: function (data) {
//                $("#person-list").html(data);
//                $(".gridView").hide();
//                $("#listView").show();
//            }
//        });
//        return false;
//    });
//});

//Hien thi thong tin khach hang tiep theo
//$(document).ready(function () {
//    $("#buttonnext").click(function () {
//        var id = $("#getId").val();
//        $.ajax({
//            url: '/CustomerManager/NextCustomer',
//            data: { id: id },
//            success: function (data) {
//                $("#person-list").html(data);
//            },
//            beforeSend: function () {
//                $("#showLoading").dialog("open");
//            },
//        });
//    });
//});

//Hien thi thong tin khach hang truoc
//$(document).ready(function () {
//    $("#buttonprevious").click(function () {
//        var id = $("#getId").val();
//        $.ajax({
//            url: '/CustomerManager/PreviousCustomer',
//            data: { id: id },
//            success: function (data) {
//                $("#person-list").html(data);
//            },
//            beforeSend: function () {
//                $("#showLoading").dialog("open");
//            },
//        });
//    });
//});

//Xu li su kien khi nhan vao nut LIST VIEW
//$("#btnListView").button().click(function () {
//    $("#showLoading").dialog("open");
//    $("#listView").show();
//    $(".gridView").hide();
//    $(".pagination").show();
//    $("#btnload").hide();
//    $(".buttonEditForCustomer").hide();
//    $("#paging").hide();
//});
//$(document).ready(function () {
//    $("#btnListView").button().click(function () {
//        $("#listView").show();
//        $(".gridView").hide();
//        $(".pagination").show();

//    });
//});
//Xu li su kien khi nhan vao nut GRID VIEW
//$("#btnGirdView").button().click(function () {
//    $("#showLoading").dialog("open");
//    $("#listView").hide();
//    $(".gridView").show();
//    $(".pagination").hide();
//    $(".buttonEditForCustomer").hide();
//    $("#paging").hide();
//    //var flag = $("#btnload").attr('value');
//    //if (flag != "") {
//    //    $("#btnload").hide();
//    //} else {
//    //    $("#btnload").show();
//    //}
//    $.ajax({
//        url: "/CustomerManager/ListCustomer/",
//        type: 'Get',
//        success: function (data) {
//            $("#person-list").empty();
//            var flag = $("#btnload").add('value');
//            if (flag != "") {
//                $("#btnload").val("");
//            }
//            $("#btnGirdView").val("1");//danh dau xem biet la co click nut gridview lan nao chua
//            $("#btnload").show();
//            $("#btnload").text("Hiển thị thêm")
//            $("#person-list").append(data);
//        },
//    });
//});
//$(document).ready(function () {
//    $("#btnGirdView").button().click(function () {

//        $("#listView").hide();
//        $(".gridView").show();
//        $(".pagination").hide();

//    });
//});
//Goi ra form EDIT cho CUSTOMER voi nut EDIT nam trong LIST VIEW
//$(".buttonEditForCustomer").button().click(function () {
//    // Lấy về Id và gán cho biến selectedId 
//    var selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
//    // selectedStaffName = $(this).parents('tr:first').children('td:nth-child(3)').text().trim();
//    $.ajax({
//        // Gọi 
//        url: "/CustomerManager/EditCustomerPV",
//        data: { id: selectedId },
//        type: 'Get',
//        success: function (msg) {
//            $("#editFormCustomer").dialog("open");
//            $("#editFormCustomer").empty().append(msg);
//            //$("#createForm").hide();
//            //$(".buttonEdit").attr('disabled', 'disabled');
//            //$(".buttonDelete").attr('disabled', 'disabled');
//        },
//        error: function () {
//            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
//        }
//    });
//});

////jQueryUI hien FORM EDIT
//$("#editFormCustomer").dialog({
//    autoOpen: false,
//    height: 400,
//    width: 1200,
//    resizable: false,
//    modal: true,
//    open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
//});

////Cho FORM DIALOG nam o giua man hinh
//$(window).resize(function () {
//    $("#editFormCustomer").dialog("option", "position", { my: "center", at: "center", of: window });
//});

//Goi ra form EDIT cho CUSTOMER voi nut EDIT nam trong DETAIL CUSTOMER
//$(document).ready(function () {
//    $(".buttonEditForDetail").click(function () {
//        var id = $("#getId").val();
//        $.ajax({
//            // Gọi 
//            url: "/CustomerManager/EditCustomerPV",
//            data: { id: id },
//            type: 'Get',
//            success: function (msg) {
//                $("#editFormCustomer").dialog("open");
//                $("#editFormCustomer").empty().append(msg);
//                //$("#createForm").hide();
//                //$(".buttonEdit").attr('disabled', 'disabled');
//                //$(".buttonDelete").attr('disabled', 'disabled');
//            },
//            error: function () {
//                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
//            }
//        });
//    });
//});

//Hien thi thong tin CUSTOMER chi tiet
//$(document).ready(function () {
//    $(".detailcustomer").on("click", function () {
//        var id = $(this).attr('value');
//        $.ajax({
//            url: '/CustomerManager/DetailCustomer',
//            data: { "custId": id },
//            success: function (data) {
//                $("#btnload").hide();
//                $("#paging").show();
//                $(".buttonEditForDetail").show();
//                //$("#addbutton").append("<input type='button' value='Sửa' class='buttonEdit btn btn-default' />");
//                $("#person-list").empty();
//                $("#person-list").append(data);
//            },
//            beforeSend: function () {
//                $("#showLoading").dialog("open");
//            },
//        });

//    });
//});
//$("#btnListView").button().click(function () {
//    $("#showLoading").dialog("open");
//    $("#listView").show();
//    $(".gridView").hide();
//    $(".pagination").show();
//    $("#btnload").hide();
//});

//$("#btnGirdView").button().click(function () {
//    $("#showLoading").dialog("open");
//    $("#listView").hide();
//    $(".gridView").show();
//    $(".pagination").hide();
//    //var flag = $("#btnload").attr('value');
//    //if (flag != "") {
//    //    $("#btnload").hide();
//    //} else {
//    //    $("#btnload").show();
//    //}
//    $.ajax({
//        url: "/CustomerManager/ListCustomer/",
//        type: 'Get',
//        success: function (data) {
//            $("#person-list").empty();
//            var flag = $("#btnload").add('value');
//            if (flag != "") {
//                $("#btnload").val("");
//            }
//            $("#btnGirdView").val("1");//danh dau xem biet la co click nut gridview lan nao chua
//            $("#btnload").show();
//            $("#btnload").text("Hiển thị thêm")
//            $("#person-list").append(data);
//        },
//    });
//});
////Goi ra form EDIT cho CUSTOMER
//$(".buttonEditForCustomer").button().click(function () {
//    // Lấy về Id và gán cho biến selectedId 
//    var selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
//    // selectedStaffName = $(this).parents('tr:first').children('td:nth-child(3)').text().trim();
//    $.ajax({
//        // Gọi 
//        url: "/CustomerManager/EditCustomerPV",
//        data: { id: selectedId },
//        type: 'Get',
//        success: function (msg) {
//            $("#editFormCustomer").dialog("open");
//            $("#editFormCustomer").empty().append(msg);
//            //$("#createForm").hide();
//            //$(".buttonEdit").attr('disabled', 'disabled');
//            //$(".buttonDelete").attr('disabled', 'disabled');
//        },
//        error: function () {
//            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
//        }
//    });
//});

////jQueryUI hien FORM EDIT
//$("#editFormCustomer").dialog({
//    autoOpen: false,
//    height: 400,
//    width: 1200,
//    resizable: false,
//    modal: true,
//    open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
//});

//$(window).resize(function () {
//    $("#editFormCustomer").dialog("option", "position", { my: "center", at: "center", of: window });
//});


//$("#deleteFormCustomer").dialog({
//    autoOpen: false,
//    modal: true,
//    height: 200,
//    width: 600,
//    resizable: false,
//    modal: true,
//    open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
//});
//$(".buttonDelete").button().click(function () {
//    $(".buttonEdit").attr('disabled', 'disabled');
//    $(".buttonCreate").attr('disabled', 'disabled');
//    $(".buttonDelete").attr('disabled', 'disabled');
//    //Open the dialog box
//    $("#deleteForm").dialog("open");
//    //Get the TrainingId
//    selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
//});
//$(".buttonCloseDelete").button().click(function () {
//    $('.buttonEdit').prop("disabled", false);
//    $('.buttonCreate').prop("disabled", false);
//    $('.buttonDelete').prop("disabled", false);
//    //Open the dialog box
//    $("#deleteForm").dialog("close");


//});
//$(".okDelete").button().click(function () {
//    $('.buttonEdit').prop("disabled", false);
//    $('.buttonCreate').prop("disabled", false);
//    $('.buttonDelete').prop("disabled", false);
//    // Close the dialog box on Yes button is clicked
//    $("#deleteForm").dialog("close");
//    $.ajax({
//        // Call Delete action method
//        url: "/StaffManager/DeleteStaff",
//        data: { id: selectedId },
//        type: 'Get',
//        success: function (msg) {

//            window.location.reload(true);
//        },
//        beforeSend: function () {
//            //$("#showspinner").html("<center><i class='fa fa-spinner fa-spin fa-5x ' id='spinner'></i></center>").delay(10000000).fadeOut();
//            $("#showspinnerForm").dialog("open");
//        },
//        error: function (xhr) {
//            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
//        }
//    });
//});
//$("#btnListView").button().click(function () {
//    $("#showLoading").dialog("open");
//    //$("#listView").show();
//    //$(".gridView").hide();
//    $(".pagination").show();
//    $("#btnload").hide();
//    $(".buttonEdit").hide();
//    $("#buttonnext").hide();
//    $("#buttonprevious").hide();
//    $.ajax({
//        url: "/CustomerManager/ListCustomer/",
//        type: 'Get',
//        success: function (data) {
//            $("#person-list").empty();
//            //var flag = $("#btnload").add('value');
//            //if (flag != "") {
//            //    $("#btnload").val("");
//            //}
//            //$("#btnGirdView").val("1");//danh dau xem biet la co click nut gridview lan nao chua        
//            $("#person-list").append(data);
//            $(".gridView").hide();
//            $("#listView").show();
//        },
//    });
//});

//$("#btnGirdView").button().click(function () {
//    $("#showLoading").dialog("open");
//    $("#listView").hide();
//    $(".gridView").show();
//    $(".pagination").hide();
//    $(".buttonEdit").hide();
//    $("#buttonnext").hide();
//    $("#buttonprevious").hide();
//    //var flag = $("#btnload").attr('value');
//    //if (flag != "") {
//    //    $("#btnload").hide();
//    //} else {
//    //    $("#btnload").show();
//    //}
//    $.ajax({
//        url: "/CustomerManager/ListCustomer/",
//        type: 'Get',
//        success: function (data) {
//            $("#person-list").empty();
//            var flag = $("#btnload").add('value');
//            if (flag != "") {
//                $("#btnload").val("");
//            }
//            $("#btnGirdView").val("1");//danh dau xem biet la co click nut gridview lan nao chua
//            $("#btnload").show();
//            $("#btnload").text("Hiển thị thêm")
//            $("#person-list").append(data);
//        },
//    });
//});
////Goi ra form EDIT cho CUSTOMER
//$(".buttonEditForCustomer").button().click(function () {
//    // Lấy về Id và gán cho biến selectedId 
//    var selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
//    // selectedStaffName = $(this).parents('tr:first').children('td:nth-child(3)').text().trim();
//    $.ajax({
//        // Gọi 
//        url: "/CustomerManager/EditCustomerPV",
//        data: { id: selectedId },
//        type: 'Get',
//        success: function (msg) {
//            $("#editFormCustomer").dialog("open");
//            $("#editFormCustomer").empty().append(msg);
//            //$("#createForm").hide();
//            //$(".buttonEdit").attr('disabled', 'disabled');
//            //$(".buttonDelete").attr('disabled', 'disabled');
//        },
//        error: function () {
//            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
//        }
//    });
//});

////jQueryUI hien FORM EDIT
//$("#editFormCustomer").dialog({
//    autoOpen: false,
//    height: 400,
//    width: 1200,
//    resizable: false,
//    modal: true,
//    open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
//});

//$(window).resize(function () {
//    $("#editFormCustomer").dialog("option", "position", { my: "center", at: "center", of: window });
//});


//$("#deleteFormCustomer").dialog({
//    autoOpen: false,
//    modal: true,
//    height: 200,
//    width: 600,
//    resizable: false,
//    modal: true,
//    open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
//});
//$(".buttonDelete").button().click(function () {
//    $(".buttonEdit").attr('disabled', 'disabled');
//    $(".buttonCreate").attr('disabled', 'disabled');
//    $(".buttonDelete").attr('disabled', 'disabled');
//    //Open the dialog box
//    $("#deleteForm").dialog("open");
//    //Get the TrainingId
//    selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
//});
//$(".buttonCloseDelete").button().click(function () {
//    $('.buttonEdit').prop("disabled", false);
//    $('.buttonCreate').prop("disabled", false);
//    $('.buttonDelete').prop("disabled", false);
//    //Open the dialog box
//    $("#deleteForm").dialog("close");


//});
//$(".okDelete").button().click(function () {
//    $('.buttonEdit').prop("disabled", false);
//    $('.buttonCreate').prop("disabled", false);
//    $('.buttonDelete').prop("disabled", false);
//    // Close the dialog box on Yes button is clicked
//    $("#deleteForm").dialog("close");
//    $.ajax({
//        // Call Delete action method
//        url: "/StaffManager/DeleteStaff",
//        data: { id: selectedId },
//        type: 'Get',
//        success: function (msg) {

//            window.location.reload(true);
//        },
//        beforeSend: function () {
//            //$("#showspinner").html("<center><i class='fa fa-spinner fa-spin fa-5x ' id='spinner'></i></center>").delay(10000000).fadeOut();
//            $("#showspinnerForm").dialog("open");
//        },
//        error: function (xhr) {
//            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
//        }
//    });
//});
//**************************************************************************************//
//PHAN DANH CHO INVENTORY
//*************************************************************************************//
//Cai dat
$(document).ready(function () {
    $("#buttonEditForInventory").hide();
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
                //$("#buttonDeleteForStaff").show();
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
            $("#btnLargeViewForInventory").prop('value','');
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
})
