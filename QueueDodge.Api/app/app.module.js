(function () {
    'use strict';

    angular.module('app', 
    ['ui.router',
    'ui.bootstrap',
    'restangular',
    'angularMoment',
    'ngAnimate']);

    angular.module('app')
    .constant('_', window._);

    angular.module('app')
        .config(function (RestangularProvider) {
            RestangularProvider.setBaseUrl('/api');
        });
})();