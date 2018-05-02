
'use strict';

/**
 * @ngdoc overview
 * @name jobVacancyApp
 * @description
 * # jobVacancyApp
 *
 * Main module of the application.
 */
angular
  .module('studentsApp', [
    'ngAnimate',
    'ngCookies',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'ui.bootstrap',
    'ngToast',
  ])
  .config(function ($routeProvider, $httpProvider, $locationProvider) {

    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl',
        controllerAs: 'main'
      })
      .otherwise({
        redirectTo: '/'
      });


  })
  .constant('ngAuthSettings', {
        /*apiServiceBaseUri: 'http://0.0.0.0:5000/api'*/
        apiServiceBaseUri: 'http://dmparcial2.eastus.cloudapp.azure.com:5000/api'
    });