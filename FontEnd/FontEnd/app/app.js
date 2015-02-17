﻿
var app = angular.module('SellAndByeApp', ['ngRoute', 'kendo.directives', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });
    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });
    $routeProvider.when("/profile", {
        //controller: "profileController",
        templateUrl: "/app/views/profile.html"
    });
    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });
    $routeProvider.otherwise({ redirectTo: "/home" });

});

var serviceBase = 'http://localhost:3961/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


