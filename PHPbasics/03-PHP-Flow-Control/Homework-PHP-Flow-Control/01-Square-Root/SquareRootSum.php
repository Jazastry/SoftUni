<?php 
	$square = 0;
	$collect = 0;
	?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Square Root</title>
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
        <table>
        	<thead>
        		<th>Number</th>
        		<th>Square</th>
        	</thead>
        	<?php 
        		for ($i=0; $i <= 100; $i++) : 
        			$square =  round(sqrt($i), 2); 
        			$collect += $square;
        			?>
        	<tr>		
				<td><?php echo $i; ?></td>
				<td><?php echo $square; ?></td>
			</tr>
			<?php
			if ($i === 100) :
				?>
        	<tr>		
				<td><?php echo 'Total:'; ?></td>
				<td><?php echo $collect; ?></td>
			</tr>
        			<?php
        			endif;        		
        		endfor;
        	 ?>
        </table>

        <!-- <script src="js/main.js"></script> -->
    </body>
</html>
<?php
 ?>