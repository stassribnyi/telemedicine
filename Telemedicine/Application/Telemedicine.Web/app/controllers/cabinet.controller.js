(function () {
    'use strict';

    angular
        .module('app')
        .controller('CabinetController', cabinet);

    cabinet.$inject = ['$scope', 'Doctor', 'Hospital', 'Account'];

    function cabinet($scope, Doctor, Hospital, Account) {
        var original = {};
        $scope.init = function () {
            Doctor.getCurrent({}, function (data) {
                $scope.doctor = data;
                original = angular.copy($scope.doctor);
            });

            Hospital.getHospitals({}, function (data) {
                $scope.hospitals = data;
            });
        };
        $scope.checkLogin = function (login) {
            if (login.toLowerCase() !== original.login.toLowerCase()) {
                Doctor.checkLogin({}, { value: login }, function (data) {
                    $scope.invalidLogin = data.value;
                });
            }
        };

        $scope.checkEmail = function (email) {
            if (email.toLowerCase() !== original.email.toLowerCase()) {
                Doctor.checkEmail({}, { value: email }, function (data) {
                    console.log(data);
                    $scope.invalidEmail = data.value;
                });
            }
        };

        $scope.checkPassword = function (password, confPassword) {
            $scope.invalidPassword = password ? password != confPassword : true;
        };

        $scope.changePassword = function (oldPassword, newPassword, confPassword) {
            var changePasswordObject = {
                oldPassword: oldPassword,
                newPassword: newPassword,
                confirmPassword: confPassword
            };

            Account.changePassword({}, changePasswordObject, function (data) {
                console.log(data);
            });
        };

        $scope.editDoctor = function (doctor) {
            //Account.register({}, doctor, function (data) {
            //    window.location.href = '/Account/Login';
            //});
        };
    }
})();
