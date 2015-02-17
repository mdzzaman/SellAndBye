app.directive("ngFileSelect", function () {
    return {
        link: function ($scope, element, attrs) {
            element.bind("change", function (e) {
                console.log(attrs.callFunction);
                $scope.file = (e.srcElement || e.target).files[0];
                $scope.files = (e.srcElement || e.target).files;
                //$scope.getFile();
                $scope.$apply(attrs.callFunction+"()");
            })
        }
    }
})