(function () {
    'use strict';
    angular.module('liquidApp')
        .controller('contact', ['$scope', '$http', function ($scope, $http) {

            $scope.submit = function () {

                var model = {
                    name: $scope.name,
                    emailAddress: $scope.emailAddress,
                    phoneNumber: $scope.phoneNumber,
                    message: $scope.message,
                };

                $http.post("api/contact", model).then(function (data) {
                    window.location.replace("Home/ThankYou");
                });
            };
        }]);
})();