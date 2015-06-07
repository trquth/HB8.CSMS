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
        var tax = $(this).parents('tr:first').find('td:eq(5)').find('select.ddlTaxForBill').val();
        $.ajax({
            url: "/BillSaleOrderManager/TotalPrice",
            type: 'Get',
            data: { quantity: quantity, price: price, tax:tax},
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#tableInventory > tr:last >td:nth-child(7)").empty();
                $("#tableInventory > tr:last >td:nth-child(7)").append(data);
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
        var tax = $(this).parents('tr:first').find('td:eq(5)').find('select.ddlTaxForBill').val();
        $.ajax({
            url: "/BillSaleOrderManager/TotalPrice",
            type: 'Get',
            data: { quantity: quantity, price: price, tax: tax },
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#tableInventory > tr:last >td:nth-child(7)").empty();
                $("#tableInventory > tr:last >td:nth-child(7)").append(data);
            },
            error: function (result) {
                swal({ title: "Xảy ra lỗi", text: "Vui lòng load lại trang web", timer: 2000, showConfirmButton: false });
            }
        });

    });
})