
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>CV Generator</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
<form method="post" id="cvInpuForm">
    <fieldset>
            <legend>Personal Information</legend>
            <input type="text" name="first_name" placeholder="First Name">
            <input type="text" name="last_name" placeholder="Last Name">
            <input type="email" name="email" placeholder="Email">
            <input type="tel" name="telaphone" placeholder="Phone Number">

            <label for="female" >Female</label>
            <input id="female" value="female" type="radio" name="gender">
            <label for="male">Male</label>
            <input id="male" value="male" type="radio" name="gender">
            <br>
            <lable for="birth-date">Birth Date</lable>
            <input id="birth-date" type="date" name="birth_date">

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
            <input id="last-work-name" name="last_work_name" type="text">
            <br>    
            <lable for="last-work-from">From</lable>
            <input id="last-work-from" name="last_work_from" type="date">
            <br>
            <lable for="last-work-to">To</lable>
            <input id="last-work-to" name="last_work_to" type="date">
        </fieldset>
    <fieldset>
        <legend>Computer Skills</legend>
        <div class="computerSkillsField">
            <div class="progInputInitial">
                <label for="program-languages">Programong Languages</label>
                <input type="text" id="program-languages" name="program_languages">

                <select name="prog_languages_level" id="prog-languages-level">
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

    <fieldset id="otherSkillsField">
    <legend>Other Skills</legend>
        <div class="languagesField">
            <div class="langInitialInputs">        

                <label for="languages">Languages</label>
                <input name="languages" id="languages" type="text">

                <select name="language_comprehension" id="">
                    <option value="" disabled="disabled" selected="selected">-Comprehesion-</option>
                    <option value="Low">Low</option>
                    <option value="Medium">Medium</option>
                    <option value="High">High</option>
                </select>

                <select name="language_reading_skills" >
                    <option value="" disabled="disabled" selected="selected">-Reading-</option>
                    <option value="Low">Low</option>
                    <option value="Medium">Medium</option>
                    <option value="High">High</option>
                </select>

                <select name="language_writing_skills" >
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
    <button type="submit">Create CV</button>
</form>

</body>

</html>