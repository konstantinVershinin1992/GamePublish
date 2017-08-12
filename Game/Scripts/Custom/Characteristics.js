var plusButtons = document.getElementsByClassName("plusButton");
var minusButtons = document.getElementsByClassName("minusButton");
var defaultState =  { FreePoints: 0, Health: 0, Protection: 0, Attack: 0, Evasion: 0, Crit: 0 };

var freePoints = document.getElementById("freePointsInput");
var health = document.getElementById("healthInput");
var protection = document.getElementById("protectionInput");
var attack = document.getElementById("attackInput");
var evasion = document.getElementById("evasionInput");
var crit = document.getElementById("critInput");
if(plusButtons != null)
 if(plusButtons.length > 0) {
     for (var i = 0; i < plusButtons.length; i++)
         plusButtons[i].onclick = ButtonsPlus;
 }
if (minusButtons != null)
    if (minusButtons.length > 0) {
        for (var i = 0; i < minusButtons.length; i++)
            minusButtons[i].onclick = ButtonsMinus;
    }

function ButtonsPlus(e) {
    var target = e.currentTarget.id
    freePoints.defaultValue -= 1;
    switch(target)
    {
        case "buttonPlusHealth":
            health.defaultValue = +health.defaultValue+5;
            break;
        case "buttonPlusProtection":
            protection.defaultValue += 2
            break;
    }
   // if(e.currentTarget.id == "")
}
function ButtonsMinus(e) {
    alert(e.currentTarget.id);
}