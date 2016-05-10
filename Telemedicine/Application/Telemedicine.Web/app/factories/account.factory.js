(function () {
    'use strict';

    angular
        .module('app')
        .factory('Account', Account);

    Account.$inject = ['$resource'];

    function Account($resource) {
        return $resource('/account/login', {}, {
            login: {
                method: 'POST'
            },
            register: {
                method: 'POST',
                url: '/account/register'
            }
        });
    }
})();