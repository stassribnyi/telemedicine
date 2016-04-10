(function () {
    'use strict';

    angular
        .module('app')
        .factory('Patient', patientFactory);

    patientFactory.$inject = ['$resource'];

    function patientFactory($resource) {
        return $resource('/api/patient/:id', { id: '@id' }, {
            getByDoctorId: {
                method: 'GET',
                isArray: true,
                url: '/api/patients/:id'
            },
            getById: {
                method: 'GET'
            },
            save: {
                method: 'POST'
            },
            saveComment: {
                method: 'POST',
                url: '/api/patient/:id/newcomment'
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