$(document).ready(function () {
    newYearSelected();
    $('.registerForm').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            username: {
                message: 'Не правильний логін',
                validators: {
                    notEmpty: {
                        message: 'Логін не може бути порожнім'
                    },
                    stringLength: {
                        min: 2,
                        max: 30,
                        message: 'Логін повинен містити від 2 до 30 символів'
                    },
                    regexp: {
                        regexp: /^[a-zA-Z0-9_]+$/,
                        message: 'Логін може містити тільки літери і цифри'
                    }
                }
            },
            email: {
                validators: {
                    notEmpty: {
                        message: 'email адреса не може бути порожньою'
                    },
                    emailAddress: {
                        message: 'Ви ввели не вірну email адресу'
                    }
                }
            },
            password: {
                validators: {
                    notEmpty: {
                        message: 'Введіть пароль'
                    }
                }
            },
            secondPassword: {
                validators: {
                    notEmpty: {
                        message: 'Введіть пароль'
                    },
                    identical: {
                        field: 'password',
                        message: 'Пароль і підтвердження паролю не співпадають'
                    }
                }
            }
        }
    });
    $('#loginform').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            username: {
                message: 'Не правильний логін',
                validators: {
                    notEmpty: {
                        message: 'Логін не може бути порожнім'
                    },
                    stringLength: {
                        min: 2,
                        max: 30,
                        message: 'Логін повинен містити від 2 до 30 символів'
                    },
                    regexp: {
                        regexp: /^[a-zA-Z0-9_]+$/,
                        message: 'Логін може містити тільки літери і цифри'
                    }
                }
            },
            email: {
                validators: {
                    notEmpty: {
                        message: 'email адреса не може бути порожньою'
                    },
                    emailAddress: {
                        message: 'Ви ввели не вірну email адресу'
                    }
                }
            },
            password: {
                validators: {
                    notEmpty: {
                        message: 'Введіть пароль'
                    }
                }
            },
            secondPassword: {
                validators: {
                    notEmpty: {
                        message: 'Введіть пароль'
                    },
                    identical: {
                        field: 'password',
                        message: 'Пароль і підтвердження паролю не співпадають'
                    }
                }
            }
        }
    });
});

function newYearSelected() {
    $('#graduates').fadeOut();
    $('#graduates').empty();
    $('#graduates').append('<th>Випускник</th>');
    $.ajax({
        url: '/Home/Changed?Year=' + $('#year').val(),
        type: 'post',
        dataType: 'json',
        success: function (data) {
            $.each(data, function (key, val) {
                var person = '<tr><td>' + val.FullName + '</td> </tr>';
                $("#graduates").append(person);
            });
            $('#graduates').fadeIn(2000);
        },
    });
};


