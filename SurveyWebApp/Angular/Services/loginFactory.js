(function () {
    var injectParams = ['$http'];
    var loginFactory = function ($http) {

        var urlBase = '/api/customers';
        var factory = {};

        factory.getCustomers = function () {
            return $http.get(urlBase);
        };

        factory.getCustomer = function (id) {
            return $http.get(urlBase + '/' + id);
        };

        return factory;
    };

    loginFactory.$inject = injectParams;

    angular.module('adminapp').factory('loginFactory', loginFactory);


}());
