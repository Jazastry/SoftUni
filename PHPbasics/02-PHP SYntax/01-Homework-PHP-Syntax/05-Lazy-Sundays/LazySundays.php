<?php
	$year = (int)date("Y");
	$daysInCurrMonth = (int)date("t");
	$currMonth = (int)date("n");
	$firstDayOfMonth = gregoriantojd($currMonth,1,2014);
	$firstDayOfWeek = jddayofweek($firstDayOfMonth,0);
	$daysToSYnday = 7 - $firstDayOfWeek;
	$firstSynday = 1 + $daysToSYnday;
	
	for ($i = $firstSynday; $i <= $daysInCurrMonth; $i = $i + 7) { 
		
		echo $i . "th " . date("F") . " " . $year . "\n";
	}
?>
