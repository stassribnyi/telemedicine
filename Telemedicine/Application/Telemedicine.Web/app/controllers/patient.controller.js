(function () {
    'use strict';

    angular
        .module('app')
        .controller('PatientController', patientController);

    patientController.$inject = ['$scope', 'Patient', 'Gender', 'Doctor', 'Comment'];

    function patientController($scope, Patient, Gender, Doctor, Comment) {
        $scope.genders = angular.copy(Gender);
        $scope.patient = {
            comments: []
        }

        $scope.isPatientFormEditable = false;
        $scope.format = 'dd.MM.yyyy';
        $scope.dateOptions = {
            //dateDisabled: disabled,
            formatYear: 'yy',
            startingDay: 1
        }

        $scope.init = function (id) {
            if (id) {
                $scope.patient = Patient.getById({ id: id }, function (data) {
                });
            }
            $scope.doctor = Doctor.getCurrent({}, function (data) {
                console.log(data);
            });
        }

        $scope.addComment = function (patient) {
            patient.comments.push({
                doctor: $scope.doctor,
                lastModified: new Date(),
                isEditable: true
            }
            );
        };

        $scope.saveComment = function (comment) {
            if ($scope.patient.id) {
                Patient.saveComment({ id: $scope.patient.id }, comment, function (data) {
                    comment.id = data.id;
                    comment.isEditable = false;
                    comment.source = null;
                });
            }
            else {
                comment.isEditable = false;
                comment.source = null;
            }
        }

        $scope.updateComment = function (comment) {
            if ($scope.patient.id) {
                if (comment.id) {
                    Comment.update({}, comment, function (data) {
                        comment.id = data.id;
                        comment.isEditable = false;
                        comment.source = null;
                    });
                }
                else {
                    $scope.saveComment(comment);
                }
            }
            else {
                comment.isEditable = false;
                comment.source = null;
            }
        };

        $scope.removeComment = function (id) {
            if ($scope.patient.id) {
                Comment.remove({ id: id }, function (data) {
                    var comments = $scope.patient.comments;
                    removeElement(comments, findById(comments, id));
                });
            }
            else {
                comment.isEditable = false;
                comment.source = null;
            }
        };

        $scope.updatePatient = function (patient) {
            Patient.update({ id: patient.id }, patient, function (data) {
                patient.isEditable = false;
                patient.source = null;
            });
        }

        $scope.savePatient = function (patient) {
            Patient.save({ id: patient.id }, patient, function (data) {
                window.location.href = '/Patient/?patientId=' + data.id;
            });
        }

        $scope.editPatient = function (patient) {
            if (!patient.isEditable) {
                $scope.patient.source = angular.copy($scope.patient);
                patient.isEditable = true;
            }
            else {
                $scope.patient = angular.copy($scope.patient.source);
                $scope.patient.source = null;
            }
        };

        $scope.editComment = function (comment) {
            var comments = $scope.patient.comments;
            if (!comment.isEditable) {
                comment.source = angular.copy(comment);
                comment.isEditable = true;
            }
            else {
                if (!comment.id) {
                    removeElement(comments, comment)
                }
                else {
                    replaceById(comments, comment.id, angular.copy(comment.source));
                }
                comment.source = null;
            }
        };

        //Helpers

        var findById = function (array, id) {
            return array.filter(function (item) {
                return item.id === id;
            })[0];
        };

        var replaceById = function (array, id, element) {
            var index = array.indexOf(findById(array, id));
            if (index !== -1) {
                array[index] = element;
            }

        };

        var removeElement = function (array, element) {
            var index = array.indexOf(element);
            if (index !== -1) {
                array.splice(index, 1);
            }
        };

        // Disable weekend selection
        function disabled(data) {
            var date = data.date,
              mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        }
    }
})();
