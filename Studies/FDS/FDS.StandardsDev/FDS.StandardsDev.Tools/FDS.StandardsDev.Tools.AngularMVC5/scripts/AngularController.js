// Defining angularjs module
var app = angular.module('configurationModule', []);

// Defining angularjs Controller and injecting ProductsService
app.controller('configurationController', function ($scope, $http, ConfigurationService) {

    $scope.ConfigurationData = null;
    // Fetching records from the factory created at the bottom of the script file
    ConfigurationService.GetAll().then(function (d) {
        $scope.ConfigurationData = d.data; // Success
        //alert($scope.ConfigurationData[0].Value);
    }, function (e) {
        //alert(e.message);
        alert('Error Occured !!!'); // Failed
    });

    // Calculate Total of Price After Initialization
    $scope.total = function () {
        var total = 0;
        angular.forEach($scope.ConfigurationData, function (item) {
            total += 1;
        })
        return total;
    }

    $scope.Configuration = {
        ConfigurationId: '',
        Description: '',
        Value: '',
        Setting: '',
        CreateAt: null,
        ModifiedAt: null
    };

    // Reset product details
    $scope.clear = function () {
        $scope.Configuration.ConfigurationId = '';
        $scope.Configuration.Description = '';
        $scope.Configuration.Value = '';
        $scope.Configuration.Setting = '';
        $scope.Configuration.CreateAt = null;
        $scope.Configuration.ModifiedAt = null;
    }

    //Add New Item
    $scope.save = function () {
        if ($scope.Configuration.Value != "") {
            // Call Http request using $.ajax

            //$.ajax({
            //    type: 'POST',
            //    contentType: 'application/json; charset=utf-8',
            //    data: JSON.stringify($scope.Configuration),
            //    url: 'api/Configuration/PostProduct',
            //    success: function (data, status) {
            //        $scope.$apply(function () {
            //            $scope.configurationData.push(data);
            //            alert("Configuration Added Successfully !!!");
            //            $scope.clear();
            //        });
            //    },
            //    error: function (status) { }
            //});
            // or you can call Http request using $http
            $http({
                method: 'POST',
                url: 'api/Configuration/Insert/',
                data: $scope.Configuration
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available
                if (response.data) {
                    $scope.ConfigurationData.push(response.data);
                    $scope.clear();
                    alert("Configuration Added Successfully !!!");
                }
                else {
                    alert("Configuration Not Added!!!");
                }
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };

    // Edit product details
    $scope.edit = function (data, index) {
        $scope.Configuration = { Index: index, ConfigurationId: data.ConfigurationId, Description: data.Description, Value: data.Value, Setting: data.Setting };
    }

    // Cancel product details
    $scope.cancel = function () {
        $scope.clear();
    }

    // Update product details
    $scope.update = function () {
        if ($scope.Configuration.Value != "") {
            $http({
                method: 'PUT',
                url: 'api/Configuration/Update/', // + JSON.stringify($scope.Configuration)
                data: $scope.Configuration
            }).then(function successCallback(response) {
                if (response.data != null) {
                    $scope.ConfigurationData[$scope.Configuration.Index] = response.data;
                    $scope.clear();
                    alert("Configuration Updated Successfully !!!");
                }
                else {
                    alert("Configuration Not Updated!!!");
                }
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };

    // Delete product details
    $scope.delete = function (index) {
        if (confirm('Are you really want to delete this Configuration?')) {
            $http({
                method: 'GET',
                url: 'api/Configuration/Delete/' + $scope.ConfigurationData[index].ConfigurationId,
            }).then(function successCallback(response) {
                if (response != null && response.data) {
                    console.log(response.data);
                    $scope.ConfigurationData.splice(index, 1);
                    $scope.clear();
                    alert("Configuration Deleted Successfully !!!");
                }
                else {
                    alert("Configuration not Deleted !!!");
                }
            }, function errorCallback(response) {
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
    };

});

// Here I have created a factory which is a popular way to create and configure services.
// You may also create the factories in another script file which is best practice.

app.factory('ConfigurationService', function ($http) {
    var fac = {};
    fac.GetAll = function () {
        return $http.get('api/Configuration/GetAll');
    }
    return fac;
});