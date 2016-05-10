(function () {
    'use strict';

    angular
        .module('app')
        .controller('RegisterController', register);

    register.$inject = ['$scope', 'Doctor', 'Hospital', 'Account'];

    function register($scope, Doctor, Hospital, Account) {

        $scope.doctor = {};
        $scope.init = function () {
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
