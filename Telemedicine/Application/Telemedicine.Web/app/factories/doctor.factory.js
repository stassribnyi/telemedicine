(function () {
    'use strict';

    angular
        .module('app')
        .factory('Doctor', doctor);

    doctor.$inject = ['$resource'];

    function doctor($resource) {
        return $resource('/api/doctor/:id', { id: '@id' }, {
            getCurrent: {
                method: 'GET',
                url: '/api/doctor/current'
            },
            checkLogin: {
                method: 'POST',
                url: '/api/doctor/checklogin/:login'
            },
            checkEmail: {
                method: 'POST',
                url: '/api/doctor/checkemail/:email'
            },
            getDoctors: {
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