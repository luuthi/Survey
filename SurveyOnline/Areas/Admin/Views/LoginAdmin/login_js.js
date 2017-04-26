'use strict';

var app = angular.module('loginForm', []);

app.controller('loginController', ['$scope', '$http',
function ($scope, $http) {
    $scope.login = function () {
        $http.get('http://www.surveyapi.dev/api/Accounts?username=' +
                $scope.UserName +
                '&password=' +
                $scope.PassWord)
            .then(successCallBack, errorCallBack);
        function successCallBack(response) {
            // console.log(response.data.Data);
            if (response.data.Data !=null) {
                window.location.href = "/Admin";
                $scope.error_login = "  ";
            } else {
                $scope.error_login = "Username hoặc password không chính xác!";
            }
        };
        function errorCallBack(error) {

        };
    }
}
]); 