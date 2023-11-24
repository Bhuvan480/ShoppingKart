$(function () {

});


function login() {
    if (isValidLogin()) {
        var email = $('#login-email').val();
        var password = $('#login-password').val();

        ValidateLogin(email, password);
    }
}


function isValidLogin() {
    $('#login-form').validate({
        rules: {
            email: {
                required: true,
                    email: true
            },
            password: {
                required: true,
                    minlength: 8
            },
        },
        messages: {
            email: {
                required: "Please enter your email",
                    email: "Please enter a valid email address"
            },
            password: {
                required: "Please enter your password",
                    minlength: "Password must be at least 8 characters long"
            }
        }
    });

    return $('#login-form').valid();
}

function ValidateLogin(email, password) {

    var logindetails = {
        email: email,
        password: password
    }

    $.ajax({
        url: '../Login/ValidateLogin',
        type: 'GET',
        data: logindetails,
        success: function (response)
        {
            if (!response.status) {
                $('#login-validate-error').text(response.message);
            }
            else
            {
                $('#login-validate-error').text('');
                window.location.href = response.redirectUrl;
            }
        },
        error: function (error) { }
    });
}

function register() {
    
    if (isValidRegister()) {
        var name = $('#username').val();
        var email = $('#register-email').val();
        var password = $('#register-password').val();

        RegisterUser(name, email, password);
    }
}

function isValidRegister() {
    $('#register-form').validate({
        rules: {
            username: {
                required: true,
            },
            email: {
                required: true,
                email: true
            },
            password: {
                required: true,
                minlength: 8
            },
            ConfirmPassword: {
                required: true,
                minlength: 8,
                equalTo: '#register-password'
            }
        },
        messages: {
            username: {
                required: "Please enter your name"
            },
            email: {
                required: "Please enter your email",
                email: "Please enter a valid email address"
            },
            password: {
                required: "Please enter your password",
                minlength: "Password must be at least 8 characters long"
            },
            ConfirmPassword:{
                required: "Please enter your confirm password",
                minlength: "Password must be at least 8 characters long",
                equalTo: 'Confirm password not matching'
            }
        }
    });

    return $('#register-form').valid();
}

function RegisterUser(name, email, password) {
    var data = {
        name: name,
        email: email,
        password: password
    }

    $.ajax({
        url: '../Register/RegisterUser',
        type: 'POST',
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (response)
        {
            if (response.success) {
                window.location.href = response.redirectUrl;
            }
            else {
                $('#register-validate-error').text('Email already Exists!');
            }
        },
        error: function (error)
        {
            console.error(error);
        }
    });
}