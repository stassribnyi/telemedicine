(function () {
    'use strict';

    angular
        .module('app')
        .filter('dateParse', dateParse);
    
    function dateParse() {
        return function (value) {
            var regExp = /(\d{4})-(\d{2})-(\d{2})T(\d{2}):(\d{2}):(\d{2})/;

            if (regExp.test(value)) {
                value = new Date(value);
            }
        
            return value;
        }
    }
})();