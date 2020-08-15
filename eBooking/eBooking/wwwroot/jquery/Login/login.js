$(document).ready(function () {
    jQuery.fn.ForceNumericOnly =
        function () {
            return this.each(function () {
                $(this).keydown(function (e) {
                    var key = e.charCode || e.keyCode || 0;
                    // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers ONLY
                    // home, end, period, and numpad decimal
                    return (
                        key == 8 ||
                        key == 9 ||
                        key == 13 ||
                        key == 46 ||
                        key == 190 ||
                        (key >= 35 && key <= 40) ||
                        (key >= 48 && key <= 57) ||
                        (key >= 96 && key <= 105));
                });
            });
        };
    $("#txtMobNum").ForceNumericOnly();
    $('#txtMobNum').keypress(function () {
        $('#txtMobNum').removeClass('is-invalid');
        $('#txtMobNumVal').text('');
    });
    $('#txtOTP').keypress(function () {
        $('#txtOTP').removeClass('is-invalid');
        $('#txtOTPlVal').text('');
    });
    $('#btnSendOPT').click(function () {
        if ($.trim($('#txtMobNum').val()) == '') {
            $('#txtMobNum').removeClass('is-invalid').addClass('is-invalid');
            $('#txtMobNumVal').text('Mobile Number is Required For OTP');
        }
        else {
            $('#txtMobNum').prop('disabled', true);
            $(this).text('Re-Send OTP').removeClass('btn-primary').addClass('btn-warning');
            $("#txtOTP,#btnSubmit").attr("hidden", false);
            $("#txtOTP").focus();
        }
    });
    $('#btnSubmit').click(function () {
        if ($.trim($('#txtOTP').val()) == '') {
            $('#txtOTP').removeClass('is-invalid').addClass('is-invalid');
            $('#txtOTPVal').text("OTP can't be Empty");
        }
        else {
            var url = $("#RedirectTo").val();
            location.href = url;
        }
    });
    $('#btnCreateUser').click(function () {
        fn_createUser();
    });
    async function fn_createUser() {
        $.ajax({
            url: '/Home/RegisterUser',
            type: 'GET',
            async: false,
            cache: false,
            success: function (data) {
                $('#RegisterUserModal').empty().append(data);
            }
        });
    }
});