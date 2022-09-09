app = angular.module('lessons', []);

app.controller("LessonsController", function ($scope, $http) {

    $scope.successGetLessonsCallback = function (response) {
         $scope.lessonsList = response.data;
        $scope.errormessage="";
        //console.log(response.data);
    };

    $scope.errorGetLessonsCallback = function (error) {
        console.log(error);
        $scope.errormessage="Unable to get list of lessons";
    };

    $scope.getLessons = function () {
        $http.get('/public/rest/lessons').then($scope.successGetLessonsCallback, $scope.errorGetLessonsCallback);
    };

    $scope.successDeleteLessonCallback = function (response) {
        for (var i = 0; i < $scope.lessonsList.length; i++) {
            var j = $scope.lessonsList[i];
            if (j.id === $scope.deletedId) {
                $scope.lessonsList.splice(i, 1);
                break;
            }
        }
        $scope.errormessage="";
        $http.get('/public/rest/lessons').then($scope.successGetLessonsCallback, $scope.errorGetLessonsCallback);
    };

    $scope.errorDeleteLessonCallback = function (error) {
        console.log(error);
        $scope.errormessage="Unable to delete lesson; check if there are any related records exist. Such records should be removed first";
    };

    $scope.deleteLesson = function (id) {
        $scope.deletedId = id;
        $http.delete('/public/rest/lessons/' + id).then($scope.successDeleteLessonCallback, $scope.errorDeleteLessonCallback);
    };


    $scope.successGetLessonCallback = function (response) {
        $scope.lessonsList.splice(0, 0, response.data);
        $scope.errormessage="";
    };

    $scope.errorGetLessonCallback = function (error) {
        console.log(error);
        $scope.errormessage="Unable to get information on lesson number "+$scope.inputnumber;
    };

    $scope.successAddLessonCallback = function (response) {
        $http.get('/public/rest/lessons').then($scope.successGetLessonsCallback, $scope.errorGetLessonsCallback);
        $scope.errormessage="";
    };

    $scope.errorAddLessonCallback = function (error) {
        console.log(error);
        $scope.errormessage="Impossible to add new lesson; check if it's number is unique";
    };

    $scope.addLesson = function () {
        const body = {title: $scope.inputTitle, weekday: $scope.inputWeekday, type: $scope.inputType, auditorium: $scope.inputAuditorium, startTime: $scope.inputStartTime};
        $http.post('/public/rest/lessons/', body).then($scope.successAddLessonCallback, $scope.errorAddLessonCallback);
    };

});
