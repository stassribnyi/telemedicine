(function () {
    'use strict';

    angular
        .module('app')
        .controller('CabinetController', cabinet);

    cabinet.$inject = ['$scope', 'Doctor', 'Hospital', 'Account'];

    function cabinet($scope, Doctor, Hospital, Account) {
        var original = {};
       
        $scope.init = function () {
            Hospital.getHospitals({}, function (data) {
                $scope.hospitals = data;
                Doctor.getCurrent({}, function (doc) {
                    doc.hospital = $scope.hospitals.filter(function (hosp) {
                        return hosp.id == doc.hospital.id;
                    })[0];
                    $scope.doctor = doc;
                    original = angular.copy($scope.doctor);
                });
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

            Account.changePassword({}, changePasswordObject, function (data) {});
        };

        $scope.editDoctor = function (doctor) {            
            Doctor.update({}, $scope.doctor, function (data) {
                if (data.login != original.login) {
                    window.location.href = '/Account/Logout';
                }
            });
        };
    }
})();
