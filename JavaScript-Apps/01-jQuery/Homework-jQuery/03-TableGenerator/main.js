$('button').click(function(){
	var input = $('#jsonInput').val();
	input = input.replace(/^\"|([\\"]$)/g, '');
	var objectArray = $.parseJSON(input);
	console.log(objectArray[0]);
	$('body').append('<table></table>');
	$('table').append('<thead><tr><th>Manufacturer</th><th>Model</th>' + 
		'<th>Year</th><th>Price</th><th>Class</th></tr></thead>');
	for (var i = 0; i < objectArray.length; i++) {
		$('table').append('<tr><td>'+objectArray[i].manufacturer+'</td>' + 
			'<td>'+objectArray[i].model+'</td>' +
			'<td>'+objectArray[i].year+'</td>' +
			'<td>'+objectArray[i].price+'</td>' + 
			'<td>'+objectArray[i].class+'</td></tr>');
	}	
	return false;
});