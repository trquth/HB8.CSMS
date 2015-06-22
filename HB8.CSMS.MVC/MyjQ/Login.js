//Kiem tra dang nhap
$(document).ready(function () {
    $('#loginForm').validate();
});
$(document).ready(function () {
    $("#btnLogin").click(function () {
        $(this).attr('type', 'button');
        var id = $("#userId").val();
        var pass = $("#password").val();
        if (id.length == 0 || pass.length == 0) {
            $(this).attr('type', 'submit');
        } else {
            $.ajax({
                url: "/LogIn/CheckAccount",
                data: { id: id, password: pass },
                type: 'POST',
                success: function (data) {
                },
                error: function () {
                    swal({ title: "Xảy ra lỗi", text: "Vui lòng kiểm tra lại ID và mật khẩu", timer: 2000, showConfirmButton: false });
                }
            })
        }

    })


})