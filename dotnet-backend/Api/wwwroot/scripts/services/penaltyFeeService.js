'use strict';

/**
 * @ngdoc service
 * @name jobVacancyApp.userService
 * @description
 * # userService
 * Factory in the jobVacancyApp.
 */
angular.module('studentsApp')
  .factory('penaltyFeeService', [
        '$http',
        '$q',
        'ngAuthSettings',
    function ($http, $q, ngAuthSettings) {

        var backURL = ngAuthSettings.apiServiceBaseUri;

        function SavePenaltFee(data) {
            var promise = $q.defer();

            $http({
                method: "POST",
                url: backURL + "/PenaltyFee/",
                data: data
            }).then(function (success) {
                console.log(success);
                promise.resolve(success.data);
            }, function (err) {
                console.log(err);
                promise.reject(err);
            });
            return promise.promise;
        }

        function GetPenaltyFee(){

            var promise = $q.defer();
            console.log("backURL", backURL);

            $http({
                method: "GET",
                url: backURL + '/PenaltyFee/' ,
            }).then(function (success) {
                console.log(success);
                promise.resolve(success.data);
            }, function (err) {
                console.log(err);
                promise.reject(err);
            });
            return promise.promise;
        }

        //Public API here
        return {
            savePenaltFee : SavePenaltFee,
            getPenaltyFee : GetPenaltyFee
        };

    }]);
