'use strict';
app.factory('userService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    var userServiceFactory = {};
    var _getUser = function () {
        return $http.get(serviceBase + 'api/User').then(function (results) {
            return results;
        });
    };
    var _putUser = function (data) {
        return $http.put(serviceBase + 'api/User',data).then(function (results) {
            return results;
        });
    };
    var _deleteUser = function (data) {
        return $http.delete(serviceBase + 'api/User' + data).then(function (results) {
            return results;
        });
    };
    var _postUser = function (data, method) {
        return $http.post(serviceBase + 'api/User/' + method, data).then(function (results) {
            return results;
        });
    };
    var _postFileUser = function (data) {
        var url = serviceBase + 'api/User';
        return $http.post(serviceBase + 'api/User', data, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .then(function (results) {
            return results;
        });
    };
    userServiceFactory.getUser = _getUser;
    userServiceFactory.putUser = _putUser;
    userServiceFactory.deleteUser = _deleteUser;
    userServiceFactory.postUser = _postUser;
    userServiceFactory.postFileUser = _postFileUser;
    return userServiceFactory;
}]);