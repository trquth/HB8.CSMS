
$(document).ready(function () {

    $("#traininId").hide();
    //Create jQuery timpicker
    $("#edittimepicker").timepicker();
    //Create jQueryUI datepicker
    $("#startdatepicker").datepicker();
    $("#enddatepicker").datepicker();
    $.ajax({
        url: "/Home/GetInstructorList",
        type: 'Get',
        success: function (data) {
            $.each(data, function (i, value) {
                if (value === selectedTrainer)
                    $('#editselectInstructor').append($('<option>').text(value).attr('value', value).attr("selected", "selected"));
                $('#editselectInstructor').append($('<option>').text(value).attr('value', value));
            });
        }
    });
});
//$(function () {
//    $.ajax({
//        url: "/StaffManager/ListPosition",
//        type: 'Get',
//        data: "{}",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function (data) {
//            $.each(data, function (key, value) {
//                $("#ddlPosition").append($("<option></option>").val(value.UserId).html(value.UserName));
//            });
//        },
//        error: function (result) {
//            alert("Error")
//        }
//    });
//});

$("#update-button").click(function () {
    //$("#editForm").dialog("close");

    var id = $("#traininId").val();
    var name = $("#name").val();
    var instructor = $("#editselectInstructor").val();
    var startdatepicker = $("#startdatepicker").val();
    var enddatepicker = $("#enddatepicker").val();
    var timepicker = $("#edittimepicker").val();
    var duration = $("#duration").val();
    // Call Edit action method
    $.post('/StaffManager/EditStaff', { "id": id, "name": name, "instructor": instructor, "startdate": startdatepicker, "enddate": enddatepicker, "time": timepicker, "duration": duration }, function () {
        alert("data is posted successfully");
        window.location.reload(true);
    });
});


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
            alert("Error")
        }
    });
})


$(document).ready(function () {
    $('#staffform').validate({

    });
});


$(function () {
    $("#uploadFile").on("change", function () {
        var files = !!this.files ? this.files : [];
        if (!files.length || !window.FileReader) return; // no file selected, or no FileReader support

        if (/^image/.test(files[0].type)) { // only image file
            var reader = new FileReader(); // instance of the FileReader
            reader.readAsDataURL(files[0]); // read the local file

            reader.onloadend = function () { // set image data as background of div
                $('#changeimage').attr('src', this.result);

            }
        }
    });
});
