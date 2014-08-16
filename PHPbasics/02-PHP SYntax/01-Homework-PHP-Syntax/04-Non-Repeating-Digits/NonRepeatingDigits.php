<?php 
	$input = [
		1234,
		145,
		15,
		247
	];
	$outputRes = ['FIRST', 'SECOND', 'THIRD', 'FOURTH'];
	$currentNumbStr = null;
	$currentDigitStr = null;
	$repeat = 0;

	for ($i=0; $i < count($input); $i++) { 

		echo "\n"."\n"."::::::::   ". $outputRes[$i] ." RESULT :::::::::"." INPUT -> ".$input[$i]."\n";

		if ($input[$i] <= 102) {			
			echo "no";
		} else {

			for ($j = 102; $j <= $input[3]; $j++) { 
				$currentNumbStr = strval($j);
				$repeat = 0;

				for ($k = 0; $k < strlen($currentNumbStr) - 1; $k++) { 

					for ($l = $k + 1; $l < strlen($currentNumbStr); $l++) { 
						
						if ($currentNumbStr[$k] == $currentNumbStr[$l]) {
							
							$repeat = 1;
							break;
						}	
					}
				}

				if ($repeat == 0) {
					
					echo $currentNumbStr . ", ";
				}
			}
		}
	}

?>
