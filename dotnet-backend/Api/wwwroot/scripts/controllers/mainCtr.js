
'use strict';

/**
 * @ngdoc function
 * @name jobVacancyApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the jobVacancyApp
 */
angular.module('studentsApp')
  .controller('MainCtrl', [
    '$location',
    '$log',
    'usersService',
    'penaltyFeeService',
    'ngToast',
    function ($location, $log, usersService,penaltyFeeService, ngToast) {

      var ctrl = this;
      ctrl.Tittle = "Sistema de Multas";
      console.log(ctrl);
      ctrl.data = {
       Date : new Date()
      }


      ctrl.userList = [];
      ctrl.userVehicleList = [];
      ctrl.getVehiclesByUser = getVehiclesByUser;
      ctrl.ok = saveTicket;
      loadUsers();
      loadPenaltyFee();

      function loadUsers() {

        ctrl.userVehicleList = [];
        usersService.getUsers().then(function (response) {
            console.log("usersService.getUsers()", response);
            ctrl.userList = response;

        }, function (err) {

          toastDanger('Error al cargar, intentalo de nuevo o espera unos minutos');
          $log.log(err);

        });
      }

      function loadPenaltyFee() {

        ctrl.penaltyFeeList = [];
        penaltyFeeService.getPenaltyFee().then(function (response) {
            console.log("penaltyFeeService.getPenaltyFee()", response);
            ctrl.penaltyFeeList = response;

        }, function (err) {

          toastDanger('Error al cargar, intentalo de nuevo o espera unos minutos');
          $log.log(err);

        });
      }

      function getVehiclesByUser() {
        console.log(ctrl.data);
        if(ctrl.data.IdOwner === undefined){
            return;
        }
        usersService.getVehiclesByUser(ctrl.data.IdOwner).then(function (response) {
            console.log("usersService.getVehiclesByUser()", response);
            ctrl.userVehicleList = response.data;
        }, function (err) {

          toastDanger('Error al cargar, intentalo de nuevo o espera unos minutos');
          $log.log(err);

        });
      }

      function saveTicket(form){
        if(!form.$valid){
            return;
        }

        console.log(JSON.stringify(ctrl.data));

         penaltyFeeService.savePenaltFee(ctrl.data).then(function (response) {
            $log.log(response);
            ctrl.data = {
               Date : new Date()
              }
             loadPenaltyFee();
             toastDone("Multa guardada correctamente");
        }, function (err) {

          toastDanger('Error al guardar, intentalo de nuevo o espera unos minutos');
          $log.log(err);

        });

      }


      function toastDanger(message) {
        ngToast.create({
          className: 'danger',
          content: '<strong>' + message + '</strong>'
        });
      }

      function toastDone(message) {
        ngToast.create(message);
      }

    }]);