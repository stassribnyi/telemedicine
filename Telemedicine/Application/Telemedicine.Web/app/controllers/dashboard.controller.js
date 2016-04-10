(function () {
    'use strict';

    angular
        .module('app')
        .controller('DashboardController', dashboardController);

    dashboardController.$inject = ['$scope', 'Patient', '$location'];

    function dashboardController($scope, Patient, $location) {

        $scope.currentPage = 1;
        $scope.itemPerPage = 12;        

        Patient.getByDoctorId({}, function (data) {
            $scope.patients = data;           
        });


        $scope.showPatient = function (id) {
            window.location.href = '/Patient/?patientId=' + id;
        };

        $scope.showPatientAnalyzes = function (id) {
            window.location.href = '/Patient/Analyze/?patientId=' + id;
        };
    }
})();
