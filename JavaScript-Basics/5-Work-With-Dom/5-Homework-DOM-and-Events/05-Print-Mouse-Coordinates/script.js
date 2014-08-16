function printMouseCoordinates(e){
    document.body.innerHTML += 'X: ' + e.pageX + '; Y: ' + e.pageY + '; Time: ' + new Date() + '</br>';
}

document.addEventListener('mouseover', printMouseCoordinates, false);