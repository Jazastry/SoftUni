<?php
	$firstNumb = [2, 1.567808, 1234.5678];
	$secondNumb = [5, 0.356, 333];

	for ($i=0; $i < count($firstNumb); $i++) { 
		echo('$firstNumb + $secondNumb = ' . 
			$firstNumb[$i] . ' + ' . $secondNumb[$i] . 
			' = ' . number_format($firstNumb[$i] + $secondNumb[$i], 2) .
			 "\n");
	}
?>
