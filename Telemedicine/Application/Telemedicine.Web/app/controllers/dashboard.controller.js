(function () {
    'use strict';

    angular
        .module('app')
        .controller('DashboardController', dashboardController);

    dashboardController.$inject = ['$scope', 'Patient', '$location', 'Doctor'];

    function dashboardController($scope, Patient, $location, Doctor) {

        $scope.currentPage = 1;
        $scope.itemPerPage = 12;

        $scope.init = function () {
            Doctor.getCurrent({}, function (data) {
                Patient.getByDoctorId({ id: data.id }, function (data) {
                    $scope.patients = data;
                });
            });

        };
        
        $scope.showPatient = function (id) {
            window.location.href = '/Patient/?patientId=' + id;
        };

        $scope.showPatientAnalyzes = function (id) {
            window.location.href = '/Patient/Analyze/?patientId=' + id;
        };
    }
})();
