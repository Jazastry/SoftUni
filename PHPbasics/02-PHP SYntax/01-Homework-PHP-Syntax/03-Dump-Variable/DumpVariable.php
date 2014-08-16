<?php
$input = ["hello",
		   15,
		   1.234,
		   array(1,2,3),
		   (object)[2,34,]
		 ];	

	for ($i=0; $i < count($input); $i++) { 
		
		if (is_numeric($input[$i])) {
			
			var_dump($input[$i]);

		} else {

			echo(gettype($input[$i]) . "\n");
		}
	}
?>
