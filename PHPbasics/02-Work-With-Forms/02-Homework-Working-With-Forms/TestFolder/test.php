<?php 

    $a = "+356 678 678 ";

    if (preg_match('/[^+][\D][^\-][\D]+/', $a) != "") {
        echo('Invalid Input ! '."\n".'Fill the Form Again !'); 
    }

   // var_dump($a);
     
 ?>