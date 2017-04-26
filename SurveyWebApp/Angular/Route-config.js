
(function () {
    'use strict';

    var app = angular.module('adminapp', ['ngRoute']);

    app.config(['$routeProvider', function ($routeProvider) {

        $routeProvider.when('/', {
            controller: 'LoginAdminController',
            templateUrl: '/Views/Home/LoginAdmin.html'
        })
        .otherwise({ redirectTo: '/' });

    }]);

}());