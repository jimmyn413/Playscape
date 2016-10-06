(function () {

    angular.module('contactApp') //you will need to declare your module with the dependencies ['mwl.calendar', 'ui.bootstrap', 'ngAnimate']
    .controller('calendarEventController', CalendarEventController);

    CalendarEventController.$inject = ['moment', '$scope'];


    function CalendarEventController(
        moment
        , $scope) {

        var vm = this;

        $alertService = alert;
        vm.$scope = $scope;

        vm.calendarView = 'month';
        vm.today = moment().format("MM/DD/YYYY");

        console.log('today', vm.today);


        render();

        function render() {

        }



        //These variables MUST be set as a minimum for the calendar to work

        var actions = [{
            label: '<i class=\'glyphicon glyphicon-pencil\'></i>',
            onClick: function (args) {
                alert.show('Edited', args.calendarEvent);
            }
        }, {
            label: '<i class=\'glyphicon glyphicon-remove\'></i>',
            onClick: function (args) {
                alert.show('Deleted', args.calendarEvent);
            }
        }];

        vm.isCellOpen = true;

        vm.isCellOpen = true;

        vm.addEvent = function () {
            vm.events.push({
                title: 'New event',
                startsAt: moment().startOf('day').toDate(),
                endsAt: moment().endOf('day').toDate(),
                color: calendarConfig.colorTypes.important,
                draggable: true,
                resizable: true
            });
        };

        vm.eventClicked = function (event) {
            alert.show('Clicked', event);
        };

        vm.eventEdited = function (event) {
            alert.show('Edited', event);
        };

        vm.eventDeleted = function (event) {
            alert.show('Deleted', event);
        };

        vm.eventTimesChanged = function (event) {
            alert.show('Dropped or resized', event);
        };

        vm.toggle = function ($event, field, event) {
            $event.preventDefault();
            $event.stopPropagation();
            event[field] = !event[field];
        };


        return vm;
    }

})();