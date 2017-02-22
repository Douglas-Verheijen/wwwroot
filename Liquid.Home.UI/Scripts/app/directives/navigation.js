(function () {
    'use strict';
    angular.module('liquidApp')
        .directive('tag', function () {
            return {
                restrict: 'E',
                template: function (element, attrs) {
                    return '<a href=' + attrs["link"] + '>' + element.text() + '</a>'
                },
                link: function (scope, element, attrs) {
                    element.bind("click", function (event) {

                        event.preventDefault();
                        $('html, body').animate({ scrollTop: $(event.target.hash).offset().top }, 500, "");
                        $(event.target.hash)
                            .find('.product-info-heading')
                            .effect('highlight', { color: '#222a32' }, 3000, "", null);
                    });
                }
            };
        });
})();