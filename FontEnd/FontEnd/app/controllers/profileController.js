'use strict';
app.controller('profileController', function ($element, $location, $rootScope, $scope, cbbHttpService, authService, ngAuthSettings, fileReader) {
    $scope.usrnInfo = {};
    
    $scope.apiServiceBaseUri = ngAuthSettings.apiServiceBaseUri;
    cbbHttpService.Get('User').then(function (results) {
        //console.log(results);
        $scope.usrnInfo = results.data;
        $scope.usrnInfo.imagePath = results.data.imagePath ? $scope.apiServiceBaseUri + results.data.imagePath : $scope.apiServiceBaseUri + "Content/ProfileImage/Default.png";
        //console.log(results.data);
    }, function (error) {
        //alert(error.data.message);
    });
    var validatable;
    function infoValidate() {
        validatable = $element.find(".infoEdit").kendoValidator({
            validateOnBlur: false,
            validateOnKeyUp: true,
            errorTemplate: '<span class="input-error-warp"><span class="input-error-contain">#=message#</span></span>',
            rules: {
                customRule1: function (input) {
                    return $.trim(input.val()) !== "";
                },
                customRule2: function (input) {
                    if (input.is("[name=Mobile Number]")) {
                        return input.val().length >= 11;
                    }
                    return true;
                }
            }
        }).data("kendoValidator");
    }
    infoValidate();
    var tempName, tempMobile;
    $scope.forEdit = function () {
        tempName = $scope.usrnInfo.name;
        tempMobile = $scope.usrnInfo.mobile;
        $scope.isEdti = false;
    }
    $scope.cancelEdit = function () {
        $scope.usrnInfo.name = tempName;
        $scope.usrnInfo.mobile = tempMobile;
        $scope.isEdti = true;
        validatable.hideMessages();
    }
    $scope.Updata = function () {
        if (validatable.validate()) {
            cbbHttpService.Put('User', $scope.usrnInfo).then(function (results) {
                $scope.isEdti = true;
            }, function (error) {
                //alert(error.data.message);
            });
        } else {
            
        }
    }
    $scope.passwordModel = {
        oldPassword: "",
        newPassword:""
    };
    var validatePass;
    function passValidate() {
        validatePass = $element.find(".passwordEdit").kendoValidator({
            validateOnBlur: false,
            validateOnKeyUp: true,
            errorTemplate: '<span class="input-error-warp"><span class="input-error-contain">#=message#</span></span>',
            rules: {
                customRule1: function (input) {
                    return $.trim(input.val()) !== "";
                },
                customRule2: function (input) {
                    if (input.is("[name=New Password]")) {
                        return input.val().length >= 6;
                    }
                    return true;
                }
            }
        }).data("kendoValidator");
    }
    passValidate();

    $scope.passwordUpdata = function () {
        if (validatePass.validate()) {
            cbbHttpService.Put('Password', $scope.passwordModel).then(function (results) {
                if (!results.data.error) {
                    $scope.isEdtiPassword = true;
                    $scope.passwordError = false;
                    $scope.passwordModel.oldPassword = "";
                    $scope.passwordModel.newPassword = "";
                } else {
                    $scope.passwordError = true;
                }
            }, function (error) {

            });
        } else {

        }
        
    }

    $scope.forEditPassword = function () {
        $scope.isEdtiPassword = false;
    }
    $scope.cancelEditPassword = function () {
        $scope.isEdtiPassword = true;
        $scope.passwordError = false;
        validatePass.hideMessages();
    }
});

