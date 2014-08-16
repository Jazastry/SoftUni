
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title>HTML Table</title>
        <link rel="stylesheet" href="style.css">
    </head>
    <body  onload="InformationTable.php">
        <?php
        $name = array('Gosho', 'Pesho');
        $phone = array('0882-321-423', '0884-888-888');
        $age = array('24', '67');
        $addres = array('Hadji Dimitar', 'Suhata Reka');

            for($i = 0; $i < count($name); $i++) {
                echo "
                    <table style='border: 1px solid black'>
                        <tr>
                            <td>Name</td>
                            <td>$name[$i]</td>
                        </tr>
                        <tr>
                            <td>Phone Number</td>
                            <td>$phone[$i]</td>
                        </tr>
                        <tr>
                            <td>Age</td>
                            <td>$age[$i]</td>
                        </tr>
                        <tr>
                            <td>Addres</td>
                            <td>$addres[$i]</td>
                        </tr>
                    </table>
                ";
            }
        ?>
    </body>
</html>

