var plusButtons = document.getElementsByClassName("plusButton");
var minusButtons = document.getElementsByClassName("minusButton");
var resetButton = document.getElementById("characteristicsReset");
var saveButton = document.getElementById("characteristicsSave");
var defaultState =  {Id:0, Name:"",FreePoints: 0, Health: 0, Protection: 0, Attack: 0, Evasion: 0, Crit: 0 };
var inputs = { id:null, name:null, freePoints:null, health:null, protection:null, attack:null, evasion:null, crit:null };
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
    inputs.freePoints.defaultValue -= 1;
    switch(target)
    {
        case "buttonPlusHealth":
            inputs.health.defaultValue = +inputs.health.defaultValue + 5;
            break;
        case "buttonPlusProtection":
            inputs.protection.defaultValue = +inputs.protection.defaultValue + 2;
            break;
        case "buttonPlusAttack":
            inputs.attack.defaultValue = +inputs.attack.defaultValue + 2;
            break;
        case "buttonPlusEvasion":
            inputs.evasion.defaultValue = +inputs.evasion.defaultValue + 2;
            break;
        case "buttonPlusCrit":
            inputs.crit.defaultValue = +inputs.crit.defaultValue + 2;
            break;
    }
}
function ButtonsMinus(e) {

    var target = e.currentTarget.id
    if (+inputs.freePoints.defaultValue >= defaultState.FreePoints)
        return;
    inputs.freePoints.defaultValue = +inputs.freePoints.defaultValue + 1;
    switch (target) {
        case "buttonMinusHealth":
            inputs.health.defaultValue = +inputs.health.defaultValue - 5;
            break;
        case "buttonMinusProtection":
            inputs.protection.defaultValue = +inputs.protection.defaultValue - 2;
            break;
        case "buttonMinusAttack":
            inputs.attack.defaultValue = +inputs.attack.defaultValue - 2;
            break;
        case "buttonMinusEvasion":
            inputs.evasion.defaultValue = +inputs.evasion.defaultValue - 2;
            break;
        case "buttonMinusCrit":
            inputs.crit.defaultValue = +inputs.crit.defaultValue - 2;
            break;
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