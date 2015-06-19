//Cai dat 
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
//Goi lai trang chu cho STAFF
$(document).ready(function () {
    $("#qlnv").click(function () {
        $.ajax({
            url: "/StaffManager/Index",
            data: '{}',
            type: 'Get',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#content").empty();
                $("#content").append(data);
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
})
//Goi lai trang chu cho INVENTORY
$(document).ready(function () {
    $("#qlsp").click(function () {
        $.ajax({
            url: "/InventoryManager/Index",
            data: '{}',
            type: 'Get',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#content").empty();
                $("#content").append(data);
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
})
//Goi lai trang chu cho CUSTOMER
$(document).ready(function () {
    $("#qlkh").click(function () {
        $.ajax({
            url: "/CustomerManager/Index",
            data: '{}',
            type: 'Get',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#content").empty();
                $("#content").append(data);
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
})
//Goi lai trang chu cho BILL
$(document).ready(function () {
    $("#qlhd").click(function () {
        $.ajax({
            url: "/BillSaleOrderManager/Index",
            data: '{}',
            type: 'Get',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $("#content").empty();
                $("#content").append(data);
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
})