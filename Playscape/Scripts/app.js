/** *************Angular app JS*********************/
"use strict"; 
var app = angular.module('contactApp', ['mwl.calendar', 'ngAnimate', 'ui.bootstrap', 'colorpicker.module']);

angular.module('contactApp')
      .config(function (calendarConfig) {

          calendarConfig.dateFormatter = 'moment'; // use moment to format dates

      })
      .factory('alert', function($uibModal) {

          function show(action, event) {
              return $uibModal.open({
                  templateUrl: '/Templates/modalContent.html',
                  controller: function() {
                      var vm = this;
                      vm.action = action;
                      vm.event = event;
                  },
                  controllerAs: 'vm'
              });
          }

          return {
              show: show
          };

      });