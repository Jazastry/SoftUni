app.controller('MainController', function($scope){
	var videoObjects = [
		{
			title: 'Course introduction',
			pictureUrl: 'http://www.nakov.com/wp-content/uploads/2014/01/Software-University-Logo-blue-horizontal.png',
			length: '3:32',
			category: 'IT',
			subscribers: 3,
			date: new Date(2014, 12, 15),
			haveSubtitles: false,
			comments: [
				{
					username: 'Pesho Peshev',
					content: 'Congratulations Nakov',
					date: new Date(2014, 12, 15, 12, 30, 0),
					likes: 3,
					websiteUrl: 'http://pesho.com/'
				}
			]
		},
		{
			title: 'Course introduction',
			pictureUrl: 'http://www.nakov.com/wp-content/uploads/2014/01/Software-University-Logo-blue-horizontal.png',
			length: '3:32',
			category: 'IT',
			subscribers: 3,
			date: new Date(2014, 12, 15),
			haveSubtitles: false,
			comments: [
				{
					username: 'Pesho Peshev',
					content: 'Congratulations Nakov',
					date: new Date(2014, 12, 15, 12, 30, 0),
					likes: 3,
					websiteUrl: 'http://pesho.com/'
				},
				{
					username: 'Pesho Peshev',
					content: 'Congratulations Nakov',
					date: new Date(2014, 12, 15, 12, 30, 0),
					likes: 3,
					websiteUrl: 'http://pesho.com/'
				}
			]
		},
		{
			title: 'Course introduction',
			pictureUrl: 'http://www.nakov.com/wp-content/uploads/2014/01/Software-University-Logo-blue-horizontal.png',
			length: '3:32',
			category: 'IT',
			subscribers: 3,
			date: new Date(2014, 12, 15),
			haveSubtitles: false,
			comments: [
				{
					username: 'Pesho Peshev',
					content: 'Congratulations Nakov',
					date: new Date(2014, 12, 15, 12, 30, 0),
					likes: 3,
					websiteUrl: 'http://pesho.com/'
				}
			]
		},				
	];

	var haveSubs = function(condition) {
		if (condition === true) {
			return 'Yes'
		} else {
			return 'No'
		}
	};

	$scope.haveSubs = haveSubs;
	$scope.videoObjects = videoObjects;
	var val = function(){
		console.log('1');
	};

	$scope.val = val;
});