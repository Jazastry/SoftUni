<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>CV Generator</title>
    <link rel="stylesheet" href="style.css">
</head>
<body id="myBody">
<form method="post" id="cvInputForm" action=CVGenerator.php"">
    <fieldset>
        <legend>Personal Information</legend>
        <input type="text" name="firstName" placeholder="First Name">
        <input type="text" name="lastName" placeholder="Last Name">
        <input type="email" name="email" placeholder="Email">
        <input type="tel" name="telephone" placeholder="Phone Number">

        <label for="female" >Female</label>
        <input id="female" value="female" type="radio" name="gender">

        <label for="male">Male</label>
        <input id="male" value="male" type="radio" name="gender">

        <br>
        <lable for="birth-date">Birth Date</lable>
        <input id="birth-date" type="date" name="birthDate">

        <lable for="nationality">Nationality</lable>
        <select name="nationality" id="nationality">
            <option value="Australian">Australian</option>
            <option value="Bulgarian" selected="selected">Bulgarian</option>
            <option value="Chinese">Chinese</option>
            <option value="German">German</option>
            <option value="Greek">Greek</option>
            <option value="Japanese">Japanese</option>
            <option value="Russian">Russian</option>
            <option value="Slovakian">Slovakian</option>
        </select>
    </fieldset>
    <fieldset>
        <legend>Last Work Position</legend>
        <lable for="last-work-name">Last Company Name</lable>
        <input id="last-work-name" name="lastWorkName" type="text">
        <br>
        <lable for="last-work-from">From</lable>
        <input id="last-work-from" name="lastWorkFromDate" type="date">
        <br>
        <lable for="last-work-to">To</lable>
        <input id="last-work-to" name="lastWorkToDate" type="date">
    </fieldset>
    <fieldset id="actionField1">
        <legend>Computer Skills</legend>
        <div class="computerSkillsField">
            <div class="progInputInitial">
                <label for="program-languages">Programing Languages</label>
                <input type="text" id="program-languages" name="programLanguages">

                <select name="progLangLevel" id="prog-languages-level">
                    <option value="Beginer" selected="selected">Beginer</option>
                    <option value="Mediun">Mediun</option>
                    <option value="Pro">Pro</option>
                </select>
            </div>
            <div id="progButtonsDiv">
                <button class="deleteFields">Remove Language</button>
                <button class="insertFields">Add Language</button>
            </div>
        </div>
    </fieldset>

    <fieldset id="actionField2">
        <legend>Other Skills</legend>
        <div class="languagesField">
            <div class="langInitialInputs">

                <label for="languages">Languages</label>
                <input name="languages" id="languages" type="text">

                <select name="languageComprehension">
                    <option value="" disabled="disabled" selected="selected">-Comprehesion-</option>
                    <option value="Low">Low</option>
                    <option value="Medium">Medium</option>
                    <option value="High">High</option>
                </select>

                <select name="languageReadingSkills" >
                    <option value="" disabled="disabled" selected="selected">-Reading-</option>
                    <option value="Low">Low</option>
                    <option value="Medium">Medium</option>
                    <option value="High">High</option>
                </select>

                <select name="languageWritingSkills" >
                    <option value="" disabled="disabled" selected="selected">-Writing-</option>
                    <option value="Low">Low</option>
                    <option value="Medium">Medium</option>
                    <option value="High">High</option>
                </select>
            </div>
            <div id="langButtonsDiv">
                <button class="deleteFields">Remove Language</button>
                <button class="insertFields">Add Language</button>
            </div>
        </div>
        <br>
        <label for="driverLicenseB">B</label>
        <input id="driverLicenseB" type="radio" name="driverLicense" value="B">

        <label for="driverLicenseA">A</label>
        <input id="driverLicenseA" type="radio" name="driverLicense" value="A">

        <label for="driverLicenseC">C</label>
        <input id="driverLicenseC" type="radio" name="driverLicense" value="C">
    </fieldset>
    <input type="submit" name="submit">
</form>

</body>
<script src="script.js"></script>
<?php
    if (isset($_POST['submit'])) {

        $firstName = $_POST["firstName"];
        $lastName = $_POST["lastName"];
        $email = $_POST["email"];
        $telephone = $_POST["telephone"];
        $comment = $_POST["comment"];
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
        $driverLicense = $_POST["driverLicense"];
        $languageWritingSkills = $_POST["languageWritingSkills"];
    }

    var_dump($_POST);
    function test_input($data) {
        $data = trim($data);
        $data = stripslashes($data);
        $data = htmlspecialchars($data);
        return $data;
    }
?>
<!-- <script src="script.js"></script> -->
</html>

