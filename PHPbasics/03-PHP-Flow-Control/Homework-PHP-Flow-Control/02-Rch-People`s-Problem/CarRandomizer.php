<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Rich Men`s Problem</title>
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
        <form method="post">
        	<input type="text" name="carsIn">
        	<input type="submit" value="Show Result" id="submitBtn">
        </form>
<?php 
	if (isset($_POST['carsIn'])) :
		$colors = array("black", "red", "grey", "green", "yellow", "brown");
		$cars = explode(", ",$_POST["carsIn"]);
		$randNumb1 = 0;
		$randNumb2 = 0;
       
		echo	"<table>
					<thead>
						<th>Car</th>
						<th>Color</th>
						<th>Count</th>
					</thead>";
        $currentCar;
        $currentColor;
		for ($i=0; $i < count($cars); $i++) :
			$randNumb1 = rand(1,5);
			$randNumb2 = rand(0, count($colors) - 1);
            $currentCar = $cars[$i];
            $currentColor = $colors[$randNumb2];
			echo "<tr>
                    <td>$currentCar</td>
                    <td>$currentColor</td>
                    <td>$randNumb1</td>
                </tr>";

	endfor;
    echo "</table>";
	endif; ?>
</body>
</html>