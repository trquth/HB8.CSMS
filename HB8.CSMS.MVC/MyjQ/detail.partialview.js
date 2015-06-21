//Xac nhan hoa don
$(document).ready(function () {
    $("#btnConfirmBill").click(function () {
        var id = $("#id").val();
        $.ajax({
            url: '/BillSaleOrderManager/Confirm',
            data: { id: id },
            type: 'GET',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $.ajax({
                    url: '/BillSaleOrderManager/DetailBill',
                    data: { "id": id },
                    type: "Get",
                    success: function (data) {
                        var theDialog = $("#showLoading").dialog(opt);
                        theDialog.dialog("close");
                        $("#buttonEditForBillSaleOrder").hide();
                        $("#buttonpreviousForBillSaleOrder").show();
                        $("#buttonnextForBillSaleOrder").show();
                        $("#buttonpreviousForBillSaleOrder").show();
                        $("#buttonnextForBillSaleOrder").show();
                        $("#billsaleorder-list").empty();
                        $("#billsaleorder-list").append(data);
                        $.ajax({
                            url: '/BillSaleOrderManager/ShowListInventoryOfBill',
                            data: { id: id },
                            type: "Get",
                            success: function (data) {
                                $("#tableInventory").empty();
                                $("#tableInventory").append(data);
                            }
                        });
                    },
                    beforeSend: function () {
                        var theDialog = $("#showLoading").dialog(opt);
                        theDialog.dialog("open");

                    },
                    error: function () {
                        swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
                    }
                });
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
//Huy hoa don
$(document).ready(function () {
    $("#btnCancleBill").click(function () {
        var id = $("#id").val();
        $.ajax({
            url: '/BillSaleOrderManager/Cancel',
            data: { id: id },
            type: 'GET',
            success: function (data) {
                var theDialog = $("#showLoading").dialog(opt);
                theDialog.dialog("close");
                $.ajax({
                    url: '/BillSaleOrderManager/DetailBill',
                    data: { "id": id },
                    type: "Get",
                    success: function (data) {
                        var theDialog = $("#showLoading").dialog(opt);
                        theDialog.dialog("close");
                        $("#buttonEditForBillSaleOrder").show();
                        $("#buttonpreviousForBillSaleOrder").show();
                        $("#buttonnextForBillSaleOrder").show();
                        $("#buttonpreviousForBillSaleOrder").show();
                        $("#buttonnextForBillSaleOrder").show();
                        $("#billsaleorder-list").empty();
                        $("#billsaleorder-list").append(data);
                        $.ajax({
                            url: '/BillSaleOrderManager/ShowListInventoryOfBill',
                            data: { id: id },
                            type: "Get",
                            success: function (data) {
                                $("#tableInventory").empty();
                                $("#tableInventory").append(data);
                            }
                        });
                    },
                    beforeSend: function () {
                        var theDialog = $("#showLoading").dialog(opt);
                        theDialog.dialog("open");

                    },
                    error: function () {
                        swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
                    }
                });
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