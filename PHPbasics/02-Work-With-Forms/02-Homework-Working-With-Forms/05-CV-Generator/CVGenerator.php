<?php
    if (isset($_POST['submit'])) {

        $validation = true;
        $firstName = $_POST["firstName"];
        $lastName = $_POST["lastName"];
        $email = $_POST["email"];
        $telephone = $_POST["telephone"];
        $gender = $_POST["gender"];
        $birthDate = $_POST["birthDate"];
        $nationality = $_POST["nationality"];
        $lastWorkName = $_POST["lastWorkName"];
        $lastWorkFromDate = $_POST["lastWorkFromDate"];
        $lastWorkToDate = $_POST["lastWorkToDate"];
        $programLanguages = $_POST["programLanguages"];
        $progLangLevel = $_POST["progLangLevel"];
         $languages = $_POST["languages"];
        $languageComprehension = $_POST["languageComprehension"];
        $languageReadingSkills = $_POST["languageReadingSkills"];
        $languageWritingSkills = $_POST["languageWritingSkills"];
        $driverLicense;
        if (isset($_POST["driverLicense"])) {
            $driverLicense = $_POST["driverLicense"];
        }

        if (preg_match('/[\W\d]+/', $firstName) ||
           preg_match('/[\W\d]+/', $lastName)) {
           $validation = false;
        }
        for ($i=0; $i < count($languages); $i++) { 
            if (preg_match('/[\W\d]+/', $languages[$i])) {
                $validation = false;
            }
        }

        if ($validation) {

            //echo('First Name, Last Name and Languages Fields - > Invalid Input ! '."\n".'Fill the Form Again !'
                ?><!doctype html>
                <html>
                    <head>
                        <meta charset="utf-8">
                        <title>Redirect</title>
                    </head>
                    <body>

                        <p>Invalid Input Refill !</p>
                        <button onclick="myFunction()">Reopen</button>

                        <script>
                        function myFunction() {
                            window.open("CVGenerator.html",'_self',false);
                        }
                        </script>
                    </body>
                </html> <?php

              //  ); 
        } else {
            ?><!doctype html>
<html>
    <head>
        <meta charset="utf-8">
        <title>CV Table</title>
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
        <table>
            <thead>
                <th colspan="2">Personal Information</th>
            </thead>
            <tr>
                <td>First Name</td>
                <td><?php echo $firstName ?></td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td><?php echo $lastName ?></td>
            </tr>
            <tr>
                <td>Email</td>
                <td><?php echo $email ?></td>
            </tr>
            <tr>
                <td>Phone Number</td>
                <td><?php echo $telephone ?></td>
            </tr>
            <tr>
                <td>Gender</td>
                <td><?php echo $gender ?></td>
            </tr>
            <tr>
                <td>Birth Date</td>
                <td><?php echo $birthDate ?></td>
            </tr>
            <tr>
                <td>Nationality</td>
                <td><?php echo $nationality ?></td>
            </tr>            
        </table>

        <table>
            <thead>
                <th colspan="2">Last Work Position</th>
            </thead>
            <tr>
                <td>Company Name</td>
                <td><?php echo $lastWorkName ?></td>
            </tr>
            <tr>
                <td>Fron Dte</td>
                <td><?php echo $lastWorkFromDate ?></td>
            </tr>
            <tr>
                <td>To Date</td>
                <td><?php echo $lastWorkToDate ?></td>
            </tr>
        </table>

        <table>
            <thead>
                <th colspan="2">Computer Skills</th>
            </thead>
            <tr>
                <td>Programming Languages</td>
                <td>
                    <table>
                        <thead>
                            <tr>
                                <th>Language</th>
                                <th>Skill Level</th>
                            </tr>
                        </thead>
                <?php 
                    for ($i=0; $i < count($programLanguages); $i++) :                       
                        ?>
                        <tr>
                           <td><?php echo $programLanguages[$i] ?></td>
                           <td><?php echo $progLangLevel[$i] ?></td> 
                        </tr>
                    <?php
                    endfor;
                ?>  </table>
                </td>
            </tr>
        </table>
        <table>
            <thead>
                <th colspan="4">Other Skills</th>
            </thead>
            <tr>
                <td>Languages</td>
                <td>
                    <table>
                        <thead>
                            <th>Language</th>
                            <th>Comprehension</th>
                            <th>Reading</th>
                            <th>Writing</th>
                        </thead>
            <?php
                for ($j=0; $j < count($languages); $j++) : 
                     ?>
                    <tr>
                       <td><?php echo $languages[$j] ?></td>
                       <td><?php echo $languageComprehension[$j] ?></td> 
                       <td><?php echo $languageReadingSkills[$j] ?></td>
                       <td><?php echo $languageWritingSkills[$j] ?></td>
                    </tr>
                 <?php
                 endfor; 
                ?>
                    </table>
                </td>
            </tr>
            <tr>
                <td>Driver`s License</td>
                <td><?php 
                if (isset($driverLicense)) {
                     echo implode(",", $driverLicense);
                 } 
                ?></td>
            </tr>
        </table>
    </body> 
</html><?php
        }       
    }     
?>
