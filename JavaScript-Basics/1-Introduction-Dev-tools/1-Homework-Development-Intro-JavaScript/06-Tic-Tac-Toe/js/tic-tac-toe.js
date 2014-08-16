
var counterWhole = 0;
var counter;
var field = [1,2,3,4,5,6,7,8,9];
var cell;
var blue = "#7F00FF";
var green = "#169C8D";
var curColor;
var symbol;
var mistake = 0;
var clicketElement;
var winnerX = 0;
var winnerO = 0;
var winner = 'NO';
var winningPosition = 0;

function clickAction(e) {

    clicketElement = e.target.id;

    cell = parseInt(findCell(clicketElement)); 

    alertCell();

    changeCellContent();

    doHaveWinner();

    winerLine();

}

function findCell(cellIn) {

    var cell;

    if (cellIn == 'one') {
        cell = 1;
    } else if (cellIn == 'twoo') {
        cell = 2;
    } else if (cellIn == 'three') {
        cell = 3;
    } else if (cellIn == 'for') {
        cell = 4;
    } else if (cellIn == 'five') {
        cell = 5;
    } else if (cellIn == 'six') {
        cell = 6;
    } else if (cellIn == 'seven') {
        cell = 7;
    } else if (cellIn == 'eight') {
        cell = 8;
    } else if (cellIn == 'nine') {
        cell = 9;
    }

    return cell;
}

function doHaveWinner() {

   // var winner = 'NO';
   // var winningPosition;

    if (counterWhole > 4) {

        if ((field[1] == field[2]) && (field[2] == field[3])) {

            winner = field[1]; 
            winningPosition = 1;

        } else if ((field[4] == field[5]) && (field[5] == field[6])) {

            winner = field[4];
            winningPosition = 2;

        } else if ((field[7] == field[8]) && (field[8] == field[9])) {

            winner = field[7];
            winningPosition = 3;

        } else if ((field[1] == field[4]) && (field[4] == field[6])) {

            winner = field[1];
            winningPosition = 4;

        } else if ((field[2] == field[5]) && (field[5] == field[8])) {

            winner = field[2];
            winningPosition = 5;
        } else if ((field[3] == field[6]) && (field[6] == field[9])) {

            winner = field[3];
            winningPosition = 6;
        } else if ((field[1] == field[5]) && (field[5] == field[9])) {

            winner = field[1];
            winningPosition = 7;
        } else if ((field[3] == field[5]) && (field[5] == field[7])) {

            winner = field[3];
            winningPosition = 8;
        }
    }

    return [winner, winningPosition];
}

function whoWins(symbolIn) {

    var win = 0;

    if (symbolIn == 'X') {

        win = 'X';
    } else if (symbolIn == 'O') {

        win = 'O';
    }

    return win;
}

function changeCellContent() {

    if (mistake == 0) {

        if (counter == 0) {


            symbol = "O";
            counter = 1;
            curColor = blue;
            document.getElementById('turnO').style.display = 'none';
            document.getElementById('turnX').style.display = 'inline';

        } else {

            symbol = "X";
            counter = 0;
            curColor = green;
            document.getElementById('turnX').style.display = 'none';
            document.getElementById('turnO').style.display = 'inline';
        }

        counterWhole += 1;

        field[cell] = symbol;

        document.getElementById(clicketElement).innerHTML = symbol;
        document.getElementById(clicketElement).style.color = curColor;

    }  else {

        mistake = 0;
    };  
}

function winerLine() {

    var lineContainer = document.getElementById('endLine');
    var currentEndLine = document.getElementById('position' + winningPosition);

    if (winner !== 'NO') {

        lineContainer.style.display = 'block'; 
        currentEndLine.style.display = 'block'; 
        alertCell();   

    }
}

function alertCell() {

    if((field[cell] == 'X') || (field[cell] == 'O')) {

        document.getElementById('baner').style.display = 'block';
        document.getElementById('banerP').innerHTML = 'Wrong Cell ! Try Another One';
        document.getElementById('btnOk').style.display = 'block';
        document.getElementById('blockingDiv').style.display = 'block';
        mistake = 1;
    } 
    if (winner !== 'NO') {

        document.getElementById('baner').style.display = 'inline';
        document.getElementById('banerP').innerHTML = winner + ' Player Wins This Game ! Do You Wnat To Play More ?';
        document.getElementById('btnYes').style.display = 'block';
        document.getElementById('btnNo').style.display = 'block';
        document.getElementById('btnOk').style.display = 'none';
        document.getElementById('blockingDiv').style.display = 'block';
        mistake = 0;

        if (winner == 'X') {
            winnerX += 1;
            document.getElementById('pointsX').innerHTML = winnerX;
        }
        if (winner == 'O') {
            winnerO += 1;
            document.getElementById('pointsO').innerHTML = winnerO;
        }
    }
    if ((counterWhole == 8) && (winner == 'NO')) {
        document.getElementById('baner').style.display = 'inline';
        document.getElementById('banerP').innerHTML = 'Nobody Wins This Game ! Do You Wnat To Play More ?';
        document.getElementById('btnYes').style.display = 'block';
        document.getElementById('btnNo').style.display = 'block';
        document.getElementById('btnOk').style.display = 'none';
        document.getElementById('blockingDiv').style.display = 'block';
        mistake = 0;
    }
    
}

function onAlertClicks(e) {

    clicketElement = e.target.id;

    if (clicketElement == 'btnOk') {
        document.getElementById('baner').style.display = 'none';
        document.getElementById('btnOk').style.display = 'none';
        document.getElementById('blockingDiv').style.display = 'none';
    } else if (clicketElement == 'btnYes') {
        document.getElementById('baner').style.display = 'none';
        document.getElementById('btnYes').style.display = 'none';
        document.getElementById('btnNo').style.display = 'none';
        document.getElementById('blockingDiv').style.display = 'none';
        document.getElementById('endLine').style.display = 'none';
        document.getElementById('one').innerHTML = '';
        document.getElementById('twoo').innerHTML = '';
        document.getElementById('three').innerHTML = '';
        document.getElementById('for').innerHTML = '';
        document.getElementById('five').innerHTML = '';
        document.getElementById('six').innerHTML = '';
        document.getElementById('seven').innerHTML = '';
        document.getElementById('eight').innerHTML = '';
        document.getElementById('nine').innerHTML = '';
        field = [1,2,3,4,5,6,7,8,9];
        winner = 'NO';
        winningPosition = 0;
        counterWhole = 0;

        for (var i = 1; i < 9; i++) {
            document.getElementById('position' + i).style.display = 'none';
        };
    } else if (clicketElement == 'btnNo') {
        document.getElementById('baner').style.display = 'none';
        document.getElementById('btnYes').style.display = 'none';
        document.getElementById('btnNo').style.display = 'none';
    }
}
