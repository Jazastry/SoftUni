var divOne = document.getElementById('progButtonsDiv');
var divTwo = document.getElementById('langButtonsDiv');
var clickedEl;
var parentEl;
var btns;
var counterProg = 1;
var counterLang  = 1;

divOne.addEventListener('click', function(e) {   
    clickedEl = e.target;
    parentEl = clickedEl.parentNode.parentNode;
    if (clickedEl.getAttribute('class') === 'deleteFields') {
        removeElement(parentEl);
    } else if (clickedEl.getAttribute('class') === 'insertFields') {
        addElement(parentEl);
    }
    e.preventDefault();
});

divTwo.addEventListener('click', function(e) {   
    clickedEl = e.target;
    parentEl = clickedEl.parentNode.parentNode;
    if (clickedEl.getAttribute('class') === 'deleteFields') {
        removeElement(parentEl);
    } else if (clickedEl.getAttribute('class') === 'insertFields') {
        addElement(parentEl);
    }
    e.preventDefault();
});

function removeElement(el) {
    var inputs = el.getElementsByTagName('div');
    var last = inputs.length - 2;
    var toRemove = inputs[last];
    if (last >= 1) {
        el.removeChild(toRemove);
    }
}

function addElement(el) {

    var inputHtmlProg = '<input type="text" name="programLanguages'+ '['+ counterProg +']' +'">' +
                         '<select name="progLangLevel'+ '['+ counterProg +']' +'" id="prog-languages-level">' +
                            '<option value="Beginer" selected="selected">Beginer</option>' +
                            '<option value="Mediun">Mediun</option>' +
                            '<option value="Pro">Pro</option>' +
                        '</select>';

    var inputHTMLLang = '<input name="languages'+ '['+ counterLang +']' +'" id="languages" type="text">' +
                        '<select name="languageComprehension'+ '['+ counterLang +']' +'" id="">' +
                            '<option value="" disabled="disabled" selected="selected">-Comprehesion-</option>' +
                            '<option value="Low">Low</option>' +
                            '<option value="Medium">Medium</option>' +
                            '<option value="High">High</option>' +
                        '</select>' +
                        '<select name="languageReadingSkills'+ '['+ counterLang +']' +'" >' +
                            '<option value="" disabled="disabled" selected="selected">-Reading-</option>' +
                            '<option value="Low">Low</option>' +
                            '<option value="Medium">Medium</option>' +
                            '<option value="High">High</option>' +
                        '</select>' +
                        '<select name="languageWritingSkills'+ '['+ counterLang +']' +'" >' +
                            '<option value="" disabled="disabled" selected="selected">-Writing-</option>' +
                            '<option value="Low">Low</option>' +
                            '<option value="Medium">Medium</option>' +
                            '<option value="High">High</option>' +
                        '</select>';

    var newDiv = document.createElement('div');

    if (el.getAttribute('class') === 'computerSkillsField') {
        btns = document.getElementById('progButtonsDiv');
        newDiv.setAttribute('class', 'progInputInitial');
        newDiv.innerHTML = inputHtmlProg;
        counterProg++;

    } else if (el.getAttribute('class') === 'languagesField') {
        btns = document.getElementById('langButtonsDiv');
        newDiv.setAttribute('class', 'langInitialInputs');
        newDiv.innerHTML = inputHTMLLang;
        counterLang++;
    }

    el.insertBefore(newDiv,btns);
}