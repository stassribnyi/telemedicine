(function () {
    'use strict';

    angular
        .module('app')
        .controller('AccountController', Account);

    Account.$inject = ['$scope', 'Account'];

    function Account($scope, Account) {
        
        $scope.credentials = {};

        $scope.login = function () {
            Account.login({}, $scope.credentials, function (data) {
                console.log(data);
            },
            function (err) {
                alert(err.message);
            });
        }
    }
})();
