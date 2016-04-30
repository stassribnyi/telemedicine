(function () {
    'use strict';

    angular
        .module('app')
        .factory('Account', Account);

    Account.$inject = ['$resource'];

    function Account($resource) {
        return $resource('/api/account/', {}, {
            login: {
                method: 'POST'
            }
        });
    }
})();