app.service('cbbHttpService', function ($http, ngAuthSettings) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;
    return {
        Get: function (url) {
            return $http.get(serviceBase + 'api/' + url)
            .then(function (results) {
                return results;
            });
        },
        Put: function (url, data, success, error) {
            return $http.put(serviceBase + 'api/' + url, data).then(function (results) {
                return results;
            });
        },
        Post: function (url, data, success, error) {
            return $http.post(serviceBase + 'api/' + url, data).then(function (results) {
                return results;
            });
        },
        Delete: function (url, data, success, error) {
            return $http.delete(serviceBase + 'api/' + url + '/' + data).then(function (results) {
                return results;
            });
        },
        guid: function () {
            return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
                return v.toString(16);
            });
        }
    };
});