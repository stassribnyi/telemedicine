(function () {
    'use strict';

    angular
        .module('app')
        .factory('Hospital', hospital);

    hospital.$inject = ['$resource'];

    function hospital($resource) {
        return $resource('/api/hospital/:id', { id: '@id' }, {
            getHospitals: {
                method: 'GET',
                isArray: true
            },
            getById: {
                method: 'GET'
            },
            save: {
                method: 'POST'
            },
            update: {
                method: 'PUT'
            }
            ,
            remove: {
                method: 'DELETE'
            }
        });
    }
})();