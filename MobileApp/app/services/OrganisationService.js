angular.module('MobileApp.AttractionService', ['ngResource']).
      factory('Parent', function ($resource) {
          return $resource("http://localhost:55539\:55539/api/AttractionAPI");

      });
