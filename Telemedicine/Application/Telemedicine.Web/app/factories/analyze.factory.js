(function () {
    'use strict';

    angular
        .module('app')
        .factory('Analyze', analyzeFactory);

    analyzeFactory.$inject = ['$resource'];

    function analyzeFactory($resource) {
    	return $resource('/api/analyze/:id', { id: '@id' }, {
    		getAll: {
    			method: 'GET',
    			isArray: true,
    			url: '/api/analyzes/:id'
    		},
            get: {
                method: 'GET'
            },
            save: {
                method: 'POST',
                url: '/api/analyze/:patientId/newanalyze'
            },
            saveComment: {
                method: 'POST',
                url: '/api/analyze/:id/newcomment'
            },
            saveECGComment: {
                method: 'POST',
                url: '/api/analyze/ecg/:id/newcomment'
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