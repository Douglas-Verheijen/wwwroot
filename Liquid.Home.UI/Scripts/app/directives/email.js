(function () {
    'use strict';
    angular.module('liquidApp')
        .directive('email', function () {
            return {
                restrict: 'AEC',
                link: function ($scope, $element, $attr, $ngModel) {

                    $scope.$watch($element, function () {

                        var regex = /^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$/
                        var value = $element.val();
                        if (value)
                            $element.setValidity(regex.test(value));
                    });
                }
            };
        });
})();
