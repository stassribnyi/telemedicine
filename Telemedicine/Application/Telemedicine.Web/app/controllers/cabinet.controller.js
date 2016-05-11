(function () {
    'use strict';

    angular
        .module('app')
        .controller('CabinetController', cabinet);

    cabinet.$inject = ['$scope', 'Doctor', 'Hospital', 'Account'];

    function cabinet($scope, Doctor, Hospital, Account) {

        $scope.init = function () {
            Doctor.getCurrent({}, function (data) {
                $scope.doctor = data;
            });

            Hospital.getHospitals({}, function (data) {
                $scope.hospitals = data;
            });
        };
        $scope.checkLogin = function (login) {
            Doctor.checkLogin({}, { value: login }, function (data) {
                $scope.invalidLogin = data.value;
            });
        };

        $scope.checkEmail = function (email) {
            Doctor.checkEmail({}, { value: email }, function (data) {
                console.log(data);
                $scope.invalidEmail = data.value;
            });
        };

        $scope.checkPassword = function (password, confPassword) {
            $scope.invalidPassword = password ? password != confPassword : true;
        };

        $scope.registerDoctor = function (doctor) {
            Account.register({}, doctor, function (data) {
                window.location.href = '/Account/Login';
            });
        };
    }
})();
