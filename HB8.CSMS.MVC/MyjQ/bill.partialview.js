//Hien thi danh sach loai
$(document).ready(function () {
    $('.ddlInventoryForBill').change(function () {
        var id = $(this).val();
        $.ajax({
            url: "/BillSaleOrderManager/ShowColumnUnit",
            type: 'Get',
            data: { id: id },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#tableInventory > tr:last >td:nth-child(4)").empty();
                $("#tableInventory > tr:last >td:nth-child(4)").append(data);
            },
            error: function (result) {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    });
})
//Hien thi gia
$(document).ready(function () {
    $('.ddlUnitForBill').change(function () {
        var id = $(this).val();
        var idInventory = $(this).parents('tr:first').find('td:eq(1)').find('select.ddlInventoryForBill').val();
        $.ajax({
            url: "/BillSaleOrderManager/ShowColumnPrice",
            type: 'Get',
            data: { id: id, idInventory: idInventory },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#tableInventory > tr:last >td:nth-child(5)").empty();
                $("#tableInventory > tr:last >td:nth-child(5)").append(data);
            },
            error: function (result) {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    });
})
//Hien thi tong tien
$(document).ready(function () {
    $('.quantity').change(function () {
        var quantity = $(this).val();
        var price = $(this).parents('tr:first').find('td:eq(4)').find('p').html();
        var tax = $(this).parents('tr:first').find('td:eq(6)').find('select.ddlTaxForBill').val();
        var overDisc = $(this).parents('tr:first').find('td:eq(5)').find('input').val();
        $.ajax({
            url: "/BillSaleOrderManager/TotalPrice",
            type: 'Get',
            data: { quantity: quantity, price: price, tax: tax, overDisc: overDisc },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#tableInventory > tr:last >td:nth-child(8)").empty();
                $("#tableInventory > tr:last >td:nth-child(8)").append(data);

            },
            error: function (result) {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });

    });
})
//Hien thi gia tien khi thay doi gia chiec khau
$(document).ready(function () {
    $('.disc').change(function () {
        var quantity = $(this).val();
        var price = $(this).parents('tr:first').find('td:eq(4)').find('p').html();
        var overDisc = $(this).parents('tr:first').find('td:eq(5)').find('input').val();
        var tax = $(this).parents('tr:first').find('td:eq(6)').find('select.ddlTaxForBill').val();
       
        $.ajax({
            url: "/BillSaleOrderManager/TotalPrice",
            type: 'Get',
            data: { quantity: quantity, price: price, tax: tax, overDisc: overDisc },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#tableInventory > tr:last >td:nth-child(8)").empty();
                $("#tableInventory > tr:last >td:nth-child(8)").append(data);

            },
            error: function (result) {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });

    });
})
//Cap nhat lai gia tien neu thue thay doi
$(document).ready(function () {
    $('.ddlTaxForBill').change(function () {
        var quantity = $(this).parents('tr:first').find('td:eq(2)').find('input').val();
        var price = $(this).parents('tr:first').find('td:eq(4)').find('p').html();
        var tax = $(this).parents('tr:first').find('td:eq(6)').find('select.ddlTaxForBill').val();
        var overDisc = $(this).parents('tr:first').find('td:eq(5)').find('input').val();
        $.ajax({
            url: "/BillSaleOrderManager/TotalPrice",
            type: 'Get',
            data: { quantity: quantity, price: price, tax: tax, overDisc: overDisc },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#tableInventory > tr:last >td:nth-child(8)").empty();
                $("#tableInventory > tr:last >td:nth-child(8)").append(data);
            },
            error: function (result) {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });

    });
})
//Xac nhan san pham duoc chon
$(document).ready(function () {
    $('.btnOkForBillSaleOrder').click(function () {
        var id = $(this).parents('tr:first').find('td:eq(0)').find('p').html();
        var invtId = $(this).parents('tr:first').find('td:eq(1)').find('select.ddlInventoryForBill ').val();
        var quantity = $(this).parents('tr:first').find('td:eq(2)').find('input').val();
        var unitId = $(this).parents('tr:first').find('td:eq(3)').find('select.ddlUnitForBill').val();
        var price = $(this).parents('tr:first').find('td:eq(4)').find('p').html();
        var orderDisc = $(this).parents('tr:first').find('td:eq(5)').find('input').val();
        var tax = $(this).parents('tr:first').find('td:eq(6)').find('select.ddlTaxForBill').val();
        var amount = $(this).parents('tr:first').find('td:eq(7)').find('p').html();
        $.ajax({
            url: "/BillSaleOrderManager/Update",
            data: { id: id, invtId: invtId, quantity: quantity, salePrice: price, tax: tax, amount: amount, unitId: unitId, orderDisc: orderDisc },
            contentType: "application/json; charset=utf-8",
            success: function (data) {             
                setTimeout(function () {
                    $("#tableInventory > tr:last >td:nth-child(9)>button>span").empty();
                    $("#tableInventory > tr:last >td:nth-child(9)>button>span").attr('class', 'glyphicon glyphicon-edit');
                }, 150)
            },
            beforeSend: function () {
                $("#tableInventory > tr:last >td:nth-child(9)>button>span").empty();
                $("#tableInventory > tr:last >td:nth-child(9)>button>span").attr('class', 'fa fa-refresh fa-spin');
            },
            error: function (result) {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    })

})
//Xoa di san pham duoc chon
$(document).ready(function () {
    $(".btnDeleteForBillSaleOrder").click(function () {
        var id = $(this).parents('tr:first').find('td:eq(0)').find('p').html();
        $(this).closest("tr").remove();
        $.ajax({
            url: "/BillSaleOrderManager/DeteleAnInventory",
            data: { id: id },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
              
            },          
            error: function () {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });
    })
})