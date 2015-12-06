(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeIndexController', HomeIndexController);

    HomeIndexController.$inject = [];

    function HomeIndexController() {
        var vm = this;

        activate();

        function activate() { }
    }
})();
