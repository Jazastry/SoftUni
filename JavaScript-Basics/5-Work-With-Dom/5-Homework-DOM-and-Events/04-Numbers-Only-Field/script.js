
function stopType(){

    if(isNaN(inPlace.value)) {

        inPlace.style.background = 'red';
        inPlace.disabled = true;
        setTimeout(saveNumbs, 500);

    } else {

        previousValue = inPlace.value;
   }
}

function saveNumbs(){

    inPlace.value = previousValue;
    inPlace.style.background = '';
    inPlace.disabled = false;
    inPlace.focus();
}

var inPlace = document.getElementById('inPlace'),

    previousValue ='';

inPlace.addEventListener('input', stopType, false);