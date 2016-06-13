crmApp.controller('contactCtlr', ['$scope', function ($scope) {
    var contact = {};
    contact.status = 1;
    contact.lastname = 'Ferm';
    $scope.contact = contact;

    $scope.status = [{
        value: 1, display: 'Aktiv'
    }, {
        value: 2,
        display:'Slutat'
    }, {
        value: 3,
        display:'Annat'
    }];
    $scope.contactSubmit = function () {
        $scope.submitted = true;
    };
}]);