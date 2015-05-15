
var selectedId = 0;
$(document).ready(function () {
    $('.buttonEdit').prop("disabled", false);
    $('.buttonCreate').prop("disabled", false);
    $('.buttonDelete').prop("disabled", false);

})
$(document).ready(function () {
    $(".itemIdClass").hide();
    $("#deleteForm").hide();

});
//jQueryUI method to create dialog box
$("#createForm").dialog({
    autoOpen: false,
    height: 400,
    width: 1200,
    resizable: false,
    modal: true,
    open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
});
//jQueryUI hien FORM EDIT
$("#editForm").dialog({
    autoOpen: false,
    height: 400,
    width: 1200,
    resizable: false,
    modal: true,
    open: function (event, ui) { $(".ui-dialog-titlebar-close").hide(); },
});
$(window).resize(function () {
    $("#editForm").dialog("option", "position", { my: "center", at: "center", of: window });
});
//jQueryUI method to create dialog box
$("#deleteForm").dialog({
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

$(".buttonCreate").button().click(function () {
    $.ajax({
        // Goi CreateStaffPV action
        url: "/StaffManager/CreateStaffPV",
        type: 'Get',
        success: function (data) {
            $("#createForm").dialog("open");
            $("#createForm").empty().append(data);
            $("#editForm").hide();
            $(".buttonEdit").attr('disabled', 'disabled');
            $(".buttonDelete").attr('disabled', 'disabled');
        },
        error: function () {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
});

var selectedTrainer;

$(".buttonEdit").button().click(function () {
    // Lấy về Id và gán cho biến selectedId 
    var selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
    selectedStaffName = $(this).parents('tr:first').children('td:nth-child(3)').text().trim();

    $.ajax({
        // Gọi 
        url: "/StaffManager/EditStaffPV",
        data: { id: selectedId },
        type: 'Get',
        success: function (msg) {
            $("#editForm").dialog("open");
            $("#editForm").empty().append(msg);
            $("#createForm").hide();
            $(".buttonEdit").attr('disabled', 'disabled');
            $(".buttonDelete").attr('disabled', 'disabled');
        },
        error: function () {
            swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
        }
    });
});



$(".buttonDelete").button().click(function () {
    $(".buttonEdit").attr('disabled', 'disabled');
    $(".buttonCreate").attr('disabled', 'disabled');
    $(".buttonDelete").attr('disabled', 'disabled');
    //Open the dialog box
    $("#deleteForm").dialog("open");
    //Get the TrainingId
    selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
});
$(".buttonCloseDelete").button().click(function () {
    $('.buttonEdit').prop("disabled", false);
    $('.buttonCreate').prop("disabled", false);
    $('.buttonDelete').prop("disabled", false);
    //Open the dialog box
    $("#deleteForm").dialog("close");


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




$("#btnListView").button().click(function () {
    $("#showLoading").dialog("open");
    $("#listView").show();
    $(".gridView").hide();
    $(".pagination").show();
});

$("#btnGirdView").button().click(function () {
    $("#showLoading").dialog("open");
    $("#listView").hide();
    $(".gridView").show();
    $(".pagination").hide();
});


//var page = 0;
//var _inCallback = false;
//$("#demo").click(function () {
//    if (page > -1 && !_inCallback) {
//        _inCallback = true;
//        page++;
//        $('div#loading').html('<p><img src="/Content/Images/loading.gif"></p>');
//        $.get("/CustomerManager/Index2/" + page, function (data) {
//            if (data != '') {
//                $("#productList").append(data);
//            }
//            else {
//                page = -1;
//            }

//            _inCallback = false;
//            $('div#loading').empty();
//        });
//    }
//});



//$(document).ready(function () {
//    $(".page-number").click(function () {
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
//    });
//});
