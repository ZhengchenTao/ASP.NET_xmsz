$(function () {
    var logflag = 0;
    var regflag = 0;
    $('#form-log').click(function () {
        $(this).tab('show');
        $('#log').tab('show');
        $('#username-group').removeClass('has-error');
        $('#username-group label').addClass('hidden');
        $('#userpass-group').removeClass('has-error');
        $('#userpass-group label').addClass('hidden');
        $('#reg-username').val('');
        $('#reg-userpass').val('');
        $('#reg-confirmpass').val('');
    });
    $('#form-reg').click(function () {
        $(this).tab('show');
        $('#reg').tab('show');
        $('#reg-username-group').removeClass('has-error');
        $('#reg-username-group label').addClass('hidden');
        $('#reg-userpass-group').removeClass('has-error');
        $('#reg-userpass-group label').addClass('hidden');
        $('#reg-confirmpass-group').removeClass('has-error');
        $('#reg-confirmpass-group label').addClass('hidden');
        $('#username').val('');
        $('#userpass').val('');
    });
    $('#logsub').click(function () {
        var username = $('#username').val().trim();
        var userpass = $('#userpass').val().trim();
        if (username == "" || username == null) {
            $('#username-group').addClass('has-error');
            $('#username-group label').removeClass('hidden');
            logflag = 0;
        } else {
            $('#username-group').removeClass('has-error');
            $('#username-group label').addClass('hidden');
            logflag++;
        }
        if (userpass == "" || userpass == null) {
            $('#userpass-group').addClass('has-error');
            $('#userpass-group label').removeClass('hidden');
            logflag = 0;
        } else {
            $('#userpass-group').removeClass('has-error');
            $('#userpass-group label').addClass('hidden');
            logflag++;
        }
        if (logflag == 2) {
            $('#log').submit();
        }
    });
    $('#regsub').click(function () {
        var username = $('#reg-username').val();
        var userpass = $('#reg-userpass').val();
        var confirmpass = $('#reg-confirmpass').val();
        if (username.length < 3 || username.length > 8) {
            $('#reg-username-group').addClass('has-error');
            $('#reg-username-group label').removeClass('hidden');
            regflag = 0;
        } else {
            $('#reg-username-group').removeClass('has-error');
            $('#reg-username-group label').addClass('hidden');
            regflag++;
        }
        if (userpass.length < 3 || userpass.length > 8) {
            $('#reg-userpass-group').addClass('has-error');
            $('#reg-userpass-group label').removeClass('hidden');
            regflag = 0;
        } else {
            $('#reg-userpass-group').removeClass('has-error');
            $('#reg-userpass-group label').addClass('hidden');
            regflag++;
        }
        if (userpass != confirmpass) {
            $('#reg-confirmpass-group').addClass('has-error');
            $('#reg-confirmpass-group label').removeClass('hidden');
            regflag = 0;
        } else {
            $('#reg-confirmpass-group').removeClass('has-error');
            $('#reg-confirmpass-group label').addClass('hidden');
            regflag++;
        }
        if (regflag == 3) {
            $('#reg').submit();
        }
    });
});