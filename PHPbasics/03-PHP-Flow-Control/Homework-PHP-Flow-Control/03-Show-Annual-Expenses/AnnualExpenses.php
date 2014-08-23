<?php 
	if (isset($_POST['yearsIn'])) {

		$years = $_POST['yearsIn'];
	}
	
	$expensesRand = 0;
	$currentYear = date("Y");

?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Annual Expenses</title>
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
        <table>
        	<thead>
        		<th>Year</th>
        		<th>January</th>
        		<th>February</th>
        		<th>March</th>
        		<th>April</th>
        		<th>May</th>
        		<th>June</th>
        		<th>July</th>
        		<th>August</th>
        		<th>September</th>
        		<th>October</th>
        		<th>November</th>
        		<th>December</th>
        		<th>Total:</th>
        	</thead>
<?php

	for ($i=0; $i < $years; $i++) :

		$collectExpenses = 0;

?>			<tr>
				<td><?php echo ($currentYear + $i); ?></td>
<?php

		for ($j=0; $j < 12; $j++) : 

			$expensesRand = rand(0, 999);
			$collectExpenses += $expensesRand; 
?>				<td><?php echo $expensesRand; ?></td>
<?php
		endfor;	
?>				<td><?php echo $collectExpenses; ?></td>
			</tr>
<?php

	endfor;
?>        </table>
    </body>
</html>

