var plusButtons = document.getElementsByClassName("plusButton");
var minusButtons = document.getElementsByClassName("minusButton");
var resetButton = document.getElementById("characteristicsReset");
var saveButton = document.getElementById("characteristicsSave");
var defaultState =  {Id:0, Name:"",FreePoints: 0, Health: 0, Protection: 0, Attack: 0, Evasion: 0, Crit: 0 };
var inputs = { id: null, name: null, freePoints: null, health: null, protection: null, attack: null, evasion: null, crit: null };

var coefHealth = 5;
var coefProtection = 2;
var coefAttack = 2;
var coefEvasion = 2;
var coefCrit = 2;

var notMoreHealth = 280;
var notMoreProtection = 70;
var notMoreAttack = 70;
var notMoreEvasion = 10;
var notMoreCrit = 10;

SetInputs();
SetValues();
SevReadOnly();
if (saveButton != null) {
    saveButton.onclick = ButtonSave;
}
if (resetButton != null) {
    resetButton.onclick = Reset;
}
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
function ButtonSave(e) {
    SetValues();
    $.ajax(
            {
                url: "/Heroes/CharacteristicSave",
                type: "GET",
                data: defaultState,
                async: false
                //success: resp

            }
            );
    var url = "/Heroes/Index";
    window.location.href = url;
}
function Reset(e) {
    inputs.freePoints.defaultValue = defaultState.FreePoints;
    inputs.health.defaultValue = defaultState.Health;
    inputs.protection.defaultValue = defaultState.Protection;
    inputs.attack.defaultValue = defaultState.Attack;
    inputs.evasion.defaultValue = defaultState.Evasion;
    inputs.crit.defaultValue = defaultState.Crit;
}
function ButtonsPlus(e) {
    if (inputs.freePoints.defaultValue == "0")
        return;
    var target = e.currentTarget.id
    switch(target)
    {
        case "buttonPlusHealth":
            plusCalculate(inputs.health, notMoreHealth, coefHealth)
            break;
        case "buttonPlusProtection":
            plusCalculate(inputs.protection, notMoreProtection, coefProtection)
            break;
        case "buttonPlusAttack":
            plusCalculate(inputs.attack, notMoreAttack, coefAttack);
            break;
        case "buttonPlusEvasion":
            plusCalculate(inputs.evasion, notMoreEvasion, coefEvasion);
            break;
        case "buttonPlusCrit":
            plusCalculate(inputs.crit, notMoreCrit, coefCrit);
            break;
    }
}
function plusCalculate(inputValue, notMore, coef) {
    if (!(+inputValue.defaultValue == +notMore)) {
        inputValue.defaultValue = +inputValue.defaultValue + coef;
        inputs.freePoints.defaultValue  -= 1;
    }
}
function ButtonsMinus(e) {

    var target = e.currentTarget.id
    if (+inputs.freePoints.defaultValue >= defaultState.FreePoints)
        return;
    switch (target) {
        case "buttonMinusHealth":
            minusCalculate(inputs.health,defaultState.Health,coefHealth)
            break;
        case "buttonMinusProtection":
            minusCalculate(inputs.protection, defaultState.Protection, coefProtection);
            break;
        case "buttonMinusAttack":
            minusCalculate(inputs.attack, defaultState.Attack, coefAttack)
            break;
        case "buttonMinusEvasion":
            minusCalculate(inputs.evasion, defaultState.Evasion, coefEvasion)
            break;
        case "buttonMinusCrit":
            minusCalculate(inputs.crit, defaultState.Crit, coefCrit)
            break;
    }
}
function minusCalculate(inputValue, defaultStateValues, coef) {
  if(!(+inputValue.defaultValue == +defaultStateValues)){
        inputValue.defaultValue = +inputValue.defaultValue - coef;
        inputs.freePoints.defaultValue = +inputs.freePoints.defaultValue+1;
   }
}
function SetInputs() {
    inputs.id = document.getElementById("Id");
    inputs.name = document.getElementById("Name");
    inputs.freePoints = document.getElementById("FreePoints");
    inputs.health  = document.getElementById("Health");
    inputs.protection = document.getElementById("Protection");
    inputs.attack = document.getElementById("Attack");
    inputs.evasion =  document.getElementById("Evasion");
    inputs.crit  = document.getElementById("Crit");
}
function SetValues() {
    defaultState.Id = inputs.id.defaultValue;
    defaultState.Name = inputs.name.defaultValue;
    defaultState.FreePoints  = inputs.freePoints.defaultValue;
    defaultState.Health  = inputs.health.defaultValue;
    defaultState.Protection = inputs.protection.defaultValue;
    defaultState.Attack  = inputs.attack.defaultValue;
    defaultState.Evasion = inputs.evasion.defaultValue;
    defaultState.Crit = inputs.crit.defaultValue;
}
function SevReadOnly() {
    inputs.freePoints.setAttribute("disabled", "disabled");
    inputs.health.setAttribute("disabled", "disabled");
    inputs.protection.setAttribute("disabled", "disabled");
    inputs.attack.setAttribute("disabled", "disabled");
    inputs.evasion.setAttribute("disabled", "disabled");
    inputs.crit.setAttribute("disabled", "disabled");
}