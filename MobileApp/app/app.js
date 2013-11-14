

var myApp = angular.module('MobileApp', [
	'MobileApp.components',
	'MobileApp.ParentService'])
	.config(function ($routeProvider) {

		$routeProvider.
			when('/about', { ProjectHermesUrl: '/partials/about.html' }).
			when('/contact', { ProjectHermesUrl: '/partials/contact.html', controller: 'contactUsCtrl' }).
			when('/login', { ProjectHermesUrl: '/partials/login.html', controller: 'loginCtrl' }).
			otherwise({ redirectTo: '/home', ProjectHermesUrl: '/partials/home.html', controller: 'homeCtrl' });


	});



