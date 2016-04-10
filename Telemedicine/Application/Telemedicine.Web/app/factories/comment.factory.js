(function () {
    'use strict';

    angular
        .module('app')
        .factory('Comment', commentFactory);

    commentFactory.$inject = ['$resource'];

    function commentFactory($resource) {
        return $resource('/api/comment/:id', { id: '@id' }, {
            get: {
                method: 'GET'
            },
            update: {
                method: 'PUT'
            },
            remove: {
                method: 'DELETE'
            }
        });
    }
})();