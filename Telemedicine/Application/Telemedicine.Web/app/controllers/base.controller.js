(function () {
    'use strict';

    angular
        .module('app')
        .controller('BaseController', controller);

    controller.$inject = ['$scope', 'Doctor']; 

    function controller($scope, Doctor) {
        Doctor.getCurrent({}, function (data) {
            $scope.currentDoctor = data;
        });
    }
})();
