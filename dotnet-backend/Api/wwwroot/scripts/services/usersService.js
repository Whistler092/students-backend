
'use strict';

/**
 * @ngdoc service
 * @name jobVacancyApp.userService
 * @description
 * # userService
 * Factory in the jobVacancyApp.
 */
angular.module('studentsApp')
  .factory('usersService', [
        '$http',
        '$q',
        'ngAuthSettings',
    function ($http, $q, ngAuthSettings) {

        var backURL = ngAuthSettings.apiServiceBaseUri;

        function GetUsers() {
            var promise = $q.defer();
            console.log("backURL", backURL);

            $http({
                method: "GET",
                url: backURL + '/Owners/' ,
            }).then(function (success) {
                console.log(success);
                promise.resolve(success.data);
            }, function (err) {
                console.log(err);
                promise.reject(err);
            });
            return promise.promise;
        }

        function GetVehiclesByUser(id){
            var promise = $q.defer();
            console.log("backURL", backURL);

            $http({
                method: "GET",
                url: backURL + '/vehicles/' + id + '/owner/' ,
            }).then(function (success) {
                console.log(success);
                promise.resolve(success);
            }, function (err) {
                console.log(err);
                promise.reject(err);
            });
            return promise.promise;
        }



        //Public API here
        return {
            getUsers: GetUsers,
            getVehiclesByUser : GetVehiclesByUser
        };

    }]);