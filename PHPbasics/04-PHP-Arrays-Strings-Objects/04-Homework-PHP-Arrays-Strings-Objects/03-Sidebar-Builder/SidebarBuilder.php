<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>Sidebar Builder</title>
        <link rel="stylesheet" href="css/style.css">
    </head>
    <body>
        <form method="post" action="">

        	<label for="categories">Categories</label>
        	<input type="text" id="categories" name="input[categories]">
        	<label for="tags">Tags</label>
        	<input type="text" id="tags" name="input[tags]">
        	<label for="months">Months</label>
        	<input type="text" id="months" name="input[months]">

        	<input type="submit" value="Generate" name="submit">
        </form>
<?php 
	if (isset($_POST['submit'])) :
		
		$input = $_POST['input'];

		foreach ($input as $key => $value) {
		$input[$key] = explode(', ', $input[$key]);
		}
		echo '<section class="sidebar">';
		foreach ($input as $key => $value) :		
			echo '	<section>
				 		<header>' . ucfirst($key) . ' </header>
				 		<ul>
				 		';
	 		foreach ($input[$key] as $key => $value) {
 				echo '<li><a href="#">' . $value . '</a></il>';
	 		}
			echo   		'</lu>
		 		 	</section>';
 		endforeach;
 		echo '</section>';
	endif;
 ?>    </body>
</html>